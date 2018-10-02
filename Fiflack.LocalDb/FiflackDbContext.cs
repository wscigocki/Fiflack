
using Fiflack.LocalDb.Models;
using System.Data.Entity;

namespace Fiflack.LocalDb
{
    public class FiflackDbContext: DbContext
    {
        public FiflackDbContext()
            :base("FiflackDb")
        {
        }

        public DbSet<PlayerDb> Players { get; set; }

        public DbSet<MatchScoreDb> MatchScores { get; set; }

        public DbSet<CompetitionDb> Competitions { get; set; }

        public DbSet<CompetitionMatchDb> CompetitionMatches { get; set; }
    }
}