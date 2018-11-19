//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[TreatmentActivity]
using System.Collections.Generic;
using System.Linq;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Models
{
    public static partial class DatabaseContextExtensions
    {
        public static TreatmentActivity GetTreatmentActivity(this IQueryable<TreatmentActivity> treatmentActivities, int treatmentActivityID)
        {
            var treatmentActivity = treatmentActivities.SingleOrDefault(x => x.TreatmentActivityID == treatmentActivityID);
            Check.RequireNotNullThrowNotFound(treatmentActivity, "TreatmentActivity", treatmentActivityID);
            return treatmentActivity;
        }

        public static void DeleteTreatmentActivity(this List<int> treatmentActivityIDList)
        {
            if(treatmentActivityIDList.Any())
            {
                HttpRequestStorage.DatabaseEntities.AllTreatmentActivities.RemoveRange(HttpRequestStorage.DatabaseEntities.TreatmentActivities.Where(x => treatmentActivityIDList.Contains(x.TreatmentActivityID)));
            }
        }

        public static void DeleteTreatmentActivity(this ICollection<TreatmentActivity> treatmentActivitiesToDelete)
        {
            if(treatmentActivitiesToDelete.Any())
            {
                HttpRequestStorage.DatabaseEntities.AllTreatmentActivities.RemoveRange(treatmentActivitiesToDelete);
            }
        }

        public static void DeleteTreatmentActivity(this int treatmentActivityID)
        {
            DeleteTreatmentActivity(new List<int> { treatmentActivityID });
        }

        public static void DeleteTreatmentActivity(this TreatmentActivity treatmentActivityToDelete)
        {
            DeleteTreatmentActivity(new List<TreatmentActivity> { treatmentActivityToDelete });
        }
    }
}