using LtInfo.Common;
using LtInfo.Common.DhtmlWrappers;
using LtInfo.Common.Views;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Controllers;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.PartnerFinder;

namespace ProjectFirma.Web.Views.ProjectFinder
{
    public class ProjectFinderGridSpec : GridSpec<PartnerOrganizationMatchMakerScore>
    {
        public ProjectFinderGridSpec()
        {
            //todo: all field definitions
            Add("Match Score", x => x.PartnerOrganizationFitnessScoreNumber.ToString(), 50, DhtmlxGridColumnFilterType.Html);
            Add("Project", x => x.Project.GetDisplayNameAsUrl(), 200, DhtmlxGridColumnFilterType.Html);
            Add("Lead Implementer", x => x.Project.GetPrimaryContactOrganization().GetDisplayNameAsUrl(), 150, DhtmlxGridColumnFilterType.Html);
            Add("Keyword", x => x.ScoreInsightDictionary[MatchMakerScoreSubScoreInsight.MatchmakerSubScoreType.MatchmakerKeyword].Matched.ToYesNo(), 50, DhtmlxGridColumnFilterType.Html);
            Add("Areas of Interest", x => x.ScoreInsightDictionary[MatchMakerScoreSubScoreInsight.MatchmakerSubScoreType.AreaOfInterest].Matched.ToYesNo(), 50, DhtmlxGridColumnFilterType.Html);
            Add("Taxonomy", x => x.ScoreInsightDictionary[MatchMakerScoreSubScoreInsight.MatchmakerSubScoreType.TaxonomySystem].Matched.ToYesNo(), 50, DhtmlxGridColumnFilterType.Html);
            Add("Classification", x => x.ScoreInsightDictionary[MatchMakerScoreSubScoreInsight.MatchmakerSubScoreType.Classification].Matched.ToYesNo(), 50, DhtmlxGridColumnFilterType.Html);
            Add("Performance Measure", x => x.ScoreInsightDictionary[MatchMakerScoreSubScoreInsight.MatchmakerSubScoreType.PerformanceMeasure].Matched.ToYesNo(), 50, DhtmlxGridColumnFilterType.Html);
            
        }
    }
}