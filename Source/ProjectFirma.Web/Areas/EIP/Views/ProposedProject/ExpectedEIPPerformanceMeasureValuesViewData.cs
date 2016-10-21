using ProjectFirma.Web.Areas.EIP.Views.Shared.EIPPerformanceMeasureControls;
using ProjectFirma.Web.Models;

namespace ProjectFirma.Web.Areas.EIP.Views.ProposedProject
{
    public class ExpectedEIPPerformanceMeasureValuesViewData : ProposedProjectViewData
    {
        public readonly EditEIPPerformanceMeasureExpectedViewData EditEipPerformanceMeasureExpectedViewData;

        public ExpectedEIPPerformanceMeasureValuesViewData(Person currentPerson,
            Models.ProposedProject proposedProject,
            ProposalSectionsStatus proposalSectionsStatus,
            EditEIPPerformanceMeasureExpectedViewData editEipPerformanceMeasureExpectedViewData)
            : base(currentPerson, proposedProject, ProposedProjectSectionEnum.EIPPerformanceMeasures, proposalSectionsStatus)
        {
            EditEipPerformanceMeasureExpectedViewData = editEipPerformanceMeasureExpectedViewData;            
        }
    }
}