using Game.DAL.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Game.DAL.Data.Config
{
    public class CategoryConfig : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            //seed data for Category
            builder.HasData(
            new Category { Id = 1, Name = "Sports" },
            new Category { Id = 2, Name = "Action" },
            new Category { Id = 3, Name = "Adventure" },
            new Category { Id = 4, Name = "Racing" },
            new Category { Id = 5, Name = "Fighting" },
            new Category { Id = 6, Name = "Film" });
        } 
    }
}
