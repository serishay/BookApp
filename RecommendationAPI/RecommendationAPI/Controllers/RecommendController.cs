using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RecommendationAPI.Services;

namespace RecommendationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecommendController : ControllerBase
    {
        private readonly IRecommendService service;

        public RecommendController(IRecommendService _service)
        {
            this.service = _service;
        }
        [HttpGet()]
        public async Task<IActionResult> GetRecommends()
        {
            var detailsExist = await service.GetRecommends();
            return new OkObjectResult(detailsExist);
        }

    }
}
