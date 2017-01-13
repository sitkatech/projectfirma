using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web;
using LtInfo.Common;
using LtInfo.Common.Models;
using LtInfo.Common.Mvc;
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
        
        [StringLength(Models.Classification.FieldLengths.GoalStatement)]
        public string GoalStatement { get; set; }

        [DisplayName("Key Image")]
        [SitkaFileExtensions("jpg|jpeg|gif|png")]
        public HttpPostedFileBase KeyImageFileResourceData { get; set; }

        [Required]
        public string ThemeColor { get; set; }

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
            ThemeColor = classification.ThemeColor;
        }

        public void UpdateModel(Models.Classification classification, Person currentPerson)
        {
            classification.DisplayName = DisplayName;
            classification.ClassificationDescription = ClassificationDescription;
            classification.GoalStatement = GoalStatement;

            if (KeyImageFileResourceData != null)
            {
                classification.KeyImageFileResource = FileResource.CreateNewFromHttpPostedFileAndSave(KeyImageFileResourceData, currentPerson);
            }
            classification.ThemeColor = ThemeColor;

        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var validationResults = new List<ValidationResult>();

            if (KeyImageFileResourceData != null && KeyImageFileResourceData.ContentLength > MaxImageSizeInBytes)
            {
                var errorMessage = String.Format("Logo is too large - must be less than {0}. Your logo was {1}.",
                    FileUtility.FormatBytes(MaxImageSizeInBytes),
                    FileUtility.FormatBytes(KeyImageFileResourceData.ContentLength));
                validationResults.Add(
                    new SitkaValidationResult<EditViewModel, HttpPostedFileBase>(errorMessage, x => x.KeyImageFileResourceData));
            }

            return validationResults;
        }

        public const int MaxImageSizeInBytes = 1024 * 500;
    }
}