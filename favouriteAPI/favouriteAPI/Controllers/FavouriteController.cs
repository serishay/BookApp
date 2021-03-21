using favouriteAPI.Exceptions;
using favouriteAPI.Models;
using favouriteAPI.Service;
using FavouriteAPI.Exceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace favouriteAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FavouriteController : ControllerBase
    {
        private readonly IFavouriteService _service;
        public FavouriteController(IFavouriteService service)
        {
            _service = service;
        }
        // GET: api/<FavouriteController>
        [HttpGet("getFavourites")]
        public IActionResult Get()
        {
            try
            {
                return Ok(_service.GetFavourites());
            }
            catch (FavouriteNotFound ex)
            {
                return Conflict(ex.Message);
            }
        }

        //[Authorize]
        [HttpGet("{userId}")]
        public IActionResult GetFavourite(string userId )
        {
            try
            {
                return Ok( _service.GetFavourite(userId));
            }
            catch (FavouriteNotFound ex)
            {
                return Conflict(ex.Message);
            }
        }

        //[Authorize]
        [HttpPost]
        [Route("Add")]
        public IActionResult AddFavourite([FromBody] Favourite fav)
        {
            try
            {              
                 return Created("", _service.AddFavourite(fav));
            }
            catch (FavouriteNotFound ex)
            {
                return Conflict(ex.Message);
            }
            //catch
            //{
            //    return StatusCode(500, "Internal Server Error");
            //}
        }
       // [Authorize]
        [HttpDelete("{userId}/{title}")]
        public IActionResult Delete(string userId)
        {
            try
            {
                return Ok(_service.DeleteFavourite(userId));
            }
            catch (FavouriteNotFound ex)
            {
                return Conflict(ex.Message);
            }
        }
    }
}
