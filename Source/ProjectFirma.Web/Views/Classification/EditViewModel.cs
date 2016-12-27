using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using LtInfo.Common.Models;
using ProjectFirma.Web.Models;

namespace ProjectFirma.Web.Views.Classification
{
    public class EditViewModel : FormViewModel, IValidatableObject
    {
        [Required]
        public int ClassificationID { get; set; }

        [Required]
        [StringLength(Models.Classification.FieldLengths.DisplayName)]
        public string DisplayName { get; set; }

        [Required]
        [StringLength(Models.Classification.FieldLengths.ClassificationDescription)]
        public string ClassificationDescription { get; set; }
        
        [Required]
        [StringLength(Models.Classification.FieldLengths.GoalStatement)]
        public string GoalStatement { get; set; }

        /// <summary>
        /// Needed by the ModelBinder
        /// </summary>
        public EditViewModel()
        {
        }

        public EditViewModel(Models.Classification classification)
        {
            ClassificationID = classification.ClassificationID;
            DisplayName = classification.DisplayName;
            ClassificationDescription = classification.ClassificationDescription;
            GoalStatement = classification.GoalStatement;
        }

        public void UpdateModel(Models.Classification classification, Person currentPerson)
        {
            classification.DisplayName = DisplayName;
            classification.ClassificationDescription = ClassificationDescription;
            classification.GoalStatement = GoalStatement;
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            return new List<ValidationResult>();
        }
    }
}