//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[Parcel]
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
        public static Parcel GetParcel(this IQueryable<Parcel> parcels, int parcelID)
        {
            var parcel = parcels.SingleOrDefault(x => x.ParcelID == parcelID);
            Check.RequireNotNullThrowNotFound(parcel, "Parcel", parcelID);
            return parcel;
        }

        public static void DeleteParcel(this IQueryable<Parcel> parcels, List<int> parcelIDList)
        {
            if(parcelIDList.Any())
            {
                parcels.Where(x => parcelIDList.Contains(x.ParcelID)).Delete();
            }
        }

        public static void DeleteParcel(this IQueryable<Parcel> parcels, ICollection<Parcel> parcelsToDelete)
        {
            if(parcelsToDelete.Any())
            {
                var parcelIDList = parcelsToDelete.Select(x => x.ParcelID).ToList();
                parcels.Where(x => parcelIDList.Contains(x.ParcelID)).Delete();
            }
        }

        public static void DeleteParcel(this IQueryable<Parcel> parcels, int parcelID)
        {
            DeleteParcel(parcels, new List<int> { parcelID });
        }

        public static void DeleteParcel(this IQueryable<Parcel> parcels, Parcel parcelToDelete)
        {
            DeleteParcel(parcels, new List<Parcel> { parcelToDelete });
        }
    }
}