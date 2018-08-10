using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using LtInfo.Common;
using LtInfo.Common.Mvc;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;

namespace ProjectFirma.Web.Views.Shared.ProjectDocument
{
    public class NewProjectDocumentViewModel: IValidatableObject
    {
        [Required]
        [DisplayName("File")]
        [SitkaFileExtensions("pdf|zip|doc|docx|xls|xlsx")]
        public HttpPostedFileBase File { get; set; }

        [Required]
        [DisplayName("Display Name")]
        [StringLength(Models.ProjectDocument.FieldLengths.DisplayName, ErrorMessage = "200 character maximum")]
        public string DisplayName { get; set; }

        [DisplayName("Description")]
        [StringLength(Models.ProjectDocument.FieldLengths.Description, ErrorMessage = "1000 character maximum.")]
        public string Description { get; set; }

        // can be the ID of a Project or a ProjectUpdateBatch depending on whether this ViewModel or its child type is invoked.
        public int? ParentID { get; set; }

        /// <summary>
        /// Needed by ModelBinder
        /// </summary>
        public NewProjectDocumentViewModel() { }
        public NewProjectDocumentViewModel(Models.Project project)
        {
            ParentID = project.ProjectID;
        }

        public void UpdateModel(Models.Project project, Person currentPerson)
        {
            var fileResource = FileResource.CreateNewFromHttpPostedFile(File, currentPerson);
            HttpRequestStorage.DatabaseEntities.AllFileResources.Add(fileResource);
            var projectDocument = new Models.ProjectDocument(project.ProjectID, fileResource.FileResourceID, DisplayName)
            {
                Description = Description
            };
            project.ProjectDocuments.Add(projectDocument);
        }

        public void UpdateModel(ProjectUpdateBatch projectUpdateBatch, Person currentPerson)
        {
            var fileResource = FileResource.CreateNewFromHttpPostedFile(File, currentPerson);
            HttpRequestStorage.DatabaseEntities.AllFileResources.Add(fileResource);
            var projectDocument = new ProjectDocumentUpdate(projectUpdateBatch.ProjectID, fileResource.FileResourceID, DisplayName)
            {
                Description = Description
            };
            projectUpdateBatch.ProjectDocumentUpdates.Add(projectDocument);
        }

        public virtual IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var validationResults = new List<ValidationResult>();
            FileResource.ValidateFileSize(File, validationResults, "File");

            if (HttpRequestStorage.DatabaseEntities.ProjectDocuments.Where(x => x.ProjectID == ParentID)
                .Any(x => x.DisplayName.ToLower() == DisplayName.ToLower()))
            {
                validationResults.Add(new SitkaValidationResult<NewProjectDocumentViewModel, string>($"The Display Name must be unique for each Document attached to a {Models.FieldDefinition.Project.GetFieldDefinitionLabel()}", m=>m.DisplayName));
            }

            return validationResults;
        }
    }
}
