using System;
using System.Web.Mvc;
using LtInfo.Common.RouteTableBuilderTestFolder.Controllers;

namespace LtInfo.Common.RouteTableBuilderTestFolder.Areas.MyTestArea1.Controllers
{
    public class MyTest4Controller : MyAbstractBaseController
    {
        public ActionResult MyAction1(string p0, int p1, int p2, int p3, int p4, int p5)
        {
            return Content(String.Empty);
        }

        public ContentResult ActionWithNoParameters()
        {
            return Content(String.Empty);
        }

        public ContentResult ActionWithOneParameter(string s)
        {
            return Content(String.Empty);
        }
    }

}
