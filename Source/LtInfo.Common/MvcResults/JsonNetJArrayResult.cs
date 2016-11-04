using System.Collections;
using System.Web.Mvc;
using Newtonsoft.Json.Linq;

namespace LtInfo.Common.MvcResults
{
    public class JsonNetJArrayResult : JsonResult
    {
        private readonly JArray _data;

        public JsonNetJArrayResult(IEnumerable enumerable)
        {
            _data = JArray.FromObject(enumerable);
        }

        public override void ExecuteResult(ControllerContext context)
        {
            var response = context.HttpContext.Response;
            response.ContentType = "application/json";
            response.Write(_data.ToString(Newtonsoft.Json.Formatting.None));
        }
    }
}