//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[DatabaseMigration]
using System.Collections.Generic;
using System.Linq;
using Z.EntityFramework.Plus;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Models
{
    public static partial class DatabaseContextExtensions
    {
        public static DatabaseMigration GetDatabaseMigration(this IQueryable<DatabaseMigration> databaseMigrations, int databaseMigrationNumber)
        {
            var databaseMigration = databaseMigrations.SingleOrDefault(x => x.DatabaseMigrationNumber == databaseMigrationNumber);
            Check.RequireNotNullThrowNotFound(databaseMigration, "DatabaseMigration", databaseMigrationNumber);
            return databaseMigration;
        }

        public static void DeleteDatabaseMigration(this IQueryable<DatabaseMigration> databaseMigrations, List<int> databaseMigrationNumberList)
        {
            if(databaseMigrationNumberList.Any())
            {
                databaseMigrations.Where(x => databaseMigrationNumberList.Contains(x.DatabaseMigrationNumber)).Delete();
            }
        }

        public static void DeleteDatabaseMigration(this IQueryable<DatabaseMigration> databaseMigrations, ICollection<DatabaseMigration> databaseMigrationsToDelete)
        {
            if(databaseMigrationsToDelete.Any())
            {
                var databaseMigrationNumberList = databaseMigrationsToDelete.Select(x => x.DatabaseMigrationNumber).ToList();
                databaseMigrations.Where(x => databaseMigrationNumberList.Contains(x.DatabaseMigrationNumber)).Delete();
            }
        }

        public static void DeleteDatabaseMigration(this IQueryable<DatabaseMigration> databaseMigrations, int databaseMigrationNumber)
        {
            DeleteDatabaseMigration(databaseMigrations, new List<int> { databaseMigrationNumber });
        }

        public static void DeleteDatabaseMigration(this IQueryable<DatabaseMigration> databaseMigrations, DatabaseMigration databaseMigrationToDelete)
        {
            DeleteDatabaseMigration(databaseMigrations, new List<DatabaseMigration> { databaseMigrationToDelete });
        }
    }
}