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
        public readonly Models.TaxonomyTierThree TaxonomyTierThree;
        public readonly Models.TaxonomyTierTwo TaxonomyTierTwo;
        public readonly Models.TaxonomyLeaf TaxonomyLeaf;
        public readonly Models.Project Project;

        public readonly bool IsProject;
        public readonly bool IsTaxonomyLeaf;
        public readonly bool IsTaxonomyTierTwo;
        public readonly bool IsTaxonomyTierThree;

        public ProjectTaxonomyViewData(Models.TaxonomyTierThree taxonomyTierThree) : this(taxonomyTierThree, null, null, null)
        {
        }

        public ProjectTaxonomyViewData(Models.TaxonomyTierTwo taxonomyTierTwo) : this(taxonomyTierTwo.TaxonomyTierThree, taxonomyTierTwo, null, null)
        {
        }

        public ProjectTaxonomyViewData(Models.TaxonomyLeaf taxonomyLeaf) : this(taxonomyLeaf.TaxonomyTierTwo.TaxonomyTierThree, taxonomyLeaf.TaxonomyTierTwo, taxonomyLeaf, null)
        {
        }

        public ProjectTaxonomyViewData(Models.Project project) : this(project.TaxonomyLeaf.TaxonomyTierTwo.TaxonomyTierThree, project.TaxonomyLeaf.TaxonomyTierTwo, project.TaxonomyLeaf, project)
        {
        }

        private ProjectTaxonomyViewData(Models.TaxonomyTierThree taxonomyTierThree, Models.TaxonomyTierTwo taxonomyTierTwo, Models.TaxonomyLeaf taxonomyLeaf, Models.Project project)
        {
            TaxonomyLeaf = taxonomyLeaf;
            TaxonomyTierThree = taxonomyTierThree;
            TaxonomyTierTwo = taxonomyTierTwo;
            Project = project;
            IsProject = Project != null;
            IsTaxonomyLeaf = TaxonomyLeaf != null && !IsProject;
            IsTaxonomyTierTwo = TaxonomyTierTwo != null && !IsTaxonomyLeaf && !IsProject;
            IsTaxonomyTierThree = TaxonomyTierThree != null && !IsTaxonomyTierTwo && !IsTaxonomyLeaf && !IsProject;

            if (HttpRequestStorage.DatabaseEntities.TaxonomyTierThrees.Count() <= 1 && !IsTaxonomyTierThree)
            {
                TaxonomyTierThree = null;
            }
        }
    }
}
