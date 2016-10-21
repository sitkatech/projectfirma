//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[TdrTransactionConversion]
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
        public static TdrTransactionConversion GetTdrTransactionConversion(this IQueryable<TdrTransactionConversion> tdrTransactionConversions, int tdrTransactionConversionID)
        {
            var tdrTransactionConversion = tdrTransactionConversions.SingleOrDefault(x => x.TdrTransactionConversionID == tdrTransactionConversionID);
            Check.RequireNotNullThrowNotFound(tdrTransactionConversion, "TdrTransactionConversion", tdrTransactionConversionID);
            return tdrTransactionConversion;
        }

        public static void DeleteTdrTransactionConversion(this IQueryable<TdrTransactionConversion> tdrTransactionConversions, List<int> tdrTransactionConversionIDList)
        {
            if(tdrTransactionConversionIDList.Any())
            {
                tdrTransactionConversions.Where(x => tdrTransactionConversionIDList.Contains(x.TdrTransactionConversionID)).Delete();
            }
        }

        public static void DeleteTdrTransactionConversion(this IQueryable<TdrTransactionConversion> tdrTransactionConversions, ICollection<TdrTransactionConversion> tdrTransactionConversionsToDelete)
        {
            if(tdrTransactionConversionsToDelete.Any())
            {
                var tdrTransactionConversionIDList = tdrTransactionConversionsToDelete.Select(x => x.TdrTransactionConversionID).ToList();
                tdrTransactionConversions.Where(x => tdrTransactionConversionIDList.Contains(x.TdrTransactionConversionID)).Delete();
            }
        }

        public static void DeleteTdrTransactionConversion(this IQueryable<TdrTransactionConversion> tdrTransactionConversions, int tdrTransactionConversionID)
        {
            DeleteTdrTransactionConversion(tdrTransactionConversions, new List<int> { tdrTransactionConversionID });
        }

        public static void DeleteTdrTransactionConversion(this IQueryable<TdrTransactionConversion> tdrTransactionConversions, TdrTransactionConversion tdrTransactionConversionToDelete)
        {
            DeleteTdrTransactionConversion(tdrTransactionConversions, new List<TdrTransactionConversion> { tdrTransactionConversionToDelete });
        }
    }
}