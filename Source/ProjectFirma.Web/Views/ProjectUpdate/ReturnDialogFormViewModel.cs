/*-----------------------------------------------------------------------
<copyright file="ReturnDialogFormViewModel.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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
using ProjectFirma.Web.Models;
using LtInfo.Common.Models;

namespace ProjectFirma.Web.Views.ProjectUpdate
{
    public class ReturnDialogFormViewModel : PartialViewModel
    {
        public string SectionComments { get; set; }
        public ProjectUpdateSectionEnum? ProjectUpdateSectionEnum { get; set; }

        public void UpdateModel(ProjectUpdateBatch projectUpdateBatch)
        {
            if (ProjectUpdateSectionEnum.HasValue)
            {
                switch (ProjectUpdateSectionEnum.Value)
                {
                    case ProjectUpdate.ProjectUpdateSectionEnum.Basics:
                        projectUpdateBatch.BasicsComment = SectionComments;
                        break;
                    case ProjectUpdate.ProjectUpdateSectionEnum.Expenditures:
                        projectUpdateBatch.ExpendituresComment = SectionComments;
                        break;
                    case ProjectUpdate.ProjectUpdateSectionEnum.PerformanceMeasures:
                        projectUpdateBatch.PerformanceMeasuresComment = SectionComments;
                        break;
                    case ProjectUpdate.ProjectUpdateSectionEnum.LocationSimple:
                        projectUpdateBatch.LocationSimpleComment = SectionComments;
                        break;
                    case ProjectUpdate.ProjectUpdateSectionEnum.LocationDetailed:
                        projectUpdateBatch.LocationDetailedComment = SectionComments;
                        break;
                    case ProjectUpdate.ProjectUpdateSectionEnum.Watershed:
                        projectUpdateBatch.WatershedComment = SectionComments;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
        }
    }
}
