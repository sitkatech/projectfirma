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
using LtInfo.Common;
using LtInfo.Common.Models;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Security;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Views.Shared.ProjectLocationControls
{
    public class ProjectMapPopupViewData : FirmaUserControlViewData
    {
        public readonly string DetailLinkDescriptor;

        public string TaxonomyTrunkDisplayName { get; private set; }
        public string TaxonomyBranchDisplayName { get; private set; }
        public string TaxonomyLeafDisplayName { get; private set; }
        public string ClassificationDisplayNamePluralized { get; private set; }

        public string DisplayName { get; set; }
        public ProjectFirmaModels.Models.ProjectImage KeyPhoto { get; set; }
        public string Duration { get; set; }
        public ProjectStage ProjectStage { get; set; }
        public ProjectFirmaModels.Models.TaxonomyLeaf TaxonomyLeaf { get; set; }
        public string EstimatedTotalCost { get; set; }
        public Dictionary<ProjectFirmaModels.Models.ClassificationSystem, string> ClassificationsBySystem { get; set; }
        public string FactSheetUrl { get; set; }
        public string ProjectUrl { get; set; }
        public TaxonomyLevel TaxonomyLevel { get; }

        public bool ShowDetailedInformation { get; }
        public bool OfferFactSheetLink { get; }

        public ProjectMapPopupViewData(FirmaSession currentFirmaSession, ProjectFirmaModels.Models.Project project, bool showDetailedInformation)
        {
            //Project = project;
            DisplayName = project.GetDisplayName();
            ProjectUrl = project.GetDetailUrl();
            KeyPhoto = project.GetKeyPhoto();
            Duration = project.GetDuration();
            ProjectStage = project.ProjectStage;
            TaxonomyLeaf = project.TaxonomyLeaf;
            EstimatedTotalCost = project.GetEstimatedTotalRegardlessOfFundingType().HasValue ? project.GetEstimatedTotalRegardlessOfFundingType().ToStringCurrency() : "Unknown";
            
            var dict = new Dictionary<ProjectFirmaModels.Models.ClassificationSystem, string>();
            project.ProjectClassifications.Select(x => x.Classification.ClassificationSystem).Distinct(new HavePrimaryKeyComparer<ProjectFirmaModels.Models.ClassificationSystem>()).ToList().ForEach(x => dict.Add(x, string.Join(", ", project.ProjectClassifications.Select(y => y.Classification).Where(y => y.ClassificationSystem == x).Select(y => y.GetDisplayName()).ToList())));
            ClassificationsBySystem = dict;

            OfferFactSheetLink = OfferProjectFactSheetLinkFeature.OfferProjectFactSheetLink(currentFirmaSession, project);
            FactSheetUrl = project.GetFactSheetUrl();
            DetailLinkDescriptor = project.IsProposal() ? $"This {FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabel()} is a proposal. For description and expected results, see the" : $"For {FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabel()} expenditures & results, see the";
            InitializeDisplayNames();
            TaxonomyLevel = MultiTenantHelpers.GetTaxonomyLevel();

            ShowDetailedInformation = showDetailedInformation;
        }

        private void InitializeDisplayNames()
        {
            TaxonomyTrunkDisplayName = FieldDefinitionEnum.TaxonomyTrunk.ToType().GetFieldDefinitionLabel();
            TaxonomyBranchDisplayName = FieldDefinitionEnum.TaxonomyBranch.ToType().GetFieldDefinitionLabel();
            TaxonomyLeafDisplayName = FieldDefinitionEnum.TaxonomyLeaf.ToType().GetFieldDefinitionLabel();
            ClassificationDisplayNamePluralized = FieldDefinitionEnum.Classification.ToType().GetFieldDefinitionLabelPluralized();
        }
    }
}
