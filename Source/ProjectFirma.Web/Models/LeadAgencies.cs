using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Web.Mvc;
using LtInfo.Common.Mvc;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Models
{
    public class LeadAgencies
    {
        public static IEnumerable<SelectListItem> ToSelectList(Person currentPerson)
        {
            IEnumerable<LeadAgency> leadAgencies;
            var selectedLeadAgencyID = currentPerson.LeadAgencyID;
            switch (currentPerson.ParcelTrackerRole.ToEnum)
            {
                case ParcelTrackerRoleEnum.Admin:
                case ParcelTrackerRoleEnum.Power:
                    leadAgencies = HttpRequestStorage.DatabaseEntities.LeadAgencies.Where(x => x.LeadAgencyTransactionTypeCommodities.Any());
                    break;
                case ParcelTrackerRoleEnum.Normal:
                    leadAgencies = new[] { HttpRequestStorage.DatabaseEntities.LeadAgencies.GetLeadAgency(selectedLeadAgencyID)};
                    break;
                default:
                    throw new InvalidEnumArgumentException();
            }
            return leadAgencies.OrderBy(x => x.DisplayName).ToSelectListWithEmptyFirstRow(la => la.LeadAgencyID.ToString(CultureInfo.InvariantCulture), la => la.LeadAgencyName);
        }
    }
}