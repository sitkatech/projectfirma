using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using LtInfo.Common.MvcResults;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Security;
using ProjectFirma.Web.Views.Shared.ProjectContact;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Controllers
{
    public class ProjectContactController : FirmaBaseController
    {
        [HttpGet]
        [ProjectEditAsAdminFeature]
        public PartialViewResult EditContacts(ProjectPrimaryKey projectPrimaryKey)
        {
            var project = projectPrimaryKey.EntityObject;
            var viewModel = new EditContactsViewModel(project, project.ProjectContacts.OrderBy(x => x.Contact.GetFullNameLastFirst()).ToList(), CurrentFirmaSession);
            return ViewEditContacts(viewModel, project);
        }

        [HttpPost]
        [ProjectEditAsAdminFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult EditContacts(ProjectPrimaryKey projectPrimaryKey, EditContactsViewModel viewModel)
        {
            var project = projectPrimaryKey.EntityObject;
            if (!ModelState.IsValid)
            {
                return ViewEditContacts(viewModel, project);
            }

            HttpRequestStorage.DatabaseEntities.ProjectContacts.Load();
            var projectContacts = HttpRequestStorage.DatabaseEntities.AllProjectContacts.Local;

            viewModel.UpdateModel(project, projectContacts);
            HttpRequestStorage.DatabaseEntities.SaveChanges();

            return new ModalDialogFormJsonResult();
        }

        private PartialViewResult ViewEditContacts(EditContactsViewModel viewModel, Project project)
        {
            var allPeople = HttpRequestStorage.DatabaseEntities.People.ToList().OrderBy(p => p.GetFullNameFirstLastAndOrg()).ToList();
            if (!allPeople.Contains(CurrentPerson))
            {
                allPeople.Add(CurrentPerson);
            }
            var allContactRelationshipTypes = HttpRequestStorage.DatabaseEntities.ContactRelationshipTypes.ToList();

            var viewData = new EditContactsViewData(allPeople, allContactRelationshipTypes);
            return RazorPartialView<EditContacts, EditContactsViewData, EditContactsViewModel>(viewData, viewModel);
        }
    }
}