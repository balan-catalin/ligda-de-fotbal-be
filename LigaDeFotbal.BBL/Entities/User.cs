namespace LigaDeFotbal.BBL.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Bet>? Bets { get; set;}
        public virtual ICollection<UserCompetition>? UserCompetitions { get; set;}
    }
}
