//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ParcelExistingPhysicalInventory]
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
        public static ParcelExistingPhysicalInventory GetParcelExistingPhysicalInventory(this IQueryable<ParcelExistingPhysicalInventory> parcelExistingPhysicalInventories, int parcelExistingPhysicalInventoryID)
        {
            var parcelExistingPhysicalInventory = parcelExistingPhysicalInventories.SingleOrDefault(x => x.ParcelExistingPhysicalInventoryID == parcelExistingPhysicalInventoryID);
            Check.RequireNotNullThrowNotFound(parcelExistingPhysicalInventory, "ParcelExistingPhysicalInventory", parcelExistingPhysicalInventoryID);
            return parcelExistingPhysicalInventory;
        }

        public static void DeleteParcelExistingPhysicalInventory(this IQueryable<ParcelExistingPhysicalInventory> parcelExistingPhysicalInventories, List<int> parcelExistingPhysicalInventoryIDList)
        {
            if(parcelExistingPhysicalInventoryIDList.Any())
            {
                parcelExistingPhysicalInventories.Where(x => parcelExistingPhysicalInventoryIDList.Contains(x.ParcelExistingPhysicalInventoryID)).Delete();
            }
        }

        public static void DeleteParcelExistingPhysicalInventory(this IQueryable<ParcelExistingPhysicalInventory> parcelExistingPhysicalInventories, ICollection<ParcelExistingPhysicalInventory> parcelExistingPhysicalInventoriesToDelete)
        {
            if(parcelExistingPhysicalInventoriesToDelete.Any())
            {
                var parcelExistingPhysicalInventoryIDList = parcelExistingPhysicalInventoriesToDelete.Select(x => x.ParcelExistingPhysicalInventoryID).ToList();
                parcelExistingPhysicalInventories.Where(x => parcelExistingPhysicalInventoryIDList.Contains(x.ParcelExistingPhysicalInventoryID)).Delete();
            }
        }

        public static void DeleteParcelExistingPhysicalInventory(this IQueryable<ParcelExistingPhysicalInventory> parcelExistingPhysicalInventories, int parcelExistingPhysicalInventoryID)
        {
            DeleteParcelExistingPhysicalInventory(parcelExistingPhysicalInventories, new List<int> { parcelExistingPhysicalInventoryID });
        }

        public static void DeleteParcelExistingPhysicalInventory(this IQueryable<ParcelExistingPhysicalInventory> parcelExistingPhysicalInventories, ParcelExistingPhysicalInventory parcelExistingPhysicalInventoryToDelete)
        {
            DeleteParcelExistingPhysicalInventory(parcelExistingPhysicalInventories, new List<ParcelExistingPhysicalInventory> { parcelExistingPhysicalInventoryToDelete });
        }
    }
}