using System.Web;

namespace ProjectFirma.Web.Models
{
    public class ProgramSectorExpenditure
    {
        public readonly Sector Sector;
        public readonly HtmlString ProgramName;
        public readonly HtmlString FocusAreaName;
        public readonly decimal ExpenditureAmount;

        public ProgramSectorExpenditure(Sector sector, Program program, decimal expenditureAmount) : this(sector, program.DisplayNameAsUrl, program.FocusArea.DisplayNameAsUrl, expenditureAmount)
        {
        }

        public ProgramSectorExpenditure(Sector sector, string programName, string focusAreaName, decimal expenditureAmount)
            : this(sector, new HtmlString(programName), new HtmlString(focusAreaName), expenditureAmount)
        {
        }

        private ProgramSectorExpenditure(Sector sector, HtmlString programName, HtmlString focusAreaName, decimal expenditureAmount)
        {
            Sector = sector;
            ProgramName = programName;
            FocusAreaName = focusAreaName;
            ExpenditureAmount = expenditureAmount;
        }
    }
}