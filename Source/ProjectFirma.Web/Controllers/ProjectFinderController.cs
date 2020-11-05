using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using LtInfo.Common;
using LtInfo.Common.MvcResults;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.PartnerFinder;
using ProjectFirma.Web.Security;
using ProjectFirma.Web.Views.Map;
using ProjectFirma.Web.Views.Organization;
using ProjectFirma.Web.Views.ProjectCustomGrid;
using ProjectFirma.Web.Views.ProjectFinder;
using ProjectFirma.Web.Views.Shared.ProjectLocationControls;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Controllers
{

    public class ProjectFinderController : FirmaBaseController
    {
        [LoggedInAndNotUnassignedRoleUnclassifiedFeature]
        [HttpGet]
        public ViewResult Organization(OrganizationPrimaryKey organizationPrimaryKey)
        {
            var organization = organizationPrimaryKey.EntityObject;
            var projectFinderGridSpec = new ProjectFinderGridSpec();
            var projectMatchmakerScoresForOrganization = new ProjectOrganizationMatchmaker().GetPartnerOrganizationMatchMakerScoresForParticularOrganization(CurrentFirmaSession, organization);
            var projectsToShow = projectMatchmakerScoresForOrganization.Select(x => x.Project).Where(x => x.ProjectStage.ShouldShowOnMap()).ToList();


            var filterValues = ResultsController.GetDefaultFilterValuesForFilterType(ProjectMapCustomization.DefaultLocationFilterType.ToEnum, true);

            var initialCustomization = new ProjectMapCustomization(ProjectMapCustomization.DefaultLocationFilterType, filterValues, ProjectColorByType.ProjectStage);
            var projectLocationsLayerGeoJson =
                new LayerGeoJson($"{FieldDefinitionEnum.ProjectLocation.ToType().GetFieldDefinitionLabel()}",
                    projectsToShow.MappedPointsToGeoJsonFeatureCollection(true, true), "blue", 1,
                    LayerInitialVisibility.Show);
            var projectLocationsMapInitJson = new ProjectLocationsMapInitJson(projectLocationsLayerGeoJson,
                initialCustomization, "ProjectLocationsMap", true);

            projectLocationsMapInitJson.Layers.AddRange(HttpRequestStorage.DatabaseEntities.Organizations.GetBoundaryLayerGeoJson());

            var profileCompletionDictionary = organization.GetMatchmakerOrganizationProfileCompletionDictionary();
            DisplayMatchMakerToastMessagesIfAny(organization, projectMatchmakerScoresForOrganization, profileCompletionDictionary);

            var viewData = new ProjectFinderOrganizationViewData(CurrentFirmaSession, organization, projectMatchmakerScoresForOrganization, projectFinderGridSpec, projectLocationsMapInitJson);
            return RazorView<ProjectFinderOrganization, ProjectFinderOrganizationViewData>(viewData);
        }

        private void DisplayMatchMakerToastMessagesIfAny(Organization organization, List<PartnerOrganizationMatchMakerScore> projectMatchmakerScoresForOrganization, Dictionary<MatchMakerScoreSubScoreInsight.MatchmakerSubScoreType, bool> profileCompletionDictionary)
        {

            var linkToOrgProfile = SitkaRoute<OrganizationController>.BuildLinkFromExpression(
                x => x.Detail(organization.OrganizationID, OrganizationDetailViewData.OrganizationDetailTab.Profile),
                $"{FieldDefinitionEnum.Organization.ToType().GetFieldDefinitionLabel()} Profile");

            // When Org profile is not filled out at all (no matches are possible)
            if (!profileCompletionDictionary.Values.Any(x => x))
            {
                SetErrorForDisplay($"The profile for your {FieldDefinitionEnum.Organization.ToType().GetFieldDefinitionLabel()} ({organization.GetDisplayName()}) is empty, so it’s not possible to identify {FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabel()} matches. Please fill out your {linkToOrgProfile} as completely as possible before using the {FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabel()} Finder");
                return;
            }

            // When Org profile is partially filled out and there are no matches
            if (profileCompletionDictionary.Values.Any(x => x == false) && !projectMatchmakerScoresForOrganization.Any())
            {
                SetWarningForDisplay($"0 {FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabel()} matches found. Please fill out your {linkToOrgProfile} as completely as possible to increase your potential for {FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabel()} matches.");
                return;
            }


            // When Org profile is partially filled out and matches exist
            if (profileCompletionDictionary.Values.Any(x => x == false) && projectMatchmakerScoresForOrganization.Any())
            {
                SetWarningForDisplay($"{FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabelPluralized()} can only be found for {profileCompletionDictionary.Values.Count(x => x)} out of {profileCompletionDictionary.Values.Count} match categories. Complete your {linkToOrgProfile} to access all your {FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabel()} matches!");
                return;
            }

            // When Org profile is completely filled out and there are no matches
            if (profileCompletionDictionary.Values.All(x => x != false) && !projectMatchmakerScoresForOrganization.Any())
            {
                SetWarningForDisplay($"No matches just yet! To increase potential matches, add more detail where possible to your {linkToOrgProfile}.");
            }

        }


        // All projects that match with the organization
        [LoggedInAndNotUnassignedRoleUnclassifiedFeature]
        public GridJsonNetJObjectResult<PartnerOrganizationMatchMakerScore> ProjectFinderGridFullJsonData(OrganizationPrimaryKey organizationPrimaryKey)
        {
            var organization = organizationPrimaryKey.EntityObject;
            var gridSpec = new ProjectFinderGridSpec();
            var projectMatchmakerScoresForOrganization = new ProjectOrganizationMatchmaker().GetPartnerOrganizationMatchMakerScoresForParticularOrganization(CurrentFirmaSession, organization);
            var projectMatchmakerScoresExcludingInvalidStages = projectMatchmakerScoresForOrganization.Where(x => x.Project.ProjectStage.ShouldShowOnMap()).ToList();

            var gridJsonNetJObjectResult = new GridJsonNetJObjectResult<PartnerOrganizationMatchMakerScore>(projectMatchmakerScoresExcludingInvalidStages, gridSpec, x => x.Project.PrimaryKey);
            return gridJsonNetJObjectResult;
        }
       
    }

}