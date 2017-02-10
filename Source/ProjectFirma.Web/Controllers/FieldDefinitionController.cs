using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjectFirma.Web.Security;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Views.FieldDefinition;
using ProjectFirma.Web.Views.Shared;
using LtInfo.Common;
using LtInfo.Common.MvcResults;

namespace ProjectFirma.Web.Controllers
{
    public class FieldDefinitionController : FirmaBaseController
    {
        [FieldDefinitionViewListFeature]
        [CrossAreaRoute]
        public ViewResult Index()
        {
            var viewData = new IndexViewData(CurrentPerson);
            return RazorView<Index, IndexViewData>(viewData);
        }

        [FieldDefinitionViewListFeature]
        [CrossAreaRoute]
        public GridJsonNetJObjectResult<FieldDefinition> IndexGridJsonData()
        {
            FieldDefinitionGridSpec gridSpec;
            var actions = GetFieldDefinitionsAndGridSpec(out gridSpec, CurrentPerson);
            var gridJsonNetJObjectResult = new GridJsonNetJObjectResult<FieldDefinition>(actions, gridSpec);
            return gridJsonNetJObjectResult;
        }

        private static List<FieldDefinition> GetFieldDefinitionsAndGridSpec(out FieldDefinitionGridSpec gridSpec, Person currentPerson)
        {
            gridSpec = new FieldDefinitionGridSpec(new FieldDefinitionViewListFeature().HasPermissionByPerson(currentPerson));
            return FieldDefinition.All.Where(x => new FieldDefinitionManageFeature().HasPermission(currentPerson, x).HasPermission).OrderBy(x => x.FieldDefinitionDisplayName).ToList();
        }

        [HttpGet]
        [FieldDefinitionManageFeature]
        [CrossAreaRoute]
        public PartialViewResult Edit(FieldDefinitionPrimaryKey fieldDefinitionPrimaryKey)
        {
            var fieldDefinitionData = HttpRequestStorage.DatabaseEntities.FieldDefinitionDatas.GetFieldDefinitionDataByFieldDefinition(fieldDefinitionPrimaryKey);            
            var viewModel = new EditViewModel(fieldDefinitionData);
            return ViewEdit(fieldDefinitionPrimaryKey, viewModel);
        }

        [HttpPost]
        [FieldDefinitionManageFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        [CrossAreaRoute]
        public ActionResult Edit(FieldDefinitionPrimaryKey fieldDefinitionPrimaryKey, EditViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return ViewEdit(fieldDefinitionPrimaryKey, viewModel);
            }
            var fieldDefinitionData = HttpRequestStorage.DatabaseEntities.FieldDefinitionDatas.GetFieldDefinitionDataByFieldDefinition(fieldDefinitionPrimaryKey);
            if (fieldDefinitionData == null)
            {
                fieldDefinitionData = new FieldDefinitionData(fieldDefinitionPrimaryKey.EntityObject);
                HttpRequestStorage.DatabaseEntities.AllFieldDefinitionDatas.Add(fieldDefinitionData);
            }

            viewModel.UpdateModel(fieldDefinitionData);
            return new ModalDialogFormJsonResult();
        }

        private PartialViewResult ViewEdit(FieldDefinitionPrimaryKey fieldDefinitionPrimaryKey, EditViewModel viewModel)
        {
            var viewData = new EditViewData(fieldDefinitionPrimaryKey);
            return RazorPartialView<Edit, EditViewData, EditViewModel>(viewData, viewModel);
        }

        [HttpGet]
        [FieldDefinitionViewFeature]
        [CrossAreaRoute]
        public PartialViewResult FieldDefinitionDetails(int fieldDefinitionID)
        {
            var fieldDefinition = FieldDefinition.AllLookupDictionary[fieldDefinitionID];
            var fieldDefinitionData = HttpRequestStorage.DatabaseEntities.FieldDefinitionDatas.SingleOrDefault(x => x.FieldDefinitionID == fieldDefinitionID);
            var fieldDefinitionDataValue = new HtmlString(string.Format("{0} not yet defined.", fieldDefinition.FieldDefinitionDisplayName));
            if (fieldDefinitionData != null)
            {
                fieldDefinitionDataValue = fieldDefinitionData.FieldDefinitionDataValueHtmlString;
            }
            var viewData = new FieldDefinitionDetailsViewData(fieldDefinitionDataValue);
            return RazorPartialView<FieldDefinitionDetails, FieldDefinitionDetailsViewData>(viewData);
        }
    }
}