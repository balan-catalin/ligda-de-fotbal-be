namespace LigaDeFotbal.BBL.Entities
{
    public class Bet
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int GameTeamId1 { get; set; }
        public int GameTeamId2 { get; set; }
        public DateTime GamePlayDate { get; set; }
        public DateTime BetDate { get; set; }
        public int Score1 { get; set; }
        public int Score2 { get; set; }

        public virtual Game? Game { get; set; }
    }
}
