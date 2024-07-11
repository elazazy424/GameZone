using Game.BLL.Interfaces;
using Game.DAL.Data;
using Game.DAL.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore.Metadata;
namespace Game.BLL.Repository
{
	public class GameRepo : IGameRepository
	{
		//inject dbcontext
		private readonly ApplicationDbContext _context;
		public GameRepo(ApplicationDbContext context)
		{
			_context = context;
		}
		public async Task<Gamee> CreateGameAsync(Gamee game)
		{
			var newGame = new Gamee
			{
				Name = game.Name,
				CategoryId = game.CategoryId,
				Description = game.Description,
				Cover = game.Cover,
				GameDevices = game.GameDevices // Include GameDevices
			};
			_context.Games.Add(newGame);
			await _context.SaveChangesAsync();
			return newGame;
		}

		public async Task<bool> DeleteGameAsync(int id)
		{
			var isDeleted = false;
			var game = await _context.Games.FindAsync(id);
			if (game != null)
			{
				_context.Games.Remove(game);
				await _context.SaveChangesAsync();
				isDeleted = true;
			}
			return isDeleted;
		}

		public async Task<IEnumerable<Gamee>> GetAllGamesAsync()
		{
			return await _context.Games
				.Include(x => x.Category)
				.Include(x => x.GameDevices)
				.ThenInclude(x => x.Device)
				.AsNoTracking()
				.ToListAsync();
		}

		public async Task<Gamee?> GetGameByIdAsync(int id)
		{
			return await _context.Games
			.Include(x => x.Category)
			.Include(x => x.GameDevices)
			.ThenInclude(x => x.Device)
			.AsNoTracking()
			.SingleOrDefaultAsync(g => g.Id == id);
		}

		public async Task<Gamee> UpdateGameAsync(Gamee game)
		{
			var gameToUpdate = await _context.Games
				.Include(g => g.GameDevices)
				.FirstOrDefaultAsync(g => g.Id == game.Id);

			if (gameToUpdate != null)
			{
				gameToUpdate.Name = game.Name;
				gameToUpdate.CategoryId = game.CategoryId;
				gameToUpdate.Description = game.Description;
				gameToUpdate.Cover = game.Cover;

				// Clear the existing GameDevices collection
				gameToUpdate.GameDevices.Clear();

				// Add the new devices to the GameDevices collection
				foreach (var deviceId in game.GameDevices.Select(d => d.DeviceId))
				{
					gameToUpdate.GameDevices.Add(new GameDevice { DeviceId = deviceId });
				}

				await _context.SaveChangesAsync();
				return gameToUpdate;
			}
			else
			{
				throw new Exception("Game not found");
			}
		}

	}
}
