using Fiflack.Core.DataProvider;
using Fiflack.Core.DataRepository;
using Fiflack.LocalDb.DataProvider;
using Fiflack.LocalDb.DataRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Unity;
using Unity.Lifetime;

namespace Fiflack.Web.DI
{
    public static class UnityContainerConfigurator
    {
        public static void Config(UnityContainer container)
        {
            // repositories
            container.RegisterType<IPlayersRepository, PlayersRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<ICompetitionsRepository, CompetitionsRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<IMatchScoresRepository, MatchScoresRepository>(new HierarchicalLifetimeManager());

            // providers
            container.RegisterType<IMatchScoresProvider, MatchScoresProvider>(new HierarchicalLifetimeManager());
            
        }
    }
}