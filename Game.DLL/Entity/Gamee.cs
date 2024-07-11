using System.ComponentModel.DataAnnotations;

namespace Game.DAL.Entity
{
    public class Gamee : BaseEntity
    {
        [MaxLength(2500, ErrorMessage = "max length is 2500")]
        public string? Description { get; set; }
        public string? Cover { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; } = default!;
        //relation m-m to GameDevice
        public ICollection<GameDevice> GameDevices { get; set; } = new List<GameDevice>();
    }
}
