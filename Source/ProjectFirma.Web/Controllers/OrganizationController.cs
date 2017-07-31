/*-----------------------------------------------------------------------
<copyright file="OrganizationController.cs" company="Tahoe Regional Planning Agency">
Copyright (c) Tahoe Regional Planning Agency. All rights reserved.
<author>Sitka Technology Group</author>
</copyright>

<license>
This program is free software: you can redistribute it and/or modify
it under the terms of the GNU Affero General Public License as published by
the Free Software Foundation, either version 3 of the License, or
(at your option) any later version.

This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU Affero General Public License <http://www.gnu.org/licenses/> for more details.

Source code is available upon request via <support@sitkatech.com>.
</license>
-----------------------------------------------------------------------*/

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web.Mvc;
using GeoJSON.Net.Feature;
using LtInfo.Common;
using LtInfo.Common.Models;
using LtInfo.Common.Mvc;
using LtInfo.Common.MvcResults;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.KeystoneDataService;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Security;
using ProjectFirma.Web.Security.Shared;
using ProjectFirma.Web.Views.Organization;
using ProjectFirma.Web.Views.Results;
using ProjectFirma.Web.Views.Shared;
using Detail = ProjectFirma.Web.Views.Organization.Detail;
using DetailViewData = ProjectFirma.Web.Views.Organization.DetailViewData;
using Index = ProjectFirma.Web.Views.Organization.Index;
using IndexGridSpec = ProjectFirma.Web.Views.Organization.IndexGridSpec;
using IndexViewData = ProjectFirma.Web.Views.Organization.IndexViewData;
using Organization = ProjectFirma.Web.Models.Organization;

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
            var hasDeleteOrganizationPermission = new OrganizationManageFeature().HasPermissionByPerson(CurrentPerson);
            var gridSpec = new IndexGridSpec(CurrentPerson, hasDeleteOrganizationPermission);
            var organizations = HttpRequestStorage.DatabaseEntities.Organizations.ToList().OrderBy(x => x.DisplayName).ToList();
            var gridJsonNetJObjectResult = new GridJsonNetJObjectResult<Organization>(organizations, gridSpec);
            return gridJsonNetJObjectResult;
        }

        [HttpGet]
        [OrganizationManageFeature]
        public PartialViewResult New()
        {
            var viewModel = new EditViewModel {IsActive = true};
            return ViewEdit(viewModel, false, null);
        }

        [HttpPost]
        [OrganizationManageFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult New(EditViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return ViewEdit(viewModel, true, null);
            }
            var organization = new Organization(String.Empty, true);
            viewModel.UpdateModel(organization, CurrentPerson);
            HttpRequestStorage.DatabaseEntities.AllOrganizations.Add(organization);
            HttpRequestStorage.DatabaseEntities.SaveChanges();
            SetMessageForDisplay($"Organization {organization.DisplayName} succesfully created.");

            return new ModalDialogFormJsonResult();
        }

        [HttpGet]
        [OrganizationManageFeature]
        public PartialViewResult Edit(OrganizationPrimaryKey organizationPrimaryKey)
        {
            var organization = organizationPrimaryKey.EntityObject;
            var viewModel = new EditViewModel(organization);
            return ViewEdit(viewModel, organization.IsInKeystone, organization.PrimaryContactPerson);
        }

        [HttpPost]
        [OrganizationManageFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult Edit(OrganizationPrimaryKey organizationPrimaryKey, EditViewModel viewModel)
        {
            var organization = organizationPrimaryKey.EntityObject;
            if (!ModelState.IsValid)
            {
                return ViewEdit(viewModel, organization.IsInKeystone, organization.PrimaryContactPerson);
            }
            viewModel.UpdateModel(organization, CurrentPerson);
            return new ModalDialogFormJsonResult();
        }

        private PartialViewResult ViewEdit(EditViewModel viewModel, bool isInKeystone, Person currentPrimaryContactPerson)
        {
            var organizationTypesAsSelectListItems = HttpRequestStorage.DatabaseEntities.OrganizationTypes
                .OrderBy(x => x.OrganizationTypeName)
                .ToSelectListWithEmptyFirstRow(x => x.OrganizationTypeID.ToString(CultureInfo.InvariantCulture),
                    x => x.OrganizationTypeName);
            var activePeople = HttpRequestStorage.DatabaseEntities.People.GetActivePeople();
            if (currentPrimaryContactPerson != null && !activePeople.Contains(currentPrimaryContactPerson))
            {
                activePeople.Add(currentPrimaryContactPerson);
            }
            var people = activePeople.OrderBy(x => x.FullNameLastFirst).ToSelectListWithEmptyFirstRow(x => x.PersonID.ToString(CultureInfo.InvariantCulture),
                x => x.FullNameFirstLastAndOrg);
            var isSitkaAdmin = new SitkaAdminFeature().HasPermissionByPerson(CurrentPerson);
            var viewData = new EditViewData(organizationTypesAsSelectListItems, people, isInKeystone, SitkaRoute<HelpController>.BuildUrlFromExpression(x => x.RequestOrganizationNameChange()), isSitkaAdmin);
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
            
            var layers = new List<LayerGeoJson>();

            if (organization.OrganizationBoundary != null)
            {
                hasSpatialData = true;
                layers.Add(new LayerGeoJson("Organization Boundary",
                    organization.OrganizationBoundaryToFeatureCollection, organization.OrganizationType?.LegendColor ?? FirmaHelpers.DefaultColorRange.First(), 1,
                    LayerInitialVisibility.Show));
            }

            var projectsLayerGeoJson = GetProjectsLayerGeoJson(organization);
            if (projectsLayerGeoJson.GeoJsonFeatureCollection.Features.Any())
            {
                hasSpatialData = true;
                layers.Add(projectsLayerGeoJson);
            }

            var projectDetails = organization.ProjectOrganizations.SelectMany(x => x.Project.GetProjectLocationDetails()).ToGeoJsonFeatureCollection();
            if (projectDetails.Features.Any())
            {
                hasSpatialData = true;
                layers.Add(new LayerGeoJson($"{FieldDefinition.Project.GetFieldDefinitionLabel()} Detailed Mapping", projectDetails, "blue", 1, LayerInitialVisibility.Hide));
            }

            var boundingBox = BoundingBox.MakeBoundingBoxFromLayerGeoJsonList(layers);

            layers.AddRange(MapInitJson.GetWatershedMapLayers());

            return new MapInitJson($"organization_{organization.OrganizationID}_Map", 10, layers, boundingBox);
        }

        private static LayerGeoJson GetProjectsLayerGeoJson(Organization organization)
        {
            var relatedProjects = organization.GetAllProjectOrganizations().Where(x => x.Project.ProjectLocationSimpleType != ProjectLocationSimpleType.None && x.Project.ProjectStage.ShouldShowOnMap()).Select(x => x.Project).ToList();
            var leadImplementerProjects = organization.ProjectsWhereYouAreTheLeadImplementerOrganization.Where(x => x.ProjectLocationSimpleType != ProjectLocationSimpleType.None && x.ProjectStage.ShouldShowOnMap()).ToList();
            var relatedProjectsThatAreNotInLeadImplementerProjects = relatedProjects.Where(x => leadImplementerProjects.All(y => y.ProjectID != x.ProjectID));
            var namedAreaFeatures = Project.NamedAreasToPointGeoJsonFeatureCollection(relatedProjects.Union(leadImplementerProjects, new HavePrimaryKeyComparer<Project>()).ToList(), true);

            var featureCollection = new FeatureCollection();
            AddToProjectsFeatureCollection(featureCollection, relatedProjectsThatAreNotInLeadImplementerProjects, namedAreaFeatures, "#99b3ff");
            AddToProjectsFeatureCollection(featureCollection, leadImplementerProjects, namedAreaFeatures, "#3366ff");
            var projectsLayerGeoJson = new LayerGeoJson("Projects", featureCollection, "blue", 1, LayerInitialVisibility.Show);
            return projectsLayerGeoJson;
        }

        private static void AddToProjectsFeatureCollection(FeatureCollection featureCollection, IEnumerable<Project> projectsToAdd,
            FeatureCollection namedAreaFeatures, string featureColor)
        {
            featureCollection.Features.AddRange(projectsToAdd.Select(x =>
            {
                Feature feature;
                if (x.ProjectLocationSimpleType == ProjectLocationSimpleType.PointOnMap)
                {
                    feature = x.MakePointFeatureWithRelevantProperties(x.ProjectLocationPoint, true);
                }
                else
                {
                    feature = namedAreaFeatures.Features.Single(y =>
                    {
                        var projectID = int.Parse(y.Properties["ProjectID"].ToString());
                        return projectID == x.ProjectID;
                    });
                }

                feature.Properties.Add("FeatureColor", featureColor);
                return feature;
            }).ToList());
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
            var canDelete = !organization.HasDependentObjects() && !organization.IsUnknown;
            var confirmMessage = canDelete
                ? $"Are you sure you want to delete this {FieldDefinition.Organization.GetFieldDefinitionLabel()} '{organization.OrganizationName}'?"
                : ConfirmDialogFormViewData.GetStandardCannotDeleteMessage($"{FieldDefinition.Organization.GetFieldDefinitionLabel()}", SitkaRoute<OrganizationController>.BuildLinkFromExpression(x => x.Detail(organization), "here"));

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
            organization.DeleteOrganization();
            return new ModalDialogFormJsonResult();
        }

        [OrganizationViewFeature]
        public GridJsonNetJObjectResult<ProjectOrganization> ProjectOrganizationsGridJsonData(OrganizationPrimaryKey organizationPrimaryKey)
        {
            ProjectOrganizationsGridSpec gridSpec;
            var projectOrganizations = GetProjectOrganizationsAndGridSpec(out gridSpec, organizationPrimaryKey.EntityObject);
            var gridJsonNetJObjectResult = new GridJsonNetJObjectResult<ProjectOrganization>(projectOrganizations, gridSpec);
            return gridJsonNetJObjectResult;
        }

        private static List<ProjectOrganization> GetProjectOrganizationsAndGridSpec(out ProjectOrganizationsGridSpec gridSpec,
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

        [HttpGet]
        [SitkaAdminFeature]
        public PartialViewResult PullOrganizationFromKeystone()
        {
            var viewModel = new PullOrganizationFromKeystoneViewModel();

            return ViewPullOrganizationFromKeystone(viewModel);
        }

        [HttpPost]
        [SitkaAdminFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult PullOrganizationFromKeystone(PullOrganizationFromKeystoneViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return ViewPullOrganizationFromKeystone(viewModel);
            }

            var keystoneClient = new KeystoneDataClient();

            var organizationGuid = viewModel.OrganizationGuid.Value;
            KeystoneDataService.Organization keystoneOrganization;
            try
            {
                keystoneOrganization = keystoneClient.GetOrganization(organizationGuid);
            }
            catch (Exception)
            {
                SetErrorForDisplay("Organization not added. Guid not found in Keystone or unable to connect to Keystone");
                return new ModalDialogFormJsonResult();
            }

            var firmaOrganization = HttpRequestStorage.DatabaseEntities.Organizations.SingleOrDefault(x => x.OrganizationGuid == organizationGuid);
            if (firmaOrganization != null)
            {
                SetErrorForDisplay("Organization not added - it already exists in ProjectFirma");
                return new ModalDialogFormJsonResult();
            }

            firmaOrganization = new Organization(keystoneOrganization.FullName, true)
            {
                OrganizationGuid = keystoneOrganization.OrganizationGuid,
                OrganizationShortName = keystoneOrganization.ShortName,
                OrganizationUrl = keystoneOrganization.URL
            };
            HttpRequestStorage.DatabaseEntities.AllOrganizations.Add(firmaOrganization);

            HttpRequestStorage.DatabaseEntities.SaveChanges();

            SetMessageForDisplay($"Organization {firmaOrganization.GetDisplayNameAsUrl()} successfully added.");

            return new ModalDialogFormJsonResult();
        }

        private PartialViewResult ViewPullOrganizationFromKeystone(PullOrganizationFromKeystoneViewModel viewModel)
        {
            var viewData = new PullOrganizationFromKeystoneViewData();
            return RazorPartialView<PullOrganizationFromKeystone, PullOrganizationFromKeystoneViewData, PullOrganizationFromKeystoneViewModel>(viewData, viewModel);
        }

        [HttpGet]
        [OrganizationManageFeature]
        public ViewResult EditBoundary(OrganizationPrimaryKey organizationPrimaryKey) {
            var viewModel = new EditBoundaryViewModel();
            var viewData = new EditBoundaryViewData(CurrentPerson, organizationPrimaryKey.EntityObject);
            return RazorView<EditBoundary, EditBoundaryViewData, EditBoundaryViewModel>(viewData, viewModel);
        }

        [HttpPost]
        [OrganizationManageFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult EditBoundary(OrganizationPrimaryKey organizationPrimaryKey, EditBoundaryViewModel viewModel)
        {
            var organization = organizationPrimaryKey.EntityObject;
            if (!ModelState.IsValid)
            {
                var viewData = new EditBoundaryViewData(CurrentPerson, organization);
                return RazorPartialView<EditBoundaryErrors, EditBoundaryViewData, EditBoundaryViewModel>(viewData, viewModel);
            }

            viewModel.UpdateModel(organization);

            return RedirectToAction(new SitkaRoute<OrganizationController>(c => c.ApproveUploadGis(organizationPrimaryKey)));
        }

        [HttpGet]
        [OrganizationManageFeature]
        public PartialViewResult ApproveUploadGis(OrganizationPrimaryKey organizationPrimaryKey)
        {
            var organization = organizationPrimaryKey.EntityObject;
            var viewModel = new ApproveUploadGisViewModel();
            return ViewApproveUploadGis(viewModel, organization);
        }

        [HttpPost]
        [OrganizationManageFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult ApproveUploadGis(OrganizationPrimaryKey organizationPrimaryKey, ApproveUploadGisViewModel viewModel)
        {
            var organization = organizationPrimaryKey.EntityObject;
            if (!ModelState.IsValid)
            {
                return ViewApproveUploadGis(viewModel, organization);
            }

            viewModel.UpdateModel(organization);

            SetMessageForDisplay($"Organization Boundary for {organization.GetDisplayNameAsUrl()} successfully updated.");
            return new ContentResult();
        }
        private PartialViewResult ViewApproveUploadGis(ApproveUploadGisViewModel viewModel, Organization organization)
        {
            var layers = organization.OrganizationBoundaryStagings.Select((x, index) => new LayerGeoJson(
                x.FeatureClassName, x.ToGeoJsonFeatureCollection(),
                FirmaHelpers.DefaultColorRange[index], 0.8m,
                index == 0 ? LayerInitialVisibility.Show : LayerInitialVisibility.Hide)).ToList();
            var mapInitJson = new MapInitJson("organizationBoundaryApproveUploadGisMap", 10, layers, BoundingBox.MakeBoundingBoxFromLayerGeoJsonList(layers));

            var viewData = new ApproveUploadGisViewData(CurrentPerson, organization, mapInitJson);
            return RazorPartialView<ApproveUploadGis, ApproveUploadGisViewData, ApproveUploadGisViewModel>(viewData, viewModel);
        }

        [HttpGet]
        [OrganizationManageFeature]
        public PartialViewResult DeleteOrganizationBoundary(OrganizationPrimaryKey organizationPrimaryKey)
        {
            var organization = organizationPrimaryKey.EntityObject;
            var viewModel = new ConfirmDialogFormViewModel(organization.OrganizationID);
            return ViewDeleteOrganizationBoundary(organization, viewModel);
        }

        [HttpPost]
        [OrganizationManageFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult DeleteOrganizationBoundary(OrganizationPrimaryKey organizationPrimaryKey,
            ConfirmDialogFormViewModel viewModel)
        {
            var organization = organizationPrimaryKey.EntityObject;
            if (!ModelState.IsValid)
            {
                return ViewDeleteOrganizationBoundary(organization, viewModel);
            }

            organization.OrganizationBoundary = null;

            return new ModalDialogFormJsonResult();
        }

        private PartialViewResult ViewDeleteOrganizationBoundary(Organization organization,
            ConfirmDialogFormViewModel viewModel)
        {
            var viewData = new ConfirmDialogFormViewData(
                $"Are you sure you want to delete the boundary for this {FieldDefinition.Organization.GetFieldDefinitionLabel()} '{organization.OrganizationName}'?");
            return RazorPartialView<ConfirmDialogForm, ConfirmDialogFormViewData, ConfirmDialogFormViewModel>(viewData,
                viewModel);
        }
    }
}
