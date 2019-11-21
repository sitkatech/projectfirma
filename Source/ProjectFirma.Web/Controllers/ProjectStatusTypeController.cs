using System.Linq;
using System.Web.Mvc;
using LtInfo.Common.MvcResults;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Security;
using ProjectFirma.Web.Security.Shared;
using ProjectFirma.Web.Views.ProjectStatus;
using ProjectFirmaModels.Models;
using Manage = ProjectFirma.Web.Views.ProjectStatus.Manage;
using ManageViewData = ProjectFirma.Web.Views.ProjectStatus.ManageViewData;

namespace ProjectFirma.Web.Controllers
{
    public class ProjectStatusController : FirmaBaseController
    {
        [FirmaAdminFeature]
        public ViewResult Manage()
        {
            var firmaPage = FirmaPageTypeEnum.ProjectStatusListEditor.GetFirmaPage();
            var viewData = new ManageViewData(CurrentFirmaSession, firmaPage);
            return RazorView<Manage, ManageViewData>(viewData);
        }

        [FirmaAdminFeature]
        public GridJsonNetJObjectResult<ProjectCustomAttributeType> ProjectCustomAttributeTypeGridJsonData()
        {
            var projectCustomAttributeTypes = HttpRequestStorage.DatabaseEntities.ProjectCustomAttributeTypes.ToList().OrderBy(x => x.ProjectCustomAttributeTypeName).ToList();
            var gridSpec = new ProjectStatusGridSpec();
            var gridJsonNetJObjectResult = new GridJsonNetJObjectResult<ProjectCustomAttributeType>(projectCustomAttributeTypes, gridSpec);
            return gridJsonNetJObjectResult;
        }

        [HttpGet]
        [AnonymousUnclassifiedFeature]
        public ContentResult Description(ProjectCustomAttributeTypePrimaryKey projectCustomAttributeTypePrimaryKey)
        {
            return Content(projectCustomAttributeTypePrimaryKey.EntityObject.ProjectCustomAttributeTypeDescription);
        }
    }
}