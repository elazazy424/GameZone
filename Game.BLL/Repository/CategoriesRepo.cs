using Game.BLL.Interfaces;
using Game.DAL.Data;
using Game.DAL.Entity;
using Microsoft.EntityFrameworkCore;

namespace Game.BLL.Repository
{
	public class CategoriesRepo : ICategoriesReposatory
	{
		//inject dbcontext
		private readonly ApplicationDbContext _context;
		public CategoriesRepo(ApplicationDbContext context)
		{
			_context = context;
		}
		public async Task<Category> CreateCategoryAsync(Category category)
		{
			var newCategory = new Category
			{
				Name = category.Name
			};
			_context.Categories.Add(newCategory);
			await _context.SaveChangesAsync();
			return newCategory;
		}

		public async Task DeleteCategoryAsync(int id)
		{
			var category = await _context.Categories.FindAsync(id);
			if (category != null)
			{
				_context.Categories.Remove(category);
				await _context.SaveChangesAsync();
			}
			else
			{
				throw new Exception("Category not found");
			}
		}

		public async Task<IEnumerable<Category>> GetAllCategoriesAsync()
		{
			var categories = await _context.Categories.ToListAsync();
			return categories;
		}

		public async Task<Category> GetCategoryByIdAsync(int id)
		{
			var category = await _context.Categories.FindAsync(id);
			if (category == null)
			{
				throw new Exception("Category not found");
			}
			return category;
		}

		public async Task<Category> UpdateCategoryAsync(Category category)
		{
			var categoryToUpdate = await _context.Categories.FindAsync(category.Id);
			if (categoryToUpdate != null)
			{
				categoryToUpdate.Name = category.Name;
				await _context.SaveChangesAsync();
				return categoryToUpdate;
			}
			else
			{
				throw new Exception("Category not found");
			}
		}
	}
}
