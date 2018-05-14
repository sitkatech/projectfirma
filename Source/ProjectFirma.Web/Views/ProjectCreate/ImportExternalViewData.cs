using ProjectFirma.Web.Common;
using ProjectFirma.Web.Controllers;
using ProjectFirma.Web.Models;

namespace ProjectFirma.Web.Views.ProjectCreate
{
    public class ImportExternalViewData : FirmaViewData
    {
        public string ValidateImportExternalProjectDataUrl { get; set; }

        public ImportExternalViewData(Person currentPerson, Models.FirmaPage firmaPage) : base(currentPerson, firmaPage)
        {
            PageTitle = "Import Project";
            ValidateImportExternalProjectDataUrl =
                SitkaRoute<ProjectCreateController>.BuildUrlFromExpression(c => c.ValidateImportExternalProjectData());
        }
    }
}
