using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using System.Text;

namespace Distributed.Caching.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExampleController : ControllerBase
    {
        readonly IDistributedCache _distributedCache;

        public ExampleController(IDistributedCache distributedCache)
        {
            _distributedCache = distributedCache;
        }

        [HttpGet("set")]
        public async Task<IActionResult> Set(string name, string surname)
        {
            try
            {
                await _distributedCache.SetStringAsync("name", name,options : new()
                {
                    AbsoluteExpiration=DateTime.Now.AddSeconds(30),
                    SlidingExpiration=TimeSpan.FromSeconds(5)
                });
                await _distributedCache.SetAsync("surname", Encoding.UTF8.GetBytes(surname), options : new()
                {
                    AbsoluteExpiration=DateTime.Now.AddSeconds(30), 
                    SlidingExpiration=TimeSpan.FromSeconds(10)
                });
                return Ok();
            }
            catch (Exception ex)
            {

                return StatusCode(500, ex.Message);
            }

        }


        [HttpGet("get")]

        public async Task<IActionResult> Get()
        {
            try
            {
                var name = await _distributedCache.GetStringAsync("name");
                var surnameBinary = await _distributedCache.GetAsync("surname");
                var surname = Encoding.UTF8.GetString(surnameBinary);
                return Ok(new
                {
                    name,
                    surname
                });
            }
            catch (Exception ex)
            {

                return StatusCode(500, ex.Message);
            }

        }

    }
}
