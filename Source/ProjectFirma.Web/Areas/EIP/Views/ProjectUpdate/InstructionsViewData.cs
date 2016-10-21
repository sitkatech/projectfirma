using ProjectFirma.Web.Models;

namespace ProjectFirma.Web.Areas.EIP.Views.ProjectUpdate
{
    public class InstructionsViewData : ProjectUpdateViewData
    {
        public InstructionsViewData(Person currentPerson, ProjectUpdateBatch projectUpdateBatch, UpdateStatus updateStatus) : base(currentPerson, projectUpdateBatch, ProjectUpdateSectionEnum.Instructions, updateStatus)
        {
        }
    }
}