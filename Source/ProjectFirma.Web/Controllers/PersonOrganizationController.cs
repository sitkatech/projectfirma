using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Security;
using ProjectFirma.Web.Views.PersonOrganization;
using LtInfo.Common;
using LtInfo.Common.MvcResults;

namespace ProjectFirma.Web.Controllers
{
    public class PersonOrganizationController : LakeTahoeInfoBaseController
    {
        [HttpGet]
        [UserEditFeature]
        public PartialViewResult EditPersonOrganizationPrimaryContacts(PersonPrimaryKey personPrimaryKey)
        {
            var person = personPrimaryKey.EntityObject;
            var organizationIDs = person.OrganizationsWhereYouAreThePrimaryContactPerson.Select(org => org.OrganizationID).ToList();
            var viewModel = new EditPersonOrganizationsViewModel(organizationIDs);
            return ViewEditPersonOrganizations(viewModel);
        }

        [HttpPost]
        [UserEditFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult EditPersonOrganizationPrimaryContacts(PersonPrimaryKey personPrimaryKey, EditPersonOrganizationsViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return ViewEditPersonOrganizations(viewModel);
            }
            var person = personPrimaryKey.EntityObject;
            viewModel.UpdateModel(person, HttpRequestStorage.DatabaseEntities.Organizations.ToList());
            return new ModalDialogFormJsonResult();
        }

        private PartialViewResult ViewEditPersonOrganizations(EditPersonOrganizationsViewModel viewModel)
        {
            var allOrganizations = HttpRequestStorage.DatabaseEntities.Organizations.GetActiveOrganizations().Select(x => new OrganizationSimple(x)).ToList();
            var viewData = new EditPersonOrganizationsViewData(allOrganizations);
            return RazorPartialView<EditPersonOrganizations, EditPersonOrganizationsViewData, EditPersonOrganizationsViewModel>(viewData, viewModel);
        }
    }
}