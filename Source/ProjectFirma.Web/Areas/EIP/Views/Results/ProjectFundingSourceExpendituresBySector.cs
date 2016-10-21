using System.Web.Mvc;
using LtInfo.Common.HtmlHelperExtensions;

namespace ProjectFirma.Web.Areas.EIP.Views.Results
{
    public abstract class ProjectFundingSourceExpendituresBySector : LtInfo.Common.Mvc.TypedWebPartialViewPage<ProjectFundingSourceExpendituresBySectorViewData>
    {
        public static void RenderPartialView(HtmlHelper html, ProjectFundingSourceExpendituresBySectorViewData viewData)
        {
            html.RenderRazorSitkaPartial<ProjectFundingSourceExpendituresBySector, ProjectFundingSourceExpendituresBySectorViewData>(viewData);
        }
    }
}