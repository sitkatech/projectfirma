using System.Collections.Generic;
using ProjectFirma.Web.Areas.EIP.Controllers;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Views.Shared.TextControls;
using LtInfo.Common;

namespace ProjectFirma.Web.Areas.EIP.Views.ProjectUpdate
{
    public class NotesViewData : ProjectUpdateViewData
    {
        public readonly EntityNotesViewData EntityNotesViewData;
        public readonly string RefreshUrl;
        public readonly string DiffUrl;

        public NotesViewData(Person currentPerson, ProjectUpdateBatch projectUpdateBatch, UpdateStatus updateStatus, string diffUrl) : base(currentPerson, projectUpdateBatch, ProjectUpdateSectionEnum.Notes, updateStatus)
        {
            EntityNotesViewData = new EntityNotesViewData(EntityNote.CreateFromEntityNote(new List<IEntityNote>(projectUpdateBatch.ProjectNoteUpdates)),
                SitkaRoute<ProjectNoteUpdateController>.BuildUrlFromExpression(x => x.New(projectUpdateBatch)),
                projectUpdateBatch.Project.DisplayName,
                IsEditable);
            RefreshUrl = SitkaRoute<ProjectUpdateController>.BuildUrlFromExpression(x => x.RefreshNotes(projectUpdateBatch.Project));
            DiffUrl = diffUrl;
        }
    }
}