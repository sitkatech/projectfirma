using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web;
using LtInfo.Common.Models;
using ProjectFirma.Web.Models;
using LtInfo.Common;
using LtInfo.Common.Mvc;

namespace ProjectFirma.Web.Areas.Threshold.Views.ThresholdEvaluation
{
    public class NewHistoricEvaluationPdfFileResourceViewModel : FormViewModel, IValidatableObject
    {
        [DisplayName("PDF File")]
        [SitkaFileExtensions("pdf")]
        public HttpPostedFileBase FileResourceData { get; set; }

        /// <summary>
        /// Needed by the ModelBinder
        /// </summary>
        public NewHistoricEvaluationPdfFileResourceViewModel() { }

        
        public void UpdateModel(Models.ThresholdEvaluation thresholdEvaluation, Person currentPerson)
        {
            if (FileResourceData != null)
            {
                thresholdEvaluation.HistoricEvaluationPdfFileResource = FileResource.CreateNewFromHttpPostedFileAndSave(FileResourceData, currentPerson);
            }
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var errors = new List<ValidationResult>();

            //If we have a pdf, make sure it's a reasonable filesize
            if (FileResourceData != null)
            {
                FileResource.ValidateFileSize(FileResourceData, errors, GeneralUtility.NameOf(() => FileResourceData));
            }

            return errors;
        }
    }
}