using RecommendationAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecommendationAPI.Repositories
{
    public interface IRecommendRepository
    {
        Task<Object> GetRecommends();
    }
}
