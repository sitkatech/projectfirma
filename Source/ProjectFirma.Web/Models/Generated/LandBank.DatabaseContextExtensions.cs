//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[LandBank]
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
        public static LandBank GetLandBank(this IQueryable<LandBank> landBanks, int landBankID)
        {
            var landBank = landBanks.SingleOrDefault(x => x.LandBankID == landBankID);
            Check.RequireNotNullThrowNotFound(landBank, "LandBank", landBankID);
            return landBank;
        }

        public static void DeleteLandBank(this IQueryable<LandBank> landBanks, List<int> landBankIDList)
        {
            if(landBankIDList.Any())
            {
                landBanks.Where(x => landBankIDList.Contains(x.LandBankID)).Delete();
            }
        }

        public static void DeleteLandBank(this IQueryable<LandBank> landBanks, ICollection<LandBank> landBanksToDelete)
        {
            if(landBanksToDelete.Any())
            {
                var landBankIDList = landBanksToDelete.Select(x => x.LandBankID).ToList();
                landBanks.Where(x => landBankIDList.Contains(x.LandBankID)).Delete();
            }
        }

        public static void DeleteLandBank(this IQueryable<LandBank> landBanks, int landBankID)
        {
            DeleteLandBank(landBanks, new List<int> { landBankID });
        }

        public static void DeleteLandBank(this IQueryable<LandBank> landBanks, LandBank landBankToDelete)
        {
            DeleteLandBank(landBanks, new List<LandBank> { landBankToDelete });
        }
    }
}