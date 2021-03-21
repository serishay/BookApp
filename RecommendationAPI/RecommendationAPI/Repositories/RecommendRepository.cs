using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;

namespace RecommendationAPI.Repositories
{
    public class RecommendRepository : IRecommendRepository
    {
        public async Task<object> GetRecommends()
        {
            dynamic res = "";
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("http://localhost:51409/api/Favourite/getFavourites"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    res = JsonConvert.DeserializeObject(apiResponse).ToString();
                }
            }
            return res;
        }
    }
}
