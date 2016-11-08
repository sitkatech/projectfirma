using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;
using LtInfo.Common;
using LtInfo.Common.Models;
using LtInfo.Common.Mvc;

namespace ProjectFirma.Web.Views.Organization
{
    public class EditViewModel : FormViewModel, IValidatableObject
    {
        public int OrganizationID { get; set; }

        [Required]
        [StringLength(Models.Organization.FieldLengths.OrganizationName)]
        public string OrganizationName { get; set; }

        [Required]
        [StringLength(Models.Organization.FieldLengths.OrganizationAbbreviation)]
        public string OrganizationAbbreviation { get; set; }

        [FieldDefinitionDisplay(FieldDefinitionEnum.Sector)]
        public int SectorID { get; set; }

        [FieldDefinitionDisplay(FieldDefinitionEnum.PrimaryContact)]
        public int? PrimaryContactPersonID { get; set; }

        [Url]
        public string OrganizationUrl { get; set; }

        [DisplayName("Is Active")]
        public bool IsActive { get; set; }

        [DisplayName("Logo")]
        [SitkaFileExtensions("jpg|jpeg|gif|png")]
        public HttpPostedFileBase LogoFileResourceData { get; set; }

        /// <summary>
        /// Needed by the ModelBinder
        /// </summary>
        public EditViewModel()
        {
        }

        public EditViewModel(Models.Organization organization)
        {
            OrganizationID = organization.OrganizationID;
            OrganizationName = organization.OrganizationName;
            OrganizationAbbreviation = organization.OrganizationAbbreviation;
            SectorID = organization.SectorID;
            PrimaryContactPersonID = organization.PrimaryContactPerson != null ? organization.PrimaryContactPerson.PersonID : (int?) null;
            OrganizationUrl = organization.OrganizationUrl;

            IsActive = organization.IsActive;            
        }

        public void UpdateModel(Models.Organization organization, Person currentPerson)
        {
            organization.OrganizationName = OrganizationName;
            organization.OrganizationAbbreviation = OrganizationAbbreviation;
            organization.SectorID = SectorID;
            organization.IsActive = IsActive;
            organization.PrimaryContactPersonID = PrimaryContactPersonID;
            organization.OrganizationUrl = OrganizationUrl;
            if (LogoFileResourceData != null)
            {
                organization.LogoFileResource = FileResource.CreateNewFromHttpPostedFileAndSave(LogoFileResourceData, currentPerson);    
            }                       
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var validationResults = new List<ValidationResult>();
            
            // If we are updating an existing object, make sure we have a Primary Contact
            var primaryContactNotSet = (PrimaryContactPersonID == null);
            if (primaryContactNotSet && ModelObjectHelpers.IsRealPrimaryKeyValue(OrganizationID))
            {
                var organizationBeingUpdated = HttpRequestStorage.DatabaseEntities.Organizations.GetOrganization(OrganizationID);
                if (organizationBeingUpdated.IsLeadImplementerForOneOrMoreProjects)
                {
                    validationResults.Add(
                        new SitkaValidationResult<EditViewModel, int?>(
                            string.Format("Organization {0} is Lead Implementer for one or more projects, so you must specify a primary contact", organizationBeingUpdated.OrganizationName),
                            x => x.PrimaryContactPersonID));
                }
            }

            if (LogoFileResourceData != null && LogoFileResourceData.ContentLength > MaxLogoSizeInBytes)
            {
                var errorMessage = String.Format("Logo is too large - must be less than {0}. Your logo was {1}.",
                    FileUtility.FormatBytes(MaxLogoSizeInBytes),
                    FileUtility.FormatBytes(LogoFileResourceData.ContentLength));
                validationResults.Add(
                    new SitkaValidationResult<EditViewModel, HttpPostedFileBase>(errorMessage, x => x.LogoFileResourceData));
            }
            return validationResults;
        }

        public const int MaxLogoSizeInBytes = 1024 * 100;
    }
}