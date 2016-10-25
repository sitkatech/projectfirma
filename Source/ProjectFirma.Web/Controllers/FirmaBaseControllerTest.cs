using System;
using System.Collections.Generic;
using System.Linq;
using LtInfo.Common.EntityModelBinding;
using NUnit.Framework;

namespace ProjectFirma.Web.Controllers
{
    [TestFixture]
    public class FirmaBaseControllerTest
    {
        [Test]
        [Description("Controller Actions should prefer using the primary key types as possible")]
        public void GivenControllerActionWhenHasIntegerIDParameterThenPreferPrimaryKeyObject()
        {
            var methods = FirmaBaseController.AllControllerActionMethods;
            var missing =
                methods.Where(
                    x =>
                        x.GetParameters()
                            .Any(
                                p =>
                                    new[] {typeof(byte), typeof(Int16), typeof(Int32), typeof(Int64)}.Contains(p.ParameterType) && p.Name.ToLower().Contains("id") && !p.Name.ToLower().Contains("guid")))
                    .ToList();
            var exceptions = new List<string>
            {
                "SampleControllerToExclude.SampleControllerAction",
                "FileResourceController.GetFileResourceResized",
                "FieldDefinitionController.Edit",
                "FieldDefinitionController.FieldDefinitionDetails",
                "FirmaPageController.FirmaPageDetails",
                "ResultsController.SpendingBySectorByOrganization",
                "ResultsController.SpendingBySectorByOrganizationExcelDownload",
                "IndicatorController.SaveChartConfiguration",
                "RoleController.Summary",
                "RoleController.PersonWithRoleGridJsonData",
            };
            var missingHumanReadable = missing.Select(x => String.Format("{0}.{1}", x.ReflectedType.Name, x.Name)).Where(x => !exceptions.Contains(x)).ToList();
            Assert.That(missingHumanReadable,
                Is.Empty,
                string.Format(
                    "Some controller actions methods may be using intergral data types for ID fields, consider using one of the types derived from \"{0}\" instead or add an exception to this test",
                    typeof(LtInfoEntityPrimaryKey<>)));
        }
    }
}