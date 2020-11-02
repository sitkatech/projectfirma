/*-----------------------------------------------------------------------
<copyright file="IndexViewData.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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

using System;
using System.Collections.Generic;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Controllers;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.PartnerFinder;
using ProjectFirma.Web.Views.Map;
using ProjectFirma.Web.Views.Shared.ProjectLocationControls;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Views.ProjectFinder
{
    public class IndexViewData : FirmaViewData
    {
        public ProjectFinderGridSpec ProjectFinderGridSpec { get; }
        public string ProjectFinderGridName { get; }
        public string ProjectFinderGridDataUrl { get; }
        public ProjectFirmaModels.Models.Organization Organization { get; }
        public List<PartnerOrganizationMatchMakerScore> ProjectMatchMakerScoresForOrganization { get; }
        public ProjectLocationsMapInitJson ProjectLocationsMapInitJson { get; }
        public Dictionary<string, List<ProjectMapLegendElement>> LegendFormats { get; }

        public IndexViewData(FirmaSession currentFirmaSession, ProjectFirmaModels.Models.Organization organization,
            List<PartnerOrganizationMatchMakerScore> projectMatchmakerScoresForOrganization,
            ProjectFinderGridSpec projectFinderGridSpec, ProjectLocationsMapInitJson projectLocationsMapInitJson) : base(currentFirmaSession)
        {
            ContainerFluid = false;
            PageTitle = $"{FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabel()} Finder";
            ProjectFinderGridSpec = projectFinderGridSpec;
            ProjectFinderGridName = "projectFinderGrid";
            ProjectFinderGridDataUrl = SitkaRoute<ProjectFinderController>.BuildUrlFromExpression(tc => tc.ProjectFinderGridFullJsonData());
            Organization = organization;


            LegendFormats = ProjectMapLegendElement.BuildLegendFormatDictionary(MultiTenantHelpers.GetTopLevelTaxonomyTiers(), true);
            ProjectLocationsMapInitJson = projectLocationsMapInitJson;


        }
    }
}
