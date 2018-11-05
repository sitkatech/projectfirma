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
using ApprovalUtilities.Utilities;
using LtInfo.Common;
using MoreLinq;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;

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
        public Models.ProjectImage KeyPhoto { get; set; }
        public string Duration { get; set; }
        public ProjectStage ProjectStage { get; set; }
        public Models.TaxonomyLeaf TaxonomyLeaf { get; set; }
        public string EstimatedTotalCost { get; set; }
        public Dictionary<Models.ClassificationSystem, string> ClassificationsBySystem { get; set; }
        public string FactSheetUrl { get; set; }
        public TaxonomyLevel TaxonomyLevel { get; }

        public bool ShowDetailedInformation { get; }

        public ProjectMapPopupViewData(Models.Project project, bool showDetailedInformation)
        {
            //Project = project;
            DisplayName = project.DisplayName;
            KeyPhoto = project.KeyPhoto;
            Duration = project.Duration;
            ProjectStage = project.ProjectStage;
            TaxonomyLeaf = project.TaxonomyLeaf;
            EstimatedTotalCost = project.EstimatedTotalCost.HasValue ? project.EstimatedTotalCost.ToStringCurrency() : "Unknown";
            
            var dict = new Dictionary<Models.ClassificationSystem, string>();
            MoreEnumerable.ForEach(project.ProjectClassifications.Select(x => x.Classification.ClassificationSystem).Distinct(), x => dict.Add(x, string.Join(", ", project.ProjectClassifications.Select(y => y.Classification).Where(y => y.ClassificationSystem == x).Select(y => y.DisplayName).ToList())));
            ClassificationsBySystem = dict;

            FactSheetUrl = project.GetFactSheetUrl();
            DetailLinkDescriptor = project.IsProposal() ? $"This {Models.FieldDefinition.Project.GetFieldDefinitionLabel()} is a proposal. For description and expected results, see the" : $"For {Models.FieldDefinition.Project.GetFieldDefinitionLabel()} expenditures & results, see the";
            InitializeDisplayNames();
            TaxonomyLevel = MultiTenantHelpers.GetTaxonomyLevel();

            ShowDetailedInformation = showDetailedInformation;
        }

        private void InitializeDisplayNames()
        {
            TaxonomyTrunkDisplayName = Models.FieldDefinition.TaxonomyTrunk.GetFieldDefinitionLabel();
            TaxonomyBranchDisplayName = Models.FieldDefinition.TaxonomyBranch.GetFieldDefinitionLabel();
            TaxonomyLeafDisplayName = Models.FieldDefinition.TaxonomyLeaf.GetFieldDefinitionLabel();
            ClassificationDisplayNamePluralized = Models.FieldDefinition.Classification.GetFieldDefinitionLabelPluralized();
        }
    }
}
