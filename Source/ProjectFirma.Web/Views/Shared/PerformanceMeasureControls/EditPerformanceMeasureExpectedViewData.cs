/*-----------------------------------------------------------------------
<copyright file="EditPerformanceMeasureExpectedViewData.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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
using System.Collections.Generic;
using System.Linq;
using LtInfo.Common.Models;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Security;
using ProjectFirmaModels.Models;
using ProjectFirma.Web.Views.Shared.SortOrder;
using PerformanceMeasureSubcategoryOptionSimple = ProjectFirma.Web.Models.PerformanceMeasureSubcategoryOptionSimple;

namespace ProjectFirma.Web.Views.Shared.PerformanceMeasureControls
{
    public class EditPerformanceMeasureExpectedViewData : FirmaUserControlViewData
    {
        public readonly List<PerformanceMeasureSimple> AllPerformanceMeasures;
        public readonly List<PerformanceMeasureSubcategorySimple> AllPerformanceMeasureSubcategories;
        public readonly List<PerformanceMeasureSubcategoryOptionSimple> AllPerformanceMeasureSubcategoryOptions;
        public readonly List<ProjectSimple> AllProjects;
        public readonly int? ProjectID;
        public readonly bool UsePanelLayout;

        public string ConfigurePerformanceMeasuresUrl { get; }

        public EditPerformanceMeasureExpectedViewData(List<ProjectSimple> allProjects, List<ProjectFirmaModels.Models.PerformanceMeasure> allPerformanceMeasures, int projectID, bool usePanelLayout, string configurePerformanceMeasuresUrl)
        {
            ProjectID = projectID;
            AllPerformanceMeasures = allPerformanceMeasures.SortByOrderThenName().Select(x => new PerformanceMeasureSimple(x)).ToList();
            var performanceMeasureSubcategories =
                allPerformanceMeasures.SelectMany(x => x.PerformanceMeasureSubcategories).Distinct(new HavePrimaryKeyComparer<PerformanceMeasureSubcategory>()).ToList();
            AllPerformanceMeasureSubcategories = performanceMeasureSubcategories.Select(x => new PerformanceMeasureSubcategorySimple(x)).ToList();
            AllPerformanceMeasureSubcategoryOptions = performanceMeasureSubcategories.SelectMany(y => y.PerformanceMeasureSubcategoryOptions.Select(z => new PerformanceMeasureSubcategoryOptionSimple(z))).ToList();
            AllProjects = allProjects;
            UsePanelLayout = usePanelLayout;
            ConfigurePerformanceMeasuresUrl = configurePerformanceMeasuresUrl;
        }

        public EditPerformanceMeasureExpectedViewData(ProjectFirmaModels.Models.Project project, List<ProjectFirmaModels.Models.PerformanceMeasure> allPerformanceMeasures, string configurePerformanceMeasuresUrl)
            : this(new List<ProjectSimple> { new ProjectSimple(project)}, allPerformanceMeasures, project.ProjectID, true, configurePerformanceMeasuresUrl)
        {
        }
    }
}
