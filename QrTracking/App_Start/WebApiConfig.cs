using System.Web.Http;
using Newtonsoft.Json.Serialization;

namespace MasterDetail.WebApp.App_Start
{
    class WebApiConfig
    {
        public static void Register(HttpConfiguration configuration)
        {
            configuration.Routes.MapHttpRoute(
                name: "API Default",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            var jsonFormatter = GlobalConfiguration.Configuration.Formatters.JsonFormatter;
            jsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
        }
    }
}

// http://stackoverflow.com/questions/11990036/how-to-add-web-api-to-an-existing-asp-net-mvc-4-web-application-project