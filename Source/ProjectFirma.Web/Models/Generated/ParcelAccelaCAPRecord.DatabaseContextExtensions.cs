//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ParcelAccelaCAPRecord]
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
        public static ParcelAccelaCAPRecord GetParcelAccelaCAPRecord(this IQueryable<ParcelAccelaCAPRecord> parcelAccelaCAPRecords, int parcelAccelaCAPRecordID)
        {
            var parcelAccelaCAPRecord = parcelAccelaCAPRecords.SingleOrDefault(x => x.ParcelAccelaCAPRecordID == parcelAccelaCAPRecordID);
            Check.RequireNotNullThrowNotFound(parcelAccelaCAPRecord, "ParcelAccelaCAPRecord", parcelAccelaCAPRecordID);
            return parcelAccelaCAPRecord;
        }

        public static void DeleteParcelAccelaCAPRecord(this IQueryable<ParcelAccelaCAPRecord> parcelAccelaCAPRecords, List<int> parcelAccelaCAPRecordIDList)
        {
            if(parcelAccelaCAPRecordIDList.Any())
            {
                parcelAccelaCAPRecords.Where(x => parcelAccelaCAPRecordIDList.Contains(x.ParcelAccelaCAPRecordID)).Delete();
            }
        }

        public static void DeleteParcelAccelaCAPRecord(this IQueryable<ParcelAccelaCAPRecord> parcelAccelaCAPRecords, ICollection<ParcelAccelaCAPRecord> parcelAccelaCAPRecordsToDelete)
        {
            if(parcelAccelaCAPRecordsToDelete.Any())
            {
                var parcelAccelaCAPRecordIDList = parcelAccelaCAPRecordsToDelete.Select(x => x.ParcelAccelaCAPRecordID).ToList();
                parcelAccelaCAPRecords.Where(x => parcelAccelaCAPRecordIDList.Contains(x.ParcelAccelaCAPRecordID)).Delete();
            }
        }

        public static void DeleteParcelAccelaCAPRecord(this IQueryable<ParcelAccelaCAPRecord> parcelAccelaCAPRecords, int parcelAccelaCAPRecordID)
        {
            DeleteParcelAccelaCAPRecord(parcelAccelaCAPRecords, new List<int> { parcelAccelaCAPRecordID });
        }

        public static void DeleteParcelAccelaCAPRecord(this IQueryable<ParcelAccelaCAPRecord> parcelAccelaCAPRecords, ParcelAccelaCAPRecord parcelAccelaCAPRecordToDelete)
        {
            DeleteParcelAccelaCAPRecord(parcelAccelaCAPRecords, new List<ParcelAccelaCAPRecord> { parcelAccelaCAPRecordToDelete });
        }
    }
}