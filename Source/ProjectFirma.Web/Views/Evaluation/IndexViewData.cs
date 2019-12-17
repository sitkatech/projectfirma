/*-----------------------------------------------------------------------
<copyright file="IndexViewData.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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

using ProjectFirma.Web.Common;
using ProjectFirma.Web.Controllers;
using ProjectFirma.Web.Models;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Views.Evaluation
{
    public class IndexViewData : FirmaViewData
    {
        public MapInitJson MapInitJson { get; }
        public IndexGridSpec GridSpec { get; }
        public string GridName { get; }
        public string GridDataUrl { get; }

        public IndexViewData(FirmaSession currentFirmaSession, MapInitJson mapInitJson) : base(currentFirmaSession)
        {
            PageTitle = $"Evaluations";
            MapInitJson = mapInitJson;
            GridSpec = new IndexGridSpec(currentFirmaSession) {ObjectNameSingular = $"Evaluation", ObjectNamePlural = $"Evaluations", SaveFiltersInCookie = true};
            GridName = "evaluationsGrid";
            GridDataUrl = SitkaRoute<EvaluationController>.BuildUrlFromExpression(tc => tc.IndexGridJsonData());
        }
    }
}
