//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[TrainingVideoRole]
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
        public static TrainingVideoRole GetTrainingVideoRole(this IQueryable<TrainingVideoRole> trainingVideoRoles, int trainingVideoRoleID)
        {
            var trainingVideoRole = trainingVideoRoles.SingleOrDefault(x => x.TrainingVideoRoleID == trainingVideoRoleID);
            Check.RequireNotNullThrowNotFound(trainingVideoRole, "TrainingVideoRole", trainingVideoRoleID);
            return trainingVideoRole;
        }

    }
}