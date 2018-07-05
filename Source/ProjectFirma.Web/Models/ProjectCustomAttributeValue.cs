using LtInfo.Common.Models;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Models
{
    public partial class ProjectCustomAttributeValue : IAuditableEntity, IProjectCustomAttributeValue
    {
        public string AuditDescriptionString
        {
            get
            {
                var projectCustomAttribute = HttpRequestStorage.DatabaseEntities.ProjectCustomAttributes.GetProjectCustomAttribute(ProjectCustomAttributeID);
                var project = projectCustomAttribute?.Project ??
                              HttpRequestStorage.DatabaseEntities.Projects.GetProject(
                                  projectCustomAttribute?.ProjectID ?? ModelObjectHelpers.NotYetAssignedID);
                var projectCustomAttributeType = projectCustomAttribute?.ProjectCustomAttributeType ??
                                                 HttpRequestStorage.DatabaseEntities.ProjectCustomAttributeTypes
                                                     .GetProjectCustomAttributeType(
                                                         projectCustomAttribute?.ProjectCustomAttributeTypeID ??
                                                         ModelObjectHelpers.NotYetAssignedID);
                return
                    $"Custom Attribute Value (type: {projectCustomAttributeType?.ProjectCustomAttributeTypeName ?? "<Type Not Found>"}, " +
                    $"project: {project?.ProjectName ?? "<Project Not Found>"}, " +
                    $"value = \"{AttributeValue}\")";
            }
        }

        public int IProjectCustomAttributeValueID
        {
            get => ProjectCustomAttributeValueID;
            set => ProjectCustomAttributeValueID = value;
        }

        public int IProjectCustomAttributeID
        {
            get => ProjectCustomAttributeID;
            set => ProjectCustomAttributeID = value;
        }

        public IProjectCustomAttribute IProjectCustomAttribute
        {
            get => ProjectCustomAttribute;
            set => ProjectCustomAttribute = (ProjectCustomAttribute) value;
        }
    }
}
