/*-----------------------------------------------------------------------
<copyright file="AddProjectEvaluationViewData.cs" company="Tahoe Regional Planning Agency">
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
using ProjectFirma.Web.Models;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Views.Evaluation
{

    public class AddProjectEvaluationViewData
    {
        public ProjectFirmaModels.Models.Evaluation Evaluation { get; }
        public AddProjectEvaluationViewDataForAngular ViewDataForAngular { get; }

        public AddProjectEvaluationViewData(AddProjectEvaluationViewDataForAngular viewDataForAngular, ProjectFirmaModels.Models.Evaluation evaluation)
        {
            Evaluation = evaluation;
            ViewDataForAngular = viewDataForAngular;

        }
    }

    public class AddProjectEvaluationViewDataForAngular
    {
        public List<TaxonomyTierSimple> TaxonomyTrunkSimples { get; set; }
        public List<TaxonomyTierSimple> TaxonomyBranchSimples { get; set; }
        public List<TaxonomyTierSimple> TaxonomyLeafSimples { get; set; }
        public List<ProjectSimple> ProjectSimples { get; set; }


        public AddProjectEvaluationViewDataForAngular(List<TaxonomyTierSimple> taxonomyTrunkSimples, List<TaxonomyTierSimple> taxonomyBranchSimples, List<TaxonomyTierSimple> taxonomyLeafSimples, List<ProjectSimple> projectSimples)
        {
            TaxonomyTrunkSimples = taxonomyTrunkSimples;
            TaxonomyBranchSimples = taxonomyBranchSimples;
            TaxonomyLeafSimples = taxonomyLeafSimples;
            ProjectSimples = projectSimples;
        }
    }
}
