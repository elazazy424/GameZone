using Game.DAL.Entity;

namespace Game.BLL.Interfaces
{
	public interface IGameRepository
	{
		Task<IEnumerable<Gamee>> GetAllGamesAsync();
		Task<Gamee?> GetGameByIdAsync(int id);
		Task<Gamee> CreateGameAsync(Gamee game);
		Task<Gamee> UpdateGameAsync(Gamee game);
		Task <bool> DeleteGameAsync(int id);
	}
}
