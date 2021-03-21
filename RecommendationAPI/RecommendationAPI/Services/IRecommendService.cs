using System;
using System.Threading.Tasks;

namespace RecommendationAPI.Services
{
    public interface IRecommendService
    {
        Task<Object> GetRecommends();
    }
}
