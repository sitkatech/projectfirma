/*-----------------------------------------------------------------------
<copyright file="PerformanceMeasureSubcategoryOption.cs" company="Tahoe Regional Planning Agency and Environmental Science Associates">
Copyright (c) Tahoe Regional Planning Agency and Environmental Science Associates. All rights reserved.
<author>Environmental Science Associates</author>
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

using System.Linq;

namespace ProjectFirmaModels.Models
{
    public partial class PerformanceMeasureSubcategoryOption : IAuditableEntity
    {
        public string GetAuditDescriptionString()
        {
            return PerformanceMeasureSubcategoryOptionName;
        }

        public bool HasCurrentDependentObjects ()
        {
            if (!HasDependentObjects())
            {
                return false;
            }
            // otherwise, check that the dependent objects are only for Projects or "current" Project Updates (i.e. not an update that was already approved and merged into the Project)
            if (PerformanceMeasureActualSubcategoryOptions.Any() || PerformanceMeasureExpectedSubcategoryOptions.Any())
            {
                // for projects, not updates, so yes it's current
                return true;
            }

            var isReferencedByNonApprovedUpdate = false;
            if (PerformanceMeasureActualSubcategoryOptionUpdates.Any())
            {
                isReferencedByNonApprovedUpdate = PerformanceMeasureActualSubcategoryOptionUpdates.Any(x =>
                    x.PerformanceMeasureActualUpdate.ProjectUpdateBatch.ProjectUpdateState !=
                    ProjectUpdateState.Approved);
            }
            if (PerformanceMeasureExpectedSubcategoryOptionUpdates.Any())
            {
                isReferencedByNonApprovedUpdate = PerformanceMeasureExpectedSubcategoryOptionUpdates.Any(x =>
                    x.PerformanceMeasureExpectedUpdate.ProjectUpdateBatch.ProjectUpdateState !=
                    ProjectUpdateState.Approved);
            }
            return isReferencedByNonApprovedUpdate;
        }

        public int GetCurrentDependentProjectCount()
        {
            var projectIDs = PerformanceMeasureActualSubcategoryOptions.Select(x => x.PerformanceMeasureActual.Project.ProjectID).ToList();
            projectIDs.AddRange(PerformanceMeasureExpectedSubcategoryOptions.Select(x => x.PerformanceMeasureExpected.Project.ProjectID));
            var nonApprovedProjectUpdates = PerformanceMeasureActualSubcategoryOptionUpdates
                .Select(x => x.PerformanceMeasureActualUpdate.ProjectUpdateBatch)
                .Where(x => x.ProjectUpdateState != ProjectUpdateState.Approved).ToList();
            nonApprovedProjectUpdates.AddRange(PerformanceMeasureExpectedSubcategoryOptionUpdates
                .Select(x => x.PerformanceMeasureExpectedUpdate.ProjectUpdateBatch)
                .Where(x => x.ProjectUpdateState != ProjectUpdateState.Approved));
            projectIDs.AddRange(nonApprovedProjectUpdates.Select(x => x.Project.ProjectID));
            return projectIDs.Distinct().Count();
        }
    }
}
