using Fiflack.Core.Model;
using Fiflack.Core.View;
using System.Collections.Generic;

namespace Fiflack.Core.DataProvider
{
    public interface IMatchScoresProvider
    {
        List<MatchScoreView> GetForCompetition(int competitionId);


    }
}
