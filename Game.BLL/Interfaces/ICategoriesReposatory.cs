using Game.DAL.Entity;
namespace Game.BLL.Interfaces
{
	public interface ICategoriesReposatory
	{
		Task<IEnumerable<Category>> GetAllCategoriesAsync();
		Task<Category> GetCategoryByIdAsync(int id);
		Task<Category> CreateCategoryAsync(Category category);
		Task<Category> UpdateCategoryAsync(Category category);
		Task DeleteCategoryAsync(int id);
	}
}
