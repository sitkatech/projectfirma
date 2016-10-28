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
        /// Used by Indicator Guidance
        /// </summary>
        public void UpdateModel(Models.Indicator indicator, EditRtfContent.IndicatorRichTextType indicatorRichTextType)
        {
            switch (indicatorRichTextType)
            {
                case EditRtfContent.IndicatorRichTextType.SimpleDescription:
                    indicator.IndicatorPublicDescriptionHtmlString = RtfContent;
                    break;
                case EditRtfContent.IndicatorRichTextType.AssociatedPrograms:
                    indicator.AssociatedProgramsHtmlString = RtfContent;
                    break;
                case EditRtfContent.IndicatorRichTextType.CriticalDefinitions:
                    indicator.PerformanceMeasure.CriticalDefinitionsHtmlString = RtfContent;
                    break;
                case EditRtfContent.IndicatorRichTextType.AccountingPeriodAndScale:
                    indicator.PerformanceMeasure.AccountingPeriodAndScaleHtmlString = RtfContent;
                    break;
                case EditRtfContent.IndicatorRichTextType.ProjectReporting:
                    indicator.PerformanceMeasure.ProjectReportingHtmlString = RtfContent;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(string.Format("Invalid GuidanceType {0}", indicatorRichTextType));
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

        /// <summary>
        /// Used by TransportationStrategy Description
        /// </summary>
        public void UpdateModel(Models.TransportationStrategy transportationStrategy)
        {
            transportationStrategy.TransportationStrategyDescriptionHtmlString = RtfContent;
        }

        /// <summary>
        /// Used by TransportationObjective Description
        /// </summary>
        public void UpdateModel(Models.TransportationObjective transportationObjective)
        {
            transportationObjective.TransportationObjectiveDescriptionHtmlString = RtfContent;
        }
    }
}