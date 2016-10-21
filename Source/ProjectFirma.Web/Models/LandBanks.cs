using System.Collections.Generic;
using System.Globalization;
using System.Web.Mvc;
using LtInfo.Common.Models;
using LtInfo.Common.Mvc;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Models
{
    public class LandBanks
    {
        public static IEnumerable<SelectListItem> ToSelectList(int? selectedLandBankID)
        {
            return ToSelectList(HttpRequestStorage.DatabaseEntities.LandBanks);
        }

        public static IEnumerable<SelectListItem> ToSelectList(LeadAgency currentLeadAgency, int? selectedLandBankID)
        {
            return ToSelectList(currentLeadAgency, selectedLandBankID ?? ModelObjectHelpers.NotYetAssignedID);
        }

        public static IEnumerable<SelectListItem> ToSelectList(LeadAgency currentLeadAgency, int selectedLandBankID)
        {
            IEnumerable<LandBank> landBanks;
            var showAllLandBanks = (currentLeadAgency.IsJurisdiction && currentLeadAgency.IsLandBank) || !currentLeadAgency.IsLandBank;
            if (showAllLandBanks)
            {
                // Show all possible land banks
                landBanks = HttpRequestStorage.DatabaseEntities.LandBanks;
            }
            else
            {
                // Limit to just the current land bank
                if (!ModelObjectHelpers.IsRealPrimaryKeyValue(selectedLandBankID))
                {
                    selectedLandBankID = currentLeadAgency.LandBank.LandBankID;
                }
                landBanks = new[] {HttpRequestStorage.DatabaseEntities.LandBanks.GetLandBank(selectedLandBankID)};
            }

            return ToSelectList(landBanks);
        }

        private static IEnumerable<SelectListItem> ToSelectList(IEnumerable<LandBank> landBanks)
        {
            return landBanks.ToSelectListWithEmptyFirstRow(la => la.LandBankID.ToString(CultureInfo.InvariantCulture), la => la.LandBankName);
        }
    }
}
