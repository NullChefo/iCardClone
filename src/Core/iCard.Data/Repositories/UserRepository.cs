using iCard.Data.Entities;

namespace iCard.Data.Repositories
{
    public class UserRepository: BaseRepository<User>
    {

        public bool Exist(string username, string password)
        {

            foreach (var i in items)
            { 
                if (username.Equals(i.Username) && password.Equals(i.Password)) 
                {
                    return true;
                }
            }

            return false;
        }
    }
}