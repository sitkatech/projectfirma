using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ProjectFirma.Web.Views.ProjectDocument
{
    public class EditViewModel
    {
        [Required]
        [DisplayName("Display Name")]
        [MaxLength(Models.ProjectDocument.FieldLengths.DisplayName)]
        public string DisplayName { get; set; }
        
        [DisplayName("Description")]
        [MaxLength(Models.ProjectDocument.FieldLengths.Description)]
        public string Description { get; set; }

        public EditViewModel()
        {
        }

        public EditViewModel(Models.ProjectDocument projectDocument)
        {
            DisplayName = projectDocument.DisplayName;
            Description = projectDocument.Description;
        }

        public void UpdateModel(Models.ProjectDocument projectDocument)
        {
            projectDocument.DisplayName = DisplayName;
            projectDocument.Description = Description;
        }
    }
}
