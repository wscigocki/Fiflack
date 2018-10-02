using Fiflack.Core.DataProvider;
using Fiflack.Core.DataRepository;
using Fiflack.Core.Model;
using Fiflack.Core.View;
using System.Collections.Generic;
using System.Web.Http;

namespace Fiflack.Web.Controllers
{
    [RoutePrefix("api/matchscores")]
    public class MatchScoresController : ApiController
    {
        private readonly IMatchScoresRepository _matchScoresRepository;
        private readonly IMatchScoresProvider _matchScoresProvider;

        public MatchScoresController(IMatchScoresRepository matchScoresRepository, IMatchScoresProvider matchScoresProvider)
        {
            _matchScoresRepository = matchScoresRepository;
            _matchScoresProvider = matchScoresProvider;
        }

        [Route("competitions/{id}")]
        [HttpGet]
        public List<MatchScoreView> GetForCompetition(int id)
        {
            return _matchScoresProvider.GetForCompetition(id);
        }

        [Route("competitions/{id}")]
        [HttpPost]
        public IHttpActionResult AddMatchScoreForCompetition(int id, MatchScore matchScore)
        {
            _matchScoresRepository.AddCompetitionMatchScore(id, matchScore);
            return Ok();
        }
    }
}