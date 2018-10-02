namespace Fiflack.Core.Model
{
    public class CompetitionMatch
    {
        public int Id { get; set; }

        public Competition Competition { get; set; }

        public MatchScore Match { get; set; }
    }
}