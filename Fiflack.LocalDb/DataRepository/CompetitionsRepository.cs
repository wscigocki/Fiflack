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
    public class CompetitionsRepository : ICompetitionsRepository
    {
        private readonly IMapper _mapper;

        public CompetitionsRepository()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Competition, CompetitionDb>();
                cfg.CreateMap<CompetitionDb, Competition>();
            });
            _mapper = config.CreateMapper();
        }

        public Competition GetCompetition(int id)
        {
            using (var context = new FiflackDbContext())
            {
                var competition = context.Competitions.FirstOrDefault(x => x.Id == id);
                if (competition != null)
                    return _mapper.Map<Competition>(competition);
                else
                    return null;
            }
        }

        public IEnumerable<Competition> GetCompetitions()
        {
            using (var context = new FiflackDbContext())
            {
                var competitions = context.Competitions;

                foreach (var competition in competitions)
                {
                    yield return _mapper.Map<Competition>(competition);
                }

                yield break;
            }
        }
    }
}
