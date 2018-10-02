using Fiflack.Core.DataRepository;
using Fiflack.Core.Model;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;

namespace Fiflack.Web.Controllers
{
    [RoutePrefix("api/players")]
    public class PlayersController : ApiController
    {
        protected IPlayersRepository PlayersRepository { get; private set; }

        public PlayersController(IPlayersRepository playersRepository)
        {
            PlayersRepository = playersRepository;
        }

        // GET: api/Players
        public IEnumerable<Player> GetPlayers()
        {
            return PlayersRepository.GetPlayers();
        }

        // GET: api/Players/5
        [ResponseType(typeof(Player))]
        public IHttpActionResult GetPlayer(int id)
        {
            Player player = PlayersRepository.GetPlayer(id);
            if (player == null)
            {
                return NotFound();
            }

            return Ok(player);
        }

        // PUT: api/Players/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPlayer(int id, Player player)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != player.Id)
            {
                return BadRequest();
            }

            PlayersRepository.UpdatePlayer(player);
            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Players
        [ResponseType(typeof(Player))]
        public IHttpActionResult PostPlayer(Player player)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            PlayersRepository.AddPlayer(player);
            return StatusCode(HttpStatusCode.NoContent);
        }

        // DELETE: api/Players/5
        [ResponseType(typeof(Player))]
        public IHttpActionResult DeletePlayer(int id)
        {
            PlayersRepository.DeletePlayer(id);
            return StatusCode(HttpStatusCode.NoContent);
        }


        [HttpPost]
        [Route("validateLogin")]
        public IHttpActionResult ValidateLogin(string login)
        {
            if (PlayersRepository.IsLoginUnique(login))
                return Ok();
            else
                return BadRequest();
        }
    }
}