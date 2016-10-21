namespace ProjectFirma.Web.Models
{
    public class ProgramEIPPerformanceMeasureSimple
    {
        /// <summary>
        /// Needed by ModelBinder
        /// </summary>
        public ProgramEIPPerformanceMeasureSimple()
        {
        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public ProgramEIPPerformanceMeasureSimple(int programEIPPerformanceMeasureID, int programID, int eipPerformanceMeasureID, bool isPrimaryProgram)
            : this()
        {
            ProgramEIPPerformanceMeasureID = programEIPPerformanceMeasureID;
            ProgramID = programID;
            EIPPerformanceMeasureID = eipPerformanceMeasureID;
            IsPrimaryProgram = isPrimaryProgram;
        }

        /// <summary>
        /// Constructor for building a new simple object with the POCO class
        /// </summary>
        public ProgramEIPPerformanceMeasureSimple(ProgramEIPPerformanceMeasure programEIPPerformanceMeasure)
            : this()
        {
            ProgramEIPPerformanceMeasureID = programEIPPerformanceMeasure.ProgramEIPPerformanceMeasureID;
            ProgramID = programEIPPerformanceMeasure.ProgramID;
            EIPPerformanceMeasureID = programEIPPerformanceMeasure.EIPPerformanceMeasureID;
            IsPrimaryProgram = programEIPPerformanceMeasure.IsPrimaryProgram;
        }

        public int ProgramEIPPerformanceMeasureID { get; set; }
        public int ProgramID { get; set; }
        public int EIPPerformanceMeasureID { get; set; }
        public bool IsPrimaryProgram { get; set; }
    }
}