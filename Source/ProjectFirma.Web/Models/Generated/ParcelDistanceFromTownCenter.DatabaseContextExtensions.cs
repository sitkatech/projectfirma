//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ParcelDistanceFromTownCenter]
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
        public static ParcelDistanceFromTownCenter GetParcelDistanceFromTownCenter(this IQueryable<ParcelDistanceFromTownCenter> parcelDistanceFromTownCenters, int parcelDistanceFromTownCenterID)
        {
            var parcelDistanceFromTownCenter = parcelDistanceFromTownCenters.SingleOrDefault(x => x.ParcelDistanceFromTownCenterID == parcelDistanceFromTownCenterID);
            Check.RequireNotNullThrowNotFound(parcelDistanceFromTownCenter, "ParcelDistanceFromTownCenter", parcelDistanceFromTownCenterID);
            return parcelDistanceFromTownCenter;
        }

        public static void DeleteParcelDistanceFromTownCenter(this IQueryable<ParcelDistanceFromTownCenter> parcelDistanceFromTownCenters, List<int> parcelDistanceFromTownCenterIDList)
        {
            if(parcelDistanceFromTownCenterIDList.Any())
            {
                parcelDistanceFromTownCenters.Where(x => parcelDistanceFromTownCenterIDList.Contains(x.ParcelDistanceFromTownCenterID)).Delete();
            }
        }

        public static void DeleteParcelDistanceFromTownCenter(this IQueryable<ParcelDistanceFromTownCenter> parcelDistanceFromTownCenters, ICollection<ParcelDistanceFromTownCenter> parcelDistanceFromTownCentersToDelete)
        {
            if(parcelDistanceFromTownCentersToDelete.Any())
            {
                var parcelDistanceFromTownCenterIDList = parcelDistanceFromTownCentersToDelete.Select(x => x.ParcelDistanceFromTownCenterID).ToList();
                parcelDistanceFromTownCenters.Where(x => parcelDistanceFromTownCenterIDList.Contains(x.ParcelDistanceFromTownCenterID)).Delete();
            }
        }

        public static void DeleteParcelDistanceFromTownCenter(this IQueryable<ParcelDistanceFromTownCenter> parcelDistanceFromTownCenters, int parcelDistanceFromTownCenterID)
        {
            DeleteParcelDistanceFromTownCenter(parcelDistanceFromTownCenters, new List<int> { parcelDistanceFromTownCenterID });
        }

        public static void DeleteParcelDistanceFromTownCenter(this IQueryable<ParcelDistanceFromTownCenter> parcelDistanceFromTownCenters, ParcelDistanceFromTownCenter parcelDistanceFromTownCenterToDelete)
        {
            DeleteParcelDistanceFromTownCenter(parcelDistanceFromTownCenters, new List<ParcelDistanceFromTownCenter> { parcelDistanceFromTownCenterToDelete });
        }
    }
}