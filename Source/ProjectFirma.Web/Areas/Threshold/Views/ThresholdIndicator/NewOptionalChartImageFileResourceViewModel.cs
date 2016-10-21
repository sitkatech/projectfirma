using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web;
using ProjectFirma.Web.Models;
using LtInfo.Common;
using LtInfo.Common.Models;
using LtInfo.Common.Mvc;

namespace ProjectFirma.Web.Areas.Threshold.Views.ThresholdIndicator
{
    public class NewOptionalChartImageFileResourceViewModel : FormViewModel, IValidatableObject
    {
        [DisplayName("Image File")]
        [SitkaFileExtensions("jpg|jpeg|gif|png")]
        public HttpPostedFileBase FileResourceData { get; set; }

        /// <summary>
        /// Needed by the ModelBinder
        /// </summary>
        public NewOptionalChartImageFileResourceViewModel() { }

        
        public void UpdateModel(Models.ThresholdIndicator thresholdIndicator, Person currentPerson)
        {
            if (FileResourceData != null)
            {
                thresholdIndicator.OptionalChartImageFileResource = FileResource.CreateNewFromHttpPostedFileAndSave(FileResourceData, currentPerson);
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