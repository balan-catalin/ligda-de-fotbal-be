namespace LigaDeFotbal.BBL.Entities
{
    public class Competition
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public virtual ICollection<UserCompetition>? UserCompetitions { get; set; }
        public virtual ICollection<Game>? Games { get; set; }
    }
}
