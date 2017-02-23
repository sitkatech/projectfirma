/*-----------------------------------------------------------------------
<copyright file="ProjectMapViewDataTest.cs" company="Tahoe Regional Planning Agency">
Copyright (c) Tahoe Regional Planning Agency. All rights reserved.
<author>Sitka Technology Group</author>
<date>Wednesday, February 22, 2017</date>
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
using ApprovalTests;
using ApprovalTests.Reporters;
using ProjectFirma.Web.Views.Shared.ProjectLocationControls;
using ProjectFirma.Web.Models;
using Newtonsoft.Json.Linq;
using NUnit.Framework;

namespace ProjectFirma.Web.Views.Results
{
    [TestFixture]
    public class ProjectMapViewDataTest
    {
        [Test]
        [UseReporter(typeof(DiffReporter))]
        public void EnsureProjectMapCustomizationSignatureTest()
        {
            var projectLocationFilter = new ProjectMapCustomization(ProjectLocationFilterType.ProjectStage, new List<int> { 2, 3, 4 }, ProjectColorByType.ProjectStage);
            Approvals.Verify(JObject.FromObject(projectLocationFilter));
        }
    }
}
