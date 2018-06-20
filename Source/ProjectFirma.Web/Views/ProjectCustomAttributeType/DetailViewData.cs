using ProjectFirma.Web.Common;
using ProjectFirma.Web.Controllers;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Security;

namespace ProjectFirma.Web.Views.ProjectCustomAttributeType
{
    public class DetailViewData : FirmaViewData
    {
        public Models.ProjectCustomAttributeType ProjectCustomAttributeType { get; }
        public bool UserHasProjectCustomAttributeTypeManagePermissions { get; }
        //public ProjectTypeGridSpec ProjectTypeGridSpec { get; }
        public string ProjectTypeGridName { get; }
        public string ProjectTypeGridDataUrl { get; }
        public string ManageUrl { get; }

        public DetailViewData(Person currentPerson,
            Models.ProjectCustomAttributeType projectCustomAttributeType) : base(currentPerson)
        {
            ProjectCustomAttributeType = projectCustomAttributeType;
            EntityName = Models.FieldDefinition.ProjectCustomAttributeType.GetFieldDefinitionLabelPluralized();
            PageTitle = projectCustomAttributeType.ProjectCustomAttributeTypeName;
            ManageUrl = SitkaRoute<ProjectCustomAttributeTypeController>.BuildUrlFromExpression(c => c.Manage());

            UserHasProjectCustomAttributeTypeManagePermissions = new FirmaAdminFeature().HasPermissionByPerson(currentPerson);

            //if (UserHasProjectCustomAttributeTypeManagePermissions)
            //{
            //    EntityUrl = SitkaRoute<ProjectCustomAttributeTypeController>.BuildUrlFromExpression(c => c.Manage());
            //}

            //ProjectTypeGridSpec = new ProjectTypeGridSpec(currentPerson)
            //{
            //    ObjectNameSingular = $"{Models.FieldDefinition.ProjectType.GetFieldDefinitionLabel()}",
            //    ObjectNamePlural = $"{Models.FieldDefinition.ProjectType.GetFieldDefinitionLabelPluralized()}",
            //    SaveFiltersInCookie = true
            //};

            ProjectTypeGridName = "projectTypeGridForAttribute";
            //ProjectTypeGridDataUrl = SitkaRoute<ProjectCustomAttributeTypeController>.BuildUrlFromExpression(tc => tc.ProjectTypeGridJsonData(projectCustomAttributeType));
            ProjectTypeGridDataUrl = "#";
        }
    }
}
