/*-----------------------------------------------------------------------
<copyright file="ProjectTaxonomyViewData.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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
using System.Linq;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Views.Shared.ProjectControls
{
    public class ProjectTaxonomyViewData : FirmaUserControlViewData
    {
        public readonly Models.TaxonomyTrunk TaxonomyTrunk;
        public readonly Models.TaxonomyTierTwo TaxonomyTierTwo;
        public readonly Models.TaxonomyLeaf TaxonomyLeaf;
        public readonly Models.Project Project;

        public readonly bool IsProject;
        public readonly bool IsTaxonomyLeaf;
        public readonly bool IsTaxonomyTierTwo;
        public readonly bool IsTaxonomyTrunk;

        public ProjectTaxonomyViewData(Models.TaxonomyTrunk taxonomyTrunk) : this(taxonomyTrunk, null, null, null)
        {
        }

        public ProjectTaxonomyViewData(Models.TaxonomyTierTwo taxonomyTierTwo) : this(taxonomyTierTwo.TaxonomyTrunk, taxonomyTierTwo, null, null)
        {
        }

        public ProjectTaxonomyViewData(Models.TaxonomyLeaf taxonomyLeaf) : this(taxonomyLeaf.TaxonomyTierTwo.TaxonomyTrunk, taxonomyLeaf.TaxonomyTierTwo, taxonomyLeaf, null)
        {
        }

        public ProjectTaxonomyViewData(Models.Project project) : this(project.TaxonomyLeaf.TaxonomyTierTwo.TaxonomyTrunk, project.TaxonomyLeaf.TaxonomyTierTwo, project.TaxonomyLeaf, project)
        {
        }

        private ProjectTaxonomyViewData(Models.TaxonomyTrunk taxonomyTrunk, Models.TaxonomyTierTwo taxonomyTierTwo, Models.TaxonomyLeaf taxonomyLeaf, Models.Project project)
        {
            TaxonomyLeaf = taxonomyLeaf;
            TaxonomyTrunk = taxonomyTrunk;
            TaxonomyTierTwo = taxonomyTierTwo;
            Project = project;
            IsProject = Project != null;
            IsTaxonomyLeaf = TaxonomyLeaf != null && !IsProject;
            IsTaxonomyTierTwo = TaxonomyTierTwo != null && !IsTaxonomyLeaf && !IsProject;
            IsTaxonomyTrunk = TaxonomyTrunk != null && !IsTaxonomyTierTwo && !IsTaxonomyLeaf && !IsProject;

            if (HttpRequestStorage.DatabaseEntities.TaxonomyTrunks.Count() <= 1 && !IsTaxonomyTrunk)
            {
                TaxonomyTrunk = null;
            }
        }
    }
}
