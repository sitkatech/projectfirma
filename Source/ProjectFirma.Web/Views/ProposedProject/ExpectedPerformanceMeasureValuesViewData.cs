using ProjectFirma.Web.Models;
using ProjectFirma.Web.Views.Shared.PerformanceMeasureControls;

namespace ProjectFirma.Web.Views.ProposedProject
{
    public class ExpectedPerformanceMeasureValuesViewData : ProposedProjectViewData
    {
        public readonly EditPerformanceMeasureExpectedViewData EditPerformanceMeasureExpectedViewData;

        public ExpectedPerformanceMeasureValuesViewData(Person currentPerson,
            Models.ProposedProject proposedProject,
            ProposalSectionsStatus proposalSectionsStatus,
            EditPerformanceMeasureExpectedViewData editPerformanceMeasureExpectedViewData)
            : base(currentPerson, proposedProject, ProposedProjectSectionEnum.PerformanceMeasures, proposalSectionsStatus)
        {
            EditPerformanceMeasureExpectedViewData = editPerformanceMeasureExpectedViewData;            
        }
    }
}