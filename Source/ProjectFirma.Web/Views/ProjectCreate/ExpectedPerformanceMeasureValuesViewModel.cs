/*-----------------------------------------------------------------------
<copyright file="ExpectedPerformanceMeasureValuesViewModel.cs" company="Tahoe Regional Planning Agency">
Copyright (c) Tahoe Regional Planning Agency. All rights reserved.
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
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using ProjectFirmaModels.Models;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Views.Shared.PerformanceMeasureControls;

namespace ProjectFirma.Web.Views.ProjectCreate
{
    public class ExpectedPerformanceMeasureValuesViewModel : EditPerformanceMeasureExpectedViewModel
    {
        [StringLength(ProjectFirmaModels.Models.Project.FieldLengths.PerformanceMeasureNotes)]
        public string PerformanceMeasureNotes { get; set; }

        [DisplayName("Reviewer Comments")]
        [StringLength(ProjectFirmaModels.Models.Project.FieldLengths.ExpectedAccomplishmentsComment)]
        public string Comments { get; set; }

        /// <summary>
        /// Needed by the ModelBinder
        /// </summary>
        public ExpectedPerformanceMeasureValuesViewModel()
        {
        }

        public ExpectedPerformanceMeasureValuesViewModel(ProjectFirmaModels.Models.Project project)
            : base(project.PerformanceMeasureExpecteds.OrderBy(pam => pam.PerformanceMeasure.GetSortOrder()).ThenBy(x=>x.PerformanceMeasure.GetDisplayName()).Select(x => new PerformanceMeasureExpectedSimple(x)).ToList())
        {
            PerformanceMeasureNotes = project.PerformanceMeasureNotes;
            Comments = project.ExpectedAccomplishmentsComment;
        }

        public override void UpdateModel(List<PerformanceMeasureExpected> currentPerformanceMeasureExpecteds,
            IList<PerformanceMeasureExpected> allPerformanceMeasureExpecteds,
            IList<PerformanceMeasureExpectedSubcategoryOption> allPerformanceMeasureExpectedSubcategoryOptions,
            ProjectFirmaModels.Models.Project project)
        {
            project.PerformanceMeasureNotes = PerformanceMeasureNotes;
            if (project.ProjectApprovalStatus == ProjectApprovalStatus.PendingApproval)
            {
                project.ExpectedAccomplishmentsComment = Comments;
            }

            base.UpdateModel(currentPerformanceMeasureExpecteds, allPerformanceMeasureExpecteds,
                allPerformanceMeasureExpectedSubcategoryOptions, project);
        }
    }
}
