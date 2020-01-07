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
        public EvaluationCriterionGridSpec EvaluationCriterionGridSpec { get; }
        public string EvaluationCriterionGridName { get; }
        public string EvaluationCriterionGridDataUrl { get; }
        public string NewEvaluationCriterionUrl { get; set; }
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

            EvaluationCriterionGridSpec = new EvaluationCriterionGridSpec(currentFirmaSession) { ObjectNameSingular = FieldDefinitionEnum.Evaluation.ToType().GetFieldDefinitionLabel(), ObjectNamePlural = FieldDefinitionEnum.Evaluation.ToType().GetFieldDefinitionLabelPluralized(), SaveFiltersInCookie = true };
            EvaluationCriterionGridName = "evaluationCriteriaGrid";
            EvaluationCriterionGridDataUrl = SitkaRoute<EvaluationController>.BuildUrlFromExpression(tc => tc.EvaluationCriterionGridJsonData(evaluation.EvaluationID));

            NewEvaluationCriterionUrl = SitkaRoute<EvaluationController>.BuildUrlFromExpression(tc => tc.NewEvaluationCriterion(evaluation));

            AddProjectEvaluationUrl = SitkaRoute<EvaluationController>.BuildUrlFromExpression(ec => ec.AddProjectEvaluation(evaluation));

            EvaluationPortfolioGridSpec = new EvaluationPortfolioGridSpec(currentFirmaSession, evaluation) { ObjectNameSingular = FieldDefinitionEnum.EvaluationPortfolio.ToType().GetFieldDefinitionLabel(), ObjectNamePlural = FieldDefinitionEnum.EvaluationPortfolio.ToType().GetFieldDefinitionLabelPluralized(), SaveFiltersInCookie = true };
            EvaluationPortfolioGridName = "evaluationPortfolioGrid";
            EvaluationPortfolioGridDataUrl = SitkaRoute<EvaluationController>.BuildUrlFromExpression(tc => tc.EvaluationPortfolioGridJsonData(evaluation.EvaluationID));
        }

        
    }
}
