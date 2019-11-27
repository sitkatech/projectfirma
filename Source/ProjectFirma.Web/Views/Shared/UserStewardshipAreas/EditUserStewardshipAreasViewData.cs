/*-----------------------------------------------------------------------
<copyright file="EditUserStewardshipAreasViewData.cs" company="Tahoe Regional Planning Agency">
Copyright (c) Tahoe Regional Planning Agency. All rights reserved.
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
using System.Linq;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Views.Shared.UserStewardshipAreas
{
    public class EditUserStewardshipAreasViewData : FirmaViewData
    {
        
        public EditViewDataForAngular ViewDataForAngular { get; }

        public bool Standalone { get; }

        public EditUserStewardshipAreasViewData(FirmaSession currentFirmaSession, List<ProjectFirmaModels.Models.Organization> allOrganizations,  bool standalone)
            : base(currentFirmaSession)
        {
            ViewDataForAngular = new EditViewDataForAngular(allOrganizations);
            Standalone = standalone;
        }

        public EditUserStewardshipAreasViewData(FirmaSession currentFirmaSession, List<ProjectFirmaModels.Models.TaxonomyBranch> allTaxonomyBranches, bool standalone) : base(currentFirmaSession)
        {
            ViewDataForAngular = new EditViewDataForAngular(allTaxonomyBranches);
            Standalone = standalone;
        }
        public EditUserStewardshipAreasViewData(FirmaSession currentFirmaSession, List<ProjectFirmaModels.Models.GeospatialArea> allGeospatialAreas, bool standalone) : base(currentFirmaSession)
        {
            ViewDataForAngular = new EditViewDataForAngular(allGeospatialAreas);
            Standalone = standalone;
        }

        public class EditViewDataForAngular
        {
            public List<StewardshipAreaSimple> AllStewardshipAreas{ get; }

            public EditViewDataForAngular(List<ProjectFirmaModels.Models.Organization> allOrganizations)
            {
                AllStewardshipAreas = allOrganizations.OrderBy(x => x.GetDisplayName()).Select(x => new StewardshipAreaSimple(x)).ToList();
            }

            public EditViewDataForAngular(List<ProjectFirmaModels.Models.TaxonomyBranch> allTaxonomyBranches)
            {
                AllStewardshipAreas = allTaxonomyBranches.OrderBy(x => x.GetDisplayName()).Select(x => new StewardshipAreaSimple(x)).ToList();
            }
            public EditViewDataForAngular(List<ProjectFirmaModels.Models.GeospatialArea> allGeospatialAreas)
            {
                AllStewardshipAreas = allGeospatialAreas.OrderBy(x => x.GetDisplayName()).Select(x => new StewardshipAreaSimple(x)).ToList();
            }
        }
    }
}