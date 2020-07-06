using LtInfo.Common.DesignByContract;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.PartnerFinder
{
    public class ProjectOrganizationMatchmaker
    {
        public double Score(Project project, Organization organization)
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

            // We want to be very sure score values fall between 0.0 and 1.0 inclusive.
            Check.Ensure(scoreToReturn >= 0.0 && scoreToReturn <= 1.0, $"Got Score of {scoreToReturn}. Expected Score between 0.0 and 1.0.");

            return scoreToReturn;
        }
    }
}