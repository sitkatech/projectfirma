using System.Collections.Generic;
using System.Linq;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Models
{
    public partial class ProjectCustomAttributeUpdate : IAuditableEntity, IProjectCustomAttribute
    {
        public string AuditDescriptionString
        {
            get
            {
                var projectUpdateBatch = ProjectUpdateBatch ??
                                         HttpRequestStorage.DatabaseEntities.ProjectUpdateBatches.GetProjectUpdateBatch(
                                             ProjectUpdateBatchID);
                var projectCustomAttributeType = ProjectCustomAttributeType ??
                                                 HttpRequestStorage.DatabaseEntities.ProjectCustomAttributeTypes
                                                     .GetProjectCustomAttributeType(ProjectCustomAttributeTypeID);
                return
                    $"Custom Attribute (type: {projectCustomAttributeType?.ProjectCustomAttributeTypeName ?? "<Type Not Found>"}, " +
                    $"Project Update: {projectUpdateBatch?.ProjectUpdate.DisplayName ?? "<Projec Update Not Found>"})";
            }
        }

        public int IProjectID
        {
            get => ProjectUpdateBatch.ProjectUpdate.ProjectUpdateID;
            set => ProjectUpdateBatch.ProjectUpdate.ProjectUpdateID = value;
        }

        public int IProjectCustomAttributeID
        {
            get => ProjectCustomAttributeUpdateID;
            set => ProjectCustomAttributeUpdateID = value;
        }

        public IEnumerable<IProjectCustomAttributeValue> Values
        {
            get => ProjectCustomAttributeUpdateValues;
            set => ProjectCustomAttributeUpdateValues = (ICollection<ProjectCustomAttributeUpdateValue>) value;
        }

        public static void CreateFromProject(ProjectUpdateBatch projectUpdateBatch)
        {
            var project = projectUpdateBatch.Project;
            projectUpdateBatch.ProjectCustomAttributeUpdates = project.ProjectCustomAttributes
                .Select(x =>
                {
                    var projectCustomAttributeUpdate = new ProjectCustomAttributeUpdate(projectUpdateBatch, x.ProjectCustomAttributeType);
                    projectCustomAttributeUpdate.ProjectCustomAttributeUpdateValues = x.ProjectCustomAttributeValues
                        .Select(y => new ProjectCustomAttributeUpdateValue(projectCustomAttributeUpdate, y.AttributeValue))
                        .ToList();
                    return projectCustomAttributeUpdate;
                })
                .ToList();
        }
    }
}
