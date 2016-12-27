using System.Collections.Generic;
using System.Runtime.Serialization;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;
using LtInfo.Common.DhtmlWrappers;
using LtInfo.Common.Models;

namespace ProjectFirma.Web.Service.ServiceModels
{
    [DataContract]
    public class WebServiceProjectDescription : SimpleModelObject
    {
        public WebServiceProjectDescription(Project project)
        {
            ProjectID = project.ProjectID;
            ProjectName = project.ProjectName;            
            ProjectDescription = project.ProjectDescription;            
        }

        [DataMember] public int ProjectID { get; set; }
        [DataMember] public string ProjectName { get; set; }
        [DataMember] public string ProjectDescription { get; set; }

        public static List<WebServiceProjectDescription> GetProjectDescription(int projectID)
        {
            var project = HttpRequestStorage.DatabaseEntities.Projects.GetProject(projectID);
            var projectDescription = new WebServiceProjectDescription(project);
            return new List<WebServiceProjectDescription> { projectDescription };
        }
    }

    public class WebServiceProjectDescriptionGridSpec : GridSpec<WebServiceProjectDescription>
    {
        public WebServiceProjectDescriptionGridSpec()
        {
            Add("ProjectID", x => x.ProjectID, 0);
            Add("ProjectName", x => x.ProjectName, 0);
            Add("ProjectDescription", x => x.ProjectDescription, 0);           
        }
    }
}
