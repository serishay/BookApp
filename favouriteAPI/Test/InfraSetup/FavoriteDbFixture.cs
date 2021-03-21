using favouriteAPI.Models;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace Test.InfraSetup
{
    public class FavoriteDbFixture: IDisposable
    {
        public FavouriteDbContext context;
        private IConfigurationRoot configuration;

        public FavoriteDbFixture()
        {
            var builder = new ConfigurationBuilder().AddJsonFile("appsettings.json");
            configuration = builder.Build();
            context = new FavouriteDbContext(configuration);
            context.Fav.DeleteMany(Builders<Favourite>.Filter.Empty);
            context.Fav.InsertMany(new List<Favourite>
            {
                new Favourite{Id=1,Author="R.R. Tolkien",Title="Lord of the Rings",UserId="Shivansh",urlImg="http://books.google.com/books/content?id=lqHNugAACAAJ&printsec=frontcover&img=1&zoom=1&source=gbs_api",webUrl="http://play.google.com/books/reader?id=lqHNugAACAAJ&hl=&printsec=frontcover&source=gbs_api"},
                new Favourite{Id=2,Author="Rowling",Title="Harry Potter",UserId="Shivansh",urlImg="http://books.google.com/books/content?id=f280CwAAQBAJ&printsec=frontcover&img=1&zoom=1&source=gbs_api",webUrl="http://play.google.com/books/reader?id=f280CwAAQBAJ&hl=&printsec=frontcover&source=gbs_api"}

            });
        }
        public void Dispose()
        {
            context = null;
        }
    }
}
