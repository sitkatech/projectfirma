/*-----------------------------------------------------------------------
<copyright file="FactSheetViewData.cs" company="Tahoe Regional Planning Agency">
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
using System.Web;
using LtInfo.Common;
using ProjectFirmaModels.Models;
using ProjectFirma.Web.Views.Map;
using ProjectFirma.Web.Views.Shared;
using LtInfo.Common.Models;
using LtInfo.Common.Views;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Controllers;
using ProjectFirma.Web.Views.Shared.SortOrder;
using ProjectFirma.Web.Models;

namespace ProjectFirma.Web.Views.Project
{
    public class ForwardLookingFactSheetViewData : ProjectViewData
    {
        public List<IGrouping<ProjectFirmaModels.Models.PerformanceMeasure, PerformanceMeasureExpected>> PerformanceMeasureExpectedValues { get; }
        public List<GooglePieChartSlice> FundingSourceRequestAmountGooglePieChartSlices { get; }
        public ProjectFirmaModels.Models.ProjectImage KeyPhoto { get; }
        public List<IGrouping<ProjectImageTiming, ProjectFirmaModels.Models.ProjectImage>> ProjectImagesExceptKeyPhotoGroupedByTiming { get; }
        public int ProjectImagesPerTimingGroup { get; }
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
        public string FactSheetPdfUrl { get; }

        public string TaxonomyColor { get; }
        public string TaxonomyLeafDisplayName { get; }
        public string TaxonomyLeafName { get; }
        public string TaxonomyBranchName { get; }
        public ViewPageContentViewData CustomFactSheetTextViewData { get; }
        public List<TechnicalAssistanceParameter> TechnicalAssistanceParameters { get; }
        public List<ProjectFirmaModels.Models.TechnicalAssistanceRequest> TechnicalAssistanceRequests { get; }
        public List<ProjectCustomAttribute> ViewableProjectCustomAttributes { get; }
        public List<ProjectFirmaModels.Models.ProjectCustomAttributeType> ViewableProjectCustomAttributeTypes { get; }


        public ForwardLookingFactSheetViewData(Person currentPerson,
            ProjectFirmaModels.Models.Project project,
            ProjectLocationSummaryMapInitJson projectLocationSummaryMapInitJson,
            GoogleChartJson googleChartJson,
            List<GooglePieChartSlice> fundingSourceRequestAmountGooglePieChartSlices, 
            ProjectFirmaModels.Models.FirmaPage firmaPageFactSheetCustomText,
            List<TechnicalAssistanceParameter> technicalAssistanceParameters) : base(currentPerson, project)
        {
            PageTitle = project.GetDisplayName();
            BreadCrumbTitle = "Fact Sheet";

            PerformanceMeasureExpectedValues = project.PerformanceMeasureExpecteds.GroupBy(x => x.PerformanceMeasure, new HavePrimaryKeyComparer<ProjectFirmaModels.Models.PerformanceMeasure>())
                .OrderBy(x=>x.Key.PerformanceMeasureSortOrder).ThenBy(x => x.Key.PerformanceMeasureDisplayName).ToList();

            KeyPhoto = project.GetKeyPhoto();
            ProjectImagesExceptKeyPhotoGroupedByTiming = project.ProjectImages.Where(x => !x.IsKeyPhoto && x.ProjectImageTiming != ProjectImageTiming.Unknown && !x.ExcludeFromFactSheet)
                .GroupBy(x => x.ProjectImageTiming).OrderBy(x => x.Key.SortOrder).ToList();
            ProjectImagesPerTimingGroup = ProjectImagesExceptKeyPhotoGroupedByTiming.Count == 1 ? 6 : 2;
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
            FactSheetPdfUrl = SitkaRoute<ProjectController>.BuildUrlFromExpression(c => c.FactSheetPdf(project));

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
            TechnicalAssistanceParameters = technicalAssistanceParameters;
            TechnicalAssistanceRequests = project.TechnicalAssistanceRequests.ToList();

            ViewableProjectCustomAttributes = project.ProjectCustomAttributes.Where(x => x.ProjectCustomAttributeType.HasViewPermission(currentPerson)).ToList();
            ViewableProjectCustomAttributeTypes = HttpRequestStorage.DatabaseEntities.ProjectCustomAttributeTypes.ToList().Where(x => x.HasViewPermission(currentPerson) && x.IsViewableOnFactSheet).ToList();
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
