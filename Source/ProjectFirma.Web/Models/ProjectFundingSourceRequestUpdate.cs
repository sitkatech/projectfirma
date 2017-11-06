/*-----------------------------------------------------------------------
<copyright file="ProjectFundingSourceRequestUpdate.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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
using System.Linq;
using LtInfo.Common;

namespace ProjectFirma.Web.Models
{
    public partial class ProjectFundingSourceRequestUpdate : IFundingSourceRequestAmount
    {
        public static void CreateFromProject(ProjectUpdateBatch projectUpdateBatch)
        {
            var project = projectUpdateBatch.Project;
            projectUpdateBatch.ProjectFundingSourceRequestUpdates = project.ProjectFundingSourceRequests.Select(projectFundingSourceRequest =>
                new ProjectFundingSourceRequestUpdate(projectUpdateBatch,
                    projectFundingSourceRequest.FundingSource,
                    projectFundingSourceRequest.SecuredAmount,
                    projectFundingSourceRequest.UnsecuredAmount)).ToList();
        }

        public static void CommitChangesToProject(ProjectUpdateBatch projectUpdateBatch, IList<ProjectFundingSourceRequest> allProjectFundingSourceRequests)
        {
            var project = projectUpdateBatch.Project;
            var projectFundingSourceExpectedFundingFromProjectUpdate = projectUpdateBatch.ProjectFundingSourceRequestUpdates
                .Select(x => new ProjectFundingSourceRequest(project.ProjectID, x.FundingSource.FundingSourceID, x.SecuredAmount, x.UnsecuredAmount)).ToList();
            project.ProjectFundingSourceRequests.Merge(projectFundingSourceExpectedFundingFromProjectUpdate,
                allProjectFundingSourceRequests,
                (x, y) => x.ProjectID == y.ProjectID && x.FundingSourceID == y.FundingSourceID,
                (x, y) =>
                {
                    x.SecuredAmount = y.SecuredAmount;
                    x.UnsecuredAmount = y.UnsecuredAmount;
                });
        }
    }
}