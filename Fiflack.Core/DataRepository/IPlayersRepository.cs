using Fiflack.Core.Model;
using System.Collections.Generic;
using System.Linq;

namespace Fiflack.Core.DataRepository
{
    public interface IPlayersRepository
    {
        IEnumerable<Player> GetPlayers();

        Player GetPlayer(int id);

        void UpdatePlayer(Player player);

        void AddPlayer(Player player);

        void DeletePlayer(int id);

        bool IsLoginUnique(string login);
    }
}
