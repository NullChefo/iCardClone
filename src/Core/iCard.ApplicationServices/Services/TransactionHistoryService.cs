using System.Collections.Generic;
using iCard.ApplicationServices.Converters;
using iCard.ApplicationServices.DTOs;
using iCard.Data.Entities;
using iCard.Data.Repositories;

namespace iCard.ApplicationServices.Services
{
    public class TransactionHistoryService
    {

        private TransactionHistoryRepository historyRepository;
        private AccountService accountService;

        public TransactionHistoryService()
        {
            historyRepository = new TransactionHistoryRepository();
            accountService = new AccountService();
        }


        public void Save(TransactionHistoryDTO dto)
        {
            historyRepository.Save(TransactionHistoryConverter.ToEntity(dto));
        }

        public void Save(TransactionHistory entity) 
        {
            historyRepository.Save(entity);
        }

        public ICollection<TransactionHistoryDTO> GetTransactionsForAccount(string username)
        {
            var acc = accountService.GetAccountForUser(username);

            return toTHDTO(acc.Transactions);

        }        
        
        public ICollection<TransactionHistoryDTO> GetTransactionsForVirtualCard(string username, string cardnumber)
        {
            var acc = accountService.GetAccountForUser(username);
            var th = toTHDTO(acc.Transactions);

            if (th == null)
            {
                return th;
            }

            var result = new List<TransactionHistoryDTO>();
            foreach (TransactionHistoryDTO t in th)
            {
                if (!"Account".Equals(t.Name) && "Deposit".Equals(t.Name))
                {
                    result.Add(t);
                }
            }

            return result;

        }

        private static ICollection<TransactionHistoryDTO> toTHDTO(ICollection<TransactionHistory> entities)
        {
            ICollection<TransactionHistoryDTO> ths = new List<TransactionHistoryDTO>();

            if (entities == null)
            {
                return ths;
            }

            foreach (TransactionHistory en in entities)
            {
                ths.Add(TransactionHistoryConverter.ToDTO(en));
            }

            return ths;
        }
    }
}