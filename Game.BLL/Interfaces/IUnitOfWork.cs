namespace Game.BLL.Interfaces
{
	public interface IUnitOfWork
	{
		IGameRepository GameRepository { get; }
		IDevicesRepository DevicesRepository { get; }
		ICategoriesReposatory CategoriesReposatory { get; }
	}
}
