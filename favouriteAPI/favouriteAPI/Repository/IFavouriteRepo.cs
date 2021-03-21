using favouriteAPI.Models;
using System.Collections.Generic;

namespace favouriteAPI.Repository
{
    public interface IFavouriteRepo
    {
        List<Favourite> GetFavourites();
        List<Favourite> GetFavourite(string userId);
        Favourite AddFavourite(Favourite favourite);
        bool DeleteFavourite(string userId);
        public bool IsFavouriteExistWithId(string userId);
        public bool IsFavouriteExist(Favourite favourite);
    }
}
