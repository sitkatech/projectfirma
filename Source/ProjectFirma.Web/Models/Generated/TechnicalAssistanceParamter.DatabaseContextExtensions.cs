//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[TechnicalAssistanceParamter]
using System.Collections.Generic;
using System.Linq;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Models
{
    public static partial class DatabaseContextExtensions
    {
        public static TechnicalAssistanceParamter GetTechnicalAssistanceParamter(this IQueryable<TechnicalAssistanceParamter> technicalAssistanceParamters, int technicalAssistanceParamter)
        {
            var technicalAssistanceParamter = technicalAssistanceParamters.SingleOrDefault(x => x.TechnicalAssistanceParamter == technicalAssistanceParamter);
            Check.RequireNotNullThrowNotFound(technicalAssistanceParamter, "TechnicalAssistanceParamter", technicalAssistanceParamter);
            return technicalAssistanceParamter;
        }

        public static void DeleteTechnicalAssistanceParamter(this List<int> technicalAssistanceParamterList)
        {
            if(technicalAssistanceParamterList.Any())
            {
                HttpRequestStorage.DatabaseEntities.AllTechnicalAssistanceParamters.RemoveRange(HttpRequestStorage.DatabaseEntities.TechnicalAssistanceParamters.Where(x => technicalAssistanceParamterList.Contains(x.TechnicalAssistanceParamter)));
            }
        }

        public static void DeleteTechnicalAssistanceParamter(this ICollection<TechnicalAssistanceParamter> technicalAssistanceParamtersToDelete)
        {
            if(technicalAssistanceParamtersToDelete.Any())
            {
                HttpRequestStorage.DatabaseEntities.AllTechnicalAssistanceParamters.RemoveRange(technicalAssistanceParamtersToDelete);
            }
        }

        public static void DeleteTechnicalAssistanceParamter(this int technicalAssistanceParamter)
        {
            DeleteTechnicalAssistanceParamter(new List<int> { technicalAssistanceParamter });
        }

        public static void DeleteTechnicalAssistanceParamter(this TechnicalAssistanceParamter technicalAssistanceParamterToDelete)
        {
            DeleteTechnicalAssistanceParamter(new List<TechnicalAssistanceParamter> { technicalAssistanceParamterToDelete });
        }
    }
}