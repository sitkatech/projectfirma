//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[TechnicalAssistanceParameter]
using System.Collections.Generic;
using System.Linq;
using CodeFirstStoreFunctions;
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public static partial class DatabaseContextExtensions
    {
        public static TechnicalAssistanceParameter GetTechnicalAssistanceParameter(this IQueryable<TechnicalAssistanceParameter> technicalAssistanceParameters, int technicalAssistanceParameterID)
        {
            var technicalAssistanceParameter = technicalAssistanceParameters.SingleOrDefault(x => x.TechnicalAssistanceParameterID == technicalAssistanceParameterID);
            Check.RequireNotNullThrowNotFound(technicalAssistanceParameter, "TechnicalAssistanceParameter", technicalAssistanceParameterID);
            return technicalAssistanceParameter;
        }

    }
}