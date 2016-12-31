using System.Globalization;
using ProjectFirma.Web.Models;
using LtInfo.Common;
using LtInfo.Common.DhtmlWrappers;
using LtInfo.Common.HtmlHelperExtensions;
using LtInfo.Common.Views;

namespace ProjectFirma.Web.Views.Results
{
    public class ProjectFundingSourceExpendituresBySectorGridSpec : GridSpec<ProjectFundingSourceSectorExpenditure>
    {
        public ProjectFundingSourceExpendituresBySectorGridSpec(int? calendarYear)
        {            
            Add(Models.FieldDefinition.ProjectName.ToGridHeaderString(),
                x => UrlTemplate.MakeHrefString(x.Project.GetDetailUrl(), x.Project.ProjectName),
                200,
                DhtmlxGridColumnFilterType.Html);
            Add(Models.FieldDefinition.TaxonomyTierThree.ToGridHeaderString(), x => UrlTemplate.MakeHrefString(x.Project.TaxonomyTierOne.TaxonomyTierTwo.TaxonomyTierThree.SummaryUrl, x.Project.TaxonomyTierOne.TaxonomyTierTwo.TaxonomyTierThree.DisplayName), 150);
            Add(Models.FieldDefinition.TaxonomyTierTwo.ToGridHeaderString(), x => UrlTemplate.MakeHrefString(x.Project.TaxonomyTierOne.TaxonomyTierTwo.SummaryUrl, x.Project.TaxonomyTierOne.TaxonomyTierTwo.DisplayName), 100);
            Add(Models.FieldDefinition.ProjectStage.ToGridHeaderStringWider(), x => x.Project.ProjectStage.ProjectStageDisplayName, 90, DhtmlxGridColumnFilterType.SelectFilterStrict);
            Add(Models.FieldDefinition.Sector.ToGridHeaderString(), x => x.FundingSource.Organization.Sector.SectorDisplayName, 80, DhtmlxGridColumnFilterType.SelectFilterStrict);
            Add(Models.FieldDefinition.FundingSource.ToGridHeaderString(), x => UrlTemplate.MakeHrefString(x.FundingSource.SummaryUrl, x.FundingSource.DisplayName), 200);
            Add(Models.FieldDefinition.Organization.ToGridHeaderString(), x => UrlTemplate.MakeHrefString(x.FundingSource.Organization.GetSummaryUrl(), x.FundingSource.Organization.DisplayName), 100);
            Add(string.Format("{0} ({1})", Models.FieldDefinition.FundedAmount.ToGridHeaderString(), calendarYear.HasValue ? calendarYear.Value.ToString(CultureInfo.InvariantCulture) : "Recent Years"), x => x.ExpenditureAmount, 100, DhtmlxGridColumnFormatType.Currency, DhtmlxGridColumnAggregationType.Total);
        }
    }
}