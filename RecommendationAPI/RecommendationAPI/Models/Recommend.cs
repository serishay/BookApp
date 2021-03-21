using Newtonsoft.Json;

namespace RecommendationAPI.Models
{
    public class Recommend
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("author")]
        public string Author { get; set; }
        [JsonProperty("title")]
        public string Title { get; set; }
        [JsonProperty("urlImg")]
        public string UrlImg { get; set; }
        [JsonProperty("webUrl")]
        public string WebUrl { get; set; }
        [JsonProperty("userId")]
        public string UserId { get; set; }
    }
}
