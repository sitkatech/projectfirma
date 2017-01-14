using LtInfo.Common;
using ProjectFirma.Web.Controllers;
using ProjectFirma.Web.Models;

namespace ProjectFirma.Web.Views.ProjectUpdate
{
    public class InstructionsViewData : ProjectUpdateViewData
    {
        public readonly string PerformanceMeasuresUrl;

        public InstructionsViewData(Person currentPerson, ProjectUpdateBatch projectUpdateBatch, UpdateStatus updateStatus) : base(currentPerson, projectUpdateBatch, ProjectUpdateSectionEnum.Instructions, updateStatus)
        {
            PerformanceMeasuresUrl = SitkaRoute<PerformanceMeasureController>.BuildUrlFromExpression(x => x.Index());
        }
    }
}