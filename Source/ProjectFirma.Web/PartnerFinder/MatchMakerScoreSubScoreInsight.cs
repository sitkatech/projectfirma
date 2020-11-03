using System.Collections.Generic;

namespace ProjectFirma.Web.PartnerFinder
{
    public class MatchMakerScoreSubScoreInsight
    {
        public enum MatchmakerSubScoreType
        {
            MatchmakerKeyword,
            AreaOfInterest,
            TaxonomySystem,
            Classification,
            PerformanceMeasure
        }

        public bool Matched { get; set; }
        public double Score { get; set; }
        public List<string> ScoreInsights { get; set; }

        public MatchMakerScoreSubScoreInsight(double score, List<string> scoreInsights)
        {
            Matched = score > 0.0;
            Score = score;
            ScoreInsights = scoreInsights;
        }
    }
}