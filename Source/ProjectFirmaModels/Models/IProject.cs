/*-----------------------------------------------------------------------
<copyright file="IProject.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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
using System.Data.Entity.Spatial;

namespace ProjectFirmaModels.Models
{
    public interface IProject
    {
        int GetEntityID();
        DbGeometry ProjectLocationPoint { get; set; }
        string GetDisplayName();
        ProjectLocationSimpleType ProjectLocationSimpleType { get; }
        int ProjectLocationSimpleTypeID { get; set; }
        string ProjectLocationNotes { get; set; }

        int? PlanningDesignStartYear { get; }
        int? ImplementationStartYear { get; }
        int? CompletionYear { get; }

        ProjectStage ProjectStage { get; }
        FundingType FundingType { get; }

        decimal? GetEstimatedTotalRegardlessOfFundingType();
        IEnumerable<IProjectCustomAttribute> GetProjectCustomAttributes();

        IEnumerable<IQuestionAnswer> GetQuestionAnswers();

        IEnumerable<IProjectLocation> GetProjectLocationDetails();
        DbGeometry GetDefaultBoundingBox();
        IEnumerable<GeospatialArea> GetProjectGeospatialAreas();
    }
}
