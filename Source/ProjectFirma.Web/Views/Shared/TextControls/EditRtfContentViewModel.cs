using System;
using System.Web;
using LtInfo.Common.Models;

namespace ProjectFirma.Web.Views.Shared.TextControls
{
    public class EditRtfContentViewModel : FormViewModel
    {
        public HtmlString RtfContent { get; set; }

        /// <summary>
        /// Needed by model binder
        /// </summary>
        public EditRtfContentViewModel()
        {
        }

        public EditRtfContentViewModel(HtmlString rtfContent)
        {
            RtfContent = rtfContent;
        }

        /// <summary>
        /// Used by PerformanceMeasure Guidance
        /// </summary>
        public void UpdateModel(Models.PerformanceMeasure performanceMeasure, EditRtfContent.PerformanceMeasureRichTextType performanceMeasureRichTextType)
        {
            switch (performanceMeasureRichTextType)
            {
                case EditRtfContent.PerformanceMeasureRichTextType.SimpleDescription:
                    performanceMeasure.PerformanceMeasurePublicDescriptionHtmlString = RtfContent;
                    break;
                case EditRtfContent.PerformanceMeasureRichTextType.CriticalDefinitions:
                    performanceMeasure.CriticalDefinitionsHtmlString = RtfContent;
                    break;
                case EditRtfContent.PerformanceMeasureRichTextType.AccountingPeriodAndScale:
                    performanceMeasure.AccountingPeriodAndScaleHtmlString = RtfContent;
                    break;
                case EditRtfContent.PerformanceMeasureRichTextType.ProjectReporting:
                    performanceMeasure.ProjectReportingHtmlString = RtfContent;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(string.Format("Invalid GuidanceType {0}", performanceMeasureRichTextType));
            }
        }

        /// <summary>
        /// Used by FocusArea Description
        /// </summary>
        public void UpdateModel(Models.FocusArea focusArea)
        {
            focusArea.FocusAreaDescriptionHtmlString = RtfContent;
        }

        /// <summary>
        /// Used by Program Description
        /// </summary>
        public void UpdateModel(Models.Program program)
        {
            program.ProgramDescriptionHtmlString = RtfContent;
        }

        /// <summary>
        /// Used by ActionPriority Description
        /// </summary>
        public void UpdateModel(Models.ActionPriority actionPriority)
        {
            actionPriority.ActionPriorityDescriptionHtmlString = RtfContent;
        }
    }
}