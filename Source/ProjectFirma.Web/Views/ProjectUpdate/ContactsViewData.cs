using ProjectFirma.Web.Common;
using ProjectFirma.Web.Controllers;
using ProjectFirmaModels.Models;
using ProjectFirma.Web.Views.Shared.ProjectContact;

namespace ProjectFirma.Web.Views.ProjectUpdate
{
    public class ContactsViewData : ProjectUpdateViewData
    {
        public readonly string RefreshUrl;
        public readonly string DiffUrl;

        public ContactsViewData(FirmaSession currentFirmaSession, ProjectUpdateBatch projectUpdateBatch, ProjectUpdateStatus projectUpdateStatus, EditContactsViewData editContactsViewData, ContactsValidationResult contactsValidationResult, ProjectContactsDetailViewData projectContactsDetailViewData) : base(
            currentFirmaSession, projectUpdateBatch, projectUpdateStatus, contactsValidationResult.GetWarningMessages(), ProjectUpdateSection.Contacts.ProjectUpdateSectionDisplayName)
        {
            EditContactsViewData = editContactsViewData;
            ProjectContactsDetailViewData = projectContactsDetailViewData;
            SectionCommentsViewData =
                new SectionCommentsViewData(projectUpdateBatch.ContactsComment, projectUpdateBatch.IsReturned());
            RefreshUrl = SitkaRoute<ProjectUpdateController>.BuildUrlFromExpression(x => x.RefreshContacts(projectUpdateBatch.Project));
            DiffUrl = SitkaRoute<ProjectUpdateController>.BuildUrlFromExpression(x => x.DiffContacts(projectUpdateBatch.Project));
        }

        public readonly SectionCommentsViewData SectionCommentsViewData;
        public readonly EditContactsViewData EditContactsViewData;
        public readonly ProjectContactsDetailViewData ProjectContactsDetailViewData;
    }
}