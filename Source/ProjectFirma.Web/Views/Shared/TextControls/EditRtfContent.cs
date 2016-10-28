using LtInfo.Common.Mvc;

namespace ProjectFirma.Web.Views.Shared.TextControls
{
    public abstract class EditRtfContent : TypedWebPartialViewPage<EditRtfContentViewData, EditRtfContentViewModel>
    {
        public enum IndicatorRichTextType
        {
            SimpleDescription,
            CriticalDefinitions,
            AccountingPeriodAndScale,
            ProjectReporting,
            AssociatedPrograms
        }
    }
}