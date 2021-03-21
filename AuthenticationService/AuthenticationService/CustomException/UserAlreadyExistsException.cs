using System;

namespace AuthenticationService.CustomException
{
    public class UserAlreadyExistsException:ApplicationException
    {
        public UserAlreadyExistsException()
        {

        }
        public UserAlreadyExistsException(string message):base(message)
        {

        }
    }
}
