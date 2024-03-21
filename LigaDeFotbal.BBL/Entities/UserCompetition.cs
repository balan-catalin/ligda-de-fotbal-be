namespace LigaDeFotbal.BBL.Entities
{
    public class UserCompetition
    {
        public int Id { get; set; }
        public DateTime RegistrationDate { get; set; }
        public DateTime? LastUpdate { get; set;}
        public int RightAnswers { get; set; }
        public int Position { get; set; }
        public string Score { get; set; }

        public int UserId { get; set; }
        public virtual User? User { get; set; }
        public int CompetitionId {  get; set; }
        public virtual Competition? Competition { get; set; }
    }
}
