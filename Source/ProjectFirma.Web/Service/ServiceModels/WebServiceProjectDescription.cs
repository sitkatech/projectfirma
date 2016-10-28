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
            ProjectNumber = project.ProjectNumberString;
            ProjectName = project.ProjectName;            
            ProjectDescription = project.ProjectDescription;            
        }

        [DataMember] public string ProjectNumber { get; set; }
        [DataMember] public string ProjectName { get; set; }
        [DataMember] public string ProjectDescription { get; set; }

        public static List<WebServiceProjectDescription> GetProjectDescription(string projectNumber)
        {
            var project = HttpRequestStorage.DatabaseEntities.Projects.GetProjectByProjectNumber(projectNumber);
            var projectDescription = new WebServiceProjectDescription(project);
            return new List<WebServiceProjectDescription> { projectDescription };
        }
    }

    public class WebServiceProjectDescriptionGridSpec : GridSpec<WebServiceProjectDescription>
    {
        public WebServiceProjectDescriptionGridSpec()
        {
            Add("ProjectNumber", x => x.ProjectNumber, 0);
            Add("ProjectName", x => x.ProjectName, 0);
            Add("ProjectDescription", x => x.ProjectDescription, 0);           
        }
    }
}
