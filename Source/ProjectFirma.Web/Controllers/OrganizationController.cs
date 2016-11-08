using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web.Mvc;
using ProjectFirma.Web.Views.Results;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Security;
using ProjectFirma.Web.Security.Shared;
using ProjectFirma.Web.Views.Organization;
using ProjectFirma.Web.Views.Shared;
using GeoJSON.Net.Feature;
using LtInfo.Common;
using LtInfo.Common.Mvc;
using LtInfo.Common.MvcResults;
using Index = ProjectFirma.Web.Views.Organization.Index;
using IndexGridSpec = ProjectFirma.Web.Views.Organization.IndexGridSpec;
using IndexViewData = ProjectFirma.Web.Views.Organization.IndexViewData;

namespace ProjectFirma.Web.Controllers
{
    public class OrganizationController : FirmaBaseController
    {
        [OrganizationViewFeature]
        public ViewResult Index()
        {
            var firmaPage = FirmaPage.GetFirmaPageByPageType(FirmaPageType.OrganizationsList);
            var viewData = new IndexViewData(CurrentPerson, firmaPage);
            return RazorView<Index, IndexViewData>(viewData);
        }

        [OrganizationViewFeature]
        public GridJsonNetJObjectResult<Organization> IndexGridJsonData()
        {
            IndexGridSpec gridSpec;
            var organizations = GetOrganizationsAndGridSpec(out gridSpec, CurrentPerson);
            var gridJsonNetJObjectResult = new GridJsonNetJObjectResult<Organization>(organizations, gridSpec);
            return gridJsonNetJObjectResult;
        }

        private static List<Organization> GetOrganizationsAndGridSpec(out IndexGridSpec gridSpec, Person currentPerson)
        {
            var hasDeleteOrganizationPermission = new OrganizationManageFeature().HasPermissionByPerson(currentPerson);
            gridSpec = new IndexGridSpec(currentPerson, hasDeleteOrganizationPermission);
            return HttpRequestStorage.DatabaseEntities.Organizations.ToList().OrderBy(x => x.DisplayName).ToList();
        }

        [HttpGet]
        [OrganizationManageFeature]
        public PartialViewResult New()
        {
            var viewModel = new EditViewModel() {IsActive = true};
            return ViewEdit(viewModel, false);
        }

        [HttpPost]
        [OrganizationManageFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult New(EditViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return ViewEdit(viewModel, true);
            }
            var organization = new Organization(String.Empty, viewModel.SectorID, true);
            viewModel.UpdateModel(organization, CurrentPerson);
            HttpRequestStorage.DatabaseEntities.Organizations.Add(organization);
            return new ModalDialogFormJsonResult();
        }

        [HttpGet]
        [OrganizationManageFeature]
        public PartialViewResult Edit(OrganizationPrimaryKey organizationPrimaryKey)
        {
            var organization = organizationPrimaryKey.EntityObject;
            var viewModel = new EditViewModel(organization);
            return ViewEdit(viewModel, organization.IsInKeystone);
        }

        [HttpPost]
        [OrganizationManageFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult Edit(OrganizationPrimaryKey organizationPrimaryKey, EditViewModel viewModel)
        {
            var organization = organizationPrimaryKey.EntityObject;
            if (!ModelState.IsValid)
            {
                return ViewEdit(viewModel, organization.IsInKeystone);
            }
            viewModel.UpdateModel(organization, CurrentPerson);
            return new ModalDialogFormJsonResult();
        }

        private PartialViewResult ViewEdit(EditViewModel viewModel, bool isInKeystone)
        {
            var sectorsAsSelectListItems = Sector.All.ToSelectList(x => x.SectorID.ToString(CultureInfo.InvariantCulture), x => x.SectorDisplayName);
            var peopleAsSelectListItems = HttpRequestStorage.DatabaseEntities.People.GetActivePeople().ToSelectListWithEmptyFirstRow(x => x.PersonID.ToString(CultureInfo.InvariantCulture), x => x.FullNameFirstLastAndOrg, "<None>").ToList();
            var viewData = new EditViewData(sectorsAsSelectListItems, peopleAsSelectListItems, isInKeystone, SitkaRoute<HelpController>.BuildUrlFromExpression(x => x.RequestOrganizationNameChange()));
            return RazorPartialView<Edit, EditViewData, EditViewModel>(viewData, viewModel);
        }

        [OrganizationViewFeature]
        public ViewResult Detail(OrganizationPrimaryKey organizationPrimaryKey)
        {
            var organization = organizationPrimaryKey.EntityObject;
            var calendarYearExpendituresLineChartViewData = GetCalendarYearExpendituresLineChartViewData(organization);

            bool hasSpatialData;
            var mapInitJson = GetMapInitJson(organization, out hasSpatialData);

            var viewData = new DetailViewData(CurrentPerson, organization, calendarYearExpendituresLineChartViewData, mapInitJson, hasSpatialData);
            return RazorView<Detail, DetailViewData>(viewData);
        }

        private static MapInitJson GetMapInitJson(Organization organization, out bool hasSpatialData)
        {
            hasSpatialData = false;
            var mapDivID = string.Format("organization_{0}_Map", organization.OrganizationID);
            var layers = new List<LayerGeoJson>();

            var projectsLayerGeoJson = GetProjectsLayerGeoJson(organization);
            if (projectsLayerGeoJson.GeoJsonFeatureCollection.Features.Any())
            {
                hasSpatialData = true;
                layers.Add(projectsLayerGeoJson);
            }
            

            var projectDetails = organization.ProjectFundingOrganizations.SelectMany(x => x.Project.GetProjectLocationDetails()).ToGeoJsonFeatureCollection();
            if (projectDetails.Features.Any())
            {
                hasSpatialData = true;
                layers.Add(new LayerGeoJson("Project Detailed Mapping", projectDetails, "blue", 1, LayerInitialVisibility.Hide));
            }

            layers.AddRange(MapInitJson.GetWatershedAndJurisdictionMapLayers());

            BoundingBox boundingBox;
            if (organization.Jurisdiction != null && organization.Jurisdiction.JurisdictionFeature != null)
            {
                hasSpatialData = true;
                layers.Add(new LayerGeoJson("Jurisdiction Boundary", Jurisdiction.ToGeoJsonFeatureCollection(new List<Jurisdiction>() { organization.Jurisdiction }), "#800000", 1, LayerInitialVisibility.Show));
                boundingBox = new BoundingBox(organization.Jurisdiction.JurisdictionFeature);
            }
            else
            {
                boundingBox = BoundingBox.MakeBoundingBoxFromLayerGeoJsonList(layers);
            }

            var mapInitJson = new MapInitJson(mapDivID, 10, layers, boundingBox);
            return mapInitJson;
        }

        private static LayerGeoJson GetProjectsLayerGeoJson(Organization organization)
        {
            var mappedProjects = organization.GetAllProjectOrganizations().Where(x => x.Project.ProjectLocationSimpleType != ProjectLocationSimpleType.None && x.Project.ProjectStage.ShouldShowOnMap()).ToList();
            
            var namedAreaFeatures = Project.NamedAreasToPointGeoJsonFeatureCollection(mappedProjects.Select(x => x.Project).ToList(), true);

            var featureCollection = new FeatureCollection();
            featureCollection.Features.AddRange(mappedProjects.Select(x =>
            {
                Feature feature;
                if (x.Project.ProjectLocationSimpleType == ProjectLocationSimpleType.PointOnMap)
                {
                    feature = x.Project.MakePointFeatureWithRelevantProperties(x.Project.ProjectLocationPoint, true);    
                }
                else
                {
                    feature = namedAreaFeatures.Features.Single(y =>
                    {
                        var projectID = int.Parse(y.Properties["ProjectID"].ToString());
                        return projectID == x.Project.ProjectID;
                    });
                }

                feature.Properties.Add("FeatureColor", x.IsLeadOrganization ? "#3366ff" : "#99b3ff");
                return feature;
            }).ToList());

            var projectsLayerGeoJson = new LayerGeoJson("Projects", featureCollection, "blue", 1, LayerInitialVisibility.Show);
            return projectsLayerGeoJson;
        }

        private static CalendarYearExpendituresLineChartViewData GetCalendarYearExpendituresLineChartViewData(Organization organization)
        {
            var yearRange = FirmaDateUtilities.GetRangeOfYearsForReporting();
            var projectFundingSourceExpenditures = organization.FundingSources.SelectMany(x => x.ProjectFundingSourceExpenditures);

            var chartPopupUrl = SitkaRoute<OrganizationController>.BuildUrlFromExpression(x => x.GoogleChartPopup(organization.OrganizationID));
            var googleChart = projectFundingSourceExpenditures.ToGoogleChart(x => x.FundingSource.FundingSourceName,
                organization.FundingSources.Select(x => x.FundingSourceName).ToList(),
                x => x.FundingSource.FundingSourceName,
                yearRange,
                "ReportedExpendituresChart",
                organization.DisplayName,
                chartPopupUrl);

            return new CalendarYearExpendituresLineChartViewData(googleChart, FirmaHelpers.DefaultColorRange);
        }

        [HttpGet]
        [OrganizationManageFeature]
        public PartialViewResult DeleteOrganization(OrganizationPrimaryKey organizationPrimaryKey)
        {
            var organization = organizationPrimaryKey.EntityObject;
            var viewModel = new ConfirmDialogFormViewModel(organization.OrganizationID);
            return ViewDeleteOrganization(organization, viewModel);
        }

        private PartialViewResult ViewDeleteOrganization(Organization organization, ConfirmDialogFormViewModel viewModel)
        {
            var canDelete = !organization.HasDependentObjects();
            var confirmMessage = canDelete
                ? String.Format("Are you sure you want to delete this Organization '{0}'?", organization.OrganizationName)
                : ConfirmDialogFormViewData.GetStandardCannotDeleteMessage("Organization", SitkaRoute<OrganizationController>.BuildLinkFromExpression(x => x.Detail(organization), "here"));

            var viewData = new ConfirmDialogFormViewData(confirmMessage, canDelete);
            return RazorPartialView<ConfirmDialogForm, ConfirmDialogFormViewData, ConfirmDialogFormViewModel>(viewData, viewModel);
        }

        [HttpPost]
        [OrganizationManageFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult DeleteOrganization(OrganizationPrimaryKey organizationPrimaryKey, ConfirmDialogFormViewModel viewModel)
        {
            var organization = organizationPrimaryKey.EntityObject;
            if (!ModelState.IsValid)
            {
                return ViewDeleteOrganization(organization, viewModel);
            }
            HttpRequestStorage.DatabaseEntities.Organizations.Remove(organization);
            return new ModalDialogFormJsonResult();
        }

        [OrganizationViewFeature]
        public GridJsonNetJObjectResult<ProjectImplementingOrganizationOrProjectFundingOrganization> ProjectOrganizationsGridJsonData(OrganizationPrimaryKey organizationPrimaryKey)
        {
            ProjectOrganizationsGridSpec gridSpec;
            var projectOrganizations = GetProjectOrganizationsAndGridSpec(out gridSpec, organizationPrimaryKey.EntityObject);
            var gridJsonNetJObjectResult = new GridJsonNetJObjectResult<ProjectImplementingOrganizationOrProjectFundingOrganization>(projectOrganizations, gridSpec);
            return gridJsonNetJObjectResult;
        }

        private static List<ProjectImplementingOrganizationOrProjectFundingOrganization> GetProjectOrganizationsAndGridSpec(out ProjectOrganizationsGridSpec gridSpec,
            Organization organization)
        {
            gridSpec = new ProjectOrganizationsGridSpec(organization.GetCalendarYearsForProjectExpenditures());
            return organization.GetAllProjectOrganizations().ToList();
        }

        [HttpGet]
        [AnonymousUnclassifiedFeature]
        public PartialViewResult GoogleChartPopup(OrganizationPrimaryKey organizationPrimaryKey)
        {
            var organization = organizationPrimaryKey.EntityObject;
            var yearRange = FirmaDateUtilities.GetRangeOfYearsForReporting();
            var projectFundingSourceExpenditures = organization.FundingSources.SelectMany(x => x.ProjectFundingSourceExpenditures);

            var googleChart = projectFundingSourceExpenditures.ToGoogleChart(x => x.FundingSource.FundingSourceName,
                organization.FundingSources.Select(x => x.FundingSourceName).ToList(),
                x => x.FundingSource.FundingSourceName,
                yearRange,
                "ReportedExpendituresChart",
                organization.DisplayName, String.Empty);

            var viewData = new GoogleChartPopupViewData(googleChart);
            return RazorPartialView<GoogleChartPopup, GoogleChartPopupViewData>(viewData);
        }
    }
}