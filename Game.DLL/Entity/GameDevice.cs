namespace Game.DAL.Entity
{
    public class GameDevice
    {
        public int GameId { get; set; }
        public Gamee Game { get; set; } = default!;
        public int DeviceId { get; set; }
        public Device Device { get; set; } = default!;
    }
}
