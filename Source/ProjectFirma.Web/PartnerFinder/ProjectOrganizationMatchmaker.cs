using System;
using System.Collections.Generic;
using System.Data.Entity.Spatial;
using System.Linq;
using LtInfo.Common.DesignByContract;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.PartnerFinder
{
    public class ProjectOrganizationMatchmaker
    {
        public double GetPartnerOrganizationFitnessScoreNumber(Project project,
            Organization organization,
            ref List<string> matchInsightStrings,
            ref Dictionary<MatchmakerSubScoreTypeEnum, MatchMakerScoreSubScoreInsight>
                scoreInsightDictionary)
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

            List<double> subScores = new List<double>();

            // Taxonomy SubScore
            CalculateTaxonomySubScore(project, organization, ref subScores, ref matchInsightStrings, ref scoreInsightDictionary);
            // Organization Area of Interest SubScore
            CalculateOrganizationAreaOfInterestSubScore(project, organization, ref subScores, ref matchInsightStrings, ref scoreInsightDictionary);
            // Keywords SubScore
            CalculateOrganizationMatchmakerKeywordSubScore(project, organization, ref subScores, ref matchInsightStrings, ref scoreInsightDictionary);
            // Classifications SubScore
            CalculateOrganizationMatchmakerClassificationSubScore(project, organization, ref subScores, ref matchInsightStrings, ref scoreInsightDictionary);
            // Performance Measure SubScore
            CalculateOrganizationMatchmakerPerformanceMeasureSubScore(project, organization, ref subScores, ref matchInsightStrings, ref scoreInsightDictionary);

            // Calculate final score from sub-scores
            double scoreToReturn = CalculateFinalScoreFromSubScores(subScores);

            // Again, we want to be very sure score values fall between 0.0 and 1.0 inclusive.
            CheckEnsureScoreInValidRange(scoreToReturn);

            return scoreToReturn;
        }
        
        private double CalculateFinalScoreFromSubScores(List<double> subScores)
        {
            double finalScore = 0.0;

            var numberOfComponents = subScores.Count;
            var weightPerSubScore = 1.0 / numberOfComponents;
            foreach (var currentSubScore in subScores)
            {
                CheckEnsureScoreInValidRange(currentSubScore);
                finalScore += currentSubScore * weightPerSubScore;
            }

            // Never hurts to check this.
            CheckEnsureScoreInValidRange(finalScore);

            return finalScore;
        }

        private static void CalculateTaxonomySubScore(Project project,
            Organization organization,
            ref List<double> subScores,
            ref List<string> matchInsightStrings,
            ref Dictionary<MatchmakerSubScoreTypeEnum, MatchMakerScoreSubScoreInsight>
                scoreInsightDictionary)
        {
            List<string> localMatchInsights = new List<string>();

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

            if (matchesLeaf)
            {
                //localMatchInsights.Add($"{matchmakerLeaves.Count} Leaf matches for {project.TaxonomyLeaf.TaxonomyLeafName} ");
                localMatchInsights.Add($"{project.TaxonomyLeaf.TaxonomyLeafName}");
            }

            if (matchesLeafForBranch)
            {
                //localMatchInsights.Add($"{matchmakerLeavesFromSelectedBranches.Count} Leaf for selected branch matches for {project.TaxonomyLeaf.TaxonomyLeafName} ");
                localMatchInsights.Add($"{project.TaxonomyLeaf.TaxonomyBranch.TaxonomyBranchName}");
            }

            if (matchesLeafForTrunk)
            {
                //localMatchInsights.Add($"{matchmakerLeavesFromSelectedTrunks.Count} Leaf for selected trunk matches for {project.TaxonomyLeaf.TaxonomyLeafName} ");
                localMatchInsights.Add($"{project.TaxonomyLeaf.TaxonomyBranch.TaxonomyTrunk.TaxonomyTrunkName}");
            }

            double taxonomySubScore = matchesLeaf || matchesLeafForBranch || matchesLeafForTrunk ? 1.0 : 0.0;

            // We want the overall score to appear first in output
            //if (taxonomySubScore > 0)
            //{
            //    localMatchInsights.Insert(0, $"Taxonomy SubScore = {taxonomySubScore:0.0}: ");
            //}

            matchInsightStrings.AddRange(localMatchInsights);
            scoreInsightDictionary.Add(MatchmakerSubScoreTypeEnum.TaxonomySystem, new MatchMakerScoreSubScoreInsight(taxonomySubScore, localMatchInsights));

            CheckEnsureScoreInValidRange(taxonomySubScore);
            subScores.Add(taxonomySubScore);
        }

        private static void CalculateOrganizationMatchmakerClassificationSubScore(Project project,
            Organization organization,
            ref List<double> subScores,
            ref List<string> matchInsightStrings,
            ref Dictionary<MatchmakerSubScoreTypeEnum, MatchMakerScoreSubScoreInsight>
                scoreInsightDictionary)
        {
            List<string> localMatchInsights = new List<string>();
            double classificationMatchScore = 0.0;

            var organizationClassifications = organization.MatchmakerOrganizationClassifications.Select(x => x.Classification).ToList();
            var projectClassificationIDs = project.ProjectClassifications.Select(x => x.ClassificationID).ToList();
            var matches = organizationClassifications.Where(x => projectClassificationIDs.Contains(x.ClassificationID)).ToList();
            if (matches.Any())
            {
                classificationMatchScore = 1.0;
                //localMatchInsights.Insert(0, $"Classification SubScore = {classificationMatchScore:0.0}: ");

                var classificationNames = MultiTenantHelpers.HasSingleClassificationSystem ? matches.Select(x => x.DisplayName) : matches.Select(x => $"{x.DisplayName}({x.ClassificationSystem.ClassificationSystemName})");
                localMatchInsights.Add($"{string.Join(", ", classificationNames)}");
            }

            
            matchInsightStrings.AddRange(localMatchInsights);
            //var classification
            scoreInsightDictionary.Add(MatchmakerSubScoreTypeEnum.Classification, new MatchMakerScoreSubScoreInsight(classificationMatchScore, localMatchInsights));
            
            CheckEnsureScoreInValidRange(classificationMatchScore);
            subScores.Add(classificationMatchScore);

        }

        private static void CalculateOrganizationMatchmakerPerformanceMeasureSubScore(Project project,
            Organization organization,
            ref List<double> subScores,
            ref List<string> matchInsightStrings,
            ref Dictionary<MatchmakerSubScoreTypeEnum, MatchMakerScoreSubScoreInsight>
                scoreInsightDictionary)
        {
            List<string> localMatchInsights = new List<string>();
            double performanceMeasureMatchScore = 0.0;

            var organizationPerformanceMeasures = organization.MatchmakerOrganizationPerformanceMeasures.Select(x => x.PerformanceMeasure).ToList();
            var projectPerformanceMeasureActualIDs = project.PerformanceMeasureActuals.Select(x => x.PerformanceMeasureID).ToList();
            var projectPerformanceMeasureExpectedIDs = project.PerformanceMeasureExpecteds.Select(x => x.PerformanceMeasureID).ToList();

            var performanceMeasureIDs = new HashSet<int>(projectPerformanceMeasureActualIDs);
            performanceMeasureIDs.UnionWith(projectPerformanceMeasureExpectedIDs);

            var matches = organizationPerformanceMeasures.Where(x => performanceMeasureIDs.Contains(x.PerformanceMeasureID)).ToList();
            if (matches.Any())
            {
                performanceMeasureMatchScore = 1.0;
                //localMatchInsights.Insert(0, $"Performance Measure SubScore = {performanceMeasureMatchScore:0.0}: ");
                var matchNames = matches.Select(x => x.PerformanceMeasureDisplayName);
                localMatchInsights.Add($"{string.Join(", ", matchNames)}");
            }

            matchInsightStrings.AddRange(localMatchInsights);
            scoreInsightDictionary.Add(MatchmakerSubScoreTypeEnum.PerformanceMeasure, new MatchMakerScoreSubScoreInsight(performanceMeasureMatchScore, localMatchInsights));

            CheckEnsureScoreInValidRange(performanceMeasureMatchScore);
            subScores.Add(performanceMeasureMatchScore);

        }

        private static void CalculateOrganizationAreaOfInterestSubScore(Project project,
            Organization organization,
            ref List<double> subScores,
            ref List<string> matchInsightStrings,
            ref Dictionary<MatchmakerSubScoreTypeEnum, MatchMakerScoreSubScoreInsight>
                scoreInsightDictionary)
        {
            List<string> localMatchInsights = new List<string>();

            // The geometries we use when matching against an Organization are configurable, and may vary, so 
            // here we get them ready to go before trying to match against all the geospatial components.
            var organizationDbGeometriesToUseInMatching = organization.GetDbGeometriesToUseForMatchMakerMatchingAgainstThisOrganization();

            // Simple Location sub-sub-score
            double simpleLocationSubSubScore = 0.0;
            {
                var projectSimpleLocation = project.ProjectLocationPoint;
                foreach (var currentOrgDbGeometry in organizationDbGeometriesToUseInMatching)
                {
                    if (projectSimpleLocation != null && 
                        projectSimpleLocation.Intersects(currentOrgDbGeometry))
                    {
                        simpleLocationSubSubScore = 1.0;
                        localMatchInsights.Add($"Simple Location");
                        // One is enough to score the subscore maximally
                        break;
                    }
                }
            }

            // Detailed location sub-sub-score
            double detailedLocationSubSubScore = 0.0;
            {
                var projectDetailedLocations = project.GetProjectLocationDetails().ToList();
                foreach (var currentOrgDbGeometry in organizationDbGeometriesToUseInMatching)
                {
                    foreach (var currentDetailedLocation in projectDetailedLocations)
                    {
                        DbGeometry currentProjectLocationGeometry = currentDetailedLocation.GetProjectLocationGeometry();
                        if (currentProjectLocationGeometry.Intersects(currentOrgDbGeometry))
                        {
                            detailedLocationSubSubScore = 1.0;
                            localMatchInsights.Add($"Detailed Location");
                            // One is enough to score the subscore maximally
                            break;
                        }
                    }
                }
            }

            // Geospatial area sub-sub-score
            double projectGeospatialAreaSubSubScore = 0.0;
            if(MultiTenantHelpers.GetTenantAttributeFromCache().MatchmakerAlgorithmIncludesProjectGeospatialAreas)
            {
                var projectGeospatialAreas = project.GetProjectGeospatialAreas().ToList();
                foreach (var currentOrgDbGeometry in organizationDbGeometriesToUseInMatching)
                {
                    foreach (var currentProjectGeoSpatialArea in projectGeospatialAreas)
                    {
                        if (currentProjectGeoSpatialArea.GeospatialAreaFeature.Intersects(currentOrgDbGeometry))
                        {
                            projectGeospatialAreaSubSubScore = 1.0;
                            localMatchInsights.Add($"{currentProjectGeoSpatialArea.GeospatialAreaName}");
                            // One is enough to score the subscore maximally
                            break;
                        }
                    }
                }
            }

            // If any of the sub-sub scores are 1.0, the AOI sub score returns 1.0. This could be refined if needed.
            var allSubScores = new List<double> {simpleLocationSubSubScore, detailedLocationSubSubScore, projectGeospatialAreaSubSubScore};
            var areaOfInterestOverallScore = allSubScores.Max();

            // We want the overall score to appear first in output
            //if (areaOfInterestOverallScore > 0)
            //{
            //    localMatchInsights.Insert(0, $"Area of Interest SubScore = {areaOfInterestOverallScore:0.0}: ");
            //}

            matchInsightStrings.AddRange(localMatchInsights);
            scoreInsightDictionary.Add(MatchmakerSubScoreTypeEnum.AreaOfInterest, new MatchMakerScoreSubScoreInsight(areaOfInterestOverallScore, localMatchInsights));
            CheckEnsureScoreInValidRange(areaOfInterestOverallScore);
            subScores.Add(areaOfInterestOverallScore);
        }

        private static void CalculateOrganizationMatchmakerKeywordSubScore(Project project,
            Organization organization,
            ref List<double> subScores,
            ref List<string> matchInsightStrings,
            ref Dictionary<MatchmakerSubScoreTypeEnum, MatchMakerScoreSubScoreInsight>
                scoreInsightDictionary)
        {
            List<string> localMatchInsights = new List<string>();

            // Just searching Name & Description for now, but definitely could search additional meta data
            double keywordProjectNameKeywordScore = 0.0;
            double keywordProjectDescriptionKeywordScore = 0.0;

            string currentProjectName = project.ProjectName.ToLower();
            string currentProjectDescription = project.ProjectDescription.ToLower();

            List<MatchmakerKeyword> keywordsForOrganization = organization.OrganizationMatchmakerKeywords.Select(omk => omk.MatchmakerKeyword).ToList();
            foreach (var currentMatchmakerKeyword in keywordsForOrganization)
            {
                string currentOrgKeyword = currentMatchmakerKeyword.MatchmakerKeywordName.ToLower();
                if (currentProjectName.Contains(currentOrgKeyword) || currentProjectDescription.Contains(currentOrgKeyword))
                {
                    keywordProjectNameKeywordScore = 1.0;
                    //localMatchInsights.Add($"Keyword Project Name SubScore = {keywordProjectNameKeywordScore:0.0}: ");
                    if (!localMatchInsights.Contains($"'{currentOrgKeyword}'"))
                    {
                        localMatchInsights.Add($"'{currentOrgKeyword}'");
                    }
                }

            }

            // If any of the sub-sub scores are 1.0, the Keyword sub score returns 1.0. This could be refined if needed.
            var allSubScores = new List<double> { keywordProjectNameKeywordScore, keywordProjectDescriptionKeywordScore };
            double keywordOverallScore = allSubScores.Max();

            matchInsightStrings.AddRange(localMatchInsights);
            scoreInsightDictionary.Add(MatchmakerSubScoreTypeEnum.MatchmakerKeyword, new MatchMakerScoreSubScoreInsight(keywordOverallScore, localMatchInsights));

            CheckEnsureScoreInValidRange(keywordOverallScore);
            subScores.Add(keywordOverallScore);
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
                    List<String> scoreInsightStrings = new List<string>();
                    Dictionary<MatchmakerSubScoreTypeEnum, MatchMakerScoreSubScoreInsight>
                        scoreInsightDictionary =
                            new Dictionary<MatchmakerSubScoreTypeEnum,
                                MatchMakerScoreSubScoreInsight>();
                    var currentScore = GetPartnerOrganizationFitnessScoreNumber(currentProject, currentOrganization, ref scoreInsightStrings, ref scoreInsightDictionary);
                    if (currentScore >= matchScoreCutoff)
                    {
                        PartnerOrganizationMatchMakerScore currentMatchMakerScore = new PartnerOrganizationMatchMakerScore(currentProject, currentOrganization, currentScore, scoreInsightStrings, scoreInsightDictionary);
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
            var allAppropriateProjects = HttpRequestStorage.DatabaseEntities.Projects.ToList().GetActiveProjectsAndProposals(currentFirmaSession.CanViewProposals()).ToList();
            return GetPartnerOrganizationMatchMakerScores(new List<Organization> {organization}, allAppropriateProjects);
        }

        /// <summary>
        /// Get all the scores for a particular Project.
        /// Will consider every active Organization that has Opted-in for the matchmaker for now; this is just a guess.
        /// </summary>
        /// <param name="currentFirmaSession"></param>
        /// <param name="project"></param>
        /// <returns></returns>
        public List<PartnerOrganizationMatchMakerScore> GetPartnerOrganizationMatchMakerScoresForParticularProject(FirmaSession currentFirmaSession, Project project)
        {
            var allAppropriateOrganizations = HttpRequestStorage.DatabaseEntities.Organizations.GetMatchmakerOrganizations();
            return GetPartnerOrganizationMatchMakerScores(allAppropriateOrganizations, new List<Project> {project});
        }


    }
}