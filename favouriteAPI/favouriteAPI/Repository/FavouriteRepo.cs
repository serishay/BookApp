using favouriteAPI.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;

namespace favouriteAPI.Repository
{
    public class FavouriteRepo : IFavouriteRepo
    {
        private readonly FavouriteDbContext db;
        public FavouriteRepo(FavouriteDbContext dbcontext)
        {
            db = dbcontext;
        }
        public Favourite AddFavourite(Favourite favourite)
        {
            var fav = this.db.Fav.AsQueryable();
            if (fav.Count() == 0)
            {
                favourite.Id = 1;
            }
            else
            {
                int max = fav.Max(c => c.Id) + 1;
                favourite.Id = max;
            }
            db.Fav.InsertOne(favourite);
           // db.Favourites.Add(favourite);
            //db.SaveChanges();
            return favourite;
        }

        public bool DeleteFavourite(string userId)
        {
            DeleteResult deleteResult = db.Fav.DeleteOne(c => c.UserId ==userId);
            return deleteResult.IsAcknowledged && deleteResult.DeletedCount > 0;

            //var article = db.Favourites.Where(x => x.Id == id && x.Title == title).FirstOrDefault();
            //if (article != null)
            //{
            //    db.Favourites.Remove(article);
            //    db.SaveChanges();
            //    return true;
            //}
            //return false;
        }

        public List<Favourite> GetFavourite(string userId)
        {

            List<Favourite> favourite = new List<Favourite>();
            favourite = db.Fav.Find(name => name.UserId == userId).ToList();
            return favourite;

            //List<Favourite> favourites = new List<Favourite>();
            //favourites = db.Favourites.Where(x => x.Id == id).ToList();
            //return favourites;
        }

        public List<Favourite> GetFavourites()
        {

            return db.Fav.Find(favourite => true).ToList();

            //return db.Favourites.ToList();
        }

        public bool IsFavouriteExist(Favourite favourite)
        {
            var favouriteExist = db.Fav.Find(favourites => favourites.UserId == favourite.UserId);
            if (favouriteExist != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool IsFavouriteExistWithId(string userid)
        {
            var favouriteExist = db.Fav.Find(x => x.UserId == userid).FirstOrDefault();
            if (favouriteExist != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
