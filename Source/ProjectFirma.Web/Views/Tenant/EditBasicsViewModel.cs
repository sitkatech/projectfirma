/*-----------------------------------------------------------------------
<copyright file="EditBasicsViewModel.cs" company="Tahoe Regional Planning Agency">
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

        [DisplayName("Primary Contact")]
        public int? PrimaryContactPersonID { get; set; }

        [DisplayName("Minimum Year")]
        [Required(ErrorMessage = "Must specify a Minimum Year")]
        public int? MinimumYear { get; set; }

        [DisplayName("Number Of Taxonomy Tiers To Use")]
        [Required(ErrorMessage = "Must specify a Number Of Taxonomy Tiers To Use")]
        [Range(1, 3, ErrorMessage = "Number Of Taxonomy Tiers To Use must be a number between 1 and 3.")]
        public int? NumberOfTaxonomyTiersToUse { get; set; }

        [DisplayName("Tenant Style Sheet")]
        [SitkaFileExtensions("css")]
        public HttpPostedFileBase TenantStyleSheetFileResourceData { get; set; }

        [DisplayName("Tenant Banner Logo")]
        [SitkaFileExtensions("jpg|jpeg|gif|png")]
        public HttpPostedFileBase TenantBannerLogoFileResourceData { get; set; }

        [DisplayName("Fact Sheet Logo")]
        [SitkaFileExtensions("jpg|jpeg|gif|png")]
        public HttpPostedFileBase TenantSquareLogoFileResourceData { get; set; }

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
            PrimaryContactPersonID = tenantAttribute.PrimaryContactPersonID;
            NumberOfTaxonomyTiersToUse = tenantAttribute.NumberOfTaxonomyTiersToUse;
            MinimumYear = tenantAttribute.MinimumYear;
        }

        public void UpdateModel(Person currentPerson)
        {
            var tenantAttribute = HttpRequestStorage.DatabaseEntities.AllTenantAttributes.Single(a => a.TenantID == TenantID);

            tenantAttribute.TenantDisplayName = TenantDisplayName;

            Person primaryContactPerson = null;
            if (PrimaryContactPersonID != null)
            {
                primaryContactPerson = HttpRequestStorage.DatabaseEntities.AllPeople.Single(p => p.PersonID == PrimaryContactPersonID);
                Check.Assert(primaryContactPerson.TenantID == TenantID, "Primary contact must belong to the tenant being edited. This should have been ensured by validation.");
                Check.Assert(new FirmaAdminFeature().HasPermissionByPerson(primaryContactPerson), "Primary contact must be an admin. This should have been ensured by validation.");
            }
            tenantAttribute.PrimaryContactPerson = primaryContactPerson;

            Check.Assert(NumberOfTaxonomyTiersToUse != null, "Number Of Taxonomy Tiers To Use must not be null. This should have been ensured by validation.");
            tenantAttribute.NumberOfTaxonomyTiersToUse = NumberOfTaxonomyTiersToUse ?? 0;

            Check.Assert(MinimumYear != null, "Minimum Year must not be null. This should have been ensured by validation.");
            tenantAttribute.MinimumYear = MinimumYear ?? 0;

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
                var primaryContact = HttpRequestStorage.DatabaseEntities.AllPeople.Single(p => p.PersonID == PrimaryContactPersonID);
                if (primaryContact.TenantID != TenantID)
                {
                    errors.Add(new SitkaValidationResult<EditBasicsViewModel, int?>("Primary contact must belong to the tenant being edited.", m => m.PrimaryContactPersonID));
                }
                if (!new FirmaAdminFeature().HasPermissionByPerson(primaryContact))
                {
                    errors.Add(new SitkaValidationResult<EditBasicsViewModel, int?>("Primary contact must be an admin.", m => m.PrimaryContactPersonID));
                }
            }

            return errors;
        }
    }
}
