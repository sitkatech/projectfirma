using LtInfo.Common.Mvc;

namespace ProjectFirma.Web.Views.Shared.TextControls
{
    public abstract class EditRtfContent : TypedWebPartialViewPage<EditRtfContentViewData, EditRtfContentViewModel>
    {
        public enum PerformanceMeasureRichTextType
        {
            SimpleDescription,
            CriticalDefinitions,
            AccountingPeriodAndScale,
            ProjectReporting,
            AssociatedPrograms
        }
    }
}