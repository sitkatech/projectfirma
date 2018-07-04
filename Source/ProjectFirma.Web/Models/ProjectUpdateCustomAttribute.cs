using System.Collections.Generic;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Models
{
    public partial class ProjectUpdateCustomAttribute : IAuditableEntity, IProjectCustomAttribute
    {
        public string AuditDescriptionString
        {
            get
            {
                var projectUpdate = ProjectUpdate ?? HttpRequestStorage.DatabaseEntities.ProjectUpdates.GetProjectUpdate(ProjectUpdateID);
                var projectCustomAttributeType = ProjectCustomAttributeType ??
                                                 HttpRequestStorage.DatabaseEntities.ProjectCustomAttributeTypes
                                                     .GetProjectCustomAttributeType(ProjectCustomAttributeTypeID);
                return
                    $"Custom Attribute (type: {projectCustomAttributeType?.ProjectCustomAttributeTypeName ?? "<Type Not Found>"}, " +
                    $"Project Update: {projectUpdate?.DisplayName ?? "<Projec Update Not Found>"})";
            }
        }

        public int IProjectID
        {
            get => ProjectUpdateID;
            set => ProjectUpdateID = value;
        }

        public int IProjectCustomAttributeID
        {
            get => ProjectUpdateCustomAttributeID;
            set => ProjectUpdateCustomAttributeID = value;
        }

        public IEnumerable<IProjectCustomAttributeValue> Values
        {
            get => ProjectUpdateCustomAttributeValues;
            set => ProjectUpdateCustomAttributeValues = (ICollection<ProjectUpdateCustomAttributeValue>) value;
        }
    }
}
