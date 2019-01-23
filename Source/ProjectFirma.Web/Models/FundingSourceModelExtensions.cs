using System.Web;
using LtInfo.Common;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Controllers;

namespace ProjectFirma.Web.Models
{
    public static class FundingSourceModelExtensions
    {
        public static string GetEditUrl(this FundingSource fundingSource)
        {
            return SitkaRoute<FundingSourceController>.BuildUrlFromExpression(t => t.Edit(fundingSource.FundingSourceID));
        }

        public static string GetDeleteUrl(this FundingSource fundingSource)
        {
            return SitkaRoute<FundingSourceController>.BuildUrlFromExpression(c => c.DeleteFundingSource(fundingSource.FundingSourceID));
        }

        public static HtmlString GetDisplayNameAsUrl(this FundingSource fundingSource) => UrlTemplate.MakeHrefString(fundingSource.GetDetailUrl(), fundingSource.GetDisplayName());

        public static string GetDetailUrl(this FundingSource fundingSource)
        {
            return SitkaRoute<FundingSourceController>.BuildUrlFromExpression(x => x.Detail(fundingSource.FundingSourceID));
        }
    }
}