using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System;

namespace favouriteAPI.Models
{
    public class FavouriteDbContext : DbContext
    {
        MongoClient client;
        IMongoDatabase database;
        public FavouriteDbContext(IConfiguration config)
        {
            // client = new MongoClient(config.GetSection("MongoDB:server").Value);
            // database = client.GetDatabase(config.GetSection("MongoDB:db").Value);
            client=new MongoClient(Environment.GetEnvironmentVariable("MONGO_CONNECTION"));
            database = client.GetDatabase(config.GetSection("MongoDB:db").Value);
        }
        public IMongoCollection<Favourite> Fav => database.GetCollection<Favourite>("Recommendation");

        //    public FavouriteDbContext()
        //    { }
        //    public FavouriteDbContext(DbContextOptions options):base(options)
        //    {
        //        try
        //        {
        //            this.Database.EnsureCreated();
        //        }
        //        catch
        //        {
        //            throw new DatabaseNotFound();
        //        }
        //    }
        //    public DbSet<Favourite> Favourites { get; set; }

        //    protected override void OnModelCreating(ModelBuilder modelBuilder)
        //    {
        //        modelBuilder.Entity<Favourite>()
        //            .HasKey(c => new { c.Author,c.Title,c.Description,c.PublishedAt,c.UserName });
        //    }
    }
}
