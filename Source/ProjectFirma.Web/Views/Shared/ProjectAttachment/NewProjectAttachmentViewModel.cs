using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Web;
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Mvc;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Views.Shared.ProjectAttachment
{
    public class NewProjectAttachmentViewModel : IValidatableObject
    {
        [Required]
        [DisplayName("File")]
        public HttpPostedFileBase UploadedFile { get; set; }

        [Required]
        [FieldDefinitionDisplay(FieldDefinitionEnum.ProjectAttachmentRelationshipType)]
        public int AttachmentRelationshipTypeID { get; set; }

        [Required]
        [DisplayName("Display Name")]
        [StringLength(ProjectFirmaModels.Models.ProjectAttachment.FieldLengths.DisplayName, ErrorMessage = "200 character maximum")]
        public string DisplayName { get; set; }

        [DisplayName("Description")]
        [StringLength(ProjectFirmaModels.Models.ProjectAttachment.FieldLengths.Description, ErrorMessage = "1000 character maximum.")]
        public string Description { get; set; }


        public int? ProjectID { get; set; }
        //8/21/2019 TK - this property is here(instead of in NewProjectAttachmentUpdateViewModel) so we can have a shared view for New Project Attachments in the Create and Update Project workflows
        public int? ProjectUpdateBatchID { get; set; } 

        /// <summary>
        /// Needed by ModelBinder
        /// </summary>
        public NewProjectAttachmentViewModel() { }
        public NewProjectAttachmentViewModel(ProjectFirmaModels.Models.Project project)
        {
            ProjectID = project.ProjectID;
            CheckForNotNullProjectId();
        }

        public void UpdateModel(ProjectFirmaModels.Models.Project project, Person currentPerson)
        {
            CheckForNotNullProjectId();
            var fileResource = FileResourceModelExtensions.CreateNewFromHttpPostedFile(UploadedFile, currentPerson);
            HttpRequestStorage.DatabaseEntities.AllFileResources.Add(fileResource);
            var projectAttachment = new ProjectFirmaModels.Models.ProjectAttachment(project.ProjectID, fileResource.FileResourceID, AttachmentRelationshipTypeID, DisplayName)
            {
                Description = Description
            };
            project.ProjectAttachments.Add(projectAttachment);
        }

        

        public virtual IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            CheckForNotNullProjectId();
            var validationResults = new List<ValidationResult>();
            FileResourceModelExtensions.ValidateFileSize(UploadedFile, validationResults, "File");

            if (HttpRequestStorage.DatabaseEntities.ProjectAttachments.Where(x => x.ProjectID == ProjectID)
                .Any(x => x.DisplayName.ToLower() == DisplayName.ToLower()))
            {
                validationResults.Add(new SitkaValidationResult<NewProjectAttachmentViewModel, string>($"The Display Name must be unique for each Attachment attached to a {FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabel()}", m=>m.DisplayName));
            }

            return validationResults;
        }


        protected void CheckForNotNullProjectId()
        {
            Check.Invariant(this.ProjectID.HasValue, "ProjectID must have a value");
        }
    }
}
