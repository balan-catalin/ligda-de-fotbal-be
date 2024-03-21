namespace LigaDeFotbal.BBL.Entities
{
    public class Team
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? ShortName { get; set; }

        public virtual ICollection<Game>? Games { get; set; }
    }
}
