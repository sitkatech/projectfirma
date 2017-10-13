/*-----------------------------------------------------------------------
<copyright file="ProjectMapPopupViewData.cs" company="Tahoe Regional Planning Agency">
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

using System.Collections;
using System.Collections.Generic;
using ProjectFirma.Web.Models;

namespace ProjectFirma.Web.Views.Shared.ProjectLocationControls
{
    public class ProjectMapPopupViewData : FirmaUserControlViewData
    {
        public readonly Models.Project Project;
        public readonly string TaxonomyTierThreeDisplayName;
        public readonly string TaxonomyTierTwoDisplayName;
        public readonly string TaxonomyTierOneDisplayName;
        public readonly string ClassificationDisplayNamePluralized;

        public string DisplayName { get; set; }
        public Models.ProjectImage KeyPhoto { get; set; }
        public string Duration { get; set; }
        public ProjectStage ProjectStage { get; set; }
        public Models.TaxonomyTierOne TaxonomyTierOne { get; set; }
        public decimal? EstimatedTotalCost { get; set; }
        public ICollection<ProjectClassification> ProjectClassifications { get; set; }
        public string DetailUrl { get; set; }

        public ProjectMapPopupViewData(Models.Project project)
        {
            Project = project;
            DisplayName = project.DisplayName;
            KeyPhoto = project.KeyPhoto;
            Duration = project.Duration;
            ProjectStage = project.ProjectStage;
            TaxonomyTierOne = project.TaxonomyTierOne;
            EstimatedTotalCost = project.EstimatedTotalCost;
            ProjectClassifications = project.ProjectClassifications;
            DetailUrl = project.GetDetailUrl();

            TaxonomyTierThreeDisplayName = Models.FieldDefinition.TaxonomyTierThree.GetFieldDefinitionLabel();
            TaxonomyTierTwoDisplayName = Models.FieldDefinition.TaxonomyTierTwo.GetFieldDefinitionLabel();
            TaxonomyTierOneDisplayName = Models.FieldDefinition.TaxonomyTierOne.GetFieldDefinitionLabel();
            ClassificationDisplayNamePluralized = Models.FieldDefinition.Classification.GetFieldDefinitionLabelPluralized();
        }

        public ProjectMapPopupViewData(Models.ProposedProject proposedProject) { }
       
    }
}
