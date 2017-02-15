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
                case EditRtfContent.PerformanceMeasureRichTextType.CriticalDefinitions:
                    performanceMeasure.CriticalDefinitionsHtmlString = RtfContent;
                    break;
                case EditRtfContent.PerformanceMeasureRichTextType.ProjectReporting:
                    performanceMeasure.ProjectReportingHtmlString = RtfContent;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(string.Format("Invalid GuidanceType {0}", performanceMeasureRichTextType));
            }
        }
    }
}