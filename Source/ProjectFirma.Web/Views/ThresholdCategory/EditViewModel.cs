using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using LtInfo.Common.Models;
using ProjectFirma.Web.Models;

namespace ProjectFirma.Web.Views.ThresholdCategory
{
    public class EditViewModel : FormViewModel, IValidatableObject
    {
        [Required]
        public int ThresholdCategoryID { get; set; }

        [Required]
        [StringLength(Models.ThresholdCategory.FieldLengths.DisplayName)]
        public string DisplayName { get; set; }

        [Required]
        [StringLength(Models.ThresholdCategory.FieldLengths.ThresholdCategoryDescription)]
        public string ThresholdCategoryDescription { get; set; }
        
        [Required]
        [StringLength(Models.ThresholdCategory.FieldLengths.GoalStatement)]
        public string GoalStatement { get; set; }

        /// <summary>
        /// Needed by the ModelBinder
        /// </summary>
        public EditViewModel()
        {
        }

        public EditViewModel(Models.ThresholdCategory thresholdCategory)
        {
            ThresholdCategoryID = thresholdCategory.ThresholdCategoryID;
            DisplayName = thresholdCategory.DisplayName;
            ThresholdCategoryDescription = thresholdCategory.ThresholdCategoryDescription;
            GoalStatement = thresholdCategory.GoalStatement;
        }

        public void UpdateModel(Models.ThresholdCategory thresholdCategory, Person currentPerson)
        {
            thresholdCategory.DisplayName = DisplayName;
            thresholdCategory.ThresholdCategoryDescription = ThresholdCategoryDescription;
            thresholdCategory.GoalStatement = GoalStatement;
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            return new List<ValidationResult>();
        }
    }
}