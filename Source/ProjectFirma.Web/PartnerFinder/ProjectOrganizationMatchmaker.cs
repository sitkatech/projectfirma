using System.Collections.Generic;
using System.Linq;
using LtInfo.Common.DesignByContract;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.PartnerFinder
{
    public class PartnerOrganizationMatchMakerScore
    {
        // Anything below this score is deemed not good enough to show to a user as
        // a potential match. We'll see if this is useful idea.
        public const double MatchScoreDisplayCutoff = 0.5;

        public Project Project { get; }
        public Organization Organization { get; }
        public double PartnerOrganizationFitnessScoreNumber { get; }

        public PartnerOrganizationMatchMakerScore(Project project,
                                                  Organization organization,
                                                  double partnerOrganizationFitnessScoreNumber)
        {
            Check.EnsureNotNull(project);
            Check.EnsureNotNull(project);
            ProjectOrganizationMatchmaker.CheckEnsureScoreInValidRange(partnerOrganizationFitnessScoreNumber);

            this.Project = project;
            this.Organization = organization;
            this.PartnerOrganizationFitnessScoreNumber = partnerOrganizationFitnessScoreNumber;
        }

        public string GetProjectOrganizationMatchString()
        {
            return $"Project:{this.Project.ProjectName}-Organization:{this.Organization.OrganizationName}-Score:{PartnerOrganizationFitnessScoreNumber}";
        }

        public string GetProjectOrganizationFitnessScoreNumberDisplayString()
        {
            return $"{this.PartnerOrganizationFitnessScoreNumber:0.00}";
        }
    }

    public class ProjectOrganizationMatchmaker
    {
        public double GetPartnerOrganizationFitnessScoreNumber(Project project, Organization organization)
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
            // * SubScores are also restricted to 0.0. - 1.0.

            // Taxonomy SubScore
            double taxonomySubScore = GetTaxonomySubScore(project, organization);
            CheckEnsureScoreInValidRange(taxonomySubScore);

            // Hardwired for just one component for the moment, but this will definitely change.
            var numberOfComponents = 1;
            var weightPerSubScore = 1.0 / numberOfComponents; 
            double scoreToReturn = taxonomySubScore * weightPerSubScore;

            // Again, we want to be very sure score values fall between 0.0 and 1.0 inclusive.
            CheckEnsureScoreInValidRange(scoreToReturn);

            return scoreToReturn;
        }

        private static double GetTaxonomySubScore(Project project, Organization organization)
        {
            var matchmakerLeaves = organization.MatchmakerOrganizationTaxonomyLeafs.Select(x => x.TaxonomyLeaf).ToList();
            
            var branchIDsIncluded = matchmakerLeaves.Select(x => x.TaxonomyBranchID).ToList();
            // if any Branch is selected, but no Leaves are selected for that branch, treat as if all leaves are selected
            var matchmakerLeavesFromSelectedBranches = organization.MatchmakerOrganizationTaxonomyBranches
                .Where(x => !branchIDsIncluded.Contains(x.TaxonomyBranchID))
                .SelectMany(x => x.TaxonomyBranch.TaxonomyLeafs).ToList();
            branchIDsIncluded.AddRange(matchmakerLeavesFromSelectedBranches.Select(x => x.TaxonomyBranchID));
            
            var trunkIDsIncluded = matchmakerLeaves.Select(x => x.TaxonomyBranch.TaxonomyTrunkID).ToList();
            trunkIDsIncluded.AddRange(matchmakerLeavesFromSelectedBranches.Select(x => x.TaxonomyBranch.TaxonomyTrunkID));
            // if any Trunk is selected, but no Branches or Leaves are selected for that trunk, treat as if all leaves are selected
            var matchmakerLeavesFromSelectedTrunks = organization.MatchmakerOrganizationTaxonomyTrunks
                .Where(x => !trunkIDsIncluded.Contains(x.TaxonomyTrunkID))
                .SelectMany(x => x.TaxonomyTrunk.GetTaxonomyLeafs()).ToList();

            var matchesLeaf = matchmakerLeaves.Any(x => x.TaxonomyLeafID == project.TaxonomyLeafID);
            var matchesLeafForBranch = matchmakerLeavesFromSelectedBranches.Any(x => x.TaxonomyLeafID == project.TaxonomyLeafID);
            var matchesLeafForTrunk = matchmakerLeavesFromSelectedTrunks.Any(x => x.TaxonomyLeafID == project.TaxonomyLeafID);
            
            double taxonomySubScore = matchesLeaf || matchesLeafForBranch || matchesLeafForTrunk ? 1.0 : 0.0;
            return taxonomySubScore;
        }

        public static void CheckEnsureScoreInValidRange(double scoreToCheck)
        {
            Check.Ensure(scoreToCheck >= 0.0 && scoreToCheck <= 1.0, $"Got Score of {scoreToCheck}. Expected Partner Fitness Score between 0.0 and 1.0.");
        }

        /// <summary>
        /// Get Partner - Organization match scores
        /// </summary>
        /// <param name="organizations"></param>
        /// <param name="projects"></param>
        /// <param name="matchScoreCutoff">The value 0.0-1.0 value below which matches will not be returned. Set to 0 to return all possible matches, no matter how poor.</param>
        /// <returns></returns>
        private List<PartnerOrganizationMatchMakerScore> GetPartnerOrganizationMatchMakerScores(List<Organization> organizations,
                                                                                                List<Project> projects,
                                                                                                double matchScoreCutoff = PartnerOrganizationMatchMakerScore.MatchScoreDisplayCutoff)
        {
            List<PartnerOrganizationMatchMakerScore> scoresToReturn = new List<PartnerOrganizationMatchMakerScore>();
            foreach (var currentOrganization in organizations)
            {
                foreach (var currentProject in projects)
                {
                    var currentScore = GetPartnerOrganizationFitnessScoreNumber(currentProject, currentOrganization);
                    if (currentScore >= matchScoreCutoff)
                    {
                        PartnerOrganizationMatchMakerScore currentMatchMakerScore = new PartnerOrganizationMatchMakerScore(currentProject, currentOrganization, currentScore);
                        scoresToReturn.Add(currentMatchMakerScore);
                    }
                }
            }

            // Order by score descending, and then by a stable sort using the names of the Project & Organization
            return scoresToReturn.OrderByDescending(s => s.PartnerOrganizationFitnessScoreNumber).ThenBy(s => s.GetProjectOrganizationMatchString()).ToList();
        }

        /// <summary>
        /// Get all the scores for a particular Organization.
        /// Will consider every active Project for now; this is just a guess.
        /// </summary>
        /// <param name="currentFirmaSession"></param>
        /// <param name="organization"></param>
        /// <returns></returns>
        public List<PartnerOrganizationMatchMakerScore> GetPartnerOrganizationMatchMakerScoresForParticularOrganization(FirmaSession currentFirmaSession, Organization organization)
        {
            var allAppropriateProjects = HttpRequestStorage.DatabaseEntities.Projects.ToList().GetActiveProjectsAndProposals(currentFirmaSession.Person.CanViewProposals()).ToList();
            return GetPartnerOrganizationMatchMakerScores(new List<Organization> {organization}, allAppropriateProjects);
        }

        /// <summary>
        /// Get all the scores for a particular Project.
        /// Will consider every active Organization for now; this is just a guess.
        /// </summary>
        /// <param name="currentFirmaSession"></param>
        /// <param name="project"></param>
        /// <returns></returns>
        public List<PartnerOrganizationMatchMakerScore> GetPartnerOrganizationMatchMakerScoresForParticularProject(FirmaSession currentFirmaSession, Project project)
        {
            var allAppropriateOrganizations = HttpRequestStorage.DatabaseEntities.Organizations.GetActiveOrganizations();
            return GetPartnerOrganizationMatchMakerScores(allAppropriateOrganizations, new List<Project> {project});
        }


    }
}