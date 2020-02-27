using System.Collections.Generic;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Controllers;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Views.ProjectCustomGrid;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Views.Reports
{
    public class ProjectsViewData : FirmaViewData
    {
        public ProjectCustomGridSpec ProjectCustomFullGridSpec { get; }
        public string GridName { get; }
        public string GridDataUrl { get; }

        public ProjectsViewData(FirmaSession currentFirmaSession, ProjectFirmaModels.Models.FirmaPage firmaPage, List<ProjectCustomGridConfiguration> projectCustomFullGridConfigurations) : base(currentFirmaSession, firmaPage)
        {
            ProjectCustomFullGridSpec = new ProjectCustomGridSpec(currentFirmaSession, projectCustomFullGridConfigurations, ProjectCustomGridType.Reports.ToEnum);
            GridName = "ReportProjects";
            PageTitle = $"{FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabelPluralized()}";
            GridDataUrl = SitkaRoute<ProjectCustomGridController>.BuildUrlFromExpression(tc => tc.AllActiveProjectsAndProposalsCustomGridReportsJsonData());
        }
    }
}