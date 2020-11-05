using System.Collections.Generic;
using System.Web;
using LtInfo.Common.DesignByContract;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.PartnerFinder
{
    public class PartnerOrganizationMatchMakerScore
    {
        // Anything below this score is deemed not good enough to show to a user as
        // a potential match. We'll see if this is useful idea.
        public const double MatchScoreDisplayCutoff = 0.2;

        public Project Project { get; }
        public Organization Organization { get; }
        public double PartnerOrganizationFitnessScoreNumber { get; }
        public List<string> ScoreInsightMessages { get; }
        public Dictionary<MatchMakerScoreSubScoreInsight.MatchmakerSubScoreType, MatchMakerScoreSubScoreInsight> ScoreInsightDictionary { get; }


        public PartnerOrganizationMatchMakerScore(Project project,
            Organization organization,
            double partnerOrganizationFitnessScoreNumber,
            List<string> scoreInsightMessages,
            Dictionary<MatchMakerScoreSubScoreInsight.MatchmakerSubScoreType,
                MatchMakerScoreSubScoreInsight> scoreInsightDictionary)
        {
            Check.EnsureNotNull(project);
            Check.EnsureNotNull(project);
            ProjectOrganizationMatchmaker.CheckEnsureScoreInValidRange(partnerOrganizationFitnessScoreNumber);

            this.Project = project;
            this.Organization = organization;
            this.PartnerOrganizationFitnessScoreNumber = partnerOrganizationFitnessScoreNumber;
            this.ScoreInsightMessages = scoreInsightMessages;
            this.ScoreInsightDictionary = scoreInsightDictionary;
        }

        public string GetProjectOrganizationMatchString()
        {
            return $"Project:{this.Project.ProjectName}-Organization:{this.Organization.OrganizationName}-Score:{PartnerOrganizationFitnessScoreNumber}";
        }

        public string GetProjectOrganizationFitnessScoreNumberDisplayString()
        {
            return $"{this.PartnerOrganizationFitnessScoreNumber:0.00}";
        }

        public string GetScoreInsightMessagesConcatenated()
        {
            return string.Join("", this.ScoreInsightMessages);
        }

        public HtmlString GetMatchMakerScoreWithPopover()
        {
            var scoreWithPopover = new HtmlString($"<a role=\"button\" data-toggle=\"popover\" data-trigger=\"focus\" data-placement=\"right\" data-html=\"false\" data-content=\"toms Test!\">{this.PartnerOrganizationFitnessScoreNumber}</a>");

            return scoreWithPopover;
        }
    }
}