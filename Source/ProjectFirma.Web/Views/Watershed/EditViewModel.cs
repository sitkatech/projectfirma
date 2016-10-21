using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;
using LtInfo.Common;
using LtInfo.Common.Models;

namespace ProjectFirma.Web.Views.Watershed
{
    public class EditViewModel : FormViewModel, IValidatableObject
    {
        [Required]
        public int WatershedID { get; set; }

        [Required]
        [StringLength(Models.Watershed.FieldLengths.WatershedName)]
        [FieldDefinitionDisplay(FieldDefinitionEnum.WatershedName)]
        public string WatershedName { get; set; }

        /// <summary>
        /// Needed by the ModelBinder
        /// </summary>
        public EditViewModel()
        {
        }

        public EditViewModel(Models.Watershed watershed)
        {
            WatershedID = watershed.WatershedID;
            WatershedName = watershed.WatershedName;
        }

        public void UpdateModel(Models.Watershed watershed, Person currentPerson)
        {
            watershed.WatershedName = WatershedName;
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var errors = new List<ValidationResult>();

            var existingWatersheds = HttpRequestStorage.DatabaseEntities.Watersheds.ToList();
            if (!Models.Watershed.IsWatershedNameUnique(existingWatersheds, WatershedName, WatershedID))
            {
                errors.Add(new SitkaValidationResult<EditViewModel, string>(ProjectFirmaValidationMessages.WatershedNameUnique, x => x.WatershedName));
            }

            return errors;
        }
    }
}