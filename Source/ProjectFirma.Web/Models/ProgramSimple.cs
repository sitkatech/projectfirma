namespace ProjectFirma.Web.Models
{
    public class ProgramSimple
    {
        /// <summary>
        /// Needed by ModelBinder
        /// </summary>
        public ProgramSimple()
        {
        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public ProgramSimple(int programID, int focusAreaID, byte programNumber, string programName, string programDescription, string associatedPrograms)
            : this()
        {
            ProgramID = programID;
            FocusAreaID = focusAreaID;
            ProgramNumber = programNumber;
            ProgramName = programName;
            ProgramDescription = programDescription;
            AssociatedPrograms = associatedPrograms;
        }

        /// <summary>
        /// Constructor for building a new simple object with the POCO class
        /// </summary>
        public ProgramSimple(Program program)
            : this()
        {
            ProgramID = program.ProgramID;
            FocusAreaID = program.FocusAreaID;
            ProgramNumber = program.ProgramNumber;
            ProgramName = program.ProgramName;
            ProgramDescription = program.ProgramDescriptionHtmlString == null ? null : program.ProgramDescriptionHtmlString.ToString();
            AssociatedPrograms = program.AssociatedProgramsHtmlString == null ? null : program.AssociatedProgramsHtmlString.ToString();
            FocusAreaNumber = program.FocusArea.DisplayNumber;
            DisplayNumber = program.DisplayNumber;
            DisplayName = program.DisplayName;
        }

        public int ProgramID { get; set; }
        public int FocusAreaID { get; set; }
        public byte ProgramNumber { get; set; }
        public string ProgramName { get; set; }
        public string ProgramDescription { get; set; }
        public string AssociatedPrograms { get; set; }
        public string FocusAreaNumber { get; set; }
        public string DisplayNumber { get; set; }
        public string DisplayName { get; set; }
    }
}