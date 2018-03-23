/*-----------------------------------------------------------------------
<copyright file="ProjectMapPopupViewData.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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
using System.Linq;
using MoreLinq;
using ProjectFirma.Web.Models;

namespace ProjectFirma.Web.Views.Shared.ProjectLocationControls
{
    public class ProjectMapPopupViewData : FirmaUserControlViewData
    {
        public readonly string DetailLinkDescriptor;

        public string TaxonomyTierThreeDisplayName { get; private set; }
        public string TaxonomyTierTwoDisplayName { get; private set; }
        public string TaxonomyLeafDisplayName { get; private set; }
        public string ClassificationDisplayNamePluralized { get; private set; }

        public string DisplayName { get; set; }
        public Models.ProjectImage KeyPhoto { get; set; }
        public string Duration { get; set; }
        public ProjectStage ProjectStage { get; set; }
        public Models.TaxonomyLeaf TaxonomyLeaf { get; set; }
        public decimal? EstimatedTotalCost { get; set; }
        public Dictionary<Models.ClassificationSystem, string> ClassificationsBySystem { get; set; }
        public string DetailUrl { get; set; }

        public ProjectMapPopupViewData(Models.Project project)
        {
            //Project = project;
            DisplayName = project.DisplayName;
            KeyPhoto = project.KeyPhoto;
            Duration = project.Duration;
            ProjectStage = project.ProjectStage;
            TaxonomyLeaf = project.TaxonomyLeaf;
            EstimatedTotalCost = project.EstimatedTotalCost;
            
            var dict = new Dictionary<Models.ClassificationSystem, string>();
            project.ProjectClassifications.Select(x => x.Classification.ClassificationSystem).Distinct().ForEach(
                x => dict.Add(x, string.Join(", ", project.ProjectClassifications.Select(y => y.Classification).Where(y => y.ClassificationSystem == x).Select(y => y.DisplayName).ToList())));
            ClassificationsBySystem = dict;

            DetailUrl = project.GetDetailUrl();
            DetailLinkDescriptor = project.IsProposal() ? "This project is a proposal. For description and expected results, see" : "For project expenditures & results, see";
            InitializeDisplayNames();
        }

        private void InitializeDisplayNames()
        {
            TaxonomyTierThreeDisplayName = Models.FieldDefinition.TaxonomyTierThree.GetFieldDefinitionLabel();
            TaxonomyTierTwoDisplayName = Models.FieldDefinition.TaxonomyTierTwo.GetFieldDefinitionLabel();
            TaxonomyLeafDisplayName = Models.FieldDefinition.TaxonomyLeaf.GetFieldDefinitionLabel();
            ClassificationDisplayNamePluralized = Models.FieldDefinition.Classification.GetFieldDefinitionLabelPluralized();
        }
    }
}
