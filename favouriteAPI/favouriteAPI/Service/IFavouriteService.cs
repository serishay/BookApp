using favouriteAPI.Models;
using System.Collections.Generic;

namespace favouriteAPI.Service
{
    public interface IFavouriteService
    {
        List<Favourite> GetFavourites();
        List<Favourite> GetFavourite(string userId);
        Favourite AddFavourite(Favourite favourite);
        bool DeleteFavourite(string userId);
    }
}
