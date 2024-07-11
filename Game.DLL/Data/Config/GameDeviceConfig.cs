using Game.DAL.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Game.DAL.Data.Config
{
    public class GameDeviceConfig : IEntityTypeConfiguration<GameDevice>
    {
        public void Configure(EntityTypeBuilder<GameDevice> builder)
        {
            //composite Primary Key
            builder.HasKey(e => new { e.GameId, e.DeviceId });
        }
    }
}
