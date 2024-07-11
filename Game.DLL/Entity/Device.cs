using System.ComponentModel.DataAnnotations;

namespace Game.DAL.Entity
{
    public class Device : BaseEntity
    {
        [MaxLength(50)]
        public string? Icon { get; set; }
    }
}
