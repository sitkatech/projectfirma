using ProjectFirma.Web.Common;
using ProjectFirma.Web.Controllers;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Views.ProjectCreate
{
    public class ImportExternalViewData : FirmaViewData
    {
        public string ValidateImportExternalProjectDataUrl { get; set; }

        public ImportExternalViewData(Person currentPerson, ProjectFirmaModels.Models.FirmaPage firmaPage) : base(currentPerson, firmaPage)
        {
            PageTitle = "Import Project";
            ValidateImportExternalProjectDataUrl =
                SitkaRoute<ProjectCreateController>.BuildUrlFromExpression(c => c.ValidateImportExternalProjectData());
        }
    }
}
