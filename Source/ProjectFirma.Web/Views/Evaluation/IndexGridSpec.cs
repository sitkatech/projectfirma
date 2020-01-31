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

using System.Web;
using LtInfo.Common;
using LtInfo.Common.DhtmlWrappers;
using LtInfo.Common.Views;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Security;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Views.Evaluation
{
    public class IndexGridSpec : GridSpec<ProjectFirmaModels.Models.Evaluation>
    {
        public IndexGridSpec(FirmaSession currentFirmaSession)
        {
            Add(string.Empty, e => MakeDeleteIconAndLinkBootstrapIfAvailable(currentFirmaSession, e), 30, DhtmlxGridColumnFilterType.None);
            Add(FieldDefinitionEnum.EvaluationName.ToType().ToGridHeaderString(), a => MakeNameLinkToDetailIfAvailable(currentFirmaSession, a), 210, DhtmlxGridColumnFilterType.Html);
            Add(FieldDefinitionEnum.EvaluationDefinition.ToType().ToGridHeaderString(), a => a.EvaluationDefinition, 210, DhtmlxGridColumnFilterType.Text);
            Add(FieldDefinitionEnum.EvaluationStatus.ToType().ToGridHeaderString(), a => a.GetEvaluationStatusDisplayName(), 80, DhtmlxGridColumnFilterType.SelectFilterStrict);
            Add(FieldDefinitionEnum.EvaluationStartDate.ToType().ToGridHeaderString(), a => a.EvaluationStartDate.HasValue ? a.EvaluationStartDate.ToStringDate() : "not set", 80);
            Add(FieldDefinitionEnum.EvaluationEndDate.ToType().ToGridHeaderString(), a => a.EvaluationEndDate.HasValue ? a.EvaluationEndDate.ToStringDate() : "not set", 80);
            Add(FieldDefinitionEnum.EvaluationCriteria.ToType().ToGridHeaderString(), a => a.GetEvaluationCriteriaNamesAsCommaDelimitedString(), 200, DhtmlxGridColumnFilterType.Text);
            Add(FieldDefinitionEnum.EvaluationVisibility.ToType().ToGridHeaderString(), a => a.GetEvaluationVisibilityDisplayName(), 200, DhtmlxGridColumnFilterType.SelectFilterStrict);
        }

        private static HtmlString MakeNameLinkToDetailIfAvailable(FirmaSession currentFirmaSession,  ProjectFirmaModels.Models.Evaluation evaluation)
        {
            if (EvaluationManageFeature.HasEvaluationManagePermission(currentFirmaSession, evaluation))
            {
                return UrlTemplate.MakeHrefString(evaluation.GetDetailUrl(), evaluation.EvaluationName);
            }
            return new HtmlString(evaluation.EvaluationName);
            
        }

        private static HtmlString MakeDeleteIconAndLinkBootstrapIfAvailable(FirmaSession currentFirmaSession, ProjectFirmaModels.Models.Evaluation evaluation)
        {
            if (EvaluationManageFeature.HasEvaluationManagePermission(currentFirmaSession, evaluation))
            {
                return DhtmlxGridHtmlHelpers.MakeDeleteIconAndLinkBootstrap(evaluation.GetDeleteUrl(), true, evaluation.CanDelete());
            }
            return new HtmlString(string.Empty);
        }
    }
}
