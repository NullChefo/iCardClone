using System.Collections.Generic;
using iCard.ApplicationServices.DTOs;
using iCard.Data.Entities;

namespace iCard.ApplicationServices.Converters
{
     public class AccountConverter
    {
        public static AccountDTO ToDTO(Account entity) 
        {
            var dto = new AccountDTO();
            dto.Active = entity.Active;
            dto.Balance = entity.Balance;
            dto.Currency = entity.Currency;
                dto.Settings = SettingsConverter.ToDTO(entity.Settings);
            dto.Plan = PlanConverter.ToDTO(entity.Plan);
            dto.VirtualCards = toVirtualCardsDTO(entity.VirtualCards);
            dto.Transactions = toTransactionHistoryDTO(entity.Transactions);
            return dto;
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

        private static ICollection<TransactionHistoryDTO> toTransactionHistoryDTO(ICollection<TransactionHistory> entities)
        {
            ICollection<TransactionHistoryDTO> th = new List<TransactionHistoryDTO>();

            if (entities == null)
            {
                return th;
            }

            foreach (TransactionHistory en in entities) 
            {
                th.Add(TransactionHistoryConverter.ToDTO(en));
            }

            return th;
        }


        public static Account ToEntity(AccountDTO dto)
        {
            var entity = new Account();
            entity.Active = dto.Active;
            entity.Balance = dto.Balance;
            entity.Currency = dto.Currency;
            entity.Settings = SettingsConverter.ToEntity(dto.Settings);
            entity.Plan = PlanConverter.ToEntity(dto.Plan);
            entity.VirtualCards = toVirtualCardsEntity(dto.VirtualCards);
            entity.Transactions = toTransactionHistoryEntity(dto.Transactions);
            return entity;
        }

        private static ICollection<VirtualCard> toVirtualCardsEntity(ICollection<VirtualCardDTO> dtos)
        {
            ICollection<VirtualCard> cards = new List<VirtualCard>();
            if (dtos == null) {
                return cards;
            }
            foreach (VirtualCardDTO dto in dtos)
            {
                cards.Add(VirtualCardConverter.ToEntity(dto));
            }

            return cards;
        }
        private static ICollection<TransactionHistory> toTransactionHistoryEntity(ICollection<TransactionHistoryDTO> dtos)
        {
            ICollection<TransactionHistory> th = new List<TransactionHistory>();

            if (dtos == null)
            {
                return th;
            }

            foreach (TransactionHistoryDTO dto in dtos)
            {
                th.Add(TransactionHistoryConverter.ToEntity(dto));
            }

            return th;
        }
    }
}