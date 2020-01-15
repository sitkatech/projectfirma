/*-----------------------------------------------------------------------
<copyright file="EditRtfContentViewModel.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
Copyright (c) Tahoe Regional Planning Agency and Sitka Technology Group. All rights reserved.
<author>Sitka Technology Group</author>
</copyright>

<license>
This program is free software: you can redistribute it and/or modify
it under the terms of the GNU Affero General Public License as published by
the Free Software Foundation, either version 3 of the License, or
(at your option) any later version.

This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU Affero General Public License <http://www.gnu.org/licenses/> for more details.

Source code is available upon request via <support@sitkatech.com>.
</license>
-----------------------------------------------------------------------*/
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
        public void UpdateModel(ProjectFirmaModels.Models.PerformanceMeasure performanceMeasure, EditRtfContent.PerformanceMeasureRichTextType performanceMeasureRichTextType)
        {
            switch (performanceMeasureRichTextType)
            {
                case EditRtfContent.PerformanceMeasureRichTextType.CriticalDefinitions:
                    performanceMeasure.CriticalDefinitionsHtmlString = RtfContent;
                    break;
                case EditRtfContent.PerformanceMeasureRichTextType.ProjectReporting:
                    performanceMeasure.ProjectReportingHtmlString = RtfContent;
                    break;
                case EditRtfContent.PerformanceMeasureRichTextType.Importance:
                    performanceMeasure.ImportanceHtmlString = RtfContent;
                    break;
                case EditRtfContent.PerformanceMeasureRichTextType.AdditionalInformation:
                    performanceMeasure.AdditionalInformationHtmlString = RtfContent;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(string.Format("Invalid GuidanceType {0}", performanceMeasureRichTextType));
            }
        }
    }
}
