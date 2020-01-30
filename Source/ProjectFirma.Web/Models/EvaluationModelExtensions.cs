using System.Collections.Generic;
using System.Linq;
using System.Web;
using LtInfo.Common;
using NUnit.Framework;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Controllers;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Models
{
    public static class EvaluationModelExtensions
    {
        public static readonly UrlTemplate<int> EditUrlTemplate = new UrlTemplate<int>(SitkaRoute<EvaluationController>.BuildUrlFromExpression(t => t.Edit(UrlTemplate.Parameter1Int)));
        public static string GetEditUrl(this Evaluation evaluation)
        {
            return EditUrlTemplate.ParameterReplace(evaluation.EvaluationID);
        }

        public static readonly UrlTemplate<int> DetailUrlTemplate = new UrlTemplate<int>(SitkaRoute<EvaluationController>.BuildUrlFromExpression(t => t.Detail(UrlTemplate.Parameter1Int)));
        public static string GetDetailUrl(this Evaluation evaluation)
        {
            return DetailUrlTemplate.ParameterReplace(evaluation.EvaluationID);
        }

        public static readonly UrlTemplate<int> DeleteUrlTemplate = new UrlTemplate<int>(SitkaRoute<EvaluationController>.BuildUrlFromExpression(t => t.Delete(UrlTemplate.Parameter1Int)));
        public static string GetDeleteUrl(this Evaluation evaluation)
        {
            return DeleteUrlTemplate.ParameterReplace(evaluation.EvaluationID);
        }
        

        public static string GetEvaluationStatusDisplayName(this Evaluation evaluation)
        {
            return evaluation.EvaluationStatus.EvaluationStatusDisplayName;
        }

        public static string GetEvaluationVisibilityDisplayName(this Evaluation evaluation)
        {
            switch ((EvaluationVisibilityEnum) evaluation.EvaluationVisibilityID)
            {
                case EvaluationVisibilityEnum.AdminsFromMyOrganizationOnly:
                    return $"{evaluation.CreatePerson.Organization.GetDisplayName()} Admins";
                case EvaluationVisibilityEnum.OnlyMe:
                    return $"Only {evaluation.CreatePerson.GetFullNameFirstLast()}";
                default:
                    return evaluation.EvaluationVisibility.EvaluationVisibilityDisplayName;
            }
        }

        public static string GetEvaluationCriteriaNamesAsCommaDelimitedString(this Evaluation evaluation)
        {
            List<string> evaluationCriteriaNames = evaluation.EvaluationCriterias.Select(x => x.EvaluationCriteriaName).ToList();
            return string.Join(", ", evaluationCriteriaNames);
        }

    }
}