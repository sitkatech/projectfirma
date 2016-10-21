using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;
using LtInfo.Common;
using LtInfo.Common.Models;
using LtInfo.Common.Mvc;

namespace ProjectFirma.Web.Views.MonitoringProgram
{
    public class NewMonitoringProgramDocumentViewModel : FormViewModel, IValidatableObject
    {
        [Required]
        public int MonitoringProgramDocumentID { get; set; }

        [Required]
        [DisplayName("Monitoring Program Document")]
        [SitkaFileExtensions("pdf")]
        public HttpPostedFileBase FileResourceData { get; set; }

        [StringLength(MonitoringProgramDocument.FieldLengths.DisplayName)]
        [FieldDefinitionDisplay(FieldDefinitionEnum.MonitoringApproach)]
        [Required]
        public string DisplayName { get; set; }

        [Required]
        public DateTime UploadDate { get; set; }


        /// <summary>
        /// Needed by the ModelBinder
        /// </summary>
        public NewMonitoringProgramDocumentViewModel()
        {
        }

        public NewMonitoringProgramDocumentViewModel(MonitoringProgramDocument monitoringProgramDocument)
        {
            DisplayName = monitoringProgramDocument.DisplayName;
            UploadDate = monitoringProgramDocument.UploadDate;
        }

        public void UpdateModel(MonitoringProgramDocument monitoringProgramDocument, Person currentPerson)
        {
            monitoringProgramDocument.DisplayName = DisplayName;
            monitoringProgramDocument.UploadDate = UploadDate;
            monitoringProgramDocument.FileResource = FileResource.CreateNewFromHttpPostedFileAndSave(FileResourceData, currentPerson);
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var errors = new List<ValidationResult>();
            FileResource.ValidateFileSize(FileResourceData, errors, GeneralUtility.NameOf(() => FileResourceData));
            return errors;
        }
    }
}