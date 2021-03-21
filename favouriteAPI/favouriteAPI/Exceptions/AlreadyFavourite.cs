using System;

namespace favouriteAPI.Exceptions
{
    public class AlreadyFavourite: ApplicationException
    {
        public AlreadyFavourite()
        {

        }

        public AlreadyFavourite(string message):base(message)
        {

        }
    }
}
