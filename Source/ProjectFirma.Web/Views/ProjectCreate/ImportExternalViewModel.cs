using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using LtInfo.Common.Models;

namespace ProjectFirma.Web.Views.ProjectCreate
{
    public class ImportExternalViewModel : FormViewModel
    {
        [Required]
        [DisplayName("Import Data URI")]
        public string ProjectExternalImportDataUri { get; set; }
    }
}
