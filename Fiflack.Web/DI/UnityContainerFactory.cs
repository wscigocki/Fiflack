using Unity;

namespace Fiflack.Web.DI
{
    public class UnityContainerFactory
    {
        public UnityContainer Create()
        {
            var container = new UnityContainer();
            UnityContainerConfigurator.Config(container);
            LocalDb.DI.UnityContainerConfigurator.Config(container);

            return container;
        }
    }
}