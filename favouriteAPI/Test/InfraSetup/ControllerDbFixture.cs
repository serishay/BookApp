using favouriteAPI.Models;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace Test.InfraSetup
{
    public class ControllerDbFixture
    {
        public FavouriteDbContext context;
        private IConfigurationRoot configuration;

        public ControllerDbFixture()
        {
            var builder = new ConfigurationBuilder().AddJsonFile("appsettings.json");
            configuration = builder.Build();
            context = new FavouriteDbContext(configuration);
            context.Fav.DeleteMany(Builders<Favourite>.Filter.Empty);
            context.Fav.InsertMany(new List<Favourite>
            {
                new Favourite{Id=5,Author="R.R. Tolkien",Title="Lord of the Rings",UserId="Shivansh"},
                new Favourite{Id=6,Author="Rowling",Title="Harry Potter",UserId="Shivansh"}

            });
        }
        public void Dispose()
        {
            context = null;
        }
    }
}
