using iCard.ApplicationServices.DTOs;
using iCard.ApplicationServices.Services;
using iCard.Data.Entities;

namespace iCard.ApplicationServices.Converters
{
    internal class UserConverter
    {

        public static User ToEntity(UserDTO user)
        {

            var entity = new User();
            entity.Username = user.Username;
            entity.Password = PasswordUtil.Encrypt(user.Password);
            entity.Active = user.Active;
            entity.Id = user.Id;

            return entity;
        }

        public static UserDTO ToDTO(User user) 
        {
            var dto = new UserDTO();
            dto.Username = user.Username;
            dto.Password = PasswordUtil.Decrypt(user.Password);
            dto.Active = user.Active;
            dto.Id = user.Id;
            return dto;
        }

    }

}