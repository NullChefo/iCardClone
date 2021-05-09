using System;
using System.Collections.Generic;
using iCard.ApplicationServices.Converters;
using iCard.ApplicationServices.DTOs;
using iCard.Data.Entities;
using iCard.Data.Repositories;

namespace iCard.ApplicationServices.Services
{
    public class VirtualCardService
    {

        private AccountService accountService;
        private VirtualCardRepository virtualCardRepository;
        private TransactionHistoryService transactionHistoryService;

        public VirtualCardService()
        {
            accountService = new AccountService();
            virtualCardRepository = new VirtualCardRepository();
            transactionHistoryService = new TransactionHistoryService();
        }

        public ICollection<VirtualCardDTO> GetVirtualCards(string username)
        {
            var account = accountService.GetAccountForUser(username);

            if (account == null)
            {
                return new List<VirtualCardDTO>();
            }

            return toVirtualCardsDTO(account.VirtualCards);

        }

        public VirtualCardDTO GetVirtualCardByCardNumber(string username, string cardnumber)
        {
            var account = accountService.GetAccountForUser(username);

            if (account == null)
            {
                return null;
            }

            var vc = virtualCardRepository.GetByAccountIdAndCardNumber(account.Id, cardnumber);
            if (vc == null)
            {
                return null;
            }

            return VirtualCardConverter.ToDTO(vc);

        }


        public VirtualCardDTO AddVirtualCard(string username, VirtualCardDTO virtualCardDTO)
        {
            var account = accountService.GetAccountForUser(username);

            if (account == null)
            {
                return null;
            }

            var virtualCard = VirtualCardConverter.ToEntity(virtualCardDTO);
            account.VirtualCards.Add(virtualCard);
            accountService.Save(account);

            return virtualCardDTO;

        }

        public VirtualCard GetVirtualCard(string username, string cardname)
        {
            var account = accountService.GetAccountForUser(username);

            if (account == null)
            {
                return null;
            }

            var vc = virtualCardRepository.GetByAccountIdAndName(account.Id, cardname);
            if (vc == null)
            {
                return null;
            }

            return vc;

        }

        public DepositDTO DepositToVirtualCard(string username, string cardName, DepositDTO depositDTO)
        {
            var account = accountService.GetAccountForUser(username);

            if (account == null)
            {
                return null;
            }

            var vc = virtualCardRepository.GetByAccountIdAndName(account.Id, cardName);
            vc.Balance = vc.Balance + depositDTO.Deposit;

            virtualCardRepository.Save(vc);

            var th = convertToTH(depositDTO.Deposit, "deposit", "success", account.Currency, vc.CardNumber);
            th.AccountId = account.Id;
            transactionHistoryService.Save(th);

            return depositDTO;
        }



        public WithdrawDTO WithdrawFromVirtualCard(string username, string cardName, WithdrawDTO dto)
        {
            var account = accountService.GetAccountForUser(username);

            if (account == null)
            {
                return null;
            }

            var vc = virtualCardRepository.GetByAccountIdAndName(account.Id, cardName);
            vc.Balance = vc.Balance - dto.Deposit;
            if (vc.Balance < 0.00)
            {
                var thFailed = convertToTH(dto.Deposit * -1, "deposit", "failed", account.Currency, vc.CardNumber);
                account.Transactions.Add(TransactionHistoryConverter.ToEntity(thFailed));
                accountService.Save(account);
                throw new Exception("You don't have that much money!!!");
            }

            virtualCardRepository.Save(vc);

            var th = convertToTH(dto.Deposit, "deposit", "success", account.Currency, vc.CardNumber);
            th.AccountId = account.Id;
            transactionHistoryService.Save(th);

            return dto;
        }


        public DepositDTO TransferFromAccount(string username, string cardName, DepositDTO dto)
        {
            var account = accountService.GetAccountForUser(username);

            if (account == null)
            {
                return null;
            }

            var vc = virtualCardRepository.GetByAccountIdAndName(account.Id, cardName);
            account.Balance = account.Balance - dto.Deposit;

            if (account.Balance < 0.00)
            {
                var thFailed = convertToTH(dto.Deposit, "deposit", "failed", account.Currency, vc.CardNumber);
                account.Transactions.Add(TransactionHistoryConverter.ToEntity(thFailed));
                accountService.Save(account);
                throw new Exception("You don't have that much money into your account!!!");
            }

            vc.Balance = vc.Balance + dto.Deposit;
            accountService.Save(account);
            virtualCardRepository.Save(vc);

            var th = convertToTH(dto.Deposit, "deposit", "success", account.Currency, vc.CardNumber);
            th.AccountId = account.Id;
            transactionHistoryService.Save(th);

            return dto;
        }


        public void Save(VirtualCard vc)
        {
            virtualCardRepository.Save(vc);
        }


        private TransactionHistoryDTO convertToTH(double sum, string from, string status, string currency,
            string cardnumber)
        {
            var th = new TransactionHistoryDTO();
            th.Currency = currency;
            th.TransactionCost = sum;
            th.TransactionType = from;
            th.TransactionTarget = cardnumber;
            th.TransactionStatus = status;
            return th;
        }


        private static ICollection<VirtualCardDTO> toVirtualCardsDTO(ICollection<VirtualCard> entities)
        {
            ICollection<VirtualCardDTO> cards = new List<VirtualCardDTO>();

            if (entities == null)
            {
                return cards;
            }

            foreach (VirtualCard en in entities)
            {
                cards.Add(VirtualCardConverter.ToDTO(en));
            }

            return cards;
        }
    }
}