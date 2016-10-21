using System.Linq;
using ProjectFirma.Web.Common;
using LtInfo.Common.Views;

namespace ProjectFirma.Web.Models
{
    public partial class LeadAgency : IAuditableEntity
    {
        public const int TRPALeadAgencyID = 8;
        public const int CSLTLeadAgencyID = 2;
        public const int UnknownLeadAgencyID = 12;

        public LeadAgencyJson ToJson()
        {
            var transactionTypes = LeadAgencyTransactionTypeCommodities.Select(ttc => ttc.TransactionTypeCommodity.TransactionType).Distinct().ToList();
            return new LeadAgencyJson(LeadAgencyID, LeadAgencyName, transactionTypes.Select(tt => tt.ToJson(LeadAgencyTransactionTypeCommodities.Where(lttc => lttc.TransactionTypeCommodity.TransactionTypeID == tt.TransactionTypeID).Select(lttc => lttc.TransactionTypeCommodity).ToList())).ToList());
        }

        public bool IsLandBank
        {
            get { return LandBank != null; }
        }

        public bool IsJurisdiction
        {
            get { return Organization.Jurisdiction != null; }
        }

        public string LeadAgencyName
        {
            get { return Organization.OrganizationName; }
        }

        public string DisplayName
        {
            get { return LeadAgencyName; }
        }

        public string CurrentLandCapability
        {
            get
            {
                if (!CanManageRightOfWayCoverage)
                {
                    return ViewUtilities.NaString;
                }
                if (!LeadAgencyRightOfWayCoverages.Any())
                {
                    return ViewUtilities.NotAvailableString;
                }
                return string.Join(" and ", LeadAgencyRightOfWayCoverages.Select(x => x.DisplayName).Distinct().OrderBy(x => x));
            }
        }

        public string AuditDescriptionString { get { return DisplayName;} }

        public CommodityPool GetDefaultSendingPool(int commodityID)
        {
            var allPools =  HttpRequestStorage.DatabaseEntities.CommodityPools.ToList().Where(x => x.JurisdictionID == Organization.Jurisdiction.JurisdictionID && x.CommodityID == commodityID && x.CommodityPoolID != TdrTransactionAllocationAssignment.TrpaAllocationAssignmentPoolID).ToList();

            return allPools.Count() == 1 ? allPools.Single() : null;
        }
    }
}