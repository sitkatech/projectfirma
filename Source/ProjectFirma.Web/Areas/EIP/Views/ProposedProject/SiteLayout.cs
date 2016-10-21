namespace ProjectFirma.Web.Areas.EIP.Views.ProposedProject
{
    public abstract class SiteLayout : LtInfo.Common.Mvc.TypedWebViewPage<ProposedProjectViewData>
    {
        protected string SetSelectedSectionStyle(ProposedProjectSectionEnum currentSection, ProposedProjectSectionEnum selectedProposedProjectSection)
        {
            return selectedProposedProjectSection == currentSection ? "selected" : string.Empty;
        }
    }
}