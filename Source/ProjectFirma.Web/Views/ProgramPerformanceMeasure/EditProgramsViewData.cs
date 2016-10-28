using System.Collections.Generic;
using ProjectFirma.Web.Views;

namespace ProjectFirma.Web.Views.ProgramPerformanceMeasure
{
    public class EditProgramsViewData : FirmaUserControlViewData
    {
        public readonly List<Models.ProgramSimple> AllPrograms;
        public readonly Models.PerformanceMeasureSimple PerformanceMeasure;

        public EditProgramsViewData(Models.PerformanceMeasureSimple performanceMeasure, List<Models.ProgramSimple> programs)
        {
            PerformanceMeasure = performanceMeasure;
            AllPrograms = programs;
        }
    }
}