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
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Views.Shared.ProjectControls
{
    public class ProjectTaxonomyViewData : FirmaUserControlViewData
    {
        public ProjectFirmaModels.Models.TaxonomyTrunk TaxonomyTrunk { get; }
        public ProjectFirmaModels.Models.TaxonomyBranch TaxonomyBranch { get; }
        public ProjectFirmaModels.Models.TaxonomyLeaf TaxonomyLeaf { get; }
        public ProjectFirmaModels.Models.Project Project { get; }

        public bool IsProject { get; }
        public bool IsTaxonomyLeaf { get; }
        public bool IsTaxonomyBranch { get; }
        public bool IsTaxonomyTrunk { get; }
        public TaxonomyLevel TaxonomyLevel { get; }

        public ProjectTaxonomyViewData(ProjectFirmaModels.Models.TaxonomyTrunk taxonomyTrunk, TaxonomyLevel taxonomyLevel) : this(taxonomyTrunk, null, null, null, taxonomyLevel)
        {
        }

        public ProjectTaxonomyViewData(ProjectFirmaModels.Models.TaxonomyBranch taxonomyBranch, TaxonomyLevel taxonomyLevel) : this(taxonomyBranch.TaxonomyTrunk, taxonomyBranch, null, null, taxonomyLevel)
        {
        }

        public ProjectTaxonomyViewData(ProjectFirmaModels.Models.TaxonomyLeaf taxonomyLeaf, TaxonomyLevel taxonomyLevel) : this(taxonomyLeaf.TaxonomyBranch.TaxonomyTrunk, taxonomyLeaf.TaxonomyBranch, taxonomyLeaf, null, taxonomyLevel)
        {
        }

        public ProjectTaxonomyViewData(ProjectFirmaModels.Models.Project project, TaxonomyLevel taxonomyLevel) : this(project.TaxonomyLeaf.TaxonomyBranch.TaxonomyTrunk, project.TaxonomyLeaf.TaxonomyBranch, project.TaxonomyLeaf, project, taxonomyLevel)
        {
        }

        private ProjectTaxonomyViewData(ProjectFirmaModels.Models.TaxonomyTrunk taxonomyTrunk, ProjectFirmaModels.Models.TaxonomyBranch taxonomyBranch, ProjectFirmaModels.Models.TaxonomyLeaf taxonomyLeaf, ProjectFirmaModels.Models.Project project, TaxonomyLevel taxonomyLevel)
        {
            TaxonomyLeaf = taxonomyLeaf;
            TaxonomyTrunk = taxonomyTrunk;
            TaxonomyBranch = taxonomyBranch;
            Project = project;
            IsProject = Project != null;
            IsTaxonomyLeaf = TaxonomyLeaf != null && !IsProject;
            IsTaxonomyBranch = TaxonomyBranch != null && !IsTaxonomyLeaf && !IsProject;
            IsTaxonomyTrunk = TaxonomyTrunk != null && !IsTaxonomyBranch && !IsTaxonomyLeaf && !IsProject;
            TaxonomyLevel = taxonomyLevel;
        }
    }
}
