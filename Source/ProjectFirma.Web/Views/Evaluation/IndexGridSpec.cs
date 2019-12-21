/*-----------------------------------------------------------------------
<copyright file="IndexGridSpec.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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

using LtInfo.Common;
using LtInfo.Common.DhtmlWrappers;
using LtInfo.Common.Views;
using ProjectFirma.Web.Models;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Views.Evaluation
{
    public class IndexGridSpec : GridSpec<ProjectFirmaModels.Models.Evaluation>
    {
        public IndexGridSpec(FirmaSession currentFirmaSession)
        {

            Add("Name", a => UrlTemplate.MakeHrefString(a.GetDetailUrl(), a.EvaluationName), 300, DhtmlxGridColumnFilterType.Html);
            Add("Definition", a => a.EvaluationDefinition, 65, DhtmlxGridColumnFilterType.Text);
            Add("Status", a => a.GetEvaluationStatusDisplayName(), 65, DhtmlxGridColumnFilterType.SelectFilterStrict);
            Add("Start Date", a => a.EvaluationStartDate.HasValue ? a.EvaluationStartDate.ToStringDate() : "not set", 65);
            Add("End Date", a => a.EvaluationEndDate.HasValue ? a.EvaluationEndDate.ToStringDate() : "not set", 65);
            Add("Criteria", a => a.GetEvaluationCriteriaNamesAsCommaDelimitedString(), 65, DhtmlxGridColumnFilterType.Text);
            Add("Visibility", a => a.GetEvaluationVisibilityDisplayName(), 65, DhtmlxGridColumnFilterType.SelectFilterStrict);
        }
    }
}
