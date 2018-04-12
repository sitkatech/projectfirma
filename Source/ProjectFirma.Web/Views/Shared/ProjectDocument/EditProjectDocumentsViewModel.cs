using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using LtInfo.Common;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Views.Shared.ProjectDocument
{
    public class EditProjectDocumentsViewModel: IValidatableObject
    {
        [Required]
        [DisplayName("Display Name")]
        [StringLength(Models.ProjectDocument.FieldLengths.DisplayName, ErrorMessage = "200 character maximum")]
        public string DisplayName { get; set; }
        
        [DisplayName("Description")]
        [StringLength(Models.ProjectDocument.FieldLengths.Description, ErrorMessage = "1000 character maximum.")]
        public string Description { get; set; }

        // can be the ID of a Project or a ProjectUpdateBatch depending on whether this ViewModel or its child type is invoked.
        public int? ParentID { get; set; }

        public EditProjectDocumentsViewModel()
        {
        }

        public EditProjectDocumentsViewModel(Models.ProjectDocument projectDocument)
        {
            ParentID = projectDocument.ProjectID;
            DisplayName = projectDocument.DisplayName;
            Description = projectDocument.Description;
        }

        public EditProjectDocumentsViewModel(Models.ProjectDocumentUpdate projectDocumentUpdate)
        {
            DisplayName = projectDocumentUpdate.DisplayName;
            Description = projectDocumentUpdate.Description;
        }

        public void UpdateModel(Models.ProjectDocument projectDocument)
        {
            projectDocument.DisplayName = DisplayName;
            projectDocument.Description = Description;
        }

        public void UpdateModel(Models.ProjectDocumentUpdate projectDocumentUpdate)
        {
            projectDocumentUpdate.DisplayName = DisplayName;
            projectDocumentUpdate.Description = Description;
        }

        public virtual IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var validationResults = new List<ValidationResult>();

            if (HttpRequestStorage.DatabaseEntities.ProjectDocuments.Where(x => x.ProjectID == ParentID)
                .Any(x => x.DisplayName.ToLower() == DisplayName.ToLower()))
            {
                validationResults.Add(new SitkaValidationResult<NewProjectDocumentViewModel, string>("The Display Name must be unique for each Document attached to a Project", m => m.DisplayName));
            }

            return validationResults;
        }
    }
}
