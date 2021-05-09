using iCard.ApplicationServices.Services;

namespace iCard.WebApiServices.Controllers.Security
{
    public class UserLogin
    {

        private readonly UserService userService = new UserService();

        public bool Login(string username, string password)
        {
            return userService.Exist(username, password);
        }
    }
}