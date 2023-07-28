using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using ProjectFirma.Web.Views.ProjectExternalLink;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Views.ProjectUpdate
{
    public class ExternalLinksViewModel : EditProjectExternalLinksViewModel
    {
        [DisplayName("Reviewer Comments")]
        [StringLength(ProjectUpdateBatch.FieldLengths.ExternalLinksComment)]
        public string Comments { get; set; }

        /// <summary>
        /// Required by the ModelBinder
        /// </summary>
        public ExternalLinksViewModel()
        {
        }

        public ExternalLinksViewModel(ProjectUpdateBatch projectUpdateBatch, List<ProjectExternalLinkSimple> projectExternalLinks) : base(projectExternalLinks)
        {
            Comments = projectUpdateBatch.ExternalLinksComment;
        }

    }
}