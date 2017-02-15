using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;
using LtInfo.Common;
using LtInfo.Common.Models;

namespace ProjectFirma.Web.Views.TaxonomyTierThree
{
    public class EditViewModel : FormViewModel, IValidatableObject
    {
        [Required]
        public int TaxonomyTierThreeID { get; set; }

        [Required]
        [StringLength(Models.TaxonomyTierThree.FieldLengths.TaxonomyTierThreeName)]
        [FieldDefinitionDisplay(FieldDefinitionEnum.TaxonomyTierThreeName)]
        public string TaxonomyTierThreeName { get; set; }

        [StringLength(Models.TaxonomyTierThree.FieldLengths.TaxonomyTierThreeDescription)]
        [DisplayName("Description")]
        public string TaxonomyTierThreeDescription { get; set; }

        [Required]
        public string ThemeColor { get; set; }

        /// <summary>
        /// Needed by the ModelBinder
        /// </summary>
        public EditViewModel()
        {
        }

        public EditViewModel(Models.TaxonomyTierThree taxonomyTierThree)
        {
            TaxonomyTierThreeID = taxonomyTierThree.TaxonomyTierThreeID;
            TaxonomyTierThreeName = taxonomyTierThree.TaxonomyTierThreeName;
            TaxonomyTierThreeDescription = taxonomyTierThree.TaxonomyTierThreeDescription;
            ThemeColor = taxonomyTierThree.ThemeColor;
        }

        public void UpdateModel(Models.TaxonomyTierThree taxonomyTierThree, Person currentPerson)
        {
            taxonomyTierThree.TaxonomyTierThreeName = TaxonomyTierThreeName;
            taxonomyTierThree.TaxonomyTierThreeDescription = TaxonomyTierThreeDescription;
            taxonomyTierThree.ThemeColor = ThemeColor;
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var errors = new List<ValidationResult>();

            var existingTaxonomyTierThrees = HttpRequestStorage.DatabaseEntities.TaxonomyTierThrees.ToList();
            if (!Models.TaxonomyTierThree.IsTaxonomyTierThreeNameUnique(existingTaxonomyTierThrees, TaxonomyTierThreeName, TaxonomyTierThreeID))
            {
                errors.Add(new SitkaValidationResult<EditViewModel, string>("Name already exists", x => x.TaxonomyTierThreeName));
            }

            return errors;
        }
    }
}