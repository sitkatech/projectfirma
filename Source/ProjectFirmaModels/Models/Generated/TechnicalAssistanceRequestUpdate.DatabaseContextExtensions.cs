//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[TechnicalAssistanceRequestUpdate]
using System.Collections.Generic;
using System.Linq;
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public static partial class DatabaseContextExtensions
    {
        public static TechnicalAssistanceRequestUpdate GetTechnicalAssistanceRequestUpdate(this IQueryable<TechnicalAssistanceRequestUpdate> technicalAssistanceRequestUpdates, int technicalAssistanceRequestUpdateID)
        {
            var technicalAssistanceRequestUpdate = technicalAssistanceRequestUpdates.SingleOrDefault(x => x.TechnicalAssistanceRequestUpdateID == technicalAssistanceRequestUpdateID);
            Check.RequireNotNullThrowNotFound(technicalAssistanceRequestUpdate, "TechnicalAssistanceRequestUpdate", technicalAssistanceRequestUpdateID);
            return technicalAssistanceRequestUpdate;
        }

    }
}