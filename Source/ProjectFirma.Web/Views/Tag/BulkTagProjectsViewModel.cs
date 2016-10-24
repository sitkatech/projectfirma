using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;
using LtInfo.Common.Models;

namespace ProjectFirma.Web.Views.Tag
{
    public class BulkTagProjectsViewModel : FormViewModel
    {
        [Required]
        public List<int> ProjectIDList { get; set; }

        [Required]
        [StringLength(Models.Tag.FieldLengths.TagName)]
        [FieldDefinitionDisplay(FieldDefinitionEnum.TagName)]
        [RegularExpression(@"^[a-zA-Z0-9-_\s]{1,}$", ErrorMessage = ProjectFirmaValidationMessages.LettersNumbersSpacesDashesAndUnderscoresOnly)]
        public string TagName { get; set; }
    }
}
