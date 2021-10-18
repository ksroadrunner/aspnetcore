using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using BookStore.Models;
using BookStore.Application.Abstractions.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Caching.Distributed;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace BookStore.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUserService _userService;
        private readonly IDistributedCache _distributedCache;

        public HomeController(ILogger<HomeController> logger,
                              IUserService userService,
                              IDistributedCache distributedCache)
        {
            _logger = logger;
            _userService = userService;
            _distributedCache = distributedCache;
        }

        [Authorize(Roles = "User")]
        public IActionResult Index()
        {
            return View();
        }

        // [FromForm], [FromQuery],[FromBody],[FromHeader], [FromRoute]
        // [FromHeader(Name = "Accept-Language")] string lang)
        public IActionResult Privacy()
        {
            return View();
        }

        public async Task<IActionResult> GetUsers()
        {
            List<Domain.User> result;

            var cache = await _distributedCache.GetStringAsync("users2").ConfigureAwait(false);
            if (!string.IsNullOrWhiteSpace(cache))
            {
                result = JsonConvert.DeserializeObject<List<Domain.User>>(cache);
            }
            else
            {
                result = await _userService.GetAllUsers();

                var json = JsonConvert.SerializeObject(result);
                _distributedCache.SetString("users2", json);
            }
            return Ok(result);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
