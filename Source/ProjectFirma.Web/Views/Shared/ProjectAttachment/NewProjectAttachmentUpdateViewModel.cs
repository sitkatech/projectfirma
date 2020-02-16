using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Views.Shared.ProjectAttachment
{
    // exists because validating a document requires making sure its name is unique, and to do that requires knowing if it's a Attachment or a Attachment Update
    public class NewProjectAttachmentUpdateViewModel : NewProjectAttachmentViewModel
    {

        /// <summary>
        /// Needed by the ModelBinder
        /// </summary>
        public NewProjectAttachmentUpdateViewModel() { }

        public NewProjectAttachmentUpdateViewModel(ProjectUpdateBatch projectUpdateBatch)
        {
            ProjectUpdateBatchID = projectUpdateBatch.ProjectUpdateBatchID;
            CheckForNotNullProjectUpdateBatchId();
        }

        public override IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            CheckForNotNullProjectUpdateBatchId();
            var validationResults = new List<ValidationResult>();

            if (HttpRequestStorage.DatabaseEntities.ProjectAttachmentUpdates.Any(x => x.ProjectUpdateBatchID == ProjectUpdateBatchID && x.DisplayName == DisplayName))
            {
                validationResults.Add(new SitkaValidationResult<NewProjectAttachmentViewModel, string>($"The Display Name must be unique for each Attachment attached to a {FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabel()} Update", m => m.DisplayName));
            }

            return validationResults;
        }

        public void UpdateModel(ProjectUpdateBatch projectUpdateBatch, FirmaSession currentFirmaSession)
        {
            CheckForNotNullProjectUpdateBatchId();
            var fileResource = FileResourceModelExtensions.CreateNewFromHttpPostedFile(UploadedFile, currentFirmaSession.Person);
            HttpRequestStorage.DatabaseEntities.AllFileResources.Add(fileResource);
            var projectAttachment = new ProjectAttachmentUpdate(projectUpdateBatch.ProjectUpdateBatchID, fileResource.FileResourceID, AttachmentTypeID, DisplayName)
            {
                Description = Description
            };
            projectUpdateBatch.ProjectAttachmentUpdates.Add(projectAttachment);
        }

        protected void CheckForNotNullProjectUpdateBatchId()
        {
            Check.Invariant(this.ProjectUpdateBatchID.HasValue, "ProjectUpdateBatchID must have a value");
        }
    }
}
