using MongoDB.Bson.Serialization.Attributes;
using System;

namespace favouriteAPI.Models
{
    [BsonIgnoreExtraElements]
    public class Favourite
    {
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //[Key]
        [BsonId]
        public int Id { get; set; }
        public string Author { get; set; }
        public string Title { get; set; }
        public string urlImg { get; set; }
        public string webUrl { get; set; }
        public string UserId { get; set; }
    }
}
