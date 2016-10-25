using ProjectFirma.Web.Controllers;
using ProjectFirma.Web.Security;
using ProjectFirma.Web.Models;
using LtInfo.Common;
using LtInfo.Common.ModalDialog;

namespace ProjectFirma.Web.Views.Program
{
    public class IndexViewData : FirmaViewData
    {
        public readonly IndexGridSpec GridSpec;
        public readonly string GridName;
        public readonly string GridDataUrl;

        public IndexViewData(Person currentPerson, Models.ProjectFirmaPage projectFirmaPage) : base(currentPerson, projectFirmaPage)
        {
            PageTitle = "Programs";

            var hasProgramManagePermissions = new ProgramManageFeature().HasPermissionByPerson(currentPerson);
            GridSpec = new IndexGridSpec(hasProgramManagePermissions) {ObjectNameSingular = "Program", ObjectNamePlural = "Programs", SaveFiltersInCookie = true};

            if (hasProgramManagePermissions)
            {
                GridSpec.CreateEntityModalDialogForm = new ModalDialogForm(SitkaRoute<ProgramController>.BuildUrlFromExpression(t => t.New()), "Create a new Program");
            }

            GridName = "programsGrid";
            GridDataUrl = SitkaRoute<ProgramController>.BuildUrlFromExpression(tc => tc.IndexGridJsonData());
        }
    }
}