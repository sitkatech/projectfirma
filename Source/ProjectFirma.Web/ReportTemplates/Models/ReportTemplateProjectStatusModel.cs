using System;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.ReportTemplates.Models
{
    public class ReportTemplateProjectStatusModel : ReportTemplateBaseModel
    {

        private ProjectProjectStatus ProjectStatus { get; set; }

        public string UpdateDate { get; set; }
        public string CreatePersonName { get; set; }
        public string CreateDate { get; set; }
        public string LastEditedPersonName { get; set; }
        public string LastEditedDate { get; set; }
        public string ProjectStatusComment { get; set; }
        public string ProjectStatusDisplayName { get; set; }
        public string ProjectStatusColor { get; set; }
        public string ProjectStatusDescription { get; set; }


        public ReportTemplateProjectStatusModel(ProjectProjectStatus projectProjectStatus)
        {
            // Private properties
            ProjectStatus = projectProjectStatus;


            // Public properties
            UpdateDate = projectProjectStatus.ProjectProjectStatusUpdateDate.ToShortDateString();
            CreatePersonName = projectProjectStatus.ProjectProjectStatusCreatePerson.GetFullNameFirstLast();
            CreateDate = projectProjectStatus.ProjectProjectStatusCreateDate.ToShortDateString();
            LastEditedPersonName = projectProjectStatus.ProjectProjectStatusLastEditedPerson?.GetFullNameFirstLast() ?? projectProjectStatus.ProjectProjectStatusCreatePerson.GetFullNameFirstLast();
            LastEditedDate = projectProjectStatus.ProjectProjectStatusLastEditedDate.HasValue ? projectProjectStatus.ProjectProjectStatusLastEditedDate.Value.ToShortDateString() : String.Empty;
            ProjectStatusComment = projectProjectStatus.ProjectProjectStatusComment;

            ProjectStatusDisplayName = projectProjectStatus.ProjectStatus.ProjectStatusDisplayName;
            ProjectStatusColor = projectProjectStatus.ProjectStatus.ProjectStatusColor;
            ProjectStatusDescription = projectProjectStatus.ProjectStatus.ProjectStatusDescription;

        }



    }
}