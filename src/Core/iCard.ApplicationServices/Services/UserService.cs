using iCard.ApplicationServices.Converters;
using iCard.ApplicationServices.DTOs;
using iCard.Data.Entities;
using iCard.Data.Repositories;

namespace iCard.ApplicationServices.Services
{
    public class UserService

    {

        private UserRepository _userRepository;

        public UserService() 
        {
            _userRepository = new UserRepository();
        }

        public bool Exist(string username, string password)
        {
            return _userRepository.Exist(username, PasswordUtil.Encrypt(password));
        }

        public UserDTO GetByUsername(string username)
        {
            var entities = _userRepository.GetAll();

            foreach (var ent in entities) {
                if (ent.Username.Equals(username)) {
                    return UserConverter.ToDTO(ent);
                }
            }
            return null;
        }

        public UserDTO CreateUser(UserDTO dto) 
        {
            _userRepository.Save(UserConverter.ToEntity(dto));
            return dto;             
        }        
        
        public UserDTO UpdateUser(UserDTO dto) 
        {
            _userRepository.Save(UserConverter.ToEntity(dto));
            return dto;             
        }

        public void Save(User user) 
        {
            _userRepository.Save(user);

        }

        public User GetEntityByUsername(string username) {

            var entities = _userRepository.GetAll();

            foreach (var ent in entities)
            {
                if (ent.Username.Equals(username))
                {
                    return ent;
                }
            }
            return null;
        }
    }
}