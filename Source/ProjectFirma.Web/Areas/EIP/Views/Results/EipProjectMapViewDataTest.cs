using System.Collections.Generic;
using ApprovalTests;
using ApprovalTests.Reporters;
using ProjectFirma.Web.Areas.EIP.Views.Shared.ProjectLocationControls;
using ProjectFirma.Web.Models;
using Newtonsoft.Json.Linq;
using NUnit.Framework;

namespace ProjectFirma.Web.Areas.EIP.Views.Results
{
    [TestFixture]
    public class EipProjectMapViewDataTest
    {
        [Test]
        [UseReporter(typeof(DiffReporter))]
        public void EnsureProjectMapCustomizationSignatureTest()
        {
            var projectLocationFilter = new ProjectMapCustomization(ProjectLocationFilterType.FocusArea, new List<int> { 2, 3, 4 }, ProjectColorByType.ProjectStage);
            Approvals.Verify(JObject.FromObject(projectLocationFilter));
        }
    }
}