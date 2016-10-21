using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.DhtmlWrappers;
using LtInfo.Common.Models;

namespace ProjectFirma.Web.Service.ServiceModels
{
    [DataContract]
    public class WebServiceProjectDescription : SimpleModelObject
    {
        public WebServiceProjectDescription(Project project)
        {
            EIPProjectNumber = project.ProjectNumberString;
            ProjectName = project.ProjectName;            
            ProjectDescription = project.ProjectDescription;            
        }

        [DataMember] public string EIPProjectNumber { get; set; }
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
            Add("EIPProjectNumber", x => x.EIPProjectNumber, 0);
            Add("ProjectName", x => x.ProjectName, 0);
            Add("ProjectDescription", x => x.ProjectDescription, 0);           
        }
    }
}
