/*-----------------------------------------------------------------------
<copyright file="EditBasicsViewModel.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
Copyright (c) Tahoe Regional Planning Agency and Sitka Technology Group. All rights reserved.
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
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;
using LtInfo.Common.Mvc;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Security;

namespace ProjectFirma.Web.Views.Tenant
{
    public class EditBasicsViewModel : FormViewModel, IValidatableObject
    {
        [Required]
        public int? TenantID { get; set; }

        [Required]
        [DisplayName("Tenant Display Name")]
        public string TenantDisplayName { get; set; }

        [Required]
        [DisplayName("Tool Display Name")]
        public string ToolDisplayName { get; set; }

        [DisplayName("Primary Contact")]
        public int? PrimaryContactPersonID { get; set; }

        [DisplayName("Minimum Year")]
        [Required(ErrorMessage = "Must specify a Minimum Year")]
        public int? MinimumYear { get; set; }

        [DisplayName("Number Of Taxonomy Tiers To Use")]
        [Required(ErrorMessage = "Must specify a Number Of Taxonomy Tiers To Use")]
        public int? TaxonomyLevelID { get; set; }

        [DisplayName("Associate Performance Measures at Taxonomy Tier")]
        public int? AssociatePerfomanceMeasureTaxonomyLevelID { get; set; }

        [DisplayName("Tenant Style Sheet")]
        [SitkaFileExtensions("css")]
        public HttpPostedFileBase TenantStyleSheetFileResourceData { get; set; }

        [DisplayName("Tenant Banner Logo")]
        [SitkaFileExtensions("jpg|jpeg|gif|png")]
        public HttpPostedFileBase TenantBannerLogoFileResourceData { get; set; }

        [DisplayName("Fact Sheet Logo")]
        [SitkaFileExtensions("jpg|jpeg|gif|png")]
        public HttpPostedFileBase TenantSquareLogoFileResourceData { get; set; }

        [DisplayName("Map Service Url")]
        [Url]
        public string MapServiceUrl { get; set; }

        [DisplayName("Watershed Layer Name")]
        public string WatershedLayerName { get; set; }

        [FieldDefinitionDisplay(FieldDefinitionEnum.ShowProposalsToThePublic)]
        public bool ShowProposalsToThePublic { get; set; }


        /// <summary>
        /// Needed by ModelBinder
        /// </summary>
        public EditBasicsViewModel()
        {
        }

        public EditBasicsViewModel(Models.Tenant tenant, TenantAttribute tenantAttribute)
        {
            TenantID = tenant.TenantID;
            TenantDisplayName = tenantAttribute.TenantDisplayName;
            ToolDisplayName = tenantAttribute.ToolDisplayName;
            PrimaryContactPersonID = tenantAttribute.PrimaryContactPersonID;
            TaxonomyLevelID = tenantAttribute.TaxonomyLevelID;
            AssociatePerfomanceMeasureTaxonomyLevelID = tenantAttribute.AssociatePerfomanceMeasureTaxonomyLevelID;
            MinimumYear = tenantAttribute.MinimumYear;
            MapServiceUrl = tenantAttribute.MapServiceUrl;
            WatershedLayerName = tenantAttribute.WatershedLayerName;
            ShowProposalsToThePublic = tenantAttribute.ShowProposalsToThePublic;
        }

        public void UpdateModel(Person currentPerson)
        {
            var tenantAttribute = HttpRequestStorage.DatabaseEntities.AllTenantAttributes.Single(a => a.TenantID == TenantID);

            tenantAttribute.TenantDisplayName = TenantDisplayName;
            tenantAttribute.ToolDisplayName = ToolDisplayName;
            tenantAttribute.ShowProposalsToThePublic = ShowProposalsToThePublic;

            Person primaryContactPerson = null;
            if (PrimaryContactPersonID != null)
            {
                primaryContactPerson = HttpRequestStorage.DatabaseEntities.People.GetPerson(PrimaryContactPersonID.Value);
            }
            tenantAttribute.PrimaryContactPerson = primaryContactPerson;
            var clearOutTaxonomyLeafPerformanceMeasures = false;
            if ((tenantAttribute.TaxonomyLevelID != TaxonomyLevelID.Value) || (tenantAttribute.AssociatePerfomanceMeasureTaxonomyLevelID != AssociatePerfomanceMeasureTaxonomyLevelID.Value))
            {
                clearOutTaxonomyLeafPerformanceMeasures = true;
            }

            if (clearOutTaxonomyLeafPerformanceMeasures)
            {
                HttpRequestStorage.DatabaseEntities.TaxonomyLeafPerformanceMeasures.Select(x => x.TaxonomyLeafPerformanceMeasureID).ToList().DeleteTaxonomyLeafPerformanceMeasure();
            }

            tenantAttribute.TaxonomyLevelID = TaxonomyLevelID.Value;
            tenantAttribute.AssociatePerfomanceMeasureTaxonomyLevelID = AssociatePerfomanceMeasureTaxonomyLevelID.Value;
            tenantAttribute.MinimumYear = MinimumYear.Value;

            tenantAttribute.MapServiceUrl = MapServiceUrl;
            tenantAttribute.WatershedLayerName = WatershedLayerName;

            if (TenantStyleSheetFileResourceData != null)
            {
                if (tenantAttribute.TenantStyleSheetFileResource != null)
                {
                    tenantAttribute.TenantStyleSheetFileResource.DeleteFileResource();
                }
                tenantAttribute.TenantStyleSheetFileResource = FileResource.CreateNewFromHttpPostedFileAndSave(TenantStyleSheetFileResourceData, currentPerson);
            }
            if (TenantSquareLogoFileResourceData != null)
            {
                if (tenantAttribute.TenantSquareLogoFileResource != null)
                {
                    tenantAttribute.TenantSquareLogoFileResource.DeleteFileResource();
                }
                tenantAttribute.TenantSquareLogoFileResource = FileResource.CreateNewFromHttpPostedFileAndSave(TenantSquareLogoFileResourceData, currentPerson);
            }
            if (TenantBannerLogoFileResourceData != null)
            {
                if (tenantAttribute.TenantBannerLogoFileResource != null)
                {
                    tenantAttribute.TenantBannerLogoFileResource.DeleteFileResource();
                }
                tenantAttribute.TenantBannerLogoFileResource = FileResource.CreateNewFromHttpPostedFileAndSave(TenantBannerLogoFileResourceData, currentPerson);
            }
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var errors = new List<ValidationResult>();

            if (PrimaryContactPersonID != null)
            {
                var primaryContact = HttpRequestStorage.DatabaseEntities.People.GetPerson(PrimaryContactPersonID.Value);
                if (!new FirmaAdminFeature().HasPermissionByPerson(primaryContact))
                {
                    errors.Add(new SitkaValidationResult<EditBasicsViewModel, int?>($"{Models.FieldDefinition.OrganizationPrimaryContact.GetFieldDefinitionLabel()} must be an admin.", m => m.PrimaryContactPersonID));
                }
            }

            if (TaxonomyLevelID.Value < AssociatePerfomanceMeasureTaxonomyLevelID.Value)
            {
                errors.Add(new SitkaValidationResult<EditBasicsViewModel, int?>("Cannot choose a Taxonomy Tier that does not exist!", m => m.AssociatePerfomanceMeasureTaxonomyLevelID));
            }

            return errors;
        }
    }
}
