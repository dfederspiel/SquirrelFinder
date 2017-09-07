using System;
using System.Web.Routing;
using Telerik.Microsoft.Practices.Unity;
using Telerik.Sitefinity.Abstractions;
using Telerik.Sitefinity.Data;
using Telerik.Sitefinity.Logging;
using System.Web.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;
using Telerik.Sitefinity.Abstractions;

namespace SquirrelFinderLogging
{
    public static class Installer
    {
        public static void PreApplicationStart()
        {
            Log.Configuring += Log_Configuring;
            Bootstrapper.Initialized += Bootstrapper_Initialized;
        }

        private static void Bootstrapper_Initialized(object sender, ExecutedEventArgs e)
        {
            if (e.CommandName == "RegisterRoutes")
            {
                RegisterRoutes(RouteTable.Routes);
            }
        }

        private static void RegisterRoutes(RouteCollection routes)
        {
            routes.Ignore("{resource}.axd/{*pathInfo}");

            routes.MapHttpRoute(
                name: "SquirrelFinder",
                routeTemplate: "squirrel/{controller}/{action}",
                defaults: new { action = RouteParameter.Optional }
            );
        }

        private static void Log_Configuring(object sender, LogConfiguringEventArgs e)
        {
            var defaultConfigurator = ObjectFactory.Resolve<ISitefinityLogCategoryConfigurator>();
            var customConfigurator = new SquirrelFinderConfigurator(defaultConfigurator, ConfigurationPolicy.ErrorLog);
            ObjectFactory.Container.RegisterInstance<ISitefinityLogCategoryConfigurator>(customConfigurator);
        }
    }
}
