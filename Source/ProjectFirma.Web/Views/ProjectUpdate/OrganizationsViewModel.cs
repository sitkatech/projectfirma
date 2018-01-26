using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using LtInfo.Common.Models;
using ProjectFirma.Web.Models;

namespace ProjectFirma.Web.Views.ProjectUpdate
{
    public class OrganizationsViewModel : FormViewModel
    {
        [DisplayName("Comments")]
        [StringLength(ProjectUpdateBatch.FieldLengths.ExpendituresComment)]
        public string Comments { get; set; }

        public List<ProjectOrganizationSimple> ProjectOrganizationSimples { get; set; }

        /// <summary>
        /// Required by the ModelBinder
        /// </summary>
        protected OrganizationsViewModel()
        {
        }

        public OrganizationsViewModel(ProjectUpdateBatch projectUpdateBatch)
        {
            ProjectOrganizationSimples = projectUpdateBatch.ProjectOrganizationUpdates.Select(x=>new ProjectOrganizationSimple(x)).ToList();
            Comments = projectUpdateBatch.OrganizationsComment;
        }

        public void UpdateModel()
        {
            throw new System.NotImplementedException();
        }
    }
}