using System.Collections.Generic;
using System.Linq;
using LtInfo.Common;
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

        public static void CommitChangesToProject(ProjectUpdateBatch projectUpdateBatch,
            IList<ProjectCustomAttribute> allProjectCustomAttributes,
            IList<ProjectCustomAttributeValue> allProjectCustomAttributeValues)
        {
            var project = projectUpdateBatch.Project;
            var projectCustomAttributesFromProjectUpdate = projectUpdateBatch.ProjectCustomAttributeUpdates
                .Select(x => new ProjectCustomAttribute(project.ProjectID, x.ProjectCustomAttributeType.ProjectCustomAttributeTypeID))
                .ToList();
            var projectCustomAttributeValuesFromProjectUpdate = projectUpdateBatch.ProjectCustomAttributeUpdates
                .SelectMany(x => x.ProjectCustomAttributeUpdateValues)
                .Select(x =>
                {
                    var projectCustomAttributeID =
                        project.ProjectCustomAttributes.SingleOrDefault(y =>
                                y.ProjectCustomAttributeTypeID ==
                                x.IProjectCustomAttribute?.ProjectCustomAttributeTypeID)
                            ?.ProjectCustomAttributeID ??
                        projectCustomAttributesFromProjectUpdate.Single().ProjectCustomAttributeID;
                    return new ProjectCustomAttributeValue(projectCustomAttributeID, x.AttributeValue);
                })
                .ToList();
            project.ProjectCustomAttributes.Merge(projectCustomAttributesFromProjectUpdate,
                allProjectCustomAttributes,
                (a, b) => a.ProjectCustomAttributeTypeID == b.ProjectCustomAttributeTypeID);
            project.ProjectCustomAttributes.SelectMany(x => x.ProjectCustomAttributeValues)
                .ToList()
                .Merge(projectCustomAttributeValuesFromProjectUpdate,
                    allProjectCustomAttributeValues,
                    (x, y) => x.ProjectCustomAttributeValueID == y.ProjectCustomAttributeValueID);
        }
    }
}
