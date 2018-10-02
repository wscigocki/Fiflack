using AutoMapper;
using Fiflack.Core.DataRepository;
using Fiflack.Core.Model;
using Fiflack.LocalDb.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Fiflack.LocalDb.DataRepository
{
    public class PlayersRepository : IPlayersRepository
    {
        private readonly IMapper _mapper;

        public PlayersRepository()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Player, PlayerDb>();
                cfg.CreateMap<PlayerDb, Player>();
            });
            _mapper = config.CreateMapper();
        }

        public void AddPlayer(Player player)
        {
            using (var context = new FiflackDbContext())
            {
                var playerDb = _mapper.Map<PlayerDb>(player);
                context.Players.Add(playerDb);
                context.SaveChanges();
            }
        }

        public void DeletePlayer(int id)
        {
            using (var context = new FiflackDbContext())
            {
                var playerDb = context.Players.FirstOrDefault(x => x.Id == id);

                if (playerDb != null)
                {
                    context.Players.Remove(playerDb);
                    context.SaveChanges();
                }
            }
        }

        public Player GetPlayer(int id)
        {
            using (var context = new FiflackDbContext())
            {
                var playerDb = context.Players.FirstOrDefault(x => x.Id == id);
                return _mapper.Map<Player>(playerDb);
            }
        }

        public IEnumerable<Player> GetPlayers()
        {
            using (var context = new FiflackDbContext())
            {
                var players = context.Players;

                foreach (var player in players)
                {
                    yield return _mapper.Map<Player>(player);
                }

                yield break;
            }
        }

        public bool IsLoginUnique(string login)
        {
            using (var context = new FiflackDbContext())
            {
                return (!context.Players.Any(x => string.Compare(x.Login, login, true) == 0));
            }
        }

        public void UpdatePlayer(Player player)
        {
            using (var context = new FiflackDbContext())
            {
                var playerDb = _mapper.Map<PlayerDb>(player);
                context.Entry(playerDb).State = EntityState.Modified;
                context.SaveChanges();
            }
        }

    }
}
