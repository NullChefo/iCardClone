using iCard.ApplicationServices.DTOs;
using iCard.Data.Entities;

namespace iCard.ApplicationServices.Converters
{
    public static class TransactionHistoryConverter
    {
        public static TransactionHistoryDTO ToDTO(TransactionHistory entity) 
        {

            var dto = new TransactionHistoryDTO();
            dto.Currency = entity.Currency;
            dto.Name = entity.Name;
            dto.TransactionCost = entity.TransactionCost;
            dto.TransactionStatus = entity.TransactionStatus;
            dto.TransactionTarget = entity.TransactionTarget;
            dto.TransactionType = entity.TransactionType;

            return dto;
        }        
        
        public static TransactionHistory ToEntity(TransactionHistoryDTO dto) 
        {
            var entity = new TransactionHistory();
            entity.Currency = dto.Currency;
            entity.Name = dto.Name;
            entity.TransactionCost = dto.TransactionCost;
            entity.TransactionStatus = dto.TransactionStatus;
            entity.TransactionTarget = dto.TransactionTarget;
            entity.TransactionType = dto.TransactionType;
            entity.AccountId = dto.AccountId;

            return entity;
        }
    }

}