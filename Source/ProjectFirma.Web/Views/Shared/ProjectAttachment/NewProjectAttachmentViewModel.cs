using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using LtInfo.Common;
using LtInfo.Common.Mvc;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Views.Shared.ProjectAttachment
{
    public class NewProjectAttachmentViewModel: IValidatableObject
    {
        [Required]
        [DisplayName("File")]
        [SitkaFileExtensions("doc|docx|jpg|jpeg|pdf|ppt|pptx|png|tif|xls|xlsx|zip")]
        public HttpPostedFileBase File { get; set; }

        [Required]
        [DisplayName("Display Name")]
        [StringLength(ProjectFirmaModels.Models.ProjectAttachment.FieldLengths.DisplayName, ErrorMessage = "200 character maximum")]
        public string DisplayName { get; set; }

        [DisplayName("Description")]
        [StringLength(ProjectFirmaModels.Models.ProjectAttachment.FieldLengths.Description, ErrorMessage = "1000 character maximum.")]
        public string Description { get; set; }

        // can be the ID of a Project or a ProjectUpdateBatch depending on whether this ViewModel or its child type is invoked.
        public int? ParentID { get; set; }

        /// <summary>
        /// Needed by ModelBinder
        /// </summary>
        public NewProjectAttachmentViewModel() { }
        public NewProjectAttachmentViewModel(ProjectFirmaModels.Models.Project project)
        {
            ParentID = project.ProjectID;
        }

        public void UpdateModel(ProjectFirmaModels.Models.Project project, Person currentPerson)
        {
            var fileResource = FileResourceModelExtensions.CreateNewFromHttpPostedFile(File, currentPerson);
            HttpRequestStorage.DatabaseEntities.AllFileResources.Add(fileResource);
            var projectAttachment = new ProjectFirmaModels.Models.ProjectAttachment(project.ProjectID, fileResource.FileResourceID, DisplayName)
            {
                Description = Description
            };
            project.ProjectAttachments.Add(projectAttachment);
        }

        public void UpdateModel(ProjectUpdateBatch projectUpdateBatch, Person currentPerson)
        {
            var fileResource = FileResourceModelExtensions.CreateNewFromHttpPostedFile(File, currentPerson);
            HttpRequestStorage.DatabaseEntities.AllFileResources.Add(fileResource);
            var projectAttachment = new ProjectAttachmentUpdate(projectUpdateBatch.ProjectID, fileResource.FileResourceID, DisplayName)
            {
                Description = Description
            };
            projectUpdateBatch.ProjectAttachmentUpdates.Add(projectAttachment);
        }

        public virtual IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var validationResults = new List<ValidationResult>();
            FileResourceModelExtensions.ValidateFileSize(File, validationResults, "File");

            if (HttpRequestStorage.DatabaseEntities.ProjectAttachments.Where(x => x.ProjectID == ParentID)
                .Any(x => x.DisplayName.ToLower() == DisplayName.ToLower()))
            {
                validationResults.Add(new SitkaValidationResult<NewProjectAttachmentViewModel, string>($"The Display Name must be unique for each Attachment attached to a {FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabel()}", m=>m.DisplayName));
            }

            return validationResults;
        }
    }
}
