using LtInfo.Common.Models;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Models
{
    public partial class ProjectUpdateCustomAttributeValue : IAuditableEntity, IProjectCustomAttributeValue
    {
        public string AuditDescriptionString
        {
            get
            {
                var projectCustomAttribute = HttpRequestStorage.DatabaseEntities.ProjectUpdateCustomAttributes.GetProjectUpdateCustomAttribute(ProjectUpdateCustomAttributeID);
                var projectUpdate = projectCustomAttribute?.ProjectUpdate ??
                              HttpRequestStorage.DatabaseEntities.ProjectUpdates.GetProjectUpdate(
                                  projectCustomAttribute?.ProjectUpdateID ?? ModelObjectHelpers.NotYetAssignedID);
                var projectCustomAttributeType = projectCustomAttribute?.ProjectCustomAttributeType ??
                                                 HttpRequestStorage.DatabaseEntities.ProjectCustomAttributeTypes
                                                     .GetProjectCustomAttributeType(
                                                         projectCustomAttribute?.ProjectCustomAttributeTypeID ??
                                                         ModelObjectHelpers.NotYetAssignedID);
                return
                    $"Custom Attribute Value (type: {projectCustomAttributeType?.ProjectCustomAttributeTypeName ?? "<Type Not Found>"}, " +
                    $"project update: {projectUpdate?.DisplayName ?? "<Project Update Not Found>"}, " +
                    $"value = \"{AttributeValue}\")";
            }
        }

        public int IProjectCustomAttributeValueID
        {
            get => ProjectUpdateCustomAttributeValueID;
            set => ProjectUpdateCustomAttributeValueID = value;
        }

        public int IProjectCustomAttributeID
        {
            get => ProjectUpdateCustomAttributeID;
            set => ProjectUpdateCustomAttributeID = value;
        }

        public IProjectCustomAttribute IProjectCustomAttribute
        {
            get => ProjectUpdateCustomAttribute;
            set => ProjectUpdateCustomAttribute = (ProjectUpdateCustomAttribute) value;
        }
    }
}