using ProjectFirma.Web.Common;
using ProjectFirma.Web.Controllers;
using ProjectFirmaModels.Models;
using ProjectFirma.Web.Security;
using ProjectFirma.Web.Models;

namespace ProjectFirma.Web.Views.ProjectCustomAttributeType
{
    public class DetailViewData : FirmaViewData
    {
        public ProjectFirmaModels.Models.ProjectCustomAttributeType ProjectCustomAttributeType { get; }
        public bool UserHasProjectCustomAttributeTypeManagePermissions { get; }
        public string ProjectTypeGridName { get; }
        public string ProjectTypeGridDataUrl { get; }
        public string ManageUrl { get; }

        public DetailViewData(FirmaSession currentFirmaSession,
            ProjectFirmaModels.Models.ProjectCustomAttributeType projectCustomAttributeType) : base(currentFirmaSession)
        {
            ProjectCustomAttributeType = projectCustomAttributeType;
            EntityName = FieldDefinitionEnum.ProjectCustomAttribute.ToType().GetFieldDefinitionLabelPluralized();
            PageTitle = projectCustomAttributeType.ProjectCustomAttributeTypeName;
            ManageUrl = SitkaRoute<ProjectCustomAttributeTypeController>.BuildUrlFromExpression(c => c.Manage());

            UserHasProjectCustomAttributeTypeManagePermissions = new FirmaAdminFeature().HasPermissionByFirmaSession(currentFirmaSession);

            ProjectTypeGridName = "projectTypeGridForAttribute";
            ProjectTypeGridDataUrl = "#";
        }
    }
}
