using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;
using LtInfo.Common;
using LtInfo.Common.Models;

namespace ProjectFirma.Web.Views.TaxonomyTierOne
{
    public class EditViewModel : FormViewModel, IValidatableObject
    {
        [Required]
        public int TaxonomyTierOneID { get; set; }

        [Required]
        [StringLength(Models.TaxonomyTierOne.FieldLengths.TaxonomyTierOneName)]
        [FieldDefinitionDisplay(FieldDefinitionEnum.TaxonomyTierOneName)]
        public string TaxonomyTierOneName { get; set; }

        [Required]
        [FieldDefinitionDisplay(FieldDefinitionEnum.TaxonomyTierTwo)]
        public int TaxonomyTierTwoID { get; set; }

        /// <summary>
        /// Needed by the ModelBinder
        /// </summary>
        public EditViewModel()
        {
        }

        public EditViewModel(Models.TaxonomyTierOne taxonomyTierOne)
        {
            TaxonomyTierOneID = taxonomyTierOne.TaxonomyTierOneID;
            TaxonomyTierOneName = taxonomyTierOne.TaxonomyTierOneName;
            TaxonomyTierTwoID = taxonomyTierOne.TaxonomyTierTwoID;
        }

        public void UpdateModel(Models.TaxonomyTierOne taxonomyTierOne, Person currentPerson)
        {
            taxonomyTierOne.TaxonomyTierOneName = TaxonomyTierOneName;
            taxonomyTierOne.TaxonomyTierTwoID = TaxonomyTierTwoID;
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var errors = new List<ValidationResult>();

            var existingTaxonomyTierOnes = HttpRequestStorage.DatabaseEntities.TaxonomyTierOnes.ToList();
            if (!Models.TaxonomyTierOne.IsTaxonomyTierOneNameUnique(existingTaxonomyTierOnes, TaxonomyTierOneName, TaxonomyTierOneID))
            {
                errors.Add(new SitkaValidationResult<EditViewModel, string>("Name already exists", x => x.TaxonomyTierOneName));
            }

            return errors;
        }
    }
}