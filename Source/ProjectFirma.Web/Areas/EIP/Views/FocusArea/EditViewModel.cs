using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;
using LtInfo.Common;
using LtInfo.Common.Models;

namespace ProjectFirma.Web.Areas.EIP.Views.FocusArea
{
    public class EditViewModel : FormViewModel, IValidatableObject
    {
        [Required]
        public int FocusAreaID { get; set; }

        [Required]
        [StringLength(Models.FocusArea.FieldLengths.FocusAreaName)]
        [FieldDefinitionDisplay(FieldDefinitionEnum.FocusAreaName)]
        public string FocusAreaName { get; set; }

        /// <summary>
        /// Needed by the ModelBinder
        /// </summary>
        public EditViewModel()
        {
        }

        public EditViewModel(Models.FocusArea focusArea)
        {
            FocusAreaID = focusArea.FocusAreaID;
            FocusAreaName = focusArea.FocusAreaName;
        }

        public void UpdateModel(Models.FocusArea focusArea, Person currentPerson)
        {
            focusArea.FocusAreaName = FocusAreaName;
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var errors = new List<ValidationResult>();

            var existingFocusAreas = HttpRequestStorage.DatabaseEntities.FocusAreas.ToList();
            if (!Models.FocusArea.IsFocusAreaNameUnique(existingFocusAreas, FocusAreaName, FocusAreaID))
            {
                errors.Add(new SitkaValidationResult<EditViewModel, string>("Name already exists", x => x.FocusAreaName));
            }

            return errors;
        }
    }
}