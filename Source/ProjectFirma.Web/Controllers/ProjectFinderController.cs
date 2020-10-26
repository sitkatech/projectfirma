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
        public ViewResult Index()
        {
            var organization = CurrentFirmaSession.Person.Organization;
            var projectFinderGridSpec = new ProjectFinderGridSpec();
            var projectMatchmakerScoresForOrganization = new ProjectOrganizationMatchmaker().GetPartnerOrganizationMatchMakerScoresForParticularOrganization(CurrentFirmaSession, organization);
            var projectsToShow = projectMatchmakerScoresForOrganization.Select(x => x.Project).ToList();


            var filterValues = ResultsController.GetDefaultFilterValuesForFilterType(ProjectMapCustomization.DefaultLocationFilterType.ToEnum, true);
            
            var initialCustomization = new ProjectMapCustomization(ProjectMapCustomization.DefaultLocationFilterType, filterValues, ProjectColorByType.ProjectStage);
            var projectLocationsLayerGeoJson =
                new LayerGeoJson($"{FieldDefinitionEnum.ProjectLocation.ToType().GetFieldDefinitionLabel()}",
                    projectsToShow.MappedPointsToGeoJsonFeatureCollection(true, true), "blue", 1,
                    LayerInitialVisibility.Show);
            var projectLocationsMapInitJson = new ProjectLocationsMapInitJson(projectLocationsLayerGeoJson,
                initialCustomization, "ProjectLocationsMap", true);

            projectLocationsMapInitJson.Layers.AddRange(HttpRequestStorage.DatabaseEntities.Organizations.GetBoundaryLayerGeoJson());


            var viewData = new IndexViewData(CurrentFirmaSession, organization, projectMatchmakerScoresForOrganization,  projectFinderGridSpec, projectLocationsMapInitJson);
            return RazorView<Index, IndexViewData>(viewData);
        }


        // All projects that match with the organization
        [LoggedInAndNotUnassignedRoleUnclassifiedFeature]
        public GridJsonNetJObjectResult<PartnerOrganizationMatchMakerScore> ProjectFinderGridFullJsonData()
        {
            var organization = CurrentFirmaSession.Person.Organization;
            var gridSpec = new ProjectFinderGridSpec();
            var projectMatchmakerScoresForOrganization = new ProjectOrganizationMatchmaker().GetPartnerOrganizationMatchMakerScoresForParticularOrganization(CurrentFirmaSession, organization);
            var gridJsonNetJObjectResult = new GridJsonNetJObjectResult<PartnerOrganizationMatchMakerScore>(projectMatchmakerScoresForOrganization, gridSpec);
            return gridJsonNetJObjectResult;
        }
       
    }

}