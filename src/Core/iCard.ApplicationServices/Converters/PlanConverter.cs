using iCard.ApplicationServices.DTOs;
using iCard.Data.Entities;

namespace iCard.ApplicationServices.Converters
{
    public class PlanConverter
    {

        public static PlanDTO ToDTO(Plan entity)
        {
            var dto = new PlanDTO();
            dto.CardTransactions = entity.CardTransactions;
            dto.Cost = entity.Cost;
            dto.Currency = entity.Currency;
            dto.Insurance = entity.Insurance;
            dto.MaxExchange = entity.MaxExchange;
            dto.Type = entity.Type;
            return dto;
        }       
        
        public static Plan ToEntity(PlanDTO dto)
        {
            var entity = new Plan();
            entity.CardTransactions = dto.CardTransactions;
            entity.Cost = dto.Cost;
            entity.Currency = dto.Currency;
            entity.Insurance = dto.Insurance;
            entity.MaxExchange = dto.MaxExchange;
            entity.Type = dto.Type;
            return entity;
        }
    }

}