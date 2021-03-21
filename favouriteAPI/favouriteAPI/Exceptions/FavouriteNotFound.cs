using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FavouriteAPI.Exceptions
{
    public class FavouriteNotFound:ApplicationException
    {
        public FavouriteNotFound() { }
        public FavouriteNotFound(string message) : base(message) { }
    }
}
