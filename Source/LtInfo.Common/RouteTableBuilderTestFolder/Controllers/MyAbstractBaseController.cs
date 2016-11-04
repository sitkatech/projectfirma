using System;
using System.Web.Mvc;

namespace LtInfo.Common.RouteTableBuilderTestFolder.Controllers
{
    public abstract class MyAbstractBaseController : Controller
    {
        public ActionResult BaseAction()
        {
            return Content(String.Empty);
        }
    }

    public struct MyStructParameter
    {
    }

    public class MyClassParamter
    {
    }

}