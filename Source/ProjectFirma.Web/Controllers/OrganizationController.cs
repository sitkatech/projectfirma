﻿/*-----------------------------------------------------------------------
<copyright file="OrganizationController.cs" company="Tahoe Regional Planning Agency and Environmental Science Associates">
Copyright (c) Tahoe Regional Planning Agency and Environmental Science Associates. All rights reserved.
<author>Environmental Science Associates</author>
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

using GeoJSON.Net.Feature;
using LtInfo.Common;
using LtInfo.Common.Models;
using LtInfo.Common.Mvc;
using LtInfo.Common.MvcResults;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.KeystoneDataService;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Security;
using ProjectFirma.Web.Views.Organization;
using ProjectFirma.Web.Views.Shared;
using ProjectFirmaModels.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Spatial;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using LtInfo.Common.DbSpatial;
using LtInfo.Common.GeoJson;
using MoreLinq;
using ProjectFirma.Web.Views.Shared.SortOrder;
using ProjectFirma.Web.Views.Shared.TextControls;
using Detail = ProjectFirma.Web.Views.Organization.Detail;
using Index = ProjectFirma.Web.Views.Organization.Index;
using IndexViewData = ProjectFirma.Web.Views.Organization.IndexViewData;
using Organization = ProjectFirmaModels.Models.Organization;

namespace ProjectFirma.Web.Controllers
{
    public class OrganizationController : FirmaBaseController
    {
        [OrganizationViewFeature]
        public ViewResult Index()
        {
            var firmaPage = FirmaPageTypeEnum.OrganizationsList.GetFirmaPage();
            var gridDataUrl = SitkaRoute<OrganizationController>.BuildUrlFromExpression(x => x.IndexGridJsonData(OrganizationIndexGridSpec.OrganizationStatusFilterTypeEnum.ActiveOrganizations));
            var activeOrAllOrganizationsSelectListItems = new List<SelectListItem>()
            {
                new SelectListItem() {Text = "Active Organizations Only", Value = SitkaRoute<OrganizationController>.BuildUrlFromExpression(x => x.IndexGridJsonData(OrganizationIndexGridSpec.OrganizationStatusFilterTypeEnum.ActiveOrganizations))},
                new SelectListItem() {Text = "All Organizations", Value = SitkaRoute<OrganizationController>.BuildUrlFromExpression(x => x.IndexGridJsonData(OrganizationIndexGridSpec.OrganizationStatusFilterTypeEnum.AllOrganizations))}
            };

            var viewData = new IndexViewData(CurrentFirmaSession, firmaPage, gridDataUrl, activeOrAllOrganizationsSelectListItems);
            return RazorView<Index, IndexViewData>(viewData);
        }

        [OrganizationViewFeature]
        public GridJsonNetJObjectResult<Organization> IndexGridJsonData(OrganizationIndexGridSpec.OrganizationStatusFilterTypeEnum organizationStatusFilterType)
        {
            var hasDeleteOrganizationPermission = new OrganizationManageFeature().HasPermissionByFirmaSession(CurrentFirmaSession);
            var gridSpec = new OrganizationIndexGridSpec(CurrentFirmaSession, hasDeleteOrganizationPermission);
            var organizations = HttpRequestStorage.DatabaseEntities.Organizations
                .Include(x => x.PrimaryContactPerson)
                .Include(x => x.ProjectOrganizations.Select(y => y.Project))
                .ToList();

            switch (organizationStatusFilterType)
            {
                case OrganizationIndexGridSpec.OrganizationStatusFilterTypeEnum.ActiveOrganizations:
                    organizations = organizations.Where(x => x.IsActive).ToList();
                    break;
                case OrganizationIndexGridSpec.OrganizationStatusFilterTypeEnum.AllOrganizations:
                    break;
                default:
                    throw new ArgumentOutOfRangeException("organizationStatusFilterType", organizationStatusFilterType,
                        null);
            }

            var gridJsonNetJObjectResult = new GridJsonNetJObjectResult<Organization>(organizations.OrderBy(x => x.GetDisplayName()).ToList(), gridSpec);
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
                return ViewEdit(viewModel, false, null);
            }
            var organization = new Organization(String.Empty, true, ModelObjectHelpers.NotYetAssignedID, Organization.UseOrganizationBoundaryForMatchmakerDefault, false);
            viewModel.UpdateModel(organization, CurrentFirmaSession, HttpRequestStorage.DatabaseEntities);
            HttpRequestStorage.DatabaseEntities.AllOrganizations.Add(organization);
            HttpRequestStorage.DatabaseEntities.SaveChanges();
            SetMessageForDisplay($"Organization {organization.GetDisplayNameAsUrl()} successfully created.");

            return new ModalDialogFormJsonResult();
        }

        [HttpGet]
        [OrganizationManageFeature]
        public PartialViewResult Edit(OrganizationPrimaryKey organizationPrimaryKey)
        {
            var organization = organizationPrimaryKey.EntityObject;
            var viewModel = new EditViewModel(organization);
            return ViewEdit(viewModel, organization.IsInKeystone(), organization.PrimaryContactPerson);
        }

        [HttpPost]
        [OrganizationManageFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult Edit(OrganizationPrimaryKey organizationPrimaryKey, EditViewModel viewModel)
        {
            var organization = organizationPrimaryKey.EntityObject;
            if (!ModelState.IsValid)
            {
                return ViewEdit(viewModel, organization.IsInKeystone(), organization.PrimaryContactPerson);
            }
            viewModel.UpdateModel(organization, CurrentFirmaSession, HttpRequestStorage.DatabaseEntities);
            return new ModalDialogFormJsonResult();
        }

        private PartialViewResult ViewEdit(EditViewModel viewModel, bool isInKeystone, Person currentPrimaryContactPerson)
        {
            var organizationTypesAsSelectListItems = HttpRequestStorage.DatabaseEntities.OrganizationTypes
                .OrderBy(x => x.OrganizationTypeName)
                .ToSelectListWithEmptyFirstRow(x => x.OrganizationTypeID.ToString(CultureInfo.InvariantCulture),
                    x => x.OrganizationTypeName);
            var activePeople = HttpRequestStorage.DatabaseEntities.People.GetActivePeople();
            var activePeopleWithAssignedRoles = activePeople.Where(ap => ap.Role != Role.Unassigned).ToList();
            if (currentPrimaryContactPerson != null && !activePeopleWithAssignedRoles.Contains(currentPrimaryContactPerson))
            {
                activePeopleWithAssignedRoles.Add(currentPrimaryContactPerson);
            }
            var possiblePrimaryContactPeople = activePeopleWithAssignedRoles.OrderBy(x => x.GetFullNameLastFirst()).ToSelectListWithEmptyFirstRow(x => x.PersonID.ToString(CultureInfo.InvariantCulture),
                x => x.GetFullNameFirstLastAndOrg());
            var isSitkaAdmin = new SitkaAdminFeature().HasPermissionByFirmaSession(CurrentFirmaSession);
            var userHasAdminPermissions = new FirmaAdminFeature().HasPermissionByFirmaSession(CurrentFirmaSession);
            string requestOrganizationChangeUrl = SitkaRoute<HelpController>.BuildUrlFromExpression(x => x.RequestOrganizationNameChange());
            var viewData = new EditViewData(organizationTypesAsSelectListItems, possiblePrimaryContactPeople, isInKeystone, requestOrganizationChangeUrl, isSitkaAdmin, userHasAdminPermissions, viewModel.KeystoneOrganizationGuid);
            return RazorPartialView<Edit, EditViewData, EditViewModel>(viewData, viewModel);
        }

        #region Matchmaker Profile Taxonomy

        [HttpGet]
        [OrganizationProfileViewEditFeature]
        public PartialViewResult EditProfileSupplementalInformation(OrganizationPrimaryKey organizationPrimaryKey)
        {
            var organization = organizationPrimaryKey.EntityObject;
            var viewModel = new EditProfileSupplementalInformationViewModel(organization);
            return ViewEditProfileSupplementalInformation(viewModel);
        }

        [HttpPost]
        [OrganizationProfileViewEditFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult EditProfileSupplementalInformation(OrganizationPrimaryKey organizationPrimaryKey, EditProfileSupplementalInformationViewModel viewModel)
        {
            var organization = organizationPrimaryKey.EntityObject;
            if (!ModelState.IsValid)
            {
                return ViewEditProfileSupplementalInformation(viewModel);
            }

            viewModel.UpdateModel(organization);
            return new ModalDialogFormJsonResult(SitkaRoute<OrganizationController>.BuildUrlFromExpression(x => x.Detail(organization, OrganizationDetailViewData.OrganizationDetailTab.Profile)));
        }

        private PartialViewResult ViewEditProfileSupplementalInformation(EditProfileSupplementalInformationViewModel viewModel)
        {
            var viewData = new EditProfileSupplementalInformationViewData();
            return RazorPartialView<EditProfileSupplementalInformation, EditProfileSupplementalInformationViewData, EditProfileSupplementalInformationViewModel>(viewData, viewModel);
        }

        [HttpGet]
        [OrganizationProfileViewEditFeature]
        public PartialViewResult EditProfileTaxonomy(OrganizationPrimaryKey organizationPrimaryKey)
        {
            var organization = organizationPrimaryKey.EntityObject;
            var taxonomyCompoundKeys = new List<string>();
            taxonomyCompoundKeys.AddRange(organization.MatchmakerOrganizationTaxonomyTrunks.Select(x => TaxonomyTierHelpers.GetComboTreeNodeKeyFromTaxonomyLevelAndID(TaxonomyLevel.Trunk, x.TaxonomyTrunkID)));
            taxonomyCompoundKeys.AddRange(organization.MatchmakerOrganizationTaxonomyBranches.Select(x => TaxonomyTierHelpers.GetComboTreeNodeKeyFromTaxonomyLevelAndID(TaxonomyLevel.Branch, x.TaxonomyBranchID)));
            taxonomyCompoundKeys.AddRange(organization.MatchmakerOrganizationTaxonomyLeafs.Select(x => TaxonomyTierHelpers.GetComboTreeNodeKeyFromTaxonomyLevelAndID(TaxonomyLevel.Leaf, x.TaxonomyLeafID)));
        
            var viewModel = new EditProfileTaxonomyViewModel(organization, taxonomyCompoundKeys);
            return ViewEditProfileTaxonomy(viewModel);
        }
        
        [HttpPost]
        [OrganizationProfileViewEditFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult EditProfileTaxonomy(OrganizationPrimaryKey organizationPrimaryKey, EditProfileTaxonomyViewModel viewModel)
        {
            var organization = organizationPrimaryKey.EntityObject;
            if (!ModelState.IsValid)
            {
                return ViewEditProfileTaxonomy(viewModel);
            }
        
            HttpRequestStorage.DatabaseEntities.MatchmakerOrganizationTaxonomyTrunks.Load();
            var matchmakerOrganizationTaxonomyTrunks = HttpRequestStorage.DatabaseEntities.AllMatchmakerOrganizationTaxonomyTrunks.Local;
        
            HttpRequestStorage.DatabaseEntities.MatchmakerOrganizationTaxonomyBranches.Load();
            var matchmakerOrganizationTaxonomyBranches = HttpRequestStorage.DatabaseEntities.AllMatchmakerOrganizationTaxonomyBranches.Local;
        
            HttpRequestStorage.DatabaseEntities.MatchmakerOrganizationTaxonomyLeafs.Load();
            var matchmakerOrganizationTaxonomyLeafs = HttpRequestStorage.DatabaseEntities.AllMatchmakerOrganizationTaxonomyLeafs.Local;
        
            viewModel.UpdateModel(organization, matchmakerOrganizationTaxonomyTrunks, matchmakerOrganizationTaxonomyBranches, matchmakerOrganizationTaxonomyLeafs);
            return new ModalDialogFormJsonResult(SitkaRoute<OrganizationController>.BuildUrlFromExpression(x => x.Detail(organization, OrganizationDetailViewData.OrganizationDetailTab.Profile)));
        }
        
        private PartialViewResult ViewEditProfileTaxonomy(EditProfileTaxonomyViewModel viewModel)
        {
            var topLevelTaxonomyTierAsComboTreeNodes = MultiTenantHelpers.GetTaxonomyLevel()
                .GetTaxonomyTiers(HttpRequestStorage.DatabaseEntities).OrderBy(x => x.SortOrder)
                .ThenBy(x => x.DisplayName, StringComparer.InvariantCultureIgnoreCase)
                .Select(x => x.ToComboTreeNode())
                .ToList();
            var viewData = new EditProfileTaxonomyViewData(topLevelTaxonomyTierAsComboTreeNodes);
            return RazorPartialView<EditProfileTaxonomy, EditProfileTaxonomyViewData, EditProfileTaxonomyViewModel>(viewData, viewModel);
        }

        #endregion Matchmaker Profile Taxonomy











        #region Matchmaker Area of Interest

        [HttpGet]
        [OrganizationProfileViewEditFeature]
        public PartialViewResult EditMatchMakerAreaOfInterest(OrganizationPrimaryKey organizationPrimaryKey)
        {
            var organization = organizationPrimaryKey.EntityObject;
            var viewModel = new MatchmakerOrganizationLocationDetailViewModel(organization);
            return ViewEditMatchMakerAreaOfInterest(organization, viewModel);
        }

        private PartialViewResult ViewEditMatchMakerAreaOfInterest(Organization organization, MatchmakerOrganizationLocationDetailViewModel viewModel)
        {
            var mapDivID = $"organization_{organization.OrganizationID}_EditMatchMakerAreaOfInterestDiv";

            var organizationBoundaryFeatureCollection = organization.OrganizationBoundaryToFeatureCollection();
            FeatureCollection editableLayerGeoJsonFeatureCollection = DbGeometryToGeoJsonHelper.FeatureCollectionFromDbGeometry(organization.MatchMakerAreaOfInterestLocations.Select(x => x.MatchMakerAreaOfInterestLocationGeometry), "SomePropertyOrOther", "SomeValueOrOther");

            LayerInitialVisibility.LayerInitialVisibilityEnum initialVisibilityForOrgBoundary = viewModel.UseOrganizationBoundaryForMatchmaker ? LayerInitialVisibility.LayerInitialVisibilityEnum.Show : LayerInitialVisibility.LayerInitialVisibilityEnum.Hide;
            LayerInitialVisibility.LayerInitialVisibilityEnum initialVisibilityForUserEditedBoundary = !viewModel.UseOrganizationBoundaryForMatchmaker ? LayerInitialVisibility.LayerInitialVisibilityEnum.Show : LayerInitialVisibility.LayerInitialVisibilityEnum.Hide;

            var orgBoundaryLayerGeoJson = new LayerGeoJson($"{FieldDefinitionEnum.Organization.ToType().GetFieldDefinitionLabel()} Boundary Geometry", organizationBoundaryFeatureCollection, "red", 1, initialVisibilityForOrgBoundary);
            LayerGeoJson editableLayerGeoJson = new LayerGeoJson($"{FieldDefinitionEnum.Organization.ToType().GetFieldDefinitionLabel()} {FieldDefinitionEnum.AreaOfInterest.ToType().GetFieldDefinitionLabel()} Geometries", editableLayerGeoJsonFeatureCollection, "red", 1, initialVisibilityForUserEditedBoundary);

            var layers = MapInitJson.GetConfiguredGeospatialAreaMapLayers();
            // Maybe show all Org project layers here? Consider doing later.
            //layers.AddRange(MapInitJson.GetProjectLocationSimpleMapLayer(project));
            //BoundingBox boundingBox = ProjectLocationSummaryMapInitJson.GetProjectBoundingBox(project);
            var boundingBox = new BoundingBox(organization.OrganizationBoundary);
            var mapInitJson = new MapInitJson(mapDivID, 10, layers, MapInitJson.GetExternalMapLayerSimples(), boundingBox)
            {
                AllowFullScreen = false,
                DisablePopups = true
            };

            var mapFormID = GenerateEditOrganizationMatchMakerAreaOfInterestFormID(organization);
            //var uploadGisFileUrl = SitkaRoute<ProjectLocationController>.BuildUrlFromExpression(c => c.ImportGdbFile(project.GetEntityID()));
            var saveFeatureCollectionUrl = SitkaRoute<OrganizationController>.BuildUrlFromExpression(x => x.EditMatchMakerAreaOfInterest(organization.OrganizationID, null));

            var viewData = new MatchmakerOrganizationLocationDetailViewData(organization, mapInitJson, orgBoundaryLayerGeoJson, mapFormID, saveFeatureCollectionUrl, ProjectLocation.FieldLengths.Annotation, editableLayerGeoJson);
            return RazorPartialView<MatchmakerOrganizationLocationDetail, MatchmakerOrganizationLocationDetailViewData, MatchmakerOrganizationLocationDetailViewModel>(viewData, viewModel);
        }

        public static string GenerateEditOrganizationMatchMakerAreaOfInterestFormID(Organization organization)
        {
            return $"editOrganizationAreaOfInterestMap_{organization.OrganizationID}";
        }

        [HttpPost]
        [OrganizationProfileViewEditFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult EditMatchMakerAreaOfInterest(OrganizationPrimaryKey organizationPrimaryKey, MatchmakerOrganizationLocationDetailViewModel viewModel)
        {
            var organization = organizationPrimaryKey.EntityObject;
            if (!ModelState.IsValid)
            {
                return ViewEditMatchMakerAreaOfInterest(organization, viewModel);
            }
            organization.UseOrganizationBoundaryForMatchmaker = viewModel.UseOrganizationBoundaryForMatchmaker;
            SaveOrganizationAreaOfInterestDetailedLocations(viewModel, organization, out bool hadToMakeValid, out bool oneWasBad);
            SetMessageForDisplay("Area of Interest successfully updated.");
            if (hadToMakeValid && !oneWasBad)
            {
                SetWarningForDisplay("One or more of your hand drawn shapes had to be corrected in order to make it a valid geometry. Most likely this resulted in no noticeable changes, but please review the area of interest to verify.");
            }
            if (oneWasBad && !hadToMakeValid)
            {
                SetWarningForDisplay("One or more of your hand drawn shapes could not be made into a valid geometry and was not saved. All other shapes were saved. Please review the area of interest to verify.");
            }

            if (oneWasBad && hadToMakeValid)
            {
                SetWarningForDisplay("One or more of your hand drawn shapes had to be corrected in order to make it a valid geometry. Most likely this resulted in no noticeable changes." +
                                     " Additionally, one or more of your hand drawn shapes could not be made into a valid geometry and was not saved. All other shapes were saved. Please review the area of interest to verify.");
            }
            return new ModalDialogFormJsonResult(SitkaRoute<OrganizationController>.BuildUrlFromExpression(x => x.Detail(organization, OrganizationDetailViewData.OrganizationDetailTab.Profile)));
        }

        private static void SaveOrganizationAreaOfInterestDetailedLocations(MatchmakerOrganizationLocationDetailViewModel viewModel, Organization organization, out bool hadToMakeValid, out bool atLeastOneCouldNotBeCorrected)
        {
            hadToMakeValid = false;
            atLeastOneCouldNotBeCorrected = false;
            // It's only appropriate to delete the hand drawn boundary if they are actually currently using it.
            // Otherwise, just keep the last-known value around in case they change their mind and toggle back to it.
            if (!viewModel.UseOrganizationBoundaryForMatchmaker)
            {
                foreach (var organizationLocation in organization.MatchMakerAreaOfInterestLocations.ToList())
                {
                    organizationLocation.DeleteFull(HttpRequestStorage.DatabaseEntities);
                }
            }

            if (viewModel.WktAndOtherInfos != null)
            {
                foreach (var wktAndOtherInfo in viewModel.WktAndOtherInfos)
                {
                    // We only save user-drawn layer info for now. Everything else (Organizational boundary) originates elsewhere.
                    if (wktAndOtherInfo.LayerSource == MatchmakerOrganizationLocationDetailViewModel.WktAndOtherInfo.LayerSourceUserDrawn)
                    {
                        DbGeometry dbGeom = null;
                        try
                        {
                            dbGeom = DbGeometry.FromText(wktAndOtherInfo.Wkt,
                                LtInfoGeometryConfiguration.DefaultCoordinateSystemId);
                        }
                        catch
                        {
                            atLeastOneCouldNotBeCorrected = true;
                        }

                        if (dbGeom != null)
                        {
                            if (!dbGeom.IsValid)
                            {
                                var sqlInvalid = dbGeom.ToSqlGeometry();
                                var sqlValid = sqlInvalid.MakeValid();
                                var dbGeomValid =
                                    sqlValid.ToDbGeometry(LtInfoGeometryConfiguration.DefaultCoordinateSystemId);
                                organization.MatchMakerAreaOfInterestLocations.Add(new MatchMakerAreaOfInterestLocation(organization, dbGeomValid));
                                hadToMakeValid = true;
                            }
                            else
                            {
                                organization.MatchMakerAreaOfInterestLocations.Add(new MatchMakerAreaOfInterestLocation(organization, dbGeom));
                            }
                        }
                    }
                }
            }
            
        }


        #endregion Matchmaker Area of Interest


        #region Matchmaker Classifications


        [HttpGet]
        [OrganizationProfileViewEditFeature]
        public PartialViewResult EditMatchMakerClassifications(OrganizationPrimaryKey organizationPrimaryKey)
        {
            var organization = organizationPrimaryKey.EntityObject;
            var allClassificationSystems = HttpRequestStorage.DatabaseEntities.ClassificationSystems.ToList();
            var viewModel = new MatchmakerOrganizationClassificationsViewModel(organization, allClassificationSystems);
            return ViewEditMatchMakerClassifications(organization, allClassificationSystems, viewModel);
        }

        private PartialViewResult ViewEditMatchMakerClassifications(Organization organization, List<ClassificationSystem> allClassificationSystems, MatchmakerOrganizationClassificationsViewModel viewModel)
        {

            var viewData = new MatchmakerOrganizationClassificationsViewData(organization, allClassificationSystems);
            return RazorPartialView<MatchmakerOrganizationClassifications, MatchmakerOrganizationClassificationsViewData, MatchmakerOrganizationClassificationsViewModel>(viewData, viewModel);
        }

        [HttpPost]
        [OrganizationProfileViewEditFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult EditMatchMakerClassifications(OrganizationPrimaryKey organizationPrimaryKey, MatchmakerOrganizationClassificationsViewModel viewModel)
        {
            var organization = organizationPrimaryKey.EntityObject;
            var allClassificationSystems = HttpRequestStorage.DatabaseEntities.ClassificationSystems.ToList();

            if (!ModelState.IsValid)
            {
                return ViewEditMatchMakerClassifications(organization, allClassificationSystems,  viewModel);
            }

            viewModel.UpdateModel(CurrentFirmaSession, organization, HttpRequestStorage.DatabaseEntities);

            return new ModalDialogFormJsonResult(SitkaRoute<OrganizationController>.BuildUrlFromExpression(x => x.Detail(organization, OrganizationDetailViewData.OrganizationDetailTab.Profile)));
        }


        #endregion Matchmaker Classifications



        #region Matchmaker Performance Measures


        [HttpGet]
        [OrganizationProfileViewEditFeature]
        public PartialViewResult EditMatchMakerPerformanceMeasures(OrganizationPrimaryKey organizationPrimaryKey)
        {
            var organization = organizationPrimaryKey.EntityObject;
            var allPerformanceMeasures = HttpRequestStorage.DatabaseEntities.PerformanceMeasures.ToList();
            var viewModel = new MatchmakerOrganizationPerformanceMeasuresViewModel(organization, allPerformanceMeasures);
            return ViewEditMatchMakerPerformanceMeasures(organization, allPerformanceMeasures, viewModel);
        }

        private PartialViewResult ViewEditMatchMakerPerformanceMeasures(Organization organization, List<PerformanceMeasure> allPerformanceMeasures, MatchmakerOrganizationPerformanceMeasuresViewModel viewModel)
        {

            var viewData = new MatchmakerOrganizationPerformanceMeasuresViewData(organization, allPerformanceMeasures);
            return RazorPartialView<MatchmakerOrganizationPerformanceMeasures, MatchmakerOrganizationPerformanceMeasuresViewData, MatchmakerOrganizationPerformanceMeasuresViewModel>(viewData, viewModel);
        }

        [HttpPost]
        [OrganizationProfileViewEditFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult EditMatchMakerPerformanceMeasures(OrganizationPrimaryKey organizationPrimaryKey, MatchmakerOrganizationPerformanceMeasuresViewModel viewModel)
        {
            var organization = organizationPrimaryKey.EntityObject;
            var allPerformanceMeasures = HttpRequestStorage.DatabaseEntities.PerformanceMeasures.ToList();

            if (!ModelState.IsValid)
            {
                return ViewEditMatchMakerPerformanceMeasures(organization, allPerformanceMeasures, viewModel);
            }

            viewModel.UpdateModel(CurrentFirmaSession, organization, HttpRequestStorage.DatabaseEntities);

            return new ModalDialogFormJsonResult(SitkaRoute<OrganizationController>.BuildUrlFromExpression(x => x.Detail(organization, OrganizationDetailViewData.OrganizationDetailTab.Profile)));
        }


        #endregion Matchmaker Performance Measures


        /// <summary>
        /// Dummy get signature so that it can find the post action
        /// </summary>
        [HttpGet]
        [OrganizationProfileViewEditFeature]
        public ContentResult EditProfileMatchmakerOptIn(OrganizationPrimaryKey organizationPrimaryKey)
        {
            return new ContentResult();
        }

        [HttpPost]
        [OrganizationProfileViewEditFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult EditProfileMatchmakerOptIn(OrganizationPrimaryKey organizationPrimaryKey, EditProfileOptInOutViewModel viewModel)
        {
            var organization = organizationPrimaryKey.EntityObject;
            if (organization != null)
            {
                organization.MatchmakerOptIn = viewModel.OptIn;
            }
            return new ModalDialogFormJsonResult();
        }

        [HttpGet]
        [OrganizationManageFeature]
        public JsonResult SyncWithKeystone(string organizationGuidAsString)
        {
            var keystoneClient = new KeystoneDataClient();
            var organizationGuid = Guid.Parse(organizationGuidAsString);
            var keystoneOrganization = keystoneClient.GetOrganization(organizationGuid);
            // create an OrganizationSimple with fields to be synced from Keystone set (ShortName and URL)
            var result = new OrganizationSimple(default(int), keystoneOrganization.OrganizationGuid, keystoneOrganization.FullName, keystoneOrganization.ShortName, default(int), null, true, keystoneOrganization.URL, null, string.Empty);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        [OrganizationPrimaryContactManageFeature]
        public PartialViewResult EditPrimaryContact(OrganizationPrimaryKey organizationPrimaryKey)
        {
            var organization = organizationPrimaryKey.EntityObject;
            var viewModel = new EditPrimaryContactViewModel(organization);
            return ViewEditPrimaryContact(viewModel, organization.PrimaryContactPerson);
        }

        [HttpPost]
        [OrganizationPrimaryContactManageFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult EditPrimaryContact(OrganizationPrimaryKey organizationPrimaryKey, EditPrimaryContactViewModel viewModel)
        {
            var organization = organizationPrimaryKey.EntityObject;
            if (!ModelState.IsValid)
            {
                return ViewEditPrimaryContact(viewModel, organization.PrimaryContactPerson);
            }
            viewModel.UpdateModel(organization, CurrentFirmaSession);
            return new ModalDialogFormJsonResult();
        }

        private PartialViewResult ViewEditPrimaryContact(EditPrimaryContactViewModel viewModel, Person currentPrimaryContactPerson)
        {
            var activePeople = HttpRequestStorage.DatabaseEntities.People.GetActivePeople();
            var activePeopleWithAssignedRoles = activePeople.Where(ap => ap.Role != Role.Unassigned).ToList();
            if (currentPrimaryContactPerson != null && !activePeopleWithAssignedRoles.Contains(currentPrimaryContactPerson))
            {
                activePeopleWithAssignedRoles.Add(currentPrimaryContactPerson);
            }
            var people = activePeopleWithAssignedRoles.OrderBy(x => x.GetFullNameLastFirst()).ToSelectListWithEmptyFirstRow(x => x.PersonID.ToString(CultureInfo.InvariantCulture),
                x => x.GetFullNameFirstLastAndOrg());

            var viewData = new EditPrimaryContactViewData(people);
            return RazorPartialView<EditPrimaryContact, EditPrimaryContactViewData, EditPrimaryContactViewModel>(viewData, viewModel);
        }

        [OrganizationViewFeature]
        public ViewResult Detail(OrganizationPrimaryKey organizationPrimaryKey, OrganizationDetailViewData.OrganizationDetailTab? organizationDetailTab)
        {
            var organization = organizationPrimaryKey.EntityObject;
            var activeTab = organizationDetailTab ?? OrganizationDetailViewData.OrganizationDetailTab.Overview;
            var expendituresDirectlyFromOrganizationViewGoogleChartViewData = GetCalendarYearExpendituresFromOrganizationFundingSourcesChartViewData(organization);
            var expendituresReceivedFromOtherOrganizationsViewGoogleChartViewData = GetCalendarYearExpendituresFromProjectFundingSourcesChartViewData(organization, CurrentFirmaSession);

            var mapInitJson = GetMapInitJson(organization, out var hasSpatialData, CurrentFirmaSession);
            var projectLocationsLayerGeoJson = GetProjectLocationsLayerGeoJson(organization, CurrentFirmaSession);
            hasSpatialData = hasSpatialData || projectLocationsLayerGeoJson != null;

            var performanceMeasures = organization.GetAllActiveProjectsAndProposals(CurrentFirmaSession).ToList()
                .SelectMany(x => x.PerformanceMeasureActuals)
                .Select(x => x.PerformanceMeasure).Distinct(new HavePrimaryKeyComparer<PerformanceMeasure>())
                .OrderBy(x => x.PerformanceMeasureDisplayName)
                .ToList();

            var topLevelMatchmakerTaxonomyTier = GetTopLevelMatchmakerTaxonomyTier(organization);
            var maximumTaxonomyLeaves = HttpRequestStorage.DatabaseEntities.TaxonomyLeafs.Count();
            var matchMakerAreaOfInterestMapInitJson = GetOrganizationAreaOfInterestMapInitJson(organization);
            var allClassificationSystems = HttpRequestStorage.DatabaseEntities.ClassificationSystems.ToList();
            var matchmakerOrganizationClassificationsOrdered = HttpRequestStorage.DatabaseEntities
                .MatchmakerOrganizationClassifications.Where(x => x.OrganizationID == organization.OrganizationID).OrderBy(x => x.Classification.ClassificationSortOrder).ToList();
            var matchmakerClassificationsGroupedByClassificationSystem = matchmakerOrganizationClassificationsOrdered
                .GroupBy(x => x.Classification.ClassificationSystem).ToList();
            var viewData = new OrganizationDetailViewData(CurrentFirmaSession,
                                              organization,
                                              mapInitJson,
                                              projectLocationsLayerGeoJson,
                                              hasSpatialData,
                                              performanceMeasures,
                                              expendituresDirectlyFromOrganizationViewGoogleChartViewData,
                                              expendituresReceivedFromOtherOrganizationsViewGoogleChartViewData,
                                              topLevelMatchmakerTaxonomyTier,
                                              maximumTaxonomyLeaves,
                                              activeTab,
                                              matchMakerAreaOfInterestMapInitJson,
                                              matchmakerClassificationsGroupedByClassificationSystem,
                                              allClassificationSystems);
            return RazorView<Detail, OrganizationDetailViewData>(viewData);
        }

        private static LayerGeoJson GetProjectLocationsLayerGeoJson(Organization organization, FirmaSession currentFirmaSession)
        {
            var allActiveProjectsAndProposals = organization.GetAllActiveProjectsAndProposals(currentFirmaSession).Where(x => x.ProjectStage.ShouldShowOnMap()).ToList();

            var projectsAsSimpleLocations = allActiveProjectsAndProposals.Where(x => !x.LocationIsPrivate).
                Where(x => x.ProjectLocationSimpleType != ProjectLocationSimpleType.None).ToList();
            var projectSimpleLocationsFeatureCollection = new FeatureCollection();
            projectSimpleLocationsFeatureCollection.Features.AddRange(projectsAsSimpleLocations.Select(x =>
            {
                var feature = x.MakePointFeatureWithRelevantProperties(x.GetProjectLocationPoint(true), true, true);
                feature.Properties["FeatureColor"] = "#99b3ff";
                return feature;
            }).ToList());

            // Always return the feature collection - even if empty.
            // SLG - 8/28/2020
            return new LayerGeoJson($"Mapped {FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabelPluralized()}", projectSimpleLocationsFeatureCollection, "blue", 1, LayerInitialVisibility.LayerInitialVisibilityEnum.Show);
        }

        private static MapInitJson GetMapInitJson(Organization organization, out bool hasSpatialData, FirmaSession currentFirmaSession)
        {
            hasSpatialData = false;
            
            var layers = new List<LayerGeoJson>();
            var dbGeometries = new List<DbGeometry>();

            if (organization.OrganizationBoundary != null)
            {
                hasSpatialData = true;
                layers.Add(new LayerGeoJson("Organization Boundary",
                    organization.OrganizationBoundaryToFeatureCollection(), organization.OrganizationType?.LegendColor ?? FirmaHelpers.DefaultColorRange.First(), 1,
                    LayerInitialVisibility.LayerInitialVisibilityEnum.Show));
                dbGeometries.Add(organization.OrganizationBoundary);
            }

            layers.AddRange(MapInitJson.GetConfiguredGeospatialAreaMapLayers());

            var allActiveProjectsAndProposals = organization.GetAllActiveProjectsAndProposals(currentFirmaSession).Where(x => x.ProjectStage.ShouldShowOnMap()).ToList();

            var filteredProjects = allActiveProjectsAndProposals.Where(x => x.ProjectLocationSimpleType != ProjectLocationSimpleType.None).ToList();

            dbGeometries.AddRange(filteredProjects.Where(currentFirmaSession.UserCanViewPrivateLocations).Select(p => p.GetProjectLocationPoint(true)));

            var boundingBox = new BoundingBox(dbGeometries);

            return new MapInitJson($"organization_{organization.OrganizationID}_Map", 10, layers, MapInitJson.GetExternalMapLayerSimples(), boundingBox);
        }

        private static MapInitJson GetOrganizationAreaOfInterestMapInitJson(Organization organization)
        {
            var layers = new List<LayerGeoJson>();

            var dbGeometries = new List<DbGeometry>();

            // organization boundary layer
            if (organization.UseOrganizationBoundaryForMatchmaker && organization.OrganizationBoundary != null)
            {
                layers.Add(new LayerGeoJson("Organization Boundary",
                    organization.OrganizationBoundaryToFeatureCollection(), Organization.OrganizationAreaOfInterestMapLayerColor, 1,
                    LayerInitialVisibility.LayerInitialVisibilityEnum.Show));
                dbGeometries.Add(organization.OrganizationBoundary);
            }

            layers.AddRange(MapInitJson.GetConfiguredGeospatialAreaMapLayers());

            // custom areas of interest
            if (!organization.UseOrganizationBoundaryForMatchmaker &&
                organization.MatchMakerAreaOfInterestLocations.Any())
            {
                var areaOfInterestLayerGeoJsonFeatureCollection = DbGeometryToGeoJsonHelper.FeatureCollectionFromDbGeometry(organization.MatchMakerAreaOfInterestLocations.Select(x => x.MatchMakerAreaOfInterestLocationGeometry), "Area Of Interest", "User Set");
                var areaOfInterestLayerGeoJson = new LayerGeoJson($"{FieldDefinitionEnum.Organization.ToType().GetFieldDefinitionLabel()} {FieldDefinitionEnum.AreaOfInterest.ToType().GetFieldDefinitionLabel()} Geometries", areaOfInterestLayerGeoJsonFeatureCollection, Organization.OrganizationAreaOfInterestMapLayerColor, 1, LayerInitialVisibility.LayerInitialVisibilityEnum.Show);
                layers.Add(areaOfInterestLayerGeoJson);
                dbGeometries.AddRange(organization.MatchMakerAreaOfInterestLocations.Select(x => x.MatchMakerAreaOfInterestLocationGeometry));
            }

            var boundingBox = new BoundingBox(dbGeometries);

            return new MapInitJson($"organization_{organization.OrganizationID}_area_of_interest_Map", 10, layers, MapInitJson.GetExternalMapLayerSimples(), boundingBox);
        }

        private static ViewGoogleChartViewData GetCalendarYearExpendituresFromOrganizationFundingSourcesChartViewData(Organization organization)
        {
            var yearRange = FirmaDateUtilities.GetRangeOfYearsForReporting();
            var projectFundingSourceExpenditures =
                organization.FundingSources.SelectMany(x => x.ProjectFundingSourceExpenditures);

            var chartTitle = $"{FieldDefinitionEnum.ReportedExpenditure.ToType().GetFieldDefinitionLabelPluralized()} By {FieldDefinitionEnum.FundingSource.ToType().GetFieldDefinitionLabel()}";
            var chartContainerID = chartTitle.Replace(" ", "");
            var filterValues = organization.FundingSources.Select(x => x.FundingSourceName).ToList();
            var googleChart = projectFundingSourceExpenditures.ToGoogleChart(x => x.FundingSource.FundingSourceName,
                filterValues,
                x => x.FundingSource.FundingSourceName,
                yearRange,
                chartContainerID,
                chartTitle,
                GoogleChartType.ColumnChart,
                true,
                null);

            return new ViewGoogleChartViewData(googleChart, chartTitle, 400, true);
        }

        private static ViewGoogleChartViewData GetCalendarYearExpendituresFromProjectFundingSourcesChartViewData(Organization organization, FirmaSession currentFirmaSession)
        {
            var yearRange = FirmaDateUtilities.GetRangeOfYearsForReporting();

            var projects = organization.GetAllActiveProjectsAndProposalsWhereOrganizationIsStewardOrPrimaryContact(currentFirmaSession).ToList();
            var projectFundingSourceExpenditures = projects.SelectMany(x => x.ProjectFundingSourceExpenditures).Where(x => x.FundingSource.Organization != organization);
            
            var chartTitle = $"{FieldDefinitionEnum.ReportedExpenditure.ToType().GetFieldDefinitionLabelPluralized()} By {FieldDefinitionEnum.OrganizationType.ToType().GetFieldDefinitionLabel()}";
            var chartContainerID = chartTitle.Replace(" ", "");
            var filterValues = projects.SelectMany(x => x.ProjectFundingSourceExpenditures).Where(x => x.FundingSource.Organization != organization).Select(x => x.FundingSource.Organization.OrganizationType.OrganizationTypeName).Distinct().ToList();
            var organizationTypes = HttpRequestStorage.DatabaseEntities.OrganizationTypes;
            
            var googleChart = projectFundingSourceExpenditures.ToGoogleChart(x => x.FundingSource.Organization.OrganizationType.OrganizationTypeName,
                filterValues,
                x => x.FundingSource.Organization.OrganizationType.OrganizationTypeName,
                yearRange,
                chartContainerID,
                chartTitle,
                GoogleChartType.ColumnChart,
                true,
                organizationTypes.ToDictionary(x => x.OrganizationTypeName, x => x.LegendColor));

            return new ViewGoogleChartViewData(googleChart, chartTitle, 400, true);
        }

        private static List<MatchmakerTaxonomyTier> GetTopLevelMatchmakerTaxonomyTier(Organization organization)
        {
            if (!MultiTenantHelpers.GetTenantAttributeFromCache().EnableMatchmaker)
            {
                return new List<MatchmakerTaxonomyTier>();
            }

            var matchmakerTierLeaves = organization.MatchmakerOrganizationTaxonomyLeafs.Select(x => new MatchmakerTaxonomyTier(x.TaxonomyLeaf)).ToList();
            var matchmakerTierBranches = new List<MatchmakerTaxonomyTier>();
            if (!MultiTenantHelpers.IsTaxonomyLevelLeaf())
            {
                // for each leaf, we need to give it its parent branch for display.
                var leafsGrouped = matchmakerTierLeaves.GroupBy(x => x.TaxonomyLeaf.TaxonomyBranchID);
                var branchIDs = new List<int>();
                foreach (var grouping in leafsGrouped)
                {
                    var branch = grouping.First().TaxonomyLeaf.TaxonomyBranch;
                    var matchmakerBranch = new MatchmakerTaxonomyTier(branch, grouping.SortByOrderThenName().ToList());
                    matchmakerTierBranches.Add(matchmakerBranch);
                    branchIDs.Add(branch.TaxonomyBranchID);
                }
                // also need to add the selected taxonomy branches (with all leafs), if not already added
                var mmBranches =
                    organization.MatchmakerOrganizationTaxonomyBranches.Where(x =>
                            !branchIDs.Contains(x.TaxonomyBranchID)).Select(x =>
                            new MatchmakerTaxonomyTier(x.TaxonomyBranch,
                                x.TaxonomyBranch.TaxonomyLeafs.Select(y => new MatchmakerTaxonomyTier(y)).SortByOrderThenName()
                                    .ToList()))
                        .ToList();
                matchmakerTierBranches.AddRange(mmBranches);
            }

            var matchmakerTierTrunks = new List<MatchmakerTaxonomyTier>();
            if (MultiTenantHelpers.IsTaxonomyLevelTrunk())
            {
                // for each branch, we need to give it its parent trunk for display.
                var branchesGrouped = matchmakerTierBranches.GroupBy(x => x.TaxonomyBranch.TaxonomyTrunkID);
                var trunkIDs = new List<int>();
                foreach (var grouping in branchesGrouped)
                {
                    var trunk = grouping.First().TaxonomyBranch.TaxonomyTrunk;
                    var branches = grouping.ToList();
                    if (branches.Count == trunk.TaxonomyBranches.Count && branches.Sum(x => x.Children.Count) == trunk.TaxonomyBranches.Sum(x => x.TaxonomyLeafs.Count))
                    {
                        // need to display as one row with all branches and all leaves
                        var leaves = branches.SelectMany(x => x.Children).ToList();
                        var matchmakerTrunkTest = new MatchmakerTaxonomyTier(trunk, branches.SortByOrderThenName().ToList(), leaves);
                        matchmakerTierTrunks.Add(matchmakerTrunkTest);
                    }
                    else
                    {
                        var matchmakerTrunk = new MatchmakerTaxonomyTier(trunk, branches.SortByOrderThenName().ToList());
                        matchmakerTierTrunks.Add(matchmakerTrunk);
                    }
                    
                    trunkIDs.Add(trunk.TaxonomyTrunkID);
                }
                // also need to add the selected taxonomy trunks (with all branches and leaves), if not already added
                var mmTrunks = new List<MatchmakerTaxonomyTier>();
                organization.MatchmakerOrganizationTaxonomyTrunks.Where(x =>
                            !trunkIDs.Contains(x.TaxonomyTrunkID)).ForEach(x =>
                {
                    var branches = x.TaxonomyTrunk.TaxonomyBranches
                        .Select(y => new MatchmakerTaxonomyTier(y, new List<MatchmakerTaxonomyTier>())).SortByOrderThenName().ToList();
                    var leaves = x.TaxonomyTrunk.TaxonomyBranches.SelectMany(y =>
                        y.TaxonomyLeafs.Select(z => new MatchmakerTaxonomyTier(z)).SortByOrderThenName()
                            .ToList()).ToList();
                    mmTrunks.Add(new MatchmakerTaxonomyTier(x.TaxonomyTrunk, branches, leaves));
                });
                matchmakerTierTrunks.AddRange(mmTrunks);
            }

            switch (MultiTenantHelpers.GetTaxonomyLevel().ToEnum)
            {
                case TaxonomyLevelEnum.Trunk:
                    return matchmakerTierTrunks.SortByOrderThenName().ToList();
                case TaxonomyLevelEnum.Branch:
                    return matchmakerTierBranches.SortByOrderThenName().ToList();
                case TaxonomyLevelEnum.Leaf:
                    return matchmakerTierLeaves.SortByOrderThenName().ToList();
                default:
                    throw new ArgumentOutOfRangeException();
            }
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
            var projectFundingSourceExpenditureTotal = organization.FundingSources.Sum(x => x.ProjectFundingSourceExpenditures.Sum(y => y.ExpenditureAmount)).ToStringCurrency();
            var canDelete = !organization.ProjectOrganizations.Any() && !organization.FundingSources.Any() &&
                            organization.People.All(x => !x.IsActive);
            var stringBuilderConfirmMessage = new StringBuilder();

            var projectUpdateCount = organization.ProjectOrganizationUpdates
                .Where(x => x.ProjectUpdateBatch.ProjectUpdateState.ProjectUpdateStateID !=
                            ProjectUpdateState.Approved.ProjectUpdateStateID)
                .Select(x => x.ProjectUpdateBatchID).Distinct().ToList().Count;

            if (!canDelete)
            {
                stringBuilderConfirmMessage.Append($"Organization \"{organization.OrganizationName}\" cannot be deleted because it");
                if (organization.ProjectOrganizations.Any() || projectUpdateCount > 0)
                {
                    stringBuilderConfirmMessage.Append($" is related to {organization.ProjectOrganizations.Select(x => x.ProjectID).Distinct().ToList().Count} projects");
                    stringBuilderConfirmMessage.Append(projectUpdateCount > 0 ? (organization.FundingSources.Any() ? $", {projectUpdateCount} project updates" : $" and {projectUpdateCount} project updates") : "");
                    stringBuilderConfirmMessage.Append(organization.FundingSources.Any() ? projectUpdateCount > 0 ? ", and" : " and" : ".");
                }
                if (organization.FundingSources.Any())
                {
                    stringBuilderConfirmMessage.Append($" has {organization.FundingSources.Count} funding sources that fund a total of {projectFundingSourceExpenditureTotal} across various projects.");
                }

                stringBuilderConfirmMessage.Append("  To delete this organization, you must first remove the organization's relationship to these");
                if (organization.ProjectOrganizations.Any() || projectUpdateCount > 0)
                {
                    stringBuilderConfirmMessage.Append(" projects");
                    stringBuilderConfirmMessage.Append(projectUpdateCount > 0 ? (organization.FundingSources.Any() ? ", project updates" : " and project updates") : "");
                    stringBuilderConfirmMessage.Append(organization.FundingSources.Any() ? projectUpdateCount > 0 ? ", and" : " and" : ".");
                }
                if (organization.FundingSources.Any())
                {
                    stringBuilderConfirmMessage.Append(" funding sources.");
                }

                if (organization.People.Any(x => x.IsActive))
                {
                    stringBuilderConfirmMessage.Append($"  It also has {organization.People.Count(x => x.IsActive)} people, which need to be inactivated before you can do this.");
                }
            }
            var confirmMessage = canDelete
                ? $"Are you sure you want to delete the Organization \"{organization.OrganizationName}\"?"
                : stringBuilderConfirmMessage.ToString();
            var viewData = new ConfirmDialogFormViewData(confirmMessage, canDelete);
            return RazorPartialView<ConfirmDialogForm, ConfirmDialogFormViewData, ConfirmDialogFormViewModel>(viewData,
                viewModel);
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
            var message = $"Organization \"{organization.OrganizationName}\" successfully deleted.";
            var databaseEntities = HttpRequestStorage.DatabaseEntities;
            organization.LogoFileResourceInfo?.FileResourceData.Delete(databaseEntities);
            organization.LogoFileResourceInfo?.Delete(databaseEntities);
            
            // assign any People to the unknown org to prevent cascade delete of Projects associated with the inactive user
            var unknownOrganization = HttpRequestStorage.DatabaseEntities.Organizations.GetUnknownOrganization();
            foreach (var person in organization.People)
            {
                person.Organization = unknownOrganization;
                person.OrganizationID = unknownOrganization.OrganizationID;
            }
            organization.People = new List<Person>();

            organization.DeleteFull(HttpRequestStorage.DatabaseEntities);
            SetMessageForDisplay(message);

            return new ModalDialogFormJsonResult();
        }

        [OrganizationViewFeature]
        public GridJsonNetJObjectResult<Project> ProjectsIncludingLeadImplementingGridJsonData(OrganizationPrimaryKey organizationPrimaryKey)
        {
            var organization = organizationPrimaryKey.EntityObject;
            var gridSpec = new ProjectsIncludingLeadImplementingGridSpec(organization, CurrentFirmaSession, false);
            var gridJsonNetJObjectResult = new GridJsonNetJObjectResult<Project>(organization.GetAllActiveProjects(), gridSpec);
            return gridJsonNetJObjectResult;
        }

        [OrganizationViewFeature]
        public GridJsonNetJObjectResult<Project> ProposalsGridJsonData(OrganizationPrimaryKey organizationPrimaryKey)
        {
            var organization = organizationPrimaryKey.EntityObject;
            var gridSpec = new ProjectsIncludingLeadImplementingGridSpec(organization, CurrentFirmaSession, true);
            var gridJsonNetJObjectResult = new GridJsonNetJObjectResult<Project>(organization.GetProposalsVisibleToUser(CurrentFirmaSession), gridSpec);
            return gridJsonNetJObjectResult;
        }

        [OrganizationViewFeature]
        public GridJsonNetJObjectResult<Project> PendingProjectsGridJsonData(OrganizationPrimaryKey organizationPrimaryKey)
        {
            var organization = organizationPrimaryKey.EntityObject;
            var gridSpec = new ProjectsIncludingLeadImplementingGridSpec(organization, CurrentFirmaSession, true);
            var gridJsonNetJObjectResult = new GridJsonNetJObjectResult<Project>(organization.GetAllPendingProjects(CurrentFirmaSession), gridSpec);
            return gridJsonNetJObjectResult;
        }

        [OrganizationViewFeature]
        public GridJsonNetJObjectResult<ProjectFundingSourceExpenditure> ProjectFundingSourceExpendituresForOrganizationGridJsonData(OrganizationPrimaryKey organizationPrimaryKey)
        {
            var organization = organizationPrimaryKey.EntityObject;
            
            // received
            var projects = organization.GetAllActiveProjectsAndProposalsWhereOrganizationIsStewardOrPrimaryContact(CurrentFirmaSession).ToList();
            var projectFundingSourceExpenditures = projects.SelectMany(x => x.ProjectFundingSourceExpenditures).Where(x => x.FundingSource.Organization != organization).ToList();

            // provided
            projectFundingSourceExpenditures.AddRange(organization.FundingSources.SelectMany(x => x.ProjectFundingSourceExpenditures));

            var projectFundingSourceExpendituresToShow =
                projectFundingSourceExpenditures.Where(x => x.ExpenditureAmount > 0).ToList();
            var gridSpec = new ProjectFundingSourceExpendituresForOrganizationGridSpec(organization);
            var gridJsonNetJObjectResult = new GridJsonNetJObjectResult<ProjectFundingSourceExpenditure>(projectFundingSourceExpendituresToShow, gridSpec);
            return gridJsonNetJObjectResult;
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

            var keystoneOrganizationGuid = viewModel.KeystoneOrganizationGuid.Value;
            KeystoneDataService.Organization keystoneOrganization;
            try
            {
                keystoneOrganization = keystoneClient.GetOrganization(keystoneOrganizationGuid);
            }
            catch (Exception)
            {
                SetErrorForDisplay("Organization not added. Guid not found in Keystone or unable to connect to Keystone");
                return new ModalDialogFormJsonResult();
            }

            var firmaOrganization = HttpRequestStorage.DatabaseEntities.Organizations.SingleOrDefault(x => x.KeystoneOrganizationGuid == keystoneOrganizationGuid);
            if (firmaOrganization != null)
            {
                SetErrorForDisplay("This organization already exists in ProjectFirma. Go to the organization’s basics editor to sync its information with Keystone.");
                return new ModalDialogFormJsonResult();
            }

            var defaultOrganizationType = HttpRequestStorage.DatabaseEntities.OrganizationTypes.GetDefaultOrganizationType();
            firmaOrganization = new Organization(keystoneOrganization.FullName, true, defaultOrganizationType, Organization.UseOrganizationBoundaryForMatchmakerDefault, false)
            {
                KeystoneOrganizationGuid = keystoneOrganization.OrganizationGuid,
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
            var viewData = new EditBoundaryViewData(CurrentFirmaSession, organizationPrimaryKey.EntityObject);
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
                var viewData = new EditBoundaryViewData(CurrentFirmaSession, organization);
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

            viewModel.UpdateModel(organization, out bool oneHadToBeCorrected);
            if (oneHadToBeCorrected)
            {
                SetWarningForDisplay("One or more of your imported shapes had to be corrected in order to make it a valid geometry. Most likely this resulted in no noticeable changes, but please review the organization boundary to verify.");
            }
            HttpRequestStorage.DatabaseEntities.AllOrganizationBoundaryStagings.RemoveRange(organization
                .OrganizationBoundaryStagings);

            SetMessageForDisplay($"Organization Boundary for {organization.GetDisplayNameAsUrl()} successfully updated.");
            return new ContentResult();
        }
        private PartialViewResult ViewApproveUploadGis(ApproveUploadGisViewModel viewModel, Organization organization)
        {
            var layers = organization.OrganizationBoundaryStagings.Select((x, index) => new LayerGeoJson(
                x.FeatureClassName, x.ToGeoJsonFeatureCollection(),
                FirmaHelpers.DefaultColorRange[index], 0.8m,
                index == 0 ? LayerInitialVisibility.LayerInitialVisibilityEnum.Show : LayerInitialVisibility.LayerInitialVisibilityEnum.Hide)).ToList();
            var mapInitJson = new MapInitJson("organizationBoundaryApproveUploadGisMap", 10, layers, MapInitJson.GetExternalMapLayerSimples(), BoundingBox.MakeBoundingBoxFromLayerGeoJsonList(layers));

            var viewData = new ApproveUploadGisViewData(CurrentFirmaSession, organization, mapInitJson);
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
                $"Are you sure you want to delete the boundary for this {FieldDefinitionEnum.Organization.ToType().GetFieldDefinitionLabel()} '{organization.OrganizationName}'?");
            return RazorPartialView<ConfirmDialogForm, ConfirmDialogFormViewData, ConfirmDialogFormViewModel>(viewData,
                viewModel);
        }

        [HttpGet]
        [OrganizationBackgroundEditFeature]
        public PartialViewResult EditDescriptionInDialog(OrganizationPrimaryKey organizationPrimaryKey)
        {
            var organization = organizationPrimaryKey.EntityObject;
            var viewModel = new EditRtfContentViewModel(organization.DescriptionHtmlString);
            return ViewEditDescriptionInDialog(viewModel, organization);
        }

        [HttpPost]
        [OrganizationBackgroundEditFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult EditDescriptionInDialog(OrganizationPrimaryKey organizationPrimaryKey, EditRtfContentViewModel viewModel)
        {
            var organization = organizationPrimaryKey.EntityObject;
            if (!ModelState.IsValid)
            {
                return ViewEditDescriptionInDialog(viewModel, organization);
            }
            viewModel.UpdateModel(organization);
            return new ModalDialogFormJsonResult();
        }

        private PartialViewResult ViewEditDescriptionInDialog(EditRtfContentViewModel viewModel, Organization organization)
        {
            var tinyMceToolbarStyle = TinyMCEExtension.TinyMCEToolbarStyle.All;
            var viewData = new EditRtfContentViewData(tinyMceToolbarStyle);
            return RazorPartialView<EditRtfContent, EditRtfContentViewData, EditRtfContentViewModel>(viewData, viewModel);
        }
    }
}
