using Game.BLL.Interfaces;
using Game.BLL.Repository;
using GameZone.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace GameZone.Controllers
{
    public class HomeController : Controller
    {
        private readonly IGameRepository _gameRepository;

		public HomeController(IGameRepository gameRepository)
		{
			_gameRepository = gameRepository;
		}
        // GET: Home reteive all games
        [HttpGet]
		public async Task <IActionResult> Index()
        {
            return View(await _gameRepository.GetAllGamesAsync());
        }

      

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
