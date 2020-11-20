using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using LtInfo.Common.DesignByContract;
using ProjectFirma.Web.Common;
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
        public Dictionary<MatchmakerSubScoreTypeEnum, MatchMakerScoreSubScoreInsight> ScoreInsightDictionary { get; }


        public PartnerOrganizationMatchMakerScore(Project project,
            Organization organization,
            double partnerOrganizationFitnessScoreNumber,
            List<string> scoreInsightMessages,
            Dictionary<MatchmakerSubScoreTypeEnum,
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
            //<div>
            //<p>This organization matches on 4 of 5 elements:</p>
	           // <ul>
            //    <li><strong>Area of Interest:</strong> Simple Location and Congressional District 02</li>
            //    <li><strong>First Keyword:</strong> “livestock” </li>
            //    <li><strong>Focus Area:</strong>  Water Quality Implementation Program</li>
            //    <li><strong>Project Theme:</strong> Rangelands </li>
            //    </ul>
            //<p>It did not match on Performance Measures.</p>
            //</div>
            var itemsMatched = this.ScoreInsightDictionary.Where(x => x.Value.Matched);
            var countOfMatches = itemsMatched.Count();
            var itemsNotMatched = this.ScoreInsightDictionary.Where(x => !x.Value.Matched).Select(x => MultiTenantHelpers.GetTenantDisplayNameForMatchmakerSubScoreTypeEnum(x.Key)).ToList();
            var countOfTotalPossibleItemsToMatchOn = Enum.GetNames(typeof(MatchmakerSubScoreTypeEnum)).Length;

            var sb = new StringBuilder();
            sb.AppendLine($"<div><p>This organization matches on {countOfMatches} of {countOfTotalPossibleItemsToMatchOn} elements:</p>");
            sb.Append("<ul>");
            foreach (var match in itemsMatched)
            {
                string keyDisplayName = MultiTenantHelpers.GetTenantDisplayNameForMatchmakerSubScoreTypeEnum(match.Key);
                sb.Append(
                    $"<li><strong>{keyDisplayName}:</strong> {string.Join(", ", match.Value.ScoreInsights)}</li>");
            }
            sb.Append("</ul>");

            if (itemsNotMatched.Any())
            {
                sb.Append($"<p>It did not match on <strong>{string.Join("</strong>, <strong>", itemsNotMatched)}</strong></p>");
            }

            sb.Append("</div>");

            var scoreWithPopover = new HtmlString($"<a tabindex=\"0\" role=\"button\" onclick=\"jQuery(this).popover('show')\" data-container=\"body\" data-toggle=\"popover\" data-trigger=\"focus\" data-placement=\"right\" data-html=\"true\" title=\"Match Score: {this.PartnerOrganizationFitnessScoreNumber}\" data-content=\"{sb}\">{this.PartnerOrganizationFitnessScoreNumber}</a>");

            return scoreWithPopover;

        }
    }
}