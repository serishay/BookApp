using AuthenticationService.CustomException;
using AuthenticationService.Models;
using AuthenticationService.Repository;

namespace AuthenticationService.BusinessLayer
{
    public class AuthService:IAuthService
    {
        private readonly IAuthRepository authRepository;
        public AuthService(IAuthRepository _authRepository)
        {
            authRepository = _authRepository;
        }
        public bool LoginUser(User user)
        {
            if (user.UserId != null && user.Password != null)
            {
                bool result = authRepository.LoginUser(user);
                return result;
            }
            else
            {
                throw new UserAlreadyExistsException("Unauthorized");
            }
        }

        public bool RegisterUser(User user)
        {
            var id = authRepository.IsUserExists(user.UserId);
            if (!id)
            {
                var result = authRepository.CreateUser(user);
                return result;
            }
            else
            {
                throw new UserAlreadyExistsException($"This userId {user.UserId} already in use");
            }
        }
    }
}
