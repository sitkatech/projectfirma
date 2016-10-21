using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;
using LtInfo.Common;
using LtInfo.Common.Models;

namespace ProjectFirma.Web.Areas.EIP.Views.Program
{
    public class EditViewModel : FormViewModel, IValidatableObject
    {
        [Required]
        public int ProgramID { get; set; }

        [Required]
        [StringLength(Models.Program.FieldLengths.ProgramName)]
        [FieldDefinitionDisplay(FieldDefinitionEnum.ProgramName)]
        public string ProgramName { get; set; }

        [Required]
        [FieldDefinitionDisplay(FieldDefinitionEnum.FocusArea)]
        public int FocusAreaID { get; set; }

        [FieldDefinitionDisplay(FieldDefinitionEnum.AssociatedPrograms)]
        public HtmlString AssociatedProgramsHtmlString { get; set; }

        /// <summary>
        /// Needed by the ModelBinder
        /// </summary>
        public EditViewModel()
        {
        }

        public EditViewModel(Models.Program program)
        {
            ProgramID = program.ProgramID;
            ProgramName = program.ProgramName;
            FocusAreaID = program.FocusAreaID;
            AssociatedProgramsHtmlString = program.AssociatedProgramsHtmlString;
        }

        public void UpdateModel(Models.Program program, Person currentPerson)
        {
            program.ProgramName = ProgramName;
            program.FocusAreaID = FocusAreaID;
            program.AssociatedProgramsHtmlString = AssociatedProgramsHtmlString;
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var errors = new List<ValidationResult>();
            var existingPrograms = HttpRequestStorage.DatabaseEntities.Programs.ToList();
            if (!Models.Program.IsProgramNameUnique(existingPrograms, ProgramName, ProgramID))
            {
                errors.Add(new SitkaValidationResult<EditViewModel, string>("Name already exists", x => x.ProgramName));
            }
            return errors;
        }
    }
}