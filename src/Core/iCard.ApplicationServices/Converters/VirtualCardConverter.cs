using iCard.ApplicationServices.DTOs;
using iCard.Data.Entities;

namespace iCard.ApplicationServices.Converters
{
    public class VirtualCardConverter
    {

        public static VirtualCardDTO ToDTO(VirtualCard entity)
        {
            var dto = new VirtualCardDTO();
            dto.Balance = entity.Balance;
            dto.CardNumber = entity.CardNumber;
            dto.Currency = entity.Currency;
            dto.CVV = entity.CVV;
            dto.Name = entity.Name;
            dto.ValidDate = entity.ValidDate;
            return dto;
        }       
        
        public static VirtualCard ToEntity(VirtualCardDTO dto)
        {
            var entity = new VirtualCard();
            entity.Balance = dto.Balance;
            entity.CardNumber = dto.CardNumber;
            entity.Currency = dto.Currency;
            entity.CVV = dto.CVV;
            entity.Name = dto.Name;
            entity.ValidDate = dto.ValidDate;
            entity.AccountId = dto.AccountId;
            return entity;
        }
    }

}