using System.Linq;
using LtInfo.Common.DesignByContract;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.PartnerFinder
{
    public class ProjectOrganizationMatchmaker
    {
        public double GetPartnerFitnessScore(Project project, Organization organization)
        {
            // Preconditions
            Check.EnsureNotNull(project);
            Check.EnsureNotNull(organization);

            // Significant assumptions, all of which are up for re-evaluation -- this is just where
            // we are starting.
            //
            // * Fitness is bidirectional. In other words, if a Project's suitability for an Organization is 0.75,
            //   that Organization's suitability for that Project is also 0.75.
            // * Scores are restricted to 0.0 - 1.0 where 0.0 is unsuitable, and 1.0 is perfect match.

            // To start off with, we assume that every Project matches every Organization perfectly.
            // This will change.
            double scoreToReturn = 1.0;

            // Use Taxonomy to match
            var taxonomyWeight = 1.0;
            // Project matches a selected Taxonomy Leaf => "perfect match" for taxonomy
            var matchesLeaf = organization.MatchmakerOrganizationTaxonomyLeafs.Any(x =>
                x.TaxonomyLeafID == project.TaxonomyLeafID);
            // If matches Branch but not a leaf, that's an pretty good score
            var matchesBranch =
                organization.MatchmakerOrganizationTaxonomyBranches.Any(x =>
                    x.TaxonomyBranchID == project.TaxonomyLeaf.TaxonomyBranchID);
            // If matches only Trunk, that's a passing score but not great
            var matchesTrunk = organization.MatchmakerOrganizationTaxonomyTrunks.Any(x =>
                x.TaxonomyTrunkID == project.TaxonomyLeaf.TaxonomyBranch.TaxonomyTrunkID);
            double taxonomyScore = matchesLeaf ? 1.0 : matchesBranch ? .75 : matchesTrunk ? .5 : 0.0;

            scoreToReturn = taxonomyWeight * taxonomyScore;

            // We want to be very sure score values fall between 0.0 and 1.0 inclusive.
            Check.Ensure(scoreToReturn >= 0.0 && scoreToReturn <= 1.0, $"Got Score of {scoreToReturn}. Expected Partner Fitness Score between 0.0 and 1.0.");

            return scoreToReturn;
        }
    }
}