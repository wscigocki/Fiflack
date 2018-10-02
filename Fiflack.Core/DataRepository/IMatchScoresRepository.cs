using Fiflack.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fiflack.Core.DataRepository
{
    public interface IMatchScoresRepository
    {
        void AddCompetitionMatchScore(int competitionId, MatchScore matchScore);
    }
}
