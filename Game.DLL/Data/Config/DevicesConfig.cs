using Game.DAL.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Game.DAL.Data.Config
{
    public class DevicesConfig : IEntityTypeConfiguration<Device>
    {
      
        public void Configure(EntityTypeBuilder<Device> builder)
        {
            //seed data for Device
            builder.HasData(
             new Device { Id = 1, Name = "PlayStation", Icon = "bi bi-playstation" },
             new Device { Id = 2, Name = "Xbox", Icon = "bi bi-xbox" },
             new Device { Id = 3, Name = "Nintendo", Icon = "bi bi-nintendo" },
            new Device { Id = 4, Name = "PC", Icon = "bi bi-pc-display" });
        }
    }
}
