using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;
using LtInfo.Common;
using LtInfo.Common.Models;

namespace ProjectFirma.Web.Views.Tag
{
    public class EditViewModel : FormViewModel, IValidatableObject
    {
        [Required]
        public int TagID { get; set; }

        [Required]
        [StringLength(Models.Tag.FieldLengths.TagName)]
        [FieldDefinitionDisplay(FieldDefinitionEnum.TagName)]
        [RegularExpression(@"^[a-zA-Z0-9-_\s]{1,}$", ErrorMessage = ProjectFirmaValidationMessages.LettersNumbersSpacesDashesAndUnderscoresOnly)]
        public string TagName { get; set; }

        [StringLength(Models.Tag.FieldLengths.TagDescription)]
        [FieldDefinitionDisplay(FieldDefinitionEnum.TagDescription)]
        public string TagDescription { get; set; }

        /// <summary>
        /// Needed by the ModelBinder
        /// </summary>
        public EditViewModel()
        {
        }

        public EditViewModel(Models.Tag tag)
        {
            TagID = tag.TagID;
            TagName = tag.TagName;
            TagDescription = tag.TagDescription;
        }

        public void UpdateModel(Models.Tag tag, Person currentPerson)
        {
            tag.TagName = TagName;
            tag.TagDescription = TagDescription;
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var errors = new List<ValidationResult>();

            var existingTags = HttpRequestStorage.DatabaseEntities.Tags.ToList();
            if (!Models.Tag.IsTagNameUnique(existingTags, TagName, TagID))
            {
                errors.Add(new SitkaValidationResult<EditViewModel, string>(ProjectFirmaValidationMessages.TagNameUnique, x => x.TagName));
            }

            return errors;
        }
    }
}