using ProjectFirma.Web.Controllers;
using ProjectFirma.Web.Views.ProposedProject;
using ProjectFirma.Web.Models;
using LtInfo.Common;

namespace ProjectFirma.Web.Views.Project
{
    public class MyOrganizationsProjectsViewData : FirmaViewData
    {
        public readonly BasicProjectInfoGridSpec ProjectsGridSpec;
        public readonly string ProjectsGridName;
        public readonly string ProjectsGridDataUrl;

        public readonly ProposedProjectGridSpec ProposedProjectsGridSpec;
        public readonly string ProposedProjectsGridName;
        public readonly string ProposedProjectsGridDataUrl;
        public readonly string ProposeNewProjectUrl;


        public MyOrganizationsProjectsViewData(Person currentPerson, Models.FirmaPage firmaPage) : base(currentPerson, firmaPage, false)
        {
            //TODO: It shouldn't be possible to reach this if Person.Organization is null...
            string organizationNamePossessive = currentPerson.Organization.OrganizationNamePossessive;
            PageTitle = string.Format("{0} Projects", organizationNamePossessive);

            ProjectsGridName = "myOrganizationsProjectListGrid";
            ProjectsGridSpec = new BasicProjectInfoGridSpec(CurrentPerson, true)
            {
                
                ObjectNameSingular = string.Format("{0} Project", organizationNamePossessive),
                ObjectNamePlural = string.Format("{0} Projects", organizationNamePossessive),
                SaveFiltersInCookie = true
            };
            ProjectsGridDataUrl = SitkaRoute<ProjectController>.BuildUrlFromExpression(tc => tc.MyOrganizationsProjectsGridJsonData());

            ProposedProjectsGridName = "myOrganizationsProposedProjectsGrid";
            ProposedProjectsGridSpec = new ProposedProjectGridSpec(currentPerson)
            {
                ObjectNameSingular = string.Format("{0} Proposed Project", organizationNamePossessive),
                ObjectNamePlural = string.Format("{0} Proposed Projects", organizationNamePossessive),
                SaveFiltersInCookie = true 
            
            };
            ProposedProjectsGridDataUrl = SitkaRoute<ProjectController>.BuildUrlFromExpression(tc => tc.MyOrganizationsProposedProjectsGridJsonData());

            ProposeNewProjectUrl = SitkaRoute<ProposedProjectController>.BuildUrlFromExpression(tc => tc.Instructions(null));
        }
    }
}