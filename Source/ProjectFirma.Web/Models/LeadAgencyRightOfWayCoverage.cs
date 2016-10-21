using ProjectFirma.Web.Common;
using LtInfo.Common.Views;

namespace ProjectFirma.Web.Models
{
    public partial class LeadAgencyRightOfWayCoverage : IAuditableEntity
    {
        public string DisplayName
        {
            get
            {
                return Commodity.CanHaveLandCapability
                    ? string.Format("{0}{1}", Commodity.CommodityDisplayName, (BaileyRating == null ? string.Empty : string.Format(" (Bailey {0})", BaileyRating.BaileyRatingDisplayName)))
                    : Commodity.CommodityDisplayName;
            }
        }
        public string AuditDescriptionString
        {
            get
            {
                var leadAgency = HttpRequestStorage.DatabaseEntities.LeadAgencies.Find(LeadAgencyID);
                var leadAgencyName = leadAgency != null ? leadAgency.LeadAgencyName : ViewUtilities.NotFoundString;
                var commodityName = Commodity.DisplayName;
                return string.Format("Lead Agency: {0}, Commodity: {1}", leadAgencyName, commodityName);
                
            }
        }
    }
}