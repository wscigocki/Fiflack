using Fiflack.Core.DataRepository;
using Fiflack.Core.Model;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;

namespace Fiflack.Web.Controllers
{
    [RoutePrefix("api/competitions")]
    public class CompetitionsController : ApiController
    {
        protected ICompetitionsRepository CompetitionsRepository { get; private set; }

        public CompetitionsController(ICompetitionsRepository competitionsRepository)
        {
            CompetitionsRepository = competitionsRepository;
        }

        [HttpGet]
        public IEnumerable<Competition> GetCompetitions()
        {
            return CompetitionsRepository.GetCompetitions();
        }

        [HttpGet]
        [ResponseType(typeof(Competition))]
        public IHttpActionResult GetCompetition(int id)
        {
            var competition = CompetitionsRepository.GetCompetition(id);
            if (competition == null)
            {
                return NotFound();
            }

            return Ok(competition);

        }
    }
}