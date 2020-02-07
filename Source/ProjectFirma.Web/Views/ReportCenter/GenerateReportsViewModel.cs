using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using LtInfo.Common.Models;

namespace ProjectFirma.Web.Views.ReportCenter
{
    public class GenerateReportsViewModel : FormViewModel
    {
        [Required]
        public List<int> ProjectIDList { get; set; }

        [Required]
        [DisplayName("Report Template")]
        public int ReportTemplateID { get; set; }

        public GenerateReportsViewModel()
        {
            ProjectIDList = new List<int>();
        }
    }
}