using System;
using iCard.ApplicationServices.Converters;
using iCard.ApplicationServices.DTOs;

namespace iCard.ApplicationServices.Services
{
      public class ExchangeService
    {

        private PlanService planService;
        private AccountService accountService;
        private TransactionHistoryService historyService;
        private VirtualCardService virtualCardService;


        public ExchangeService()
        {
            planService = new PlanService();
            accountService = new AccountService();
            historyService = new TransactionHistoryService();
            virtualCardService = new VirtualCardService();
        }

        public ExchangeDTO ExchangeFromAccount(string username, ExchangeDTO dto) 
        {
            var account = accountService.GetAccountForUser(username);
            if (!planService.CanExchange(account.PlanId, dto.Amount, false)) 
            {
                var th = convertToTH(dto, "failed");
                account.Transactions.Add(TransactionHistoryConverter.ToEntity(th));
                accountService.Save(account);
                throw new Exception("Couldn't complete transaction. The desired sum is bigger than the max allowed for the current plan");
            }

            account.Balance = account.Balance - dto.Amount;

            if (account.Balance < 0.00)
            {
                throw new Exception("not enough balance in the account");
            }
            
            var recipient = accountService.GetAccountForUser(dto.To);
            
            if (recipient == null)
            {
                throw new Exception("Couldn't find such a user");
            }

            recipient.Balance += dto.Amount;

            var transaction = convertToTH(dto, "success");
            transaction.Name = "Account";
            var originTransaction = transaction.ShallowCopy();
            originTransaction.TransactionCost *= -1; // we need to make the transaction cost negative since its a withdraw from the sender`s account
            originTransaction.Name = "Account";

            account.Transactions.Add(TransactionHistoryConverter.ToEntity(originTransaction));
            recipient.Transactions.Add(TransactionHistoryConverter.ToEntity(transaction));

            accountService.Save(account);
            accountService.Save(recipient);

            return dto;
        }

        public ExchangeDTO ExchangeFromVirtualCard(string username, string virtualCardName, ExchangeDTO dto) 
        {
            var account = accountService.GetAccountForUser(username);
            var vc = virtualCardService.GetVirtualCard(username, virtualCardName);
            if (!planService.CanExchange(account.PlanId, dto.Amount, false)) 
            {
                var th = convertToTH(dto, "failed");
                account.Transactions.Add(TransactionHistoryConverter.ToEntity(th));
                accountService.Save(account);
                throw new Exception("Couldn't complete transaction. The desired sum is bigger than the max allowed for the current plan or you dont have any more transactions permitted");
            }

            vc.Balance = vc.Balance - dto.Amount;

            if (vc.Balance < 0.00)
            {
                throw new Exception("not enough balance in the virtual card");
            }
            
            var recipient = accountService.GetAccountForUser(dto.To);
            
            if (recipient == null)
            {
                throw new Exception("Couldn't find such a user");
            }

            recipient.Balance += dto.Amount;

            var transaction = convertToTH(dto, "success");
            transaction.Name = "Account";
            var originTransaction = transaction.ShallowCopy();
            originTransaction.TransactionCost *= -1; // we need to make the transaction cost negative since its a withdraw from the sender`s account
            originTransaction.Name = vc.CardNumber;
            originTransaction.AccountId = account.Id;
            transaction.AccountId = recipient.Id;

            historyService.Save(originTransaction);
            historyService.Save(transaction);
            planService.ExecuteTransaction(account.PlanId);

            virtualCardService.Save(vc);

            return dto;
        }

        private TransactionHistoryDTO convertToTH(ExchangeDTO dto, string status)
        {
            var th = new TransactionHistoryDTO();
            th.Currency = dto.Currency;
            th.TransactionCost = dto.Amount;
            th.TransactionType = dto.From;
            th.TransactionTarget = dto.To;
            th.TransactionStatus = status;
            return th;
        }
    }
}