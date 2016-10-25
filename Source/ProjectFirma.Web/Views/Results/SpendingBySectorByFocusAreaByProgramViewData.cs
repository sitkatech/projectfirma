using System.Collections.Generic;
using System.Web.Mvc;
using ProjectFirma.Web.Controllers;
using ProjectFirma.Web.Models;
using LtInfo.Common;

namespace ProjectFirma.Web.Views.Results
{
    public class SpendingBySectorByFocusAreaByProgramViewData : FirmaViewData
    {
        public readonly List<ProgramSectorExpenditure> ProgramSectorExpenditures;
        public readonly List<Sector> Sectors;
        public readonly int? SelectedCalendarYear;
        public readonly IEnumerable<SelectListItem> CalendarYears;
        public readonly string SpendingBySectorByFocusAreaByProgramUrl;

        public SpendingBySectorByFocusAreaByProgramViewData(Person currentPerson,
            Models.ProjectFirmaPage projectFirmaPage,
            List<ProgramSectorExpenditure> programSectorExpenditures,
            List<Sector> sectors,
            int? selectedCalendarYear,
            IEnumerable<SelectListItem> calendarYears) : base(currentPerson, projectFirmaPage)
        {
            ProgramSectorExpenditures = programSectorExpenditures;
            PageTitle = "Spending by Sector by Focus Area by Program";
            SelectedCalendarYear = selectedCalendarYear;
            CalendarYears = calendarYears;
            Sectors = sectors;
            SpendingBySectorByFocusAreaByProgramUrl = SitkaRoute<ResultsController>.BuildUrlFromExpression(x => x.SpendingBySectorByFocusAreaByProgram(UrlTemplate.Parameter1Int));
        }
    }
}