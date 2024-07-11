using Game.BLL.Interfaces;

namespace Game.BLL.Repository
{
	public class UnitOfWork : IUnitOfWork
	{
		public IGameRepository GameRepository { get; set; }

		public IDevicesRepository DevicesRepository { get; set; }

		public ICategoriesReposatory CategoriesReposatory { get; set; }
		public UnitOfWork(IGameRepository gameRepository, IDevicesRepository devicesRepository, ICategoriesReposatory categoriesReposatory)
		{
			GameRepository = gameRepository;
			DevicesRepository = devicesRepository;
			CategoriesReposatory = categoriesReposatory;
		}

	}
}
