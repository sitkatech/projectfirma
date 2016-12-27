using System.Collections.Generic;
using System.Data.Entity.Spatial;
using System.Linq;
using NUnit.Framework;

namespace ProjectFirma.Web.Models
{
    [TestFixture]
    public class ProjectLocationFilterTypeTest
    {
        [Test]
        public void TestProjectLocationFilterTypesAddedAsProjectProperties()
        {
            var project = Project.CreateNewBlank(TaxonomyTierOne.CreateNewBlank(TaxonomyTierTwo.CreateNewBlank(TaxonomyTierThree.CreateNewBlank())),
                ProjectStage.Completed,
                ProjectLocationSimpleType.None,
                FundingType.Capital);

            project.ProjectLocationPoint = DbGeometry.PointFromText("POINT(29.11 40.11)", 4326);

            var feature = Project.MappedPointsToGeoJsonFeatureCollection(new List<Project> {project}, true).Features.First();

            foreach (var plft in ProjectLocationFilterType.All)
            {
                Assert.That(feature.Properties.ContainsKey(plft.ProjectLocationFilterTypeNameWithIdentifier),
                    "ProjectLocationFilterType {0} not present as a property of Project.",
                    plft.ProjectLocationFilterTypeNameWithIdentifier);
            }
        }
    }
}