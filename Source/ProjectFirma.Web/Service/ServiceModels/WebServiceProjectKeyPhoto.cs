using System.Collections.Generic;
using System.Runtime.Serialization;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Controllers;
using ProjectFirma.Web.Models;
using LtInfo.Common;
using LtInfo.Common.DhtmlWrappers;
using LtInfo.Common.Models;
using LtInfo.Common.Views;

namespace ProjectFirma.Web.Service.ServiceModels
{
    [DataContract]
    public class WebServiceProjectKeyPhoto : SimpleModelObject
    {
        public WebServiceProjectKeyPhoto(Project project)
        {
            ProjectNumber = project.ProjectNumberString;
            ProjectName = project.ProjectName;
            KeyPhotoUrl = project.KeyPhoto != null
                ? SitkaRoute<FileResourceController>.BuildAbsoluteUrlHttpsFromExpression(x => x.DisplayResource(project.KeyPhoto.FileResource.FileResourceGUIDAsString), SitkaWebConfiguration.CanonicalHostName)
                : ViewUtilities.NoneString;
        }

        [DataMember] public string ProjectNumber { get; set; }
        [DataMember] public string ProjectName { get; set; }
        [DataMember] public string KeyPhotoUrl { get; set; }

        public static List<WebServiceProjectKeyPhoto> GetProjectKeyPhoto(string projectNumber)
        {
            var project = HttpRequestStorage.DatabaseEntities.Projects.GetProjectByProjectNumber(projectNumber);
            var projectKeyPhoto = new WebServiceProjectKeyPhoto(project);
            return new List<WebServiceProjectKeyPhoto> { projectKeyPhoto };
        }
    }

    public class WebServiceProjectKeyPhotoGridSpec : GridSpec<WebServiceProjectKeyPhoto>
    {
        public WebServiceProjectKeyPhotoGridSpec()
        {
            Add("ProjectNumber", x => x.ProjectNumber, 0);
            Add("ProjectName", x => x.ProjectName, 0);
            Add("KeyPhotoUrl", x => x.KeyPhotoUrl, 0);            
        }
    }
}
