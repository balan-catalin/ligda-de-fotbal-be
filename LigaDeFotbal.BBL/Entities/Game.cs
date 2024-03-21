namespace LigaDeFotbal.BBL.Entities
{
    public class Game
    {
        public DateTime PlayDate { get; set; }
        public int Fixture { get; set; }
        public int? Score1 { get; set; }
        public int? Score2 { get; set; }

        public int FirstTeamId { get; set; }
        public Team? FirstTeam { get; set; }
        public int SecondTeamId {  get; set; }
        public Team? SecondTeam { get; set; }
        public int CompetitionId { get; set; }
        public virtual Competition? Competition { get; set; }
        public virtual ICollection<Bet>? Bets { get; set; }
    }
}
