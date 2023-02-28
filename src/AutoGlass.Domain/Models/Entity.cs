namespace AutoGlass.Domain.Models
{
    public abstract class Entity
    {
        public int Id { get; protected set; }
        public bool Removed { get; set; } = false;

    }

}