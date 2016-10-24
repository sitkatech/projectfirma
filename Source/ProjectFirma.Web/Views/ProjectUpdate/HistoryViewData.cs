using ProjectFirma.Web.Models;

namespace ProjectFirma.Web.Views.ProjectUpdate
{
    public class HistoryViewData : ProjectUpdateViewData
    {
        public HistoryViewData(Person currentPerson, ProjectUpdateBatch projectUpdateBatch, UpdateStatus updateStatus) : base(currentPerson, projectUpdateBatch, ProjectUpdateSectionEnum.History, updateStatus)
        {
        }
    }
}