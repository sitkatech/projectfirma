using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Models
{
    public partial class Sector
    {
        public decimal GetPreReportingYearExpenditures()
        {
            if (ProjectFirmaDateUtilities.GetMinimumYearForReportingExpenditures() == 2007)
            {
                return Pre2007Expenditures;
            }
            return Pre2010Expenditures;
        }
    }
}