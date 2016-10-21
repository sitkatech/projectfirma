//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ParcelGeometry]
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
        public static ParcelGeometry GetParcelGeometry(this IQueryable<ParcelGeometry> parcelGeometries, int parcelGeometryID)
        {
            var parcelGeometry = parcelGeometries.SingleOrDefault(x => x.ParcelGeometryID == parcelGeometryID);
            Check.RequireNotNullThrowNotFound(parcelGeometry, "ParcelGeometry", parcelGeometryID);
            return parcelGeometry;
        }

        public static void DeleteParcelGeometry(this IQueryable<ParcelGeometry> parcelGeometries, List<int> parcelGeometryIDList)
        {
            if(parcelGeometryIDList.Any())
            {
                parcelGeometries.Where(x => parcelGeometryIDList.Contains(x.ParcelGeometryID)).Delete();
            }
        }

        public static void DeleteParcelGeometry(this IQueryable<ParcelGeometry> parcelGeometries, ICollection<ParcelGeometry> parcelGeometriesToDelete)
        {
            if(parcelGeometriesToDelete.Any())
            {
                var parcelGeometryIDList = parcelGeometriesToDelete.Select(x => x.ParcelGeometryID).ToList();
                parcelGeometries.Where(x => parcelGeometryIDList.Contains(x.ParcelGeometryID)).Delete();
            }
        }

        public static void DeleteParcelGeometry(this IQueryable<ParcelGeometry> parcelGeometries, int parcelGeometryID)
        {
            DeleteParcelGeometry(parcelGeometries, new List<int> { parcelGeometryID });
        }

        public static void DeleteParcelGeometry(this IQueryable<ParcelGeometry> parcelGeometries, ParcelGeometry parcelGeometryToDelete)
        {
            DeleteParcelGeometry(parcelGeometries, new List<ParcelGeometry> { parcelGeometryToDelete });
        }
    }
}