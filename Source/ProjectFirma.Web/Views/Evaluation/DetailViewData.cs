/*-----------------------------------------------------------------------
<copyright file="DetailViewData.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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
using ProjectFirma.Web.Security;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Views.Evaluation
{
    public class DetailViewData : FirmaViewData
    {
        public ProjectFirmaModels.Models.Evaluation Evaluation { get; }

        public bool UserHasEvaluationManagePermissions { get; }
        public string IndexUrl { get; }
        public string EditEvaluationUrl { get; }
        public EvaluationCriteriaGridSpec EvaluationCriteriaGridSpec { get; }
        public string EvaluationCriteriaGridName { get; }
        public string EvaluationCriteriaGridDataUrl { get; }
        public string NewEvaluationCriteriaUrl { get; set; }
        public string AddProjectEvaluationUrl { get; set; }

        public EvaluationPortfolioGridSpec EvaluationPortfolioGridSpec { get; }
        public string EvaluationPortfolioGridName { get; }
        public string EvaluationPortfolioGridDataUrl { get; }


        public DetailViewData(FirmaSession currentFirmaSession, ProjectFirmaModels.Models.Evaluation evaluation) : base(currentFirmaSession)
        {
            Evaluation = evaluation;
            PageTitle = evaluation.EvaluationName;

            UserHasEvaluationManagePermissions = new FirmaAdminFeature().HasPermissionByFirmaSession(currentFirmaSession);
            IndexUrl = SitkaRoute<EvaluationController>.BuildUrlFromExpression(x => x.Index());
            EditEvaluationUrl = evaluation.GetEditUrl();

            EvaluationCriteriaGridSpec = new EvaluationCriteriaGridSpec(currentFirmaSession) { ObjectNameSingular = FieldDefinitionEnum.Evaluation.ToType().GetFieldDefinitionLabel(), ObjectNamePlural = FieldDefinitionEnum.Evaluation.ToType().GetFieldDefinitionLabelPluralized(), SaveFiltersInCookie = true };
            EvaluationCriteriaGridName = "evaluationCriteriaGrid";
            EvaluationCriteriaGridDataUrl = SitkaRoute<EvaluationController>.BuildUrlFromExpression(tc => tc.EvaluationCriteriaGridJsonData(evaluation.EvaluationID));

            NewEvaluationCriteriaUrl = SitkaRoute<EvaluationController>.BuildUrlFromExpression(tc => tc.NewEvaluationCriteria(evaluation));

            AddProjectEvaluationUrl = SitkaRoute<EvaluationController>.BuildUrlFromExpression(ec => ec.AddProjectEvaluation(evaluation));

            EvaluationPortfolioGridSpec = new EvaluationPortfolioGridSpec(currentFirmaSession, evaluation) { ObjectNameSingular = FieldDefinitionEnum.EvaluationPortfolio.ToType().GetFieldDefinitionLabel(), ObjectNamePlural = FieldDefinitionEnum.EvaluationPortfolio.ToType().GetFieldDefinitionLabelPluralized(), SaveFiltersInCookie = true };
            EvaluationPortfolioGridName = "evaluationPortfolioGrid";
            EvaluationPortfolioGridDataUrl = SitkaRoute<EvaluationController>.BuildUrlFromExpression(tc => tc.EvaluationPortfolioGridJsonData(evaluation.EvaluationID));
        }

        
    }
}
