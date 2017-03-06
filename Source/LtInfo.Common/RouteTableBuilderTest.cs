/*-----------------------------------------------------------------------
<copyright file="RouteTableBuilderTest.cs" company="Sitka Technology Group">
Copyright (c) Sitka Technology Group. All rights reserved.
<author>Sitka Technology Group</author>
</copyright>

<license>
This program is free software: you can redistribute it and/or modify
it under the terms of the GNU Affero General Public License as published by
the Free Software Foundation, either version 3 of the License, or
(at your option) any later version.

This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU Affero General Public License <http://www.gnu.org/licenses/> for more details.

Source code is available upon request via <support@sitkatech.com>.
</license>
-----------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Web.Mvc;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.RouteTableBuilderTestFolder.Areas.MyTestArea1.Controllers;
using LtInfo.Common.RouteTableBuilderTestFolder.Controllers;
using NUnit.Framework;

namespace LtInfo.Common
{
    [TestFixture]
    public class RouteTableBuilderTest
    {
        [Test]
        public void TestThatNullStringAsFirstParameterThrows()
        {
            SetupRoutesUsingTestClasses();
            Assert.DoesNotThrow(() => SitkaRoute<MyTest1Controller>.BuildUrlFromExpression(c => c.MyAction1("a", 1, 1, 1, 1, 1)),
                                "Should have been able to create url for TestAction with non-null string as first parameter!");
            var exception = Assert.Catch(() => SitkaRoute<MyTest1Controller>.BuildUrlFromExpression(c => c.MyAction1(null, 1, 1, 1, 1, 1)),
                                               "Should NOT have been able to create url for TestAction with null string as first parameter!");
            Assert.That(exception.Message, Is.StringContaining("Could not find a route entry"), "Should be message about illegal route");
        }

        [Test]
        public void TestBadRoutesThrow()
        {
            SetupRoutesUsingTestClasses();
            int defaultRouteCount = GetDefaultRouteCount();
            TestRouteParameterOptionality(defaultRouteCount, typeof(RouteTableBuilderTestNullFirstController), true);
            TestRouteParameterOptionality(defaultRouteCount, typeof(RouteTableBuilderTestNullInMiddleController), true);
            TestRouteParameterOptionality(defaultRouteCount + 1, typeof(RouteTableBuilderTestNullStringFirstIsOkayController), false);
        }

        private static int GetDefaultRouteCount()
        {
            List<SitkaRouteTableEntry> routeEntries = RouteTableBuilder.SetupRouteTableImpl(new MethodInfo[] {});
            return routeEntries.Count;
        }

        private static void TestRouteParameterOptionality(int expectedCountOfRoutes, Type type, bool shouldThrow)
        {
            List<MethodInfo> methods = SitkaController.FindControllerActions(type);
            Assert.That(methods, Is.Not.Empty, string.Format("Test Precondition: the test type {0} should have a controller action on it", type));

            if (shouldThrow)
            {
                Assert.Throws<PreconditionException>(() => RouteTableBuilder.SetupRouteTableImpl(methods), string.Format("An illegal route was allowed into the route table! {0}", type.Name));
            }
            else
            {
                var routeEntries = new List<SitkaRouteTableEntry>();
                Assert.DoesNotThrow(() => routeEntries = RouteTableBuilder.SetupRouteTableImpl(methods), string.Format("A legal route was not allowed into the route table! {0}", type.Name));
                Assert.That(routeEntries.Count, Is.EqualTo(expectedCountOfRoutes), string.Format("Route count is not what was expected. {0}", type.Name));
            }
        }

        [Test]
        public void TestRouteBuilder()
        {
            List<MethodInfo> methods = SitkaController.FindControllerActions(typeof(RouteTableBuilderTestController));
            Assert.That(methods.Count, Is.EqualTo(6));

            List<SitkaRouteTableEntry> routeEntries = RouteTableBuilder.SetupRouteTableImpl(methods);

            Assert.That(routeEntries.Count, Is.EqualTo(11 + GetDefaultRouteCount()));
        }

        [Test]
        public void RoutesShouldNotCollide()
        {
            List<MethodInfo> allTestControllerActions = SitkaController.FindControllerActions(typeof(MyAbstractBaseController));
            List<SitkaRouteTableEntry> routeEntries = RouteTableBuilder.SetupRouteTableImpl(allTestControllerActions);

            Assert.That(routeEntries.All(re => re != null));

            List<IGrouping<string, SitkaRouteTableEntry>> duplicateRouteNames = routeEntries.ToLookup(x => x.RouteName).Where(grp => grp.Count() > 1).ToList();
            Assert.That(duplicateRouteNames, Is.Empty, "All route names should be unique but there are duplicates");

            List<IGrouping<string, SitkaRouteTableEntry>> duplicateRouteUrls = routeEntries.ToLookup(x => x.RouteUrl).Where(grp => grp.Count() > 1).ToList();
            Assert.That(duplicateRouteUrls, Is.Empty, "All route urls should be unique but there are duplicates");
        }

        [Test]
        public void CanDetectOptionalParameters()
        {
            Assert.IsTrue(RouteTableBuilder.IsOptionalRouteType(typeof(int?)));
            Assert.IsTrue(RouteTableBuilder.IsOptionalRouteType(typeof(string)));
            Assert.IsFalse(RouteTableBuilder.IsOptionalRouteType(typeof(int)));
            Assert.IsFalse(RouteTableBuilder.IsOptionalRouteType(typeof(MyStructParameter)));
            Assert.IsTrue(RouteTableBuilder.IsOptionalRouteType(typeof(MyStructParameter?)));
            Assert.IsFalse(RouteTableBuilder.IsOptionalRouteType(typeof(MyClassParamter)), "Classes can't be optional - we use them for getting into objects directly");
            Assert.IsFalse(RouteTableBuilder.IsOptionalRouteType(typeof(MyTest2Controller.MyEnum)));
            Assert.IsTrue(RouteTableBuilder.IsOptionalRouteType(typeof(MyTest2Controller.MyEnum?)));
        }

        [Test]
        public void CanMatchRealUrlVariations()
        {
            SetupRoutesUsingTestClasses();
            AssertUrlBuilderMatches<MyTest1Controller>(c => c.ActionWithNoParameters(), "/MyTest1/ActionWithNoParameters", "Route with no parameters");
            AssertUrlBuilderMatches<MyTest1Controller>(c => c.ActionWithOneParameter("2001-001-00"), "/MyTest1/ActionWithOneParameter/2001-001-00", "Route with one parameter");
            AssertUrlBuilderMatches<MyTest2Controller>(c => c.ActionWithThreeOptionalParameters(null, null, null), "/MyTest2/ActionWithThreeOptionalParameters", "Route with optional parameters, none specified");
            AssertUrlBuilderMatches<MyTest2Controller>(c => c.ActionWithThreeOptionalParameters(1, null, null), "/MyTest2/ActionWithThreeOptionalParameters/1", "Route with optional parameters, one specified");
            AssertUrlBuilderMatches<MyTest2Controller>(c => c.ActionWithThreeOptionalParameters(1, 1, 3), "/MyTest2/ActionWithThreeOptionalParameters/1/1/3", "Route with optional parameters, all specified");
            AssertUrlBuilderMatches<MyTest2Controller>(c => c.ActionWithEnumIsntOptional(MyTest2Controller.MyEnum.One), "/MyTest2/ActionWithEnumIsntOptional/One", "Route with optional parameters, all specified");
            AssertUrlBuilderMatches<MyTest2Controller>(c => c.ActionNullableEnumIsOptional(null), "/MyTest2/ActionNullableEnumIsOptional", "Nullable enum is allowed");
            AssertUrlBuilderMatches<MyTest2Controller>(c => c.ActionNullableEnumIsOptional(MyTest2Controller.MyEnum.One), "/MyTest2/ActionNullableEnumIsOptional/One", "Nullable enum is allowed");
            AssertUrlBuilderMatches<MyTest2Controller>(c => c.ActionWithClassParameterIsNotOptionalAtEnd(1, new object()), "/MyTest2/ActionWithClassParameterIsNotOptionalAtEnd/1/System.Object", "Route with class parameters must be considered non-nullable to allow for special object handling ModelBinder to data object");
            AssertUrlBuilderMatches<MyTest2Controller>(c => c.ActionWithClassParameterIsNotOptionalAtStart(new object(), 1), "/MyTest2/ActionWithClassParameterIsNotOptionalAtStart/System.Object/1", "Route with class parameters must be considered non-nullable to allow for special object handling ModelBinder to data object");

            // routes with areas
            AssertUrlBuilderMatches<MyTest4Controller>(c => c.ActionWithNoParameters(), "/MyTest4/ActionWithNoParameters", "Route with no parameters");
            AssertUrlBuilderMatches<MyTest4Controller>(c => c.MyAction1("Hello", 1, 2, 3, 4, 6), "/MyTest4/MyAction1/Hello/1/2/3/4/6", "Route with no parameters");
            AssertUrlBuilderMatches<MyTest4Controller>(c => c.ActionWithOneParameter("Ray"), "/MyTest4/ActionWithOneParameter/Ray", "Route with no parameters");


            var ex = Assert.Catch(() => SitkaRoute<MyTest2Controller>.BuildUrlFromExpression(c => c.ActionWithThreeOptionalParameters(null, 1, null)), "Expected throw exception when converting UrlParameter to QueryStringParameter");
            Assert.That(ex.Message, Is.StringContaining("?"), "Expected message to show the query string it was about to make");
            Assert.That(ex.Message, Is.StringContaining("optional"), "Expected message to mention the optional parameter was in conflict");
            Assert.That(ex.Message, Is.StringContaining("p1"), "Expected message to mention parameter that was in conflict");

            Assert.Catch(() => SitkaRoute<MyTest2Controller>.BuildUrlFromExpression(c => c.ActionWithClassParameterIsNotOptionalAtEnd(1, null)), "Expected throw exception when converting UrlParameter to QueryStringParameter");
            Assert.Catch(() => SitkaRoute<MyTest2Controller>.BuildUrlFromExpression(c => c.ActionWithClassParameterIsNotOptionalAtStart(null, 1)), "Expected throw exception when converting UrlParameter to QueryStringParameter");
        }

        [Test]
        public void CanFindActionsInheritedFromBaseClass()
        {
            var controllerActionMethods = SitkaController.FindControllerActions(typeof(MyTest1Controller));
            var methodNames = controllerActionMethods.Select(x => String.Format("{0}.{1}", x.ReflectedType.Name, x.Name)).ToList();
            var expected = new[] { "MyTest1Controller.MyAction1", "MyTest1Controller.ActionWithNoParameters", "MyTest1Controller.ActionWithOneParameter", "MyTest1Controller.BaseAction" };
            Assert.That(methodNames, Is.EquivalentTo(expected), "Should find both base declared actions and derived actions");

            var abstractBaseControllerActionMethods = SitkaController.FindControllerActions(typeof(MyAbstractBaseController));
            Assert.That(abstractBaseControllerActionMethods, Is.Empty, "Should not find any in abstract base classes - they don't count for routes");
        }

        private static void SetupRoutesUsingTestClasses()
        {
            RouteTableBuilder.ClearRoutes();
            var allTestControllerActions = SitkaController.GetAllControllerActionMethods(typeof(MyAbstractBaseController));
            RouteTableBuilder.Build(allTestControllerActions, null, new Dictionary<string, string>());
        }

        private static void AssertUrlBuilderMatches<T>(Expression<Action<T>> expression, string expectedUrl, string message) where T : Controller
        {
            string ourRoute = String.Empty;
            Assert.DoesNotThrow(() => ourRoute = SitkaRoute<T>.BuildUrlFromExpression(expression), string.Format("Should work but failed while calculating route {0}", expectedUrl));
            Assert.That(ourRoute, Is.EqualTo(expectedUrl), "Routes don't match - " + message);
        }

        // ReSharper disable UnusedMember.Local
        // ReSharper disable UnusedParameter.Local
        private class RouteTableBuilderTestController
        {
            public ActionResult TestAction1()
            {
                return null;
            }

            public ActionResult TestAction2(int a)
            {
                return null;
            }

            public ActionResult TestAction3(int? a)
            {
                return null;
            }

            public ActionResult TestAction4(string b)
            {
                return null;
            }

            public ActionResult TestAction5(int a, string b)
            {
                return null;
            }

            public ActionResult TestAction6(int a, int? b, string c)
            {
                return null;
            }
        }

        private class RouteTableBuilderTestNullFirstController
        {
            public ActionResult TestActionNoNullsFirst(int? a, int b)
            {
                return null;
            }
        }

        private class RouteTableBuilderTestNullInMiddleController
        {
            public ActionResult TestActionNoNullsBeforeNonNulls(int a, int? b, int c)
            {
                return null;
            }
        }

        private class RouteTableBuilderTestNullStringFirstIsOkayController
        {
            public ActionResult TestActionNoNullsBeforeNonNulls(int a, String b, int c)
            {
                return null;
            }
        }

        // ReSharper restore UnusedParameter.Local
        // ReSharper restore UnusedMember.Local
    }
}
