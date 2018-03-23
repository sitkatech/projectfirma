/*-----------------------------------------------------------------------
<copyright file="ProjectLocationFilterTypeTest.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
Copyright (c) Tahoe Regional Planning Agency and Sitka Technology Group. All rights reserved.
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
            var project = Project.CreateNewBlank(
                TaxonomyLeaf.CreateNewBlank(TaxonomyTierTwo.CreateNewBlank(TaxonomyTierThree.CreateNewBlank())),
                ProjectStage.Completed,
                ProjectLocationSimpleType.None,
                FundingType.Capital,
                // TODO: Verify that "Approved" is the correct project state or use the correct value
                ProjectApprovalStatus.Approved);

            project.ProjectLocationPoint = DbGeometry.PointFromText("POINT(29.11 40.11)", 4326);

            var feature = Project.MappedPointsToGeoJsonFeatureCollection(new List<IMappableProject> {project}, true).Features.First();

            foreach (var plft in ProjectLocationFilterType.All)
            {
                Assert.That(feature.Properties.ContainsKey(plft.ProjectLocationFilterTypeNameWithIdentifier),
                    "ProjectLocationFilterType {0} not present as a property of Project.",
                    plft.ProjectLocationFilterTypeNameWithIdentifier);
            }
        }
    }
}
