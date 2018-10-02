using Fiflack.Core.DataRepository;
using Fiflack.LocalDb.DataRepository;
using Fiflack.Web.DI;
using Newtonsoft.Json.Serialization;
using System.Web.Http;

namespace Fiflack.Web
{
    public class WebApiApplication : System.Web.HttpApplication
    {
         protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);

            HttpConfiguration config = GlobalConfiguration.Configuration;
            config.Formatters.JsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();

            var containerFactory = new UnityContainerFactory();
            var container = containerFactory.Create();
            config.DependencyResolver = new UnityResolver(container);
        }

    }
}
