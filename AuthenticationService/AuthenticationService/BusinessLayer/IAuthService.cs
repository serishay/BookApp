using AuthenticationService.Models;

namespace AuthenticationService.BusinessLayer
{
    public interface IAuthService
    {
        bool LoginUser(User user);
        bool RegisterUser(User user);
    }
}
