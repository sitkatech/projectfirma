using System.Collections.Generic;
using System.Linq;
using ProjectFirma.Web.Models;
using LtInfo.Common;
using LtInfo.Common.Models;

namespace ProjectFirma.Web.Views.ProgramPerformanceMeasure
{
    public class EditProgramsViewModel : FormViewModel
    {
        public int? PrimaryProgramID { get; set; }
        public List<ProgramPerformanceMeasureSimple> ProgramPerformanceMeasures { get; set; }

        /// <summary>
        /// Needed by the ModelBinder
        /// </summary>
        public EditProgramsViewModel()
        {
        }

        public EditProgramsViewModel(List<ProgramPerformanceMeasureSimple> programPerformanceMeasureSimples, int? primaryProgramID)
        {
            ProgramPerformanceMeasures = programPerformanceMeasureSimples;
            PrimaryProgramID = primaryProgramID;
        }

        public void UpdateModel(List<Models.ProgramPerformanceMeasure> currentProgramPerformanceMeasures, IList<Models.ProgramPerformanceMeasure> allProgramPerformanceMeasures)
        {
            var programPerformanceMeasuresUpdated = new List<Models.ProgramPerformanceMeasure>();
            if (ProgramPerformanceMeasures != null)
            {
                // Completely rebuild the list
                programPerformanceMeasuresUpdated = ProgramPerformanceMeasures.Select(x => new Models.ProgramPerformanceMeasure(x.ProgramID, x.PerformanceMeasureID, false)).ToList();
            }
            currentProgramPerformanceMeasures.Merge(programPerformanceMeasuresUpdated,
                allProgramPerformanceMeasures,
                (x, y) => x.ProgramID == y.ProgramID && x.PerformanceMeasureID == y.PerformanceMeasureID,
                (x, y) => x.IsPrimaryProgram = (PrimaryProgramID == x.ProgramID));
        }
    }
}