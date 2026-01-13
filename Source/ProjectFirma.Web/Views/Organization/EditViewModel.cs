/*-----------------------------------------------------------------------
<copyright file="EditViewModel.cs" company="Tahoe Regional Planning Agency and Environmental Science Associates">
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
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using ProjectFirma.Web.Common;
using ProjectFirmaModels.Models;
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;
using LtInfo.Common.Mvc;
using ProjectFirma.Web.KeystoneDataService;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Security;

namespace ProjectFirma.Web.Views.Organization
{
    public class EditViewModel : FormViewModel, IValidatableObject
    {
        public int OrganizationID { get; set; }

        [Required]
        [StringLength(ProjectFirmaModels.Models.Organization.FieldLengths.OrganizationName)]
        [DisplayName("Name")]
        public string OrganizationName { get; set; }

        [StringLength(ProjectFirmaModels.Models.Organization.FieldLengths.OrganizationShortName)]
        [DisplayName("Short Name")]
        public string OrganizationShortName { get; set; }

        [FieldDefinitionDisplay(FieldDefinitionEnum.OrganizationType)]
        [Required]
        public int? OrganizationTypeID { get; set; }

        [FieldDefinitionDisplay(FieldDefinitionEnum.OrganizationPrimaryContact)]
        public int? PrimaryContactPersonID { get; set; }

        [Url]
        [DisplayName("Website")]
        public string OrganizationUrl { get; set; }

        [StringLength(ProjectFirmaModels.Models.Organization.FieldLengths.OrganizationShortName)]
        [RegularExpression(@"^[a-zA-Z0-9.-]*$", ErrorMessage = "Only letters, digits, hyphens, and dots are allowed.")]
        [DisplayName("Domain")]
        public string Domain
        {
            get => _domain;
            set => _domain = value?.Trim();
        }
        private string _domain;


        [DisplayName("Is Active")]
        public bool IsActive { get; set; }

        [DisplayName("Logo")]
        [SitkaFileExtensions("jpg|jpeg|gif|png")]
        public HttpPostedFileBase LogoFileResourceData { get; set; }

        [DisplayName("Keystone Organization Guid")]
        public Guid? KeystoneOrganizationGuid { get; set; }

        /// <summary>
        /// Needed by the ModelBinder
        /// </summary>
        public EditViewModel()
        {
        }

        public EditViewModel(ProjectFirmaModels.Models.Organization organization)
        {
            OrganizationID = organization.OrganizationID;
            OrganizationName = organization.OrganizationName;
            OrganizationShortName = organization.OrganizationShortName;
            OrganizationTypeID = organization.OrganizationTypeID;
            PrimaryContactPersonID = organization.PrimaryContactPerson?.PersonID;
            OrganizationUrl = organization.OrganizationUrl;
            Domain = organization.Domain;
            IsActive = organization.IsActive;
            KeystoneOrganizationGuid = organization.KeystoneOrganizationGuid;
        }

        public void UpdateModel(ProjectFirmaModels.Models.Organization organization, FirmaSession currentFirmaSession, DatabaseEntities databaseEntities)
        {
            organization.OrganizationName = OrganizationName;
            organization.OrganizationShortName = OrganizationShortName;
            organization.OrganizationTypeID = OrganizationTypeID.Value;
            organization.IsActive = IsActive;
            organization.PrimaryContactPersonID = PrimaryContactPersonID;
            organization.OrganizationUrl = OrganizationUrl;
            organization.Domain = Domain;
            if (LogoFileResourceData != null)
            {
                var oldLogoFileResourceInfo = organization.LogoFileResourceInfo;
                organization.LogoFileResourceInfo = FileResourceModelExtensions.CreateNewFromHttpPostedFileAndSave(LogoFileResourceData, currentFirmaSession);
                oldLogoFileResourceInfo?.FileResourceData.Delete(databaseEntities);
                oldLogoFileResourceInfo?.Delete(databaseEntities);
            }

            var isSitkaAdmin = new SitkaAdminFeature().HasPermissionByFirmaSession(currentFirmaSession);
            if (isSitkaAdmin)
            {
                organization.KeystoneOrganizationGuid = KeystoneOrganizationGuid;
            }

        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var validationResults = new List<ValidationResult>();
            
            bool isNewOrganization = this.OrganizationID <= 0;

            // If New organization, make sure Org name not already taken by existing Org
            if (isNewOrganization)
            {
                var existingOrg = HttpRequestStorage.DatabaseEntities.Organizations.SingleOrDefault(o => o.OrganizationName.ToLower() == this.OrganizationName.ToLower());
                if (existingOrg != null)
                {
                    validationResults.Add(new SitkaValidationResult<EditViewModel, string>($"There is already an Organization named {this.OrganizationName}.", x => x.OrganizationName));
                }
            }
            else
            // If Existing Organization being edited, and name is being changed, make sure Org name not already taken by other Org
            {
                var existingOrgWithCurrentID = HttpRequestStorage.DatabaseEntities.Organizations.SingleOrDefault(o => o.OrganizationID == this.OrganizationID);
                Check.EnsureNotNull(existingOrgWithCurrentID, $"Was expecting to find existing record for Organization with OrganizationID {this.OrganizationID}; please contact Sitka support");
                bool organizationNameIsBeingChanged = existingOrgWithCurrentID.OrganizationName.ToLower() != this.OrganizationName.ToLower();
                if (organizationNameIsBeingChanged)
                {
                    var existingOrgWithNewName = HttpRequestStorage.DatabaseEntities.Organizations.SingleOrDefault(o => o.OrganizationName.ToLower() == this.OrganizationName.ToLower());
                    if (existingOrgWithNewName != null)
                    {
                        validationResults.Add(new SitkaValidationResult<EditViewModel, string>($"There is already another Organization named {this.OrganizationName}.", x => x.OrganizationName));
                    }
                }
            }

            if (string.IsNullOrEmpty(OrganizationShortName))
            {
                validationResults.Add(new SitkaValidationResult<EditViewModel, string>("The Short Name field is required.", x => x.OrganizationShortName));
            }

            if (LogoFileResourceData != null && LogoFileResourceData.ContentLength > MaxLogoSizeInBytes)
            {
                var errorMessage = $"Logo is too large - must be less than {FileUtility.FormatBytes(MaxLogoSizeInBytes)}. Your logo was {FileUtility.FormatBytes(LogoFileResourceData.ContentLength)}.";
                validationResults.Add(new SitkaValidationResult<EditViewModel, HttpPostedFileBase>(errorMessage, x => x.LogoFileResourceData));
            }

            var isSitkaAdmin = new SitkaAdminFeature().HasPermissionByFirmaSession(HttpRequestStorage.FirmaSession);
            if (KeystoneOrganizationGuid.HasValue && isSitkaAdmin)
            {
                var organization = HttpRequestStorage.DatabaseEntities.Organizations.SingleOrDefault(x => x.KeystoneOrganizationGuid == KeystoneOrganizationGuid);
                if (organization != null && organization.OrganizationID != OrganizationID)
                {
                    validationResults.Add(new SitkaValidationResult<EditViewModel, Guid?>("This Guid is already associated with an Organization", x => x.KeystoneOrganizationGuid));
                }
                else
                {
                    try
                    {
                        var keystoneClient = new KeystoneDataClient();
                        var keystoneOrganization = keystoneClient.GetOrganization(KeystoneOrganizationGuid.Value);
                    }
                    catch (Exception)
                    {
                        validationResults.Add(new SitkaValidationResult<EditViewModel, Guid?>("Organization Guid not found in Keystone", x => x.KeystoneOrganizationGuid));
                    }
                    
                }
            }

            return validationResults;
        }

        public const int MaxLogoSizeInBytes = 1024 * 200;
    }
}
