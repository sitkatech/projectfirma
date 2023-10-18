﻿/*-----------------------------------------------------------------------
<copyright file="FactSheetViewData.cs" company="Tahoe Regional Planning Agency">
Copyright (c) Tahoe Regional Planning Agency. All rights reserved.
<author>Environmental Science Associates</author>
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
using System.Linq;
using System.Web;
using LtInfo.Common;
using ProjectFirmaModels.Models;
using ProjectFirma.Web.Views.Map;
using ProjectFirma.Web.Views.Shared;
using LtInfo.Common.Models;
using LtInfo.Common.Views;
using MoreLinq;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Controllers;
using ProjectFirma.Web.Views.Shared.SortOrder;
using ProjectFirma.Web.Models;

namespace ProjectFirma.Web.Views.Project
{
    public class ForwardLookingFactSheetViewData : ProjectViewData
    {
        /// <summary>
        /// We hope this is enough time to allow the mapping components to load. Increase if map components don't render properly in PDF.
        /// </summary>
        public static int FactSheetPdfEmptyImageLoadDelayInMilliseconds = 4000;

        public List<IGrouping<ProjectFirmaModels.Models.PerformanceMeasure, PerformanceMeasureExpected>> PerformanceMeasureExpectedValues { get; }
        public List<GooglePieChartSlice> FundingSourceRequestAmountGooglePieChartSlices { get; }
        public ProjectFirmaModels.Models.ProjectImage KeyPhoto { get; }
        public List<ProjectFirmaModels.Models.ProjectImage> ProjectImages { get; }

        public List<ProjectFirmaModels.Models.Classification> Classifications { get; }
        public ProjectLocationSummaryMapInitJson ProjectLocationSummaryMapInitJson { get; }
        public GoogleChartJson GoogleChartJson { get; }
        public string EstimatedTotalCost { get; }

        public string EstimatedTotalCostLabel { get; }
        public string NoFundingSourceIdentifiedLabel { get; }
        public string NoFundingSourceIdentified { get; }
        public string SecuredFunding { get; }
        public string TargetedFundingLabel { get; }
        public string TargetedFunding { get; }

        public string FundingBudget { get; }
        public int CalculatedChartHeight { get; }
        public bool WithCustomAttributes { get; }

        public string TaxonomyColor { get; }
        public string TaxonomyLeafDisplayName { get; }
        public string TaxonomyLeafName { get; }
        public string TaxonomyBranchName { get; }
        public ViewPageContentViewData CustomFactSheetTextViewData { get; }
        public List<ProjectCustomAttribute> ViewableProjectCustomAttributes { get; }
        public List<ProjectFirmaModels.Models.ProjectCustomAttributeType> ViewableProjectCustomAttributeTypes { get; }
        public DateTime LastUpdated { get; }

        public ProjectController.FactSheetPdfEnum FactSheetPdfEnum { get; }

        public bool ProjectLocationIsProvided { get; }

        public ProjectFirmaModels.Models.ProjectAttachment QuickAccessAttachment { get; }

        public ForwardLookingFactSheetViewData(FirmaSession currentFirmaSession,
            ProjectFirmaModels.Models.Project project,
            ProjectLocationSummaryMapInitJson projectLocationSummaryMapInitJson,
            GoogleChartJson googleChartJson,
            List<GooglePieChartSlice> fundingSourceRequestAmountGooglePieChartSlices, 
            ProjectFirmaModels.Models.FirmaPage firmaPageFactSheetCustomText,
            bool withCustomAttributes,
            ProjectController.FactSheetPdfEnum factSheetPdfEnum) : base(currentFirmaSession, project)
        {
            PageTitle = project.GetDisplayName();
            BreadCrumbTitle = "Fact Sheet";

            PerformanceMeasureExpectedValues = project.PerformanceMeasureExpecteds.GroupBy(x => x.PerformanceMeasure, new HavePrimaryKeyComparer<ProjectFirmaModels.Models.PerformanceMeasure>())
                .OrderBy(x=>x.Key.PerformanceMeasureSortOrder).ThenBy(x => x.Key.PerformanceMeasureDisplayName).ToList();

            KeyPhoto = project.GetKeyPhoto();
            ProjectImages = project.ProjectImages.Where(x => x.IncludeInFactSheet && !x.IsKeyPhoto).ToList().OrderBy(x => x.ProjectImageTiming.SortOrder).ThenBy(x => x.FileResourceInfo.GetOrientation()).ToList();

            Classifications = project.ProjectClassifications.Select(x => x.Classification).ToList().SortByOrderThenName().ToList();

            ProjectLocationSummaryMapInitJson = projectLocationSummaryMapInitJson;
            GoogleChartJson = googleChartJson;
            FundingSourceRequestAmountGooglePieChartSlices = fundingSourceRequestAmountGooglePieChartSlices;

            var labelUsesFullDisplayName = FundingSourceRequestAmountGooglePieChartSlices.Count <= 2 || 
                                           FundingSourceRequestAmountGooglePieChartSlices.Count <=3 && fundingSourceRequestAmountGooglePieChartSlices.Any(x => x.Label.Equals(FieldDefinitionEnum.NoFundingSourceIdentified.ToType().GetFieldDefinitionLabel()));
            //Dynamically resize chart based on how much space the legend requires

            CalculatedChartHeight = 400 - (labelUsesFullDisplayName
                                        ? FundingSourceRequestAmountGooglePieChartSlices.Count * 52
                                        : FundingSourceRequestAmountGooglePieChartSlices.Count * 18);

            if (project.TaxonomyLeaf == null)
            {
                TaxonomyColor = "blue";
            }
            else
            {
                switch (MultiTenantHelpers.GetTaxonomyLevel().ToEnum)
                {
                    case TaxonomyLevelEnum.Leaf:
                        TaxonomyColor = project.TaxonomyLeaf.ThemeColor;
                        break;
                    case TaxonomyLevelEnum.Branch:
                        TaxonomyColor = project.TaxonomyLeaf.TaxonomyBranch.ThemeColor;
                        break;
                    case TaxonomyLevelEnum.Trunk:
                        TaxonomyColor = project.TaxonomyLeaf.TaxonomyBranch.TaxonomyTrunk.ThemeColor;
                        break;
                }
            }

            TaxonomyLeafName = project.TaxonomyLeaf == null ? $"{FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabel()} Taxonomy Not Set" : project.TaxonomyLeaf.GetDisplayName();
            TaxonomyBranchName = project.TaxonomyLeaf == null ? $"{FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabel()} Taxonomy Not Set" : project.TaxonomyLeaf.TaxonomyBranch.GetDisplayName();
            TaxonomyLeafDisplayName = FieldDefinitionEnum.TaxonomyLeaf.ToType().GetFieldDefinitionLabel();

            EstimatedTotalCost = Project.GetEstimatedTotalRegardlessOfFundingType().HasValue ? Project.GetEstimatedTotalRegardlessOfFundingType().ToStringCurrency() : "";
            EstimatedTotalCostLabel =
                Project.FundingTypeID.HasValue && Project.FundingType.ToEnum == FundingTypeEnum.BudgetSameEachYear
                    ? FieldDefinitionEnum.EstimatedAnnualOperatingCost.ToType().GetFieldDefinitionLabel()
                    : FieldDefinitionEnum.EstimatedTotalCost.ToType().GetFieldDefinitionLabel();
            NoFundingSourceIdentifiedLabel = FieldDefinitionEnum.NoFundingSourceIdentified.ToType().GetFieldDefinitionLabel();
            NoFundingSourceIdentified = project.GetNoFundingSourceIdentifiedAmount() != null ? Project.GetNoFundingSourceIdentifiedAmount().ToStringCurrency() : "";
            SecuredFunding = Project.GetSecuredFunding().ToStringCurrency();
            TargetedFundingLabel = FieldDefinitionEnum.TargetedFunding.ToType().GetFieldDefinitionLabel();
            TargetedFunding = Project.GetTargetedFunding().ToStringCurrency();

            FundingBudget = project.ProjectFundingSourceBudgets.Any() ? project.ProjectFundingSourceBudgets.Sum(x => x.TargetedAmount).ToStringCurrency() : ViewUtilities.Unknown;
            CustomFactSheetTextViewData = new ViewPageContentViewData(firmaPageFactSheetCustomText, false);

            ViewableProjectCustomAttributeTypes = HttpRequestStorage.DatabaseEntities.ProjectCustomAttributeTypes.ToList().Where(x => x.HasViewPermission(currentFirmaSession) && x.IsViewableOnFactSheet).ToList();
            ViewableProjectCustomAttributes = project.ProjectCustomAttributes.Where(x => x.ProjectCustomAttributeType.HasViewPermission(currentFirmaSession) && ViewableProjectCustomAttributeTypes.Contains(x.ProjectCustomAttributeType)).ToList();
            
            WithCustomAttributes = withCustomAttributes;
            LastUpdated = project.LastUpdatedDate;
            FactSheetPdfEnum = factSheetPdfEnum;

            ProjectLocationIsProvided = project.ProjectLocationPoint != null || project.ProjectLocations.Any();

            QuickAccessAttachment =
                project.ProjectAttachments.SingleOrDefault(x => x.AttachmentType.IsQuickAccessAttachment && x.AttachmentType.HasViewPermission(currentFirmaSession));
        }

        public HtmlString LegendHtml
        {
            get
            {
                var legendHtml = "<div>";
                foreach (var googlePieChartSlice in FundingSourceRequestAmountGooglePieChartSlices.OrderBy(x => x.SortOrder))
                {
                    legendHtml += "<div class='chartLegendColorBox' style='display:inline-block; border: solid 6px " + googlePieChartSlice.Color + "'></div> ";
                    legendHtml += "<div style='display:inline-block' >" + googlePieChartSlice.Value.ToStringCurrency() + " " + googlePieChartSlice.Label + "</div>";
                    legendHtml += "<br>";
                }
                legendHtml += "</div>";
                return new HtmlString(legendHtml);
            }
        }
    }
}
