using System;
using System.Web.Mvc;

namespace LtInfo.Common.RouteTableBuilderTestFolder.Controllers
{
    public class MyTest2Controller : MyAbstractBaseController
    {
        public enum MyEnum
        {
            One
        }

        public ContentResult ActionWithThreeOptionalParameters(int? p0, int? p1, int? p2)
        {
            return Content(String.Empty);
        }
        public ContentResult ActionWithClassParameterIsNotOptionalAtEnd(int p0, object p1)
        {
            return Content(String.Empty);
        }
        public ContentResult ActionWithClassParameterIsNotOptionalAtStart(object p1, int p0)
        {
            return Content(String.Empty);
        }
        public ContentResult ActionWithEnumIsntOptional(MyEnum p0)
        {
            return Content(String.Empty);
        }
        public ContentResult ActionNullableEnumIsOptional(MyEnum? p0)
        {
            return Content(String.Empty);
        }
    }
}