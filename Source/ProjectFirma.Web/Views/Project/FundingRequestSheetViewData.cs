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
using ProjectFirma.Web.Views.Shared.ProjectLocationControls;
using LtInfo.Common.Models;

namespace ProjectFirma.Web.Views.Project
{
    public class FundingRequestSheetViewData : ProjectViewData
    {
        public readonly ProjectLocationSummaryViewData ProjectLocationSummaryViewData;
        public readonly List<IGrouping<Models.PerformanceMeasure, PerformanceMeasureExpected>> PerformanceMeasureReportedValues;
        public readonly List<GooglePieChartSlice> FundingSourceRequestAmountGooglePieChartSlices;
        public readonly Models.ProjectImage KeyPhoto;
        public readonly List<IGrouping<ProjectImageTiming, Models.ProjectImage>> ProjectImagesExceptKeyPhotoGroupedByTiming;
        public readonly int ProjectImagesPerTimingGroup;
        public readonly List<Models.Classification> ThresholdCategories;
        public readonly GoogleChartJson GoogleChartJson;
        public readonly string LeadFederalAgency;
        public readonly string FundingRequest;
        public readonly int CalculatedChartHeight;

        public FundingRequestSheetViewData(Person currentPerson,
            Models.Project project,
            ProjectLocationSummaryMapInitJson projectLocationSummaryMapInitJson,
            GoogleChartJson googleChartJson,
            List<GooglePieChartSlice> fundingSourceRequestAmountGooglePieChartSlices) : base(currentPerson, project)
        {
            PageTitle = project.DisplayName;
            BreadCrumbTitle = "Funding Request Sheet";

            PerformanceMeasureReportedValues = project.PerformanceMeasureExpecteds.GroupBy(x => x.PerformanceMeasure, new HavePrimaryKeyComparer<Models.PerformanceMeasure>())
                .OrderBy(x => x.Key.PerformanceMeasureDisplayName).ToList();
            ProjectLocationSummaryViewData = new ProjectLocationSummaryViewData(project, projectLocationSummaryMapInitJson);

            KeyPhoto = project.KeyPhoto;
            ProjectImagesExceptKeyPhotoGroupedByTiming = project.ProjectImages.Where(x => !x.IsKeyPhoto && x.ProjectImageTiming != ProjectImageTiming.Unknown && !x.ExcludeFromFactSheet)
                .GroupBy(x => x.ProjectImageTiming).OrderBy(x => x.Key.SortOrder).ToList();
            ProjectImagesPerTimingGroup = ProjectImagesExceptKeyPhotoGroupedByTiming.Count == 1 ? 6 : 2;
            ThresholdCategories = project.ProjectClassifications.Select(x => x.Classification).OrderBy(x => x.DisplayName).ToList();

            GoogleChartJson = googleChartJson;
            FundingSourceRequestAmountGooglePieChartSlices = fundingSourceRequestAmountGooglePieChartSlices;

            //Dynamically resize chart based on how much space the legend requires
            CalculatedChartHeight = 477 - (FundingSourceRequestAmountGooglePieChartSlices.Count <= 2
                                        ? FundingSourceRequestAmountGooglePieChartSlices.Count * 24
                                        : FundingSourceRequestAmountGooglePieChartSlices.Count * 20);

            LeadFederalAgency = project.ProjectFundingSourceRequests.Any()
                ? string.Join(", ", project.ProjectFundingSourceRequests.Select(x => x.FundingSource.Organization.OrganizationName).OrderBy(x => x))
                : "?";
            FundingRequest = project.ProjectFundingSourceRequests.Any() ? project.ProjectFundingSourceRequests.Sum(x => x.UnsecuredAmount).ToStringCurrency() : "?";
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
