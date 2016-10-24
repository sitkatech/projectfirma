using System.Collections.Generic;
using ProjectFirma.Web.Views;

namespace ProjectFirma.Web.Views.ProgramEIPPerformanceMeasure
{
    public class EditProgramsViewData : LakeTahoeInfoUserControlViewData
    {
        public readonly List<Models.ProgramSimple> AllPrograms;
        public readonly Models.EIPPerformanceMeasureSimple EIPPerformanceMeasure;

        public EditProgramsViewData(Models.EIPPerformanceMeasureSimple eipPerformanceMeasure, List<Models.ProgramSimple> programs)
        {
            EIPPerformanceMeasure = eipPerformanceMeasure;
            AllPrograms = programs;
        }
    }
}