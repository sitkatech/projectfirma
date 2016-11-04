using System.Web.Mvc;
using Newtonsoft.Json.Linq;

namespace LtInfo.Common.MvcResults
{
    public class JsonNetJObjectResult : JsonResult
    {
        private readonly JObject _data;

        public JsonNetJObjectResult(object obj)
        {
            _data = JObject.FromObject(obj);
        }

        public override void ExecuteResult(ControllerContext context)
        {
            var response = context.HttpContext.Response;
            response.ContentType = "application/json";
            response.Write(_data.ToString(Newtonsoft.Json.Formatting.None));
        }
    }
}