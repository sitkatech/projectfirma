namespace ProjectFirma.Web.Areas.EIP.Views.Shared
{
    public class HtmlDiffSummaryViewData
    {
        public readonly string HtmlDiffResult;
        public readonly string DiffTitle;

        public HtmlDiffSummaryViewData(string htmlDiffResult, string diffTitle)
        {
            HtmlDiffResult = htmlDiffResult;
            DiffTitle = diffTitle;
        }
    }
}