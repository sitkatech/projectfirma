﻿using System.Web;
using LtInfo.Common.AgGridWrappers;
using LtInfo.Common.Views;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Security;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Views.Evaluation
{
    public class EvaluationCriteriaGridSpec : GridSpec<EvaluationCriteria>
    {
        public EvaluationCriteriaGridSpec(FirmaSession currentFirmaSession)
        {
            Add("delete", ec => MakeDeleteIconAndLinkBootstrapIfAvailable(currentFirmaSession, ec), 30, AgGridColumnFilterType.None);
            Add("edit", ec => MakeEditIconAndLinkBootstrapIfAvailable(currentFirmaSession, ec), 30, AgGridColumnFilterType.None);

            Add("Name", a => a.EvaluationCriteriaName, 170, AgGridColumnFilterType.Text);
            Add("Definition", a => a.EvaluationCriteriaDefinition, 170, AgGridColumnFilterType.Text);
            Add("# of Criteria Values", a => a.GetNumberOfEvaluationCriteriaValues().ToString(), 70, AgGridColumnFilterType.SelectFilterStrict);

        }

        private static HtmlString MakeDeleteIconAndLinkBootstrapIfAvailable(FirmaSession currentFirmaSession, EvaluationCriteria evaluationCriteria)
        {
            if (EvaluationCriteriaManageFeature.HasEvaluationCriteriaManagePermission(currentFirmaSession, evaluationCriteria))
            {
                return AgGridHtmlHelpers.MakeDeleteIconAndLinkBootstrap(evaluationCriteria.GetDeleteUrl(), true, evaluationCriteria.CanDelete());
            }
            return new HtmlString(string.Empty);
        }

        private static HtmlString MakeEditIconAndLinkBootstrapIfAvailable(FirmaSession currentFirmaSession, EvaluationCriteria evaluationCriteria)
        {
            if (EvaluationManageFeature.HasEvaluationManagePermission(currentFirmaSession, evaluationCriteria.Evaluation))
            {
                string linkTitleText = $"Edit {FieldDefinitionEnum.EvaluationCriteria.ToType().GetFieldDefinitionLabel()} '{evaluationCriteria.EvaluationCriteriaName}'";
                string editDialogUrl = evaluationCriteria.GetEditUrl();
                return AgGridHtmlHelpers.MakeEditIconAsModalDialogLinkBootstrap(editDialogUrl, linkTitleText);
            }
            return new HtmlString(string.Empty);
        }
    }
}