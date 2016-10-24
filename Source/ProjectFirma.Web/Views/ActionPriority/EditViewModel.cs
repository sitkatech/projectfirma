using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;
using LtInfo.Common;
using LtInfo.Common.Models;

namespace ProjectFirma.Web.Views.ActionPriority
{
    public class EditViewModel : FormViewModel, IValidatableObject
    {
        [Required]
        public int ActionPriorityID { get; set; }

        [Required]
        [StringLength(Models.ActionPriority.FieldLengths.ActionPriorityName)]
        [FieldDefinitionDisplay(FieldDefinitionEnum.ActionPriorityName)]
        public string ActionPriorityName { get; set; }

        [Required]
        [FieldDefinitionDisplay(FieldDefinitionEnum.Program)]
        public int ProgramID { get; set; }

        /// <summary>
        /// Needed by the ModelBinder
        /// </summary>
        public EditViewModel()
        {
        }

        public EditViewModel(Models.ActionPriority actionPriority)
        {
            ActionPriorityID = actionPriority.ActionPriorityID;
            ActionPriorityName = actionPriority.ActionPriorityName;
            ProgramID = actionPriority.ProgramID;
        }

        public void UpdateModel(Models.ActionPriority actionPriority, Person currentPerson)
        {
            actionPriority.ActionPriorityName = ActionPriorityName;
            actionPriority.ProgramID = ProgramID;
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var errors = new List<ValidationResult>();

            var existingActionPriorities = HttpRequestStorage.DatabaseEntities.ActionPriorities.ToList();
            if (!Models.ActionPriority.IsActionPriorityNameUnique(existingActionPriorities, ActionPriorityName, ActionPriorityID))
            {
                errors.Add(new SitkaValidationResult<EditViewModel, string>("Name already exists", x => x.ActionPriorityName));
            }

            return errors;
        }
    }
}