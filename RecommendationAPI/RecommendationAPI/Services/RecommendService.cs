using RecommendationAPI.Repositories;
using System.Threading.Tasks;

namespace RecommendationAPI.Services
{
    public class RecommendService : IRecommendService
    {
        private readonly IRecommendRepository repository;
        public RecommendService(IRecommendRepository _repository)
        {
           repository = _repository;
        }

        public Task<object> GetRecommends()
        {
            return repository.GetRecommends();
        }
    }
}
