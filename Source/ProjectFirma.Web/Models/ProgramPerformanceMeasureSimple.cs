namespace ProjectFirma.Web.Models
{
    public class ProgramPerformanceMeasureSimple
    {
        /// <summary>
        /// Needed by ModelBinder
        /// </summary>
        public ProgramPerformanceMeasureSimple()
        {
        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public ProgramPerformanceMeasureSimple(int programPerformanceMeasureID, int programID, int performanceMeasureID, bool isPrimaryProgram)
            : this()
        {
            ProgramPerformanceMeasureID = programPerformanceMeasureID;
            ProgramID = programID;
            PerformanceMeasureID = performanceMeasureID;
            IsPrimaryProgram = isPrimaryProgram;
        }

        /// <summary>
        /// Constructor for building a new simple object with the POCO class
        /// </summary>
        public ProgramPerformanceMeasureSimple(ProgramPerformanceMeasure programPerformanceMeasure)
            : this()
        {
            ProgramPerformanceMeasureID = programPerformanceMeasure.ProgramPerformanceMeasureID;
            ProgramID = programPerformanceMeasure.ProgramID;
            PerformanceMeasureID = programPerformanceMeasure.PerformanceMeasureID;
            IsPrimaryProgram = programPerformanceMeasure.IsPrimaryProgram;
        }

        public int ProgramPerformanceMeasureID { get; set; }
        public int ProgramID { get; set; }
        public int PerformanceMeasureID { get; set; }
        public bool IsPrimaryProgram { get; set; }
    }
}