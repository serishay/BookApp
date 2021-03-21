using favouriteAPI.Exceptions;
using favouriteAPI.Models;
using favouriteAPI.Repository;
using FavouriteAPI.Exceptions;
using System.Collections.Generic;
using System.Linq;

namespace favouriteAPI.Service
{
    public class FavouriteService : IFavouriteService
    {
        private readonly IFavouriteRepo repo;
        public FavouriteService(IFavouriteRepo _repo)
        {
            repo = _repo;
        }
        public Favourite AddFavourite(Favourite favourite)
        {
            var availability = repo.GetFavourites().Where(c => c.Title == favourite.Title && c.UserId==favourite.UserId).FirstOrDefault();
            if (availability==null)
            {
                return repo.AddFavourite(favourite);

            }
            else
            {
                throw new AlreadyFavourite("already exists in Favourites");
            }
           
        }

        public bool DeleteFavourite(string userId)
        {         
              var availability = repo.IsFavouriteExistWithId(userId);
                if (availability)
                {
                return repo.DeleteFavourite(userId);
                }
                else
                {
                    throw new FavouriteNotFound("favourite does not exist");
                }
        }

        public List<Favourite> GetFavourite(string userId)
        {
            var availability = repo.IsFavouriteExistWithId(userId);
            if (availability)
            {
                return repo.GetFavourite(userId);
            }
            else
            {
                throw new FavouriteNotFound("favourite does not Exist");
            }        
        }

        public List<Favourite> GetFavourites()
        {
            return repo.GetFavourites();
        }
    }
}
