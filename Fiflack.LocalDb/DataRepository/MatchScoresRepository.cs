using AutoMapper;
using Fiflack.Core.DataRepository;
using Fiflack.Core.Model;
using Fiflack.LocalDb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fiflack.LocalDb.DataRepository
{
    public class MatchScoresRepository : IMatchScoresRepository
    {
        private readonly IMapper _mapper;

        public MatchScoresRepository()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<MatchScore, MatchScoreDb>();
                cfg.CreateMap<MatchScoreDb, MatchScore>();
            });
            _mapper = config.CreateMapper();
        }

        public void AddCompetitionMatchScore(int competitionId, MatchScore matchScore)
        {
            using (var context = new FiflackDbContext())
            {
                var matchScoreDb = _mapper.Map<MatchScoreDb>(matchScore);
                var savedMatchScore = context.MatchScores.Add(matchScoreDb);
                var copmetition = context.Competitions.FirstOrDefault(x => x.Id == competitionId);

                var competitionMatch = new CompetitionMatchDb();
                competitionMatch.Match = savedMatchScore;
                competitionMatch.Competition = copmetition;
                context.CompetitionMatches.Add(competitionMatch);

                context.SaveChanges();
            }
        }
    }
}
