using AutoMapper;
using Game.BLL.Interfaces;
using Game.DAL.Entity;
using GameZone.Helpers;
using GameZone.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GameZone.Controllers
{
    public class GamesController : Controller
    {
        private readonly IGameRepository _GameRepo;
        private readonly ICategoriesReposatory _CategoriesRepo;
        private readonly IDevicesRepository _DevicesRepo;
        private readonly IMapper _mapper;

        public GamesController(IGameRepository GameRepo,
            ICategoriesReposatory categoriesRepo,
            IDevicesRepository devicesRepo,
            IMapper mapper)
        {
            _GameRepo = GameRepo;
            _CategoriesRepo = categoriesRepo;
            _DevicesRepo = devicesRepo;
            _mapper = mapper;
        }
        public async Task <IActionResult> Index()
        {
            var games = await _GameRepo.GetAllGamesAsync();
            return View(games);
        }
		#region show form
		[HttpGet]
		public async Task<IActionResult> Create()
		{
			var viewModel = new CreateGameFormViewModel();
			await PopulateCategoriesAndDevicesAsync(viewModel);
			return View(viewModel);
		}
		#endregion
		#region create game
		[HttpPost]
		[ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateGameFormViewModel viewModel)
		{
			if (ModelState.IsValid)
			{
				viewModel.CoverName = DocumentSettings.UploadFile(viewModel.Cover, "images");
				var game = _mapper.Map<Gamee>(viewModel);
				game.Cover = viewModel.CoverName;

				// Use the DevicesRepository to get existing device IDs
				var existingDeviceIds = await _DevicesRepo.GetExistingDeviceIdsAsync(viewModel.SelectedDevices);

				if (existingDeviceIds.Count != viewModel.SelectedDevices.Count)
				{
					// Handle the error (e.g., return an error message)
					ModelState.AddModelError("", "One or more selected devices do not exist.");
					await PopulateCategoriesAndDevicesAsync(viewModel);
					return View(viewModel);
				}

				// Map selected devices
				foreach (var deviceId in viewModel.SelectedDevices)
				{
					game.GameDevices.Add(new GameDevice { DeviceId = deviceId });
				}

				await _GameRepo.CreateGameAsync(game);
				return RedirectToAction("Index");
			}

			await PopulateCategoriesAndDevicesAsync(viewModel);
			return View(viewModel);
		}

		#endregion
		#region details
		[HttpGet]
		public async Task<IActionResult> Details(int id)
        {
			var game = await _GameRepo.GetGameByIdAsync(id);
			if (game == null)
            {
				return NotFound();
			}
			return View(game);
		}
		#endregion
		#region edit get
		[HttpGet]
		public async Task<IActionResult> Edit(int id)
		{
			var game = await _GameRepo.GetGameByIdAsync(id);
			if (game == null)
			{
				return NotFound();
			}

			var viewModel = _mapper.Map<EditGameFormViewModel>(game);
			viewModel.SelectedDevices = game.GameDevices.Select(d => d.DeviceId).ToList();
			viewModel.CoverName = game.Cover; // Ensure CoverName is set

			await PopulateCategoriesAndDevicesAsync(viewModel);

			return View(viewModel);
		}
		#endregion
		#region edit post
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(EditGameFormViewModel viewModel)
		{
			if (ModelState.IsValid)
			{
				var game = await _GameRepo.GetGameByIdAsync(viewModel.Id);
				if (game == null)
				{
					return NotFound();
				}

				if (viewModel.Cover != null)
				{
					viewModel.CoverName = DocumentSettings.UploadFile(viewModel.Cover, "images");
					game.Cover = viewModel.CoverName;
				}
				else
				{
					viewModel.CoverName = game.Cover; // Preserve existing cover if no new file is uploaded
				}

				_mapper.Map(viewModel, game);

				// Use the DevicesRepository to get existing device IDs
				var existingDeviceIds = await _DevicesRepo.GetExistingDeviceIdsAsync(viewModel.SelectedDevices);

				if (existingDeviceIds.Count != viewModel.SelectedDevices.Count)
				{
					// Handle the error (e.g., return an error message)
					ModelState.AddModelError("", "One or more selected devices do not exist.");
					await PopulateCategoriesAndDevicesAsync(viewModel);
					return View(viewModel);
				}

				// Map selected devices
				game.GameDevices.Clear();
				foreach (var deviceId in viewModel.SelectedDevices)
				{
					game.GameDevices.Add(new GameDevice { DeviceId = deviceId });
				}

				await _GameRepo.UpdateGameAsync(game);
				return RedirectToAction("Index");
			}

			await PopulateCategoriesAndDevicesAsync(viewModel);
			return View(viewModel);
		}


		#endregion
		#region delete
		[HttpDelete]
		public async Task<IActionResult> Delete(int id)
		{
			var isDeleted = await _GameRepo.DeleteGameAsync(id);
			if (!isDeleted)
			{
				return NotFound();
			}
			return RedirectToAction("Index");
		}
		#endregion
		#region function to return categories and devices
		private async Task PopulateCategoriesAndDevicesAsync(GameFormViewModel viewModel)
		{
			var categories = await _CategoriesRepo.GetAllCategoriesAsync();
			viewModel.Categories = categories.Select(c => new SelectListItem
			{
				Text = c.Name,
				Value = c.Id.ToString()
			}).OrderBy(c => c.Text);

			var devices = await _DevicesRepo.GetAllDevicesAsync();
			viewModel.Devices = devices.Select(d => new SelectListItem
			{
				Text = d.Name,
				Value = d.Id.ToString()
			}).OrderBy(d => d.Text);
		}

		#endregion
	}
}

