//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[AccelaCAPRecord]
using System.Collections.Generic;
using System.Linq;
using EntityFramework.Extensions;
using ProjectFirma.Web.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirma.Web.Models
{
    public static partial class DatabaseContextExtensions
    {
        public static AccelaCAPRecord GetAccelaCAPRecord(this IQueryable<AccelaCAPRecord> accelaCAPRecords, int accelaCAPRecordID)
        {
            var accelaCAPRecord = accelaCAPRecords.SingleOrDefault(x => x.AccelaCAPRecordID == accelaCAPRecordID);
            Check.RequireNotNullThrowNotFound(accelaCAPRecord, "AccelaCAPRecord", accelaCAPRecordID);
            return accelaCAPRecord;
        }

        public static void DeleteAccelaCAPRecord(this IQueryable<AccelaCAPRecord> accelaCAPRecords, List<int> accelaCAPRecordIDList)
        {
            if(accelaCAPRecordIDList.Any())
            {
                accelaCAPRecords.Where(x => accelaCAPRecordIDList.Contains(x.AccelaCAPRecordID)).Delete();
            }
        }

        public static void DeleteAccelaCAPRecord(this IQueryable<AccelaCAPRecord> accelaCAPRecords, ICollection<AccelaCAPRecord> accelaCAPRecordsToDelete)
        {
            if(accelaCAPRecordsToDelete.Any())
            {
                var accelaCAPRecordIDList = accelaCAPRecordsToDelete.Select(x => x.AccelaCAPRecordID).ToList();
                accelaCAPRecords.Where(x => accelaCAPRecordIDList.Contains(x.AccelaCAPRecordID)).Delete();
            }
        }

        public static void DeleteAccelaCAPRecord(this IQueryable<AccelaCAPRecord> accelaCAPRecords, int accelaCAPRecordID)
        {
            DeleteAccelaCAPRecord(accelaCAPRecords, new List<int> { accelaCAPRecordID });
        }

        public static void DeleteAccelaCAPRecord(this IQueryable<AccelaCAPRecord> accelaCAPRecords, AccelaCAPRecord accelaCAPRecordToDelete)
        {
            DeleteAccelaCAPRecord(accelaCAPRecords, new List<AccelaCAPRecord> { accelaCAPRecordToDelete });
        }
    }
}