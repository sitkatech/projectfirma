using System.Web;
using LtInfo.Common;
using LtInfo.Common.DhtmlWrappers;
using LtInfo.Common.Views;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Controllers;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.PartnerFinder;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Views.ProjectFinder
{
    public class ProjectFinderGridSpec : GridSpec<PartnerOrganizationMatchMakerScore>
    {
        public ProjectFinderGridSpec()
        {
            Add(FieldDefinitionEnum.MatchScore.ToType().GetFieldDefinitionLabel(), x => x.PartnerOrganizationFitnessScoreNumber.ToString(), 50, DhtmlxGridColumnFilterType.Html);
            Add(FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabel(), x => x.Project.GetDisplayNameAsUrl(), 200, DhtmlxGridColumnFilterType.Html);
            Add("Lead Implementer", x => x.Project.GetPrimaryContactOrganization().GetDisplayNameAsUrl(), 150, DhtmlxGridColumnFilterType.Html);
            Add(FieldDefinitionEnum.MatchmakerKeyword.ToType().GetFieldDefinitionLabel(), x => x.ScoreInsightDictionary[MatchMakerScoreSubScoreInsight.MatchmakerSubScoreType.MatchmakerKeyword].Matched.ToCheckboxImageOrEmptyForGrid(), 50, DhtmlxGridColumnFilterType.SelectFilterHtmlStrict);
            Add(FieldDefinitionEnum.AreaOfInterest.ToType().GetFieldDefinitionLabel(), x => x.ScoreInsightDictionary[MatchMakerScoreSubScoreInsight.MatchmakerSubScoreType.AreaOfInterest].Matched.ToCheckboxImageOrEmptyForGrid(), 50, DhtmlxGridColumnFilterType.SelectFilterHtmlStrict);
            Add(FieldDefinitionEnum.TaxonomySystemName.ToType().GetFieldDefinitionLabel(), x => x.ScoreInsightDictionary[MatchMakerScoreSubScoreInsight.MatchmakerSubScoreType.TaxonomySystem].Matched.ToCheckboxImageOrEmptyForGrid(), 50, DhtmlxGridColumnFilterType.SelectFilterHtmlStrict);
            Add(FieldDefinitionEnum.Classification.ToType().GetFieldDefinitionLabel(), x => x.ScoreInsightDictionary[MatchMakerScoreSubScoreInsight.MatchmakerSubScoreType.Classification].Matched.ToCheckboxImageOrEmptyForGrid(), 50, DhtmlxGridColumnFilterType.SelectFilterHtmlStrict);
            Add(FieldDefinitionEnum.PerformanceMeasure.ToType().GetFieldDefinitionLabel(), x => x.ScoreInsightDictionary[MatchMakerScoreSubScoreInsight.MatchmakerSubScoreType.PerformanceMeasure].Matched.ToCheckboxImageOrEmptyForGrid(), 50, DhtmlxGridColumnFilterType.SelectFilterHtmlStrict);
            Add("Map", x => new HtmlString($"<form onsubmit=\"return false;\"data-id=\"{x.Project.ProjectID}\"><button type=\"submit\">Map</button></form>"), 50, DhtmlxGridColumnFilterType.Html);
        }
    }
}