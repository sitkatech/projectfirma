using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace ProjectFirma.Api
{
    public class ValidateModelAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            if (!actionContext.ModelState.IsValid)
            {
                var errors = new List<string>();
                foreach (var state in actionContext.ModelState)
                {
                    foreach (var error in state.Value.Errors)
                    {
                        errors.Add(error.ErrorMessage);
                    }
                }
                actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.BadRequest, errors);
            }
        }
    }
}