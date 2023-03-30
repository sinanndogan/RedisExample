using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace InMemory.Caching.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        readonly IMemoryCache _memoryCache;

        public ValuesController(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }



        #region Basic Set and Get example
        [HttpGet]
        public string Get()
        {
            _memoryCache.Set("name", "xyzt");
            return _memoryCache.Get<string>("name");
        }
        #endregion


        #region TryGetValue example
        [HttpGet("set/{name}")]
        public void setName(string name)
        {
            _memoryCache.Set("name", name);
        }


        [HttpGet]

        public string GetName()
        {

            var check = _memoryCache.TryGetValue<string>("name", out string name);

            if (check)
            {
                return name;
            }

            return "";


        }
        #endregion



        #region Absolute and Sliding Time Example
        [HttpGet("setDate")]
        public void SetDate()
        {
            _memoryCache.Set<DateTime>("date", DateTime.Now, options: new()
            {
                AbsoluteExpiration = DateTime.Now.AddSeconds(30),
                SlidingExpiration = TimeSpan.FromSeconds(5)
            });
        }


        [HttpGet("getDate")]
        public DateTime GetDate()
        {
            return _memoryCache.Get<DateTime>("date");
        }
        #endregion


    }
}
