using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using LtInfo.Common.DhtmlWrappers;
using LtInfo.Common.GeoJson;
using LtInfo.Common.Models;
using MoreLinq;
using Newtonsoft.Json;
using ProjectFirma.Web.Common;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Service.ServiceModels
{
    [DataContract]
    public class WebServiceProjectGeometry : SimpleModelObject
    {
        
        [DataMember] public string ProjectLocationGeometry { get; set; }

        public WebServiceProjectGeometry(ProjectLocation projectLocation)
        {
            ProjectLocationGeometry =
                DbGeometryToGeoJsonHelper.MakeDbGeometryIntoGeoJsonString(projectLocation.ProjectLocationGeometry, Formatting.None);
        }

        public static List<WebServiceProjectGeometry> GetProjectGeometries(int projectID)
        {
            var project = HttpRequestStorage.DatabaseEntities.Projects.GetProject(projectID);
            return project.ProjectLocations.Select(x => new WebServiceProjectGeometry(x)).ToList();
        }
    }

    public class WebServiceProjectGeometryGridSpec : GridSpec<WebServiceProjectGeometry>
    {
        public WebServiceProjectGeometryGridSpec()
        {
            Add("ProjectLocationGeometryGeoJson", x => x.ProjectLocationGeometry, 0);
        }
    }

}