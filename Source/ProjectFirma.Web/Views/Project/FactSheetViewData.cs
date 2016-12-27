using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjectFirma.Web.Controllers;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Views.Map;
using ProjectFirma.Web.Views.Shared;
using ProjectFirma.Web.Views.Shared.ProjectLocationControls;
using LtInfo.Common.Models;

namespace ProjectFirma.Web.Views.Project
{
    public class FactSheetViewData : ProjectViewData
    {
        public readonly ImageGalleryViewData ImageGalleryViewData;
        public readonly ProjectLocationSummaryViewData ProjectLocationSummaryViewData;
        public readonly List<IGrouping<Models.PerformanceMeasure, PerformanceMeasureReportedValue>> PerformanceMeasureReportedValues;
        public readonly string ChartID;
        public readonly Dictionary<string, decimal> FundingSourceExpenditures;
        public readonly Models.ProjectImage KeyPhoto;
        public readonly List<IGrouping<ProjectImageTiming, Models.ProjectImage>> ProjectImagesExceptKeyPhotoGroupedByTiming;
        public readonly int ProjectImagesPerTimingGroup;
        public readonly List<string> ChartColorRange;
        public readonly List<Models.Classification> Classifications;
        public readonly GoogleChartJson GoogleChartJson;

        public FactSheetViewData(Person currentPerson, Models.Project project, ProjectLocationSummaryMapInitJson projectLocationSummaryMapInitJson, List<string> chartColorRange) : base(currentPerson, project)
        {
            ChartColorRange = chartColorRange;
            PageTitle = project.DisplayName;
            BreadCrumbTitle = "Fact Sheet";

            const bool userCanAddPhotosToThisProject = false;
            var newPhotoForProjectUrl = string.Empty;
            var selectKeyImageUrl = string.Empty;
            var galleryName = string.Format("ProjectImage{0}", project.ProjectID);
            ImageGalleryViewData = new ImageGalleryViewData(currentPerson,
                galleryName,
                project.ProjectImages,
                userCanAddPhotosToThisProject,
                newPhotoForProjectUrl,
                selectKeyImageUrl,
                true,
                x => x.CaptionOnFullView,
                "Photo");

            PerformanceMeasureReportedValues =
                Project.GetReportedPerformanceMeasures()
                    .GroupBy(x => x.PerformanceMeasure, new HavePrimaryKeyComparer<Models.PerformanceMeasure>())
                    .OrderBy(x => x.Key.PerformanceMeasureName)
                    .ToList();
            ProjectLocationSummaryViewData = new ProjectLocationSummaryViewData(project, projectLocationSummaryMapInitJson);

            ChartID = string.Format("fundingChartForProject{0}", project.ProjectID);
            FundingSourceExpenditures = project.ProjectFundingSourceExpenditures.GroupBy(x => x.FundingSource.DisplayName).ToDictionary(x => x.Key, x => x.Sum(y => y.ExpenditureAmount));
            KeyPhoto = project.KeyPhoto;
            ProjectImagesExceptKeyPhotoGroupedByTiming =
                project.ProjectImages.Where(x => !x.IsKeyPhoto && x.ProjectImageTiming != ProjectImageTiming.Unknown && !x.ExcludeFromFactSheet)
                    .GroupBy(x => x.ProjectImageTiming)
                    .OrderBy(x => x.Key.SortOrder)
                    .ToList();
            ProjectImagesPerTimingGroup = ProjectImagesExceptKeyPhotoGroupedByTiming.Count == 1 ? 6 : 2;
            Classifications = project.ProjectClassifications.Select(x => x.Classification).OrderBy(x => x.DisplayName).ToList();

            GoogleChartJson = ProjectController.GetProjectFactSheetGoogleChart(project.PrimaryKey);

            //Dynamically resize chart based on how much space the legend requires
            var chartHeight = 435 - (FundingSourceExpenditures.Count*19);
            GoogleChartJson.GoogleChartConfiguration.SetSize(chartHeight, 450);
        }

        public HtmlString LegendHTML
        {
            get
            {
                var legendHtml = "<div>";
                foreach (var fund in FundingSourceExpenditures)
                {
                    var index = ProjectController.GetConsistentFundingSourceExpendituresIndexDictionary(FundingSourceExpenditures)[fund.Key];
                    legendHtml += "<div class='chartLegendColorBox' style='display:inline-block; border: solid 6px " + ChartColorRange[index] + "'></div> ";
                    legendHtml += "<div style='display:inline-block'>" + fund.Key + " = " + fund.Value.ToString("C0") + "</div>";
                    legendHtml += "<br>";
                }
                legendHtml += "</div>";
                return new HtmlString(legendHtml);
            }
        }
    }
}