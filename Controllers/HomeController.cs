using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using SignalrApp.Hubs;
using SignalrApp.Models;
using System.Diagnostics;

namespace SignalrApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IHubContext<DeathlyHallowsHub> _deathlyHallowsHub;

        public HomeController(IHubContext<DeathlyHallowsHub> deathlyHallowsHub)
        {
            _deathlyHallowsHub = deathlyHallowsHub;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> DeathlyHallows(string type) 
        {
            if(SD.DealthyHallowRace.ContainsKey(type))
            {
                SD.DealthyHallowRace[type]++;
            }
            await _deathlyHallowsHub.Clients.All.SendAsync("updateDeathlyAllowCount",
                SD.DealthyHallowRace[SD.Wand],
                SD.DealthyHallowRace[SD.Stone],
                SD.DealthyHallowRace[SD.Cloack]
                );
            return Accepted();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}