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
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Views.Map;
using ProjectFirma.Web.Views.Shared;
using LtInfo.Common.Models;
using LtInfo.Common.Views;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Controllers;
using ProjectFirma.Web.Views.Shared.SortOrder;

namespace ProjectFirma.Web.Views.Project
{
    public class ForwardLookingFactSheetViewData : ProjectViewData
    {
        public List<IGrouping<Models.PerformanceMeasure, PerformanceMeasureExpected>> PerformanceMeasureExpectedValues { get; }
        public List<GooglePieChartSlice> FundingSourceRequestAmountGooglePieChartSlices { get; }
        public Models.ProjectImage KeyPhoto { get; }
        public List<IGrouping<ProjectImageTiming, Models.ProjectImage>> ProjectImagesExceptKeyPhotoGroupedByTiming { get; }
        public int ProjectImagesPerTimingGroup { get; }
        public List<Models.Classification> Classifications { get; }
        public ProjectLocationSummaryMapInitJson ProjectLocationSummaryMapInitJson { get; }
        public GoogleChartJson GoogleChartJson { get; }
        public string EstimatedTotalCost { get; }

        public string NoFundingSourceIdentified { get; }
        public string SecuredFunding { get; }
        public string UnsecuredFunding { get; }

        public string FundingRequest { get; }
        public int CalculatedChartHeight { get; }
        public string FactSheetPdfUrl { get; }

        public string TaxonomyColor { get; }
        public string TaxonomyLeafDisplayName { get; }
        public string TaxonomyLeafName { get; }
        public string TaxonomyBranchName { get; }

        public ViewPageContentViewData CustomFactSheetTextViewData { get; }


        public ForwardLookingFactSheetViewData(Person currentPerson,
            Models.Project project,
            ProjectLocationSummaryMapInitJson projectLocationSummaryMapInitJson,
            GoogleChartJson googleChartJson,
            List<GooglePieChartSlice> fundingSourceRequestAmountGooglePieChartSlices, Models.FirmaPage firmaPageFactSheetCustomText) : base(currentPerson, project)
        {
            PageTitle = project.DisplayName;
            BreadCrumbTitle = "Fact Sheet";

            PerformanceMeasureExpectedValues = project.PerformanceMeasureExpecteds.GroupBy(x => x.PerformanceMeasure, new HavePrimaryKeyComparer<Models.PerformanceMeasure>())
                .OrderBy(x=>x.Key.PerformanceMeasureSortOrder).ThenBy(x => x.Key.PerformanceMeasureDisplayName).ToList();

            KeyPhoto = project.KeyPhoto;
            ProjectImagesExceptKeyPhotoGroupedByTiming = project.ProjectImages.Where(x => !x.IsKeyPhoto && x.ProjectImageTiming != ProjectImageTiming.Unknown && !x.ExcludeFromFactSheet)
                .GroupBy(x => x.ProjectImageTiming).OrderBy(x => x.Key.SortOrder).ToList();
            ProjectImagesPerTimingGroup = ProjectImagesExceptKeyPhotoGroupedByTiming.Count == 1 ? 6 : 2;
            Classifications = project.ProjectClassifications.Select(x => x.Classification).ToList().SortByOrderThenName().ToList();

            ProjectLocationSummaryMapInitJson = projectLocationSummaryMapInitJson;
            GoogleChartJson = googleChartJson;
            FundingSourceRequestAmountGooglePieChartSlices = fundingSourceRequestAmountGooglePieChartSlices;

            //Dynamically resize chart based on how much space the legend requires
            CalculatedChartHeight = 350 - (FundingSourceRequestAmountGooglePieChartSlices.Count <= 2
                                        ? FundingSourceRequestAmountGooglePieChartSlices.Count * 24
                                        : FundingSourceRequestAmountGooglePieChartSlices.Count * 20);
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

            TaxonomyLeafName = project.TaxonomyLeaf == null ? $"{Models.FieldDefinition.Project.GetFieldDefinitionLabel()} Taxonomy Not Set" : project.TaxonomyLeaf.DisplayName;
            TaxonomyBranchName = project.TaxonomyLeaf == null ? $"{Models.FieldDefinition.Project.GetFieldDefinitionLabel()} Taxonomy Not Set" : project.TaxonomyLeaf.TaxonomyBranch.DisplayName;
            TaxonomyLeafDisplayName = Models.FieldDefinition.TaxonomyLeaf.GetFieldDefinitionLabel();
            EstimatedTotalCost = Project.EstimatedTotalCost.HasValue ? Project.EstimatedTotalCost.ToStringCurrency() : "";
            NoFundingSourceIdentified = project.GetNoFundingSourceIdentifiedAmount() != null ? Project.GetNoFundingSourceIdentifiedAmount().ToStringCurrency() : "";
            SecuredFunding = Project.GetSecuredFunding() != null ? Project.GetSecuredFunding().ToStringCurrency() : "";
            UnsecuredFunding = Project.GetUnsecuredFunding() != null ? Project.GetUnsecuredFunding().ToStringCurrency() : "";


            FundingRequest = project.ProjectFundingSourceRequests.Any() ? project.ProjectFundingSourceRequests.Sum(x => x.UnsecuredAmount).ToStringCurrency() : ViewUtilities.Unknown;
            CustomFactSheetTextViewData = new ViewPageContentViewData(firmaPageFactSheetCustomText, false);
        }

        public HtmlString LegendHtml
        {
            get
            {
                var legendHtml = "<div>";
                foreach (var googlePieChartSlice in FundingSourceRequestAmountGooglePieChartSlices.OrderBy(x => x.SortOrder))
                {
                    legendHtml += "<div class='chartLegendColorBox' style='display:inline-block; border: solid 6px " + googlePieChartSlice.Color + "'></div> ";
                    legendHtml += "<div style='display:inline-block' >" + googlePieChartSlice.Label + "</div>";
                    legendHtml += "<br>";
                }
                legendHtml += "</div>";
                return new HtmlString(legendHtml);
            }
        }
    }
}
