namespace Game.DAL.Entity
{
    public class Category : BaseEntity
    {
        public ICollection<Gamee> Games { get; set; } = new List<Gamee>();
    }
}
