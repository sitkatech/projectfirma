//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ParcelLandCapability]
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
        public static ParcelLandCapability GetParcelLandCapability(this IQueryable<ParcelLandCapability> parcelLandCapabilities, int parcelLandCapabilityID)
        {
            var parcelLandCapability = parcelLandCapabilities.SingleOrDefault(x => x.ParcelLandCapabilityID == parcelLandCapabilityID);
            Check.RequireNotNullThrowNotFound(parcelLandCapability, "ParcelLandCapability", parcelLandCapabilityID);
            return parcelLandCapability;
        }

        public static void DeleteParcelLandCapability(this IQueryable<ParcelLandCapability> parcelLandCapabilities, List<int> parcelLandCapabilityIDList)
        {
            if(parcelLandCapabilityIDList.Any())
            {
                parcelLandCapabilities.Where(x => parcelLandCapabilityIDList.Contains(x.ParcelLandCapabilityID)).Delete();
            }
        }

        public static void DeleteParcelLandCapability(this IQueryable<ParcelLandCapability> parcelLandCapabilities, ICollection<ParcelLandCapability> parcelLandCapabilitiesToDelete)
        {
            if(parcelLandCapabilitiesToDelete.Any())
            {
                var parcelLandCapabilityIDList = parcelLandCapabilitiesToDelete.Select(x => x.ParcelLandCapabilityID).ToList();
                parcelLandCapabilities.Where(x => parcelLandCapabilityIDList.Contains(x.ParcelLandCapabilityID)).Delete();
            }
        }

        public static void DeleteParcelLandCapability(this IQueryable<ParcelLandCapability> parcelLandCapabilities, int parcelLandCapabilityID)
        {
            DeleteParcelLandCapability(parcelLandCapabilities, new List<int> { parcelLandCapabilityID });
        }

        public static void DeleteParcelLandCapability(this IQueryable<ParcelLandCapability> parcelLandCapabilities, ParcelLandCapability parcelLandCapabilityToDelete)
        {
            DeleteParcelLandCapability(parcelLandCapabilities, new List<ParcelLandCapability> { parcelLandCapabilityToDelete });
        }
    }
}