//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[LastSQLServerDatabaseBackup]
using System.Collections.Generic;
using System.Linq;
using Z.EntityFramework.Plus;
using CodeFirstStoreFunctions;
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public static partial class DatabaseContextExtensions
    {
        public static LastSQLServerDatabaseBackup GetLastSQLServerDatabaseBackup(this IQueryable<LastSQLServerDatabaseBackup> lastSQLServerDatabaseBackups, int lastSQLServerDatabaseBackupID)
        {
            var lastSQLServerDatabaseBackup = lastSQLServerDatabaseBackups.SingleOrDefault(x => x.LastSQLServerDatabaseBackupID == lastSQLServerDatabaseBackupID);
            Check.RequireNotNullThrowNotFound(lastSQLServerDatabaseBackup, "LastSQLServerDatabaseBackup", lastSQLServerDatabaseBackupID);
            return lastSQLServerDatabaseBackup;
        }

        // Delete using an IDList (Firma style)
        public static void DeleteLastSQLServerDatabaseBackup(this IQueryable<LastSQLServerDatabaseBackup> lastSQLServerDatabaseBackups, List<int> lastSQLServerDatabaseBackupIDList)
        {
            if(lastSQLServerDatabaseBackupIDList.Any())
            {
                lastSQLServerDatabaseBackups.Where(x => lastSQLServerDatabaseBackupIDList.Contains(x.LastSQLServerDatabaseBackupID)).Delete();
            }
        }

        // Delete using an object list (Firma style)
        public static void DeleteLastSQLServerDatabaseBackup(this IQueryable<LastSQLServerDatabaseBackup> lastSQLServerDatabaseBackups, ICollection<LastSQLServerDatabaseBackup> lastSQLServerDatabaseBackupsToDelete)
        {
            if(lastSQLServerDatabaseBackupsToDelete.Any())
            {
                var lastSQLServerDatabaseBackupIDList = lastSQLServerDatabaseBackupsToDelete.Select(x => x.LastSQLServerDatabaseBackupID).ToList();
                lastSQLServerDatabaseBackups.Where(x => lastSQLServerDatabaseBackupIDList.Contains(x.LastSQLServerDatabaseBackupID)).Delete();
            }
        }

        public static void DeleteLastSQLServerDatabaseBackup(this IQueryable<LastSQLServerDatabaseBackup> lastSQLServerDatabaseBackups, int lastSQLServerDatabaseBackupID)
        {
            DeleteLastSQLServerDatabaseBackup(lastSQLServerDatabaseBackups, new List<int> { lastSQLServerDatabaseBackupID });
        }

        public static void DeleteLastSQLServerDatabaseBackup(this IQueryable<LastSQLServerDatabaseBackup> lastSQLServerDatabaseBackups, LastSQLServerDatabaseBackup lastSQLServerDatabaseBackupToDelete)
        {
            DeleteLastSQLServerDatabaseBackup(lastSQLServerDatabaseBackups, new List<LastSQLServerDatabaseBackup> { lastSQLServerDatabaseBackupToDelete });
        }
    }
}