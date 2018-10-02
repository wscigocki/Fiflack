using AutoMapper;
using Fiflack.Core.DataProvider;
using Fiflack.Core.View;
using Fiflack.LocalDb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fiflack.LocalDb.DataProvider
{
    public class MatchScoresProvider : IMatchScoresProvider
    {
        private readonly IMapper _mapper;

        public MatchScoresProvider()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<MatchScoreDb, MatchScoreView>();
            });
            _mapper = config.CreateMapper();
        }

        public List<MatchScoreView> GetForCompetition(int competitionId)
        {
            using (var db = new FiflackDbContext())
            {
                var matches =
                    from ms in db.MatchScores
                    join cm in db.CompetitionMatches on ms.Id equals cm.Match.Id
                    join p1 in db.Players on ms.PlayerId_1 equals p1.Id
                    join p2 in db.Players on ms.PlayerId_2 equals p2.Id
                    where cm.Competition.Id == competitionId
                    select new MatchScoreView
                    {
                        Id = ms.Id,
                        PlayerId_1 = ms.PlayerId_1,
                        PlayerId_2 = ms.PlayerId_2,
                        PlayerName_1 = p1.Name,
                        PlayerName_2 = p2.Name,
                        PlayerGoals_1 = ms.GoalsOfPlayer_1,
                        PlayerGoals_2 = ms.GoalsOfPlayer_2
                    };

                return matches.ToList();
            }
        }
    }
}
