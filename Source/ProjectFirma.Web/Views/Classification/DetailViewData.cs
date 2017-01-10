using LtInfo.Common;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Controllers;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Security;
using ProjectFirma.Web.Views.Project;

namespace ProjectFirma.Web.Views.Classification
{
    public class DetailViewData : FirmaViewData
    {
        public readonly Models.Classification Classification;
        public readonly string EditClassificationUrl;
        public readonly string IndexUrl;
        public readonly bool UserHasClassificationManagePermissions;

        public readonly BasicProjectInfoGridSpec BasicProjectInfoGridSpec;
        public readonly string BasicProjectInfoGridName;
        public readonly string BasicProjectInfoGridDataUrl;

        public DetailViewData(Person currentPerson, Models.Classification classification)
            : base(currentPerson)
        {
            Classification = classification;
            EditClassificationUrl = SitkaRoute<ClassificationController>.BuildUrlFromExpression(c => c.Edit(classification));
            IndexUrl = SitkaRoute<ClassificationController>.BuildUrlFromExpression(c => c.Index());

            UserHasClassificationManagePermissions = new PerformanceMeasureManageFeature().HasPermissionByPerson(currentPerson);

            BasicProjectInfoGridName = "watershedProjectListGrid";
            BasicProjectInfoGridSpec = new BasicProjectInfoGridSpec(CurrentPerson, false)
            {
                ObjectNameSingular = string.Format("Project associated with this {0}", MultiTenantHelpers.GetClassificationDisplayName()),
                ObjectNamePlural = string.Format("Projects associated with this {0}", MultiTenantHelpers.GetClassificationDisplayNamePluralized()),
                SaveFiltersInCookie = true
            };

            BasicProjectInfoGridDataUrl = SitkaRoute<ClassificationController>.BuildUrlFromExpression(tc => tc.ProjectsGridJsonData(classification));
        }
    }
}