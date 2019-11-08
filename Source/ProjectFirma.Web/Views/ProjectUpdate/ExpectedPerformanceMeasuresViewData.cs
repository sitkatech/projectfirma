/*-----------------------------------------------------------------------
<copyright file="ExpectedPerformanceMeasureValuesViewData.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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

using System.Collections.Generic;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Controllers;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Views.Shared.ProjectUpdateDiffControls;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Views.ProjectUpdate
{
    public class ExpectedPerformanceMeasuresViewData : ProjectUpdateViewData
    {
        public string RefreshUrl { get; }
        public string DiffUrl { get; }

        public ViewDataForAngularEditor ViewDataForAngular { get; }
        public SectionCommentsViewData SectionCommentsViewData { get; }
        public PerformanceMeasureExpectedValuesSummaryViewData PerformanceMeasureExpectedValuesSummaryViewData { get; }

        public ExpectedPerformanceMeasuresViewData(FirmaSession currentFirmaSession,
            ProjectUpdateBatch projectUpdateBatch,
            ProjectUpdateStatus projectUpdateStatus,
            ViewDataForAngularEditor viewDataForAngular, PerformanceMeasureExpectedValuesSummaryViewData performanceMeasureExpectedValuesSummaryViewData)
            : base(currentFirmaSession, projectUpdateBatch, projectUpdateStatus, new List<string>(), ProjectUpdateSection.ExpectedAccomplishments.ProjectUpdateSectionDisplayName)
        {
            RefreshUrl = SitkaRoute<ProjectUpdateController>.BuildUrlFromExpression(x => x.RefreshExpectedPerformanceMeasures(projectUpdateBatch.Project));
            DiffUrl = SitkaRoute<ProjectUpdateController>.BuildUrlFromExpression(x => x.DiffExpectedPerformanceMeasures(projectUpdateBatch.Project));
            ViewDataForAngular = viewDataForAngular;
            PerformanceMeasureExpectedValuesSummaryViewData = performanceMeasureExpectedValuesSummaryViewData;
            SectionCommentsViewData = new SectionCommentsViewData(projectUpdateBatch.ExpectedPerformanceMeasuresComment, projectUpdateBatch.IsReturned());
        }

        public class ViewDataForAngularEditor
        {
            public ViewDataForAngularEditor(List<PerformanceMeasureSimple> allPerformanceMeasures, List<PerformanceMeasureSubcategorySimple> allPerformanceMeasureSubcategories, List<PerformanceMeasureSubcategoryOptionSimple> allPerformanceMeasureSubcategoryOptions)
            {
                AllPerformanceMeasures = allPerformanceMeasures;
                AllPerformanceMeasureSubcategories = allPerformanceMeasureSubcategories;
                AllPerformanceMeasureSubcategoryOptions = allPerformanceMeasureSubcategoryOptions;
            }

            public List<PerformanceMeasureSimple> AllPerformanceMeasures { get; }
            public List<PerformanceMeasureSubcategorySimple> AllPerformanceMeasureSubcategories { get; }
            public List<PerformanceMeasureSubcategoryOptionSimple> AllPerformanceMeasureSubcategoryOptions { get; }
        }
    }
}
