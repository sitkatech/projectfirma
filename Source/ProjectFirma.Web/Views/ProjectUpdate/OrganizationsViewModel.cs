using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using LtInfo.Common.Models;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Views.Shared.ProjectOrganization;

namespace ProjectFirma.Web.Views.ProjectUpdate
{
    public class OrganizationsViewModel : EditOrganizationsViewModel
    {
        [DisplayName("Comments")]
        [StringLength(ProjectUpdateBatch.FieldLengths.ExpendituresComment)]
        public string Comments { get; set; }

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