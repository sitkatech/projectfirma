//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[TechnicalAssistanceParameter]
using System.Collections.Generic;
using System.Linq;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Models
{
    public static partial class DatabaseContextExtensions
    {
        public static TechnicalAssistanceParameter GetTechnicalAssistanceParameter(this IQueryable<TechnicalAssistanceParameter> technicalAssistanceParameters, int technicalAssistanceParameterID)
        {
            var technicalAssistanceParameter = technicalAssistanceParameters.SingleOrDefault(x => x.TechnicalAssistanceParameterID == technicalAssistanceParameterID);
            Check.RequireNotNullThrowNotFound(technicalAssistanceParameter, "TechnicalAssistanceParameter", technicalAssistanceParameterID);
            return technicalAssistanceParameter;
        }

        public static void DeleteTechnicalAssistanceParameter(this List<int> technicalAssistanceParameterIDList)
        {
            if(technicalAssistanceParameterIDList.Any())
            {
                HttpRequestStorage.DatabaseEntities.AllTechnicalAssistanceParameters.RemoveRange(HttpRequestStorage.DatabaseEntities.TechnicalAssistanceParameters.Where(x => technicalAssistanceParameterIDList.Contains(x.TechnicalAssistanceParameterID)));
            }
        }

        public static void DeleteTechnicalAssistanceParameter(this ICollection<TechnicalAssistanceParameter> technicalAssistanceParametersToDelete)
        {
            if(technicalAssistanceParametersToDelete.Any())
            {
                HttpRequestStorage.DatabaseEntities.AllTechnicalAssistanceParameters.RemoveRange(technicalAssistanceParametersToDelete);
            }
        }

        public static void DeleteTechnicalAssistanceParameter(this int technicalAssistanceParameterID)
        {
            DeleteTechnicalAssistanceParameter(new List<int> { technicalAssistanceParameterID });
        }

        public static void DeleteTechnicalAssistanceParameter(this TechnicalAssistanceParameter technicalAssistanceParameterToDelete)
        {
            DeleteTechnicalAssistanceParameter(new List<TechnicalAssistanceParameter> { technicalAssistanceParameterToDelete });
        }
    }
}