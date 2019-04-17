using System.Net.Http.Formatting;
using System.Web.Http;

namespace ProjectFirma.Api
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API routes
            config.MapHttpAttributeRoutes();

            // Model validation
            config.Filters.Add(new ValidateModelAttribute());

            config.Formatters.Add(new BsonMediaTypeFormatter());
        }
    }
}
