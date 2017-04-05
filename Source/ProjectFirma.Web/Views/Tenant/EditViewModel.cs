/*-----------------------------------------------------------------------
<copyright file="EditViewModel.cs" company="Tahoe Regional Planning Agency">
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
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using LtInfo.Common.Models;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;

namespace ProjectFirma.Web.Views.Tenant
{
    public class EditViewModel : FormViewModel
    {
        [Required]
        public int? TenantID { get; set; }

        [DisplayName("Primary Contact")]
        [Required(ErrorMessage = "Must specify a Primary Contact")]
        public int? PrimaryContactID { get; set; }

        [DisplayName("Tenant Style Sheet Url")]
        [Required(ErrorMessage = "Must specify a Tenant Style Sheet Url")]
        [StringLength(TenantAttribute.FieldLengths.TenantStyleSheetUrl)]
        public string TenantStyleSheetUrl { get; set; }

        [DisplayName("Minimum Year")]
        [Required(ErrorMessage = "Must specify a Minimum Year")]
        public int MinimumYear { get; set; }

        [DisplayName("Number Of Taxonomy Tiers To Use")]
        [Required(ErrorMessage = "Must specify a Number Of Taxonomy Tiers To Use")]
        public int NumberOfTaxonomyTiersToUse { get; set; }

        [DisplayName("Tenant Banner Logo Url")]
        [Required(ErrorMessage = "Must specify a Tenant Banner Logo Url")]
        [StringLength(TenantAttribute.FieldLengths.TenantBannerLogoUrl)]
        public string TenantBannerLogoUrl { get; set; }

        [DisplayName("Tenant Square Logo Url")]
        [Required(ErrorMessage = "Must specify a Tenant Square Logo Url")]
        [StringLength(TenantAttribute.FieldLengths.TenantSquareLogoUrl)]
        public string TenantSquareLogoUrl { get; set; }

        [DisplayName("Classification Display Name")]
        [Required(ErrorMessage = "Must specify a Classification Display Name")]
        [StringLength(TenantAttribute.FieldLengths.ClassificationDisplayName)]
        public string ClassificationDisplayName { get; set; }

        [DisplayName("Performance Measure Display Name")]
        [Required(ErrorMessage = "Must specify a Performance Measure Display Name")]
        [StringLength(TenantAttribute.FieldLengths.PerformanceMeasureDisplayName)]
        public string PerformanceMeasureDisplayName { get; set; }

        [DisplayName("Taxonomy Tier One Display Name For Project")]
        [Required(ErrorMessage = "Must specify a Taxonomy Tier One Display Name For Project")]
        [StringLength(TenantAttribute.FieldLengths.TaxonomyTierOneDisplayNameForProject)]
        public string TaxonomyTierOneDisplayNameForProject { get; set; }

        [DisplayName("Taxonomy System Name")]
        [Required(ErrorMessage = "Must specify a Taxonomy System Name")]
        [StringLength(TenantAttribute.FieldLengths.TaxonomySystemName)]
        public string TaxonomySystemName { get; set; }

        /// <summary>
        /// Needed by ModelBinder
        /// </summary>
        public EditViewModel()
        {
        }

        public EditViewModel(Models.Tenant tenant, TenantAttribute tenantAttribute)
        {
            TenantID = tenant.TenantID;
            TaxonomySystemName = tenantAttribute.TaxonomySystemName;
            TaxonomyTierOneDisplayNameForProject = tenantAttribute.TaxonomyTierOneDisplayNameForProject;
            PerformanceMeasureDisplayName = tenantAttribute.PerformanceMeasureDisplayName;
            ClassificationDisplayName = tenantAttribute.ClassificationDisplayName;
            TenantSquareLogoUrl = tenantAttribute.TenantSquareLogoUrl;
            TenantBannerLogoUrl = tenantAttribute.TenantBannerLogoUrl;
            NumberOfTaxonomyTiersToUse = tenantAttribute.NumberOfTaxonomyTiersToUse;
            MinimumYear = tenantAttribute.MinimumYear;
            TenantStyleSheetUrl = tenantAttribute.TenantStyleSheetUrl;
        }

        public void UpdateModel()
        {
            var tenantAttribute = HttpRequestStorage.DatabaseEntities.AllTenantAttributes.Single(a => a.TenantID == TenantID);
            tenantAttribute.TaxonomySystemName = TaxonomySystemName;
            tenantAttribute.TaxonomyTierOneDisplayNameForProject = TaxonomyTierOneDisplayNameForProject;
            tenantAttribute.PerformanceMeasureDisplayName = PerformanceMeasureDisplayName;
            tenantAttribute.ClassificationDisplayName = ClassificationDisplayName;
            tenantAttribute.TenantSquareLogoUrl = TenantSquareLogoUrl;
            tenantAttribute.TenantBannerLogoUrl = TenantBannerLogoUrl;
            tenantAttribute.NumberOfTaxonomyTiersToUse = NumberOfTaxonomyTiersToUse;
            tenantAttribute.MinimumYear = MinimumYear;
            tenantAttribute.TenantStyleSheetUrl = TenantStyleSheetUrl;
        }
    }
}
