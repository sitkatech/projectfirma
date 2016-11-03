using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;
using LtInfo.Common;
using LtInfo.Common.Models;

namespace ProjectFirma.Web.Views.FundingSource
{
    public class EditViewModel : FormViewModel, IValidatableObject
    {
        [Required]
        public int FundingSourceID { get; set; }

        [Required]
        [StringLength(Models.FundingSource.FieldLengths.FundingSourceName)]
        [FieldDefinitionDisplay(FieldDefinitionEnum.FundingSourceName)]
        public string FundingSourceName { get; set; }

        [Required]
        [FieldDefinitionDisplay(FieldDefinitionEnum.Organization)]
        public int OrganizationID { get; set; }

        [Required]
        [DisplayName("Is Active")]
        public bool IsActive { get; set; }

        [StringLength(Models.FundingSource.FieldLengths.FundingSourceDescription)]
        [FieldDefinitionDisplay(FieldDefinitionEnum.FundingSourceDescription)]
        public string FundingSourceDescription { get; set; }

        /// <summary>
        /// Needed by the ModelBinder
        /// </summary>
        public EditViewModel()
        {
        }

        public EditViewModel(Models.FundingSource fundingSource)
        {
            FundingSourceID = fundingSource.FundingSourceID;
            FundingSourceName = fundingSource.FundingSourceName;
            FundingSourceDescription = fundingSource.FundingSourceDescription;
            OrganizationID = fundingSource.OrganizationID;
            IsActive = fundingSource.IsActive;
        }

        public void UpdateModel(Models.FundingSource fundingSource, Person currentPerson)
        {
            fundingSource.FundingSourceName = FundingSourceName;
            fundingSource.FundingSourceDescription = FundingSourceDescription;
            fundingSource.OrganizationID = OrganizationID;
            fundingSource.IsActive = IsActive;
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var errors = new List<ValidationResult>();

            var existingFundingSources = HttpRequestStorage.DatabaseEntities.FundingSources.Where(x => x.OrganizationID == OrganizationID).ToList();
            if (!Models.FundingSource.IsFundingSourceNameUnique(existingFundingSources, FundingSourceName, FundingSourceID))
            {
                errors.Add(new SitkaValidationResult<EditViewModel, string>(FirmaValidationMessages.FundingSourceNameUnique, x => x.FundingSourceName));
            }
            return errors;
        }
    }
}