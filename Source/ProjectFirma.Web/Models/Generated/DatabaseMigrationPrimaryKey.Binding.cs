//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.DatabaseMigration
using ProjectFirma.Web.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirma.Web.Models
{
    public class DatabaseMigrationPrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<DatabaseMigration>
    {
        public DatabaseMigrationPrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public DatabaseMigrationPrimaryKey(DatabaseMigration databaseMigration) : base(databaseMigration){}

        public static implicit operator DatabaseMigrationPrimaryKey(int primaryKeyValue)
        {
            return new DatabaseMigrationPrimaryKey(primaryKeyValue);
        }

        public static implicit operator DatabaseMigrationPrimaryKey(DatabaseMigration databaseMigration)
        {
            return new DatabaseMigrationPrimaryKey(databaseMigration);
        }
    }
}