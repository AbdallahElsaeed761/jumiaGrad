using Microsoft.Owin;
using Microsoft.Owin.Cors;
using Owin;
using System;
using System.Threading.Tasks;
using System.Web.Http;

[assembly: OwinStartup(typeof(JumiaWebApiGrad.Startup1))]

namespace JumiaWebApiGrad
{
    public class Startup1
    {
        public void Configuration(IAppBuilder app)
        {
            HttpConfiguration config = new HttpConfiguration();
            app.UseCors(CorsOptions.AllowAll);
            config.MapHttpAttributeRoutes();
            config.Routes.MapHttpRoute("RouterController", "{id}", new { id = RouteParameter.Optional });
            config.Routes.MapHttpRoute("DefaultApi", "api/{controller}/{id}",
                new { id = RouteParameter.Optional });
            // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=316888
            app.UseWebApi(config);
           
        }
    }
}
