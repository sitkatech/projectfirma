using System.Collections.Generic;
using System.Linq;
using ProjectFirma.Web.Models;
using LtInfo.Common;
using LtInfo.Common.Models;

namespace ProjectFirma.Web.Views.ProgramEIPPerformanceMeasure
{
    public class EditProgramsViewModel : FormViewModel
    {
        public int? PrimaryProgramID { get; set; }
        public List<ProgramEIPPerformanceMeasureSimple> ProgramEIPPerformanceMeasures { get; set; }

        /// <summary>
        /// Needed by the ModelBinder
        /// </summary>
        public EditProgramsViewModel()
        {
        }

        public EditProgramsViewModel(List<ProgramEIPPerformanceMeasureSimple> programEIPPerformanceMeasureSimples, int? primaryProgramID)
        {
            ProgramEIPPerformanceMeasures = programEIPPerformanceMeasureSimples;
            PrimaryProgramID = primaryProgramID;
        }

        public void UpdateModel(List<Models.ProgramEIPPerformanceMeasure> currentProgramEIPPerformanceMeasures, IList<Models.ProgramEIPPerformanceMeasure> allProgramEIPPerformanceMeasures)
        {
            var programEIPPerformanceMeasuresUpdated = new List<Models.ProgramEIPPerformanceMeasure>();
            if (ProgramEIPPerformanceMeasures != null)
            {
                // Completely rebuild the list
                programEIPPerformanceMeasuresUpdated = ProgramEIPPerformanceMeasures.Select(x => new Models.ProgramEIPPerformanceMeasure(x.ProgramID, x.EIPPerformanceMeasureID, false)).ToList();
            }
            currentProgramEIPPerformanceMeasures.Merge(programEIPPerformanceMeasuresUpdated,
                allProgramEIPPerformanceMeasures,
                (x, y) => x.ProgramID == y.ProgramID && x.EIPPerformanceMeasureID == y.EIPPerformanceMeasureID,
                (x, y) => x.IsPrimaryProgram = (PrimaryProgramID == x.ProgramID));
        }
    }
}