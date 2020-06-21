using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Get_HttpContext_ASP.NET_Core.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IUserService _userService;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, 
            IHttpContextAccessor httpContextAccessor,
            IUserService userService)
        {
            _logger = logger;
            _httpContextAccessor = httpContextAccessor;
            _userService = userService;
        }

        [HttpGet("/getDetails")]
        public string GetDetails()
        {
            var result = "Method - " + HttpContext.Request.Method + " Path - " + HttpContext.Request.Path;
            return result;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var res = HttpContext.Request.Method;
            var userName = _userService.GetLoginUserName();
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}
