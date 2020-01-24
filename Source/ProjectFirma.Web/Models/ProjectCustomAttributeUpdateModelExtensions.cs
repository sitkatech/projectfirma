using System.Linq;
using ProjectFirmaModels;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Models
{
    public static class ProjectCustomAttributeUpdateModelExtensions
    {
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

        public static void CommitChangesToProject(ProjectUpdateBatch projectUpdateBatch, DatabaseEntities databaseEntities)
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
                                x.GetIProjectCustomAttribute()?.ProjectCustomAttributeTypeID)
                            ?.ProjectCustomAttributeID ??
                        projectCustomAttributesFromProjectUpdate.Single(y =>
                            y.ProjectCustomAttributeTypeID ==
                            x.GetIProjectCustomAttribute()?.ProjectCustomAttributeTypeID).ProjectCustomAttributeID;
                    return new ProjectCustomAttributeValue(projectCustomAttributeID, x.AttributeValue);
                })
                .ToList();
            var existingProjectCustomAttributes = project.ProjectCustomAttributes.ToList();
            existingProjectCustomAttributes.Merge(projectCustomAttributesFromProjectUpdate,
                (a, b) => a.ProjectID == b.ProjectID && a.ProjectCustomAttributeTypeID == b.ProjectCustomAttributeTypeID, databaseEntities);
            existingProjectCustomAttributes.SelectMany(x => x.ProjectCustomAttributeValues)
                .ToList()
                .Merge(projectCustomAttributeValuesFromProjectUpdate,
                    (x, y) => x.ProjectCustomAttributeValueID == y.ProjectCustomAttributeValueID, databaseEntities);
        }
    }
}