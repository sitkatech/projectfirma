using LtInfo.Common.Models;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Models
{
    public partial class ProjectCustomAttributeUpdateValue : IAuditableEntity, IProjectCustomAttributeValue
    {
        public string AuditDescriptionString
        {
            get
            {
                var projectCustomAttribute = HttpRequestStorage.DatabaseEntities.ProjectCustomAttributeUpdates.GetProjectCustomAttributeUpdate(ProjectCustomAttributeUpdateID);
                var projectUpdateBatch = projectCustomAttribute?.ProjectUpdateBatch ??
                              HttpRequestStorage.DatabaseEntities.ProjectUpdateBatches.GetProjectUpdateBatch(
                                  projectCustomAttribute?.ProjectUpdateBatchID ?? ModelObjectHelpers.NotYetAssignedID);
                var projectCustomAttributeType = projectCustomAttribute?.ProjectCustomAttributeType ??
                                                 HttpRequestStorage.DatabaseEntities.ProjectCustomAttributeTypes
                                                     .GetProjectCustomAttributeType(
                                                         projectCustomAttribute?.ProjectCustomAttributeTypeID ??
                                                         ModelObjectHelpers.NotYetAssignedID);
                return
                    $"Custom Attribute Value (type: {projectCustomAttributeType?.ProjectCustomAttributeTypeName ?? "<Type Not Found>"}, " +
                    $"project update: {projectUpdateBatch?.ProjectUpdate.DisplayName ?? "<Project Update Not Found>"}, " +
                    $"value = \"{AttributeValue}\")";
            }
        }

        public int IProjectCustomAttributeValueID
        {
            get => ProjectCustomAttributeUpdateValueID;
            set => ProjectCustomAttributeUpdateValueID = value;
        }

        public int IProjectCustomAttributeID
        {
            get => ProjectCustomAttributeUpdateID;
            set => ProjectCustomAttributeUpdateID = value;
        }

        public IProjectCustomAttribute IProjectCustomAttribute
        {
            get => ProjectCustomAttributeUpdate;
            set => ProjectCustomAttributeUpdate = (ProjectCustomAttributeUpdate) value;
        }
    }
}
