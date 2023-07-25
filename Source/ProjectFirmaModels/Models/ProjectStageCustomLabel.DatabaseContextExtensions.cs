/*-----------------------------------------------------------------------
<copyright file="ProjectStageCustomLabel.DatabaseContextExtensions.cs" company="Tahoe Regional Planning Agency and Environmental Science Associates">
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
    public static partial class DatabaseContextExtensions
    {
        public static ProjectStageCustomLabel GetProjectStageCustomLabelByProjectStage(this IQueryable<ProjectStageCustomLabel> projectStageCustomLabels, ProjectStage projectStage)
        {
            return GetProjectStageCustomLabelByProjectStage(projectStageCustomLabels, projectStage.ProjectStageID);
        }

        public static ProjectStageCustomLabel GetProjectStageCustomLabelByProjectStage(this IQueryable<ProjectStageCustomLabel> projectStageCustomLabels, int projectStageID)
        {
            return projectStageCustomLabels.SingleOrDefault(x => x.ProjectStageID == projectStageID);
        }

        public static ProjectStageCustomLabel GetProjectStageCustomLabelByProjectStage(this IQueryable<ProjectStageCustomLabel> projectStageCustomLabels, ProjectStageEnum projectStageEnum)
        {
            return projectStageCustomLabels.SingleOrDefault(x => x.ProjectStageID == (int) projectStageEnum);
        }

        public static ProjectStageCustomLabel GetProjectStageCustomLabelByProjectStage(this IQueryable<ProjectStageCustomLabel> projectStageCustomLabels, ProjectStagePrimaryKey projectStagePrimaryKey)
        {
            return projectStageCustomLabels.SingleOrDefault(x => x.ProjectStageID == projectStagePrimaryKey.PrimaryKeyValue);
        }
    }
}
