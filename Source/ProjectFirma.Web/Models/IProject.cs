/*-----------------------------------------------------------------------
<copyright file="IProject.cs" company="Sitka Technology Group">
Copyright (c) Sitka Technology Group. All rights reserved.
<author>Sitka Technology Group</author>
<date>Wednesday, February 22, 2017</date>
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

namespace ProjectFirma.Web.Models
{
    public enum ProjectType
    {
        Project,
        ProjectUpdate,
        ProposedProject
    }

    public interface IProject
    {
        int EntityID { get; }
        DbGeometry ProjectLocationPoint { get; set; }
        string DisplayName { get; }
        int? ProjectLocationAreaID { get; set; }
        ProjectLocationSimpleType ProjectLocationSimpleType { get; }
        int ProjectLocationSimpleTypeID { get; set; }
        ProjectLocationArea ProjectLocationArea { get; }
        string ProjectLocationNotes { get; set; }

        int? PlanningDesignStartYear { get; }
        int? ImplementationStartYear { get; }
        int? CompletionYear { get; }

        ProjectStage ProjectStage { get; }
        FundingType FundingType { get; }

        decimal? EstimatedTotalCost { get; }
        decimal? EstimatedAnnualOperatingCost { get; }

        ProjectType ProjectType { get; }


        IEnumerable<IQuestionAnswer> GetQuestionAnswers();

        IEnumerable<IProjectLocation> GetProjectLocationDetails();

        GeoJSON.Net.Feature.FeatureCollection DetailedLocationToGeoJsonFeatureCollection();

        GeoJSON.Net.Feature.FeatureCollection SimpleLocationToGeoJsonFeatureCollection(bool addProjectProperties);

    }
}
