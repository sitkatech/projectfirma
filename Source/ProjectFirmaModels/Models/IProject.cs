/*-----------------------------------------------------------------------
<copyright file="IProject.cs" company="Tahoe Regional Planning Agency and Environmental Science Associates">
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
using System.Collections.Generic;
using System.Data.Entity.Spatial;

namespace ProjectFirmaModels.Models
{
    public interface IProject
    {
        int GetEntityID();
        Project GetProject();
        bool HasProjectLocationPoint(bool includePrivateLocation);
        // Only use ProjectLocationPoint to updated project location
        DbGeometry ProjectLocationPoint { get; set; }
        DbGeometry GetProjectLocationPoint(bool showLocationIfPrivate);
        bool HasProjectLocationDetailed(bool includePrivateLocation);

        IEnumerable<IProjectLocation> GetProjectLocationDetailed(bool showLocationIfPrivate);

        string GetDisplayName();
        ProjectLocationSimpleType ProjectLocationSimpleType { get; }
        int ProjectLocationSimpleTypeID { get; set; }
        string ProjectLocationNotes { get; set; }

        int? PlanningDesignStartYear { get; }
        int? ImplementationStartYear { get; }
        int? CompletionYear { get; }
        int ProjectCategoryID { get; }

        ProjectStage ProjectStage { get; }
        FundingType FundingType { get; }

        decimal? GetEstimatedTotalRegardlessOfFundingType();
        IEnumerable<IProjectCustomAttribute> GetProjectCustomAttributes();

        IEnumerable<IQuestionAnswer> GetQuestionAnswers();

        DbGeometry GetDefaultBoundingBox();
        IEnumerable<GeospatialArea> GetProjectGeospatialAreas();
        decimal GetTargetedFunding();
        decimal GetSecuredFunding();
        decimal GetNoFundingSourceIdentifiedAmountOrZero();

        int ProjectOrProjectUpdateID { get; }

        bool IsProject { get; }
        bool IsProjectUpdate { get; }
        bool LocationIsPrivate { get; set; }
    }
}
