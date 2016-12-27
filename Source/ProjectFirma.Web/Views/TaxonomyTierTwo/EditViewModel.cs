using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;
using LtInfo.Common;
using LtInfo.Common.Models;

namespace ProjectFirma.Web.Views.TaxonomyTierTwo
{
    public class EditViewModel : FormViewModel, IValidatableObject
    {
        [Required]
        public int TaxonomyTierTwoID { get; set; }

        [Required]
        [StringLength(Models.TaxonomyTierTwo.FieldLengths.TaxonomyTierTwoName)]
        [FieldDefinitionDisplay(FieldDefinitionEnum.TaxonomyTierTwoName)]
        public string TaxonomyTierTwoName { get; set; }

        [Required]
        [FieldDefinitionDisplay(FieldDefinitionEnum.TaxonomyTierThree)]
        public int TaxonomyTierThreeID { get; set; }

        /// <summary>
        /// Needed by the ModelBinder
        /// </summary>
        public EditViewModel()
        {
        }

        public EditViewModel(Models.TaxonomyTierTwo taxonomyTierTwo)
        {
            TaxonomyTierTwoID = taxonomyTierTwo.TaxonomyTierTwoID;
            TaxonomyTierTwoName = taxonomyTierTwo.TaxonomyTierTwoName;
            TaxonomyTierThreeID = taxonomyTierTwo.TaxonomyTierThreeID;
        }

        public void UpdateModel(Models.TaxonomyTierTwo taxonomyTierTwo, Person currentPerson)
        {
            taxonomyTierTwo.TaxonomyTierTwoName = TaxonomyTierTwoName;
            taxonomyTierTwo.TaxonomyTierThreeID = TaxonomyTierThreeID;
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var errors = new List<ValidationResult>();
            var existingTaxonomyTierTwos = HttpRequestStorage.DatabaseEntities.TaxonomyTierTwos.ToList();
            if (!Models.TaxonomyTierTwo.IsTaxonomyTierTwoNameUnique(existingTaxonomyTierTwos, TaxonomyTierTwoName, TaxonomyTierTwoID))
            {
                errors.Add(new SitkaValidationResult<EditViewModel, string>("Name already exists", x => x.TaxonomyTierTwoName));
            }
            return errors;
        }
    }
}