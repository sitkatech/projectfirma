using System.Collections.Generic;
using LtInfo.Common.Models;

namespace ProjectFirma.Web.Areas.EIP.Views.Project
{
    public class EditFeaturedProjectsViewModel : FormViewModel
    {
        public List<int> ProjectIDList { get; set; }

        /// <summary>
        /// Needed by the ModelBinder
        /// </summary>
        public EditFeaturedProjectsViewModel()
        {
        }

        public EditFeaturedProjectsViewModel(List<int> projectIDs)
        {
            ProjectIDList = projectIDs;
        }
    }
}