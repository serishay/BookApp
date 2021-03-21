using System;

namespace favouriteAPI.Exceptions
{
    public class DatabaseNotFound: ApplicationException
    {
        public DatabaseNotFound() { }
        public DatabaseNotFound(string message) : base(message) { }
    }
}
