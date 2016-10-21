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
    public class EditMapAndCaptionViewModel : FormViewModel, IValidatableObject
    {
        [DisplayName("Image File")]
        [SitkaFileExtensions("jpg|jpeg|gif|png")]
        public HttpPostedFileBase FileResourceData { get; set; }

        [DisplayName("Description")]
        [StringLength(Models.ThresholdEvaluation.FieldLengths.MapCaption)]
        public string MapCaption { get; set; }

        /// <summary>
        /// Needed by the ModelBinder
        /// </summary>
        public EditMapAndCaptionViewModel() { }

        public EditMapAndCaptionViewModel(string mapCaption)
        {
            MapCaption = mapCaption;
        }

        public void UpdateModel(Models.ThresholdEvaluation thresholdEvaluation, Person currentPerson)
        {
            if (FileResourceData != null)
            {
                thresholdEvaluation.MapFileResource = FileResource.CreateNewFromHttpPostedFileAndSave(FileResourceData, currentPerson);
            }

            thresholdEvaluation.MapCaption = MapCaption;
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var errors = new List<ValidationResult>();

            //If we have an image, make sure it's a reasonable filesize
            if (FileResourceData != null)
            {
                FileResource.ValidateFileSize(FileResourceData, errors, GeneralUtility.NameOf(() => FileResourceData));
            }

            return errors;
        }
    }
}