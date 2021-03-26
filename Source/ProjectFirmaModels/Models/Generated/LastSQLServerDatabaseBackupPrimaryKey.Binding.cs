//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.LastSQLServerDatabaseBackup
using CodeFirstStoreFunctions;
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public class LastSQLServerDatabaseBackupPrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<LastSQLServerDatabaseBackup>
    {
        public LastSQLServerDatabaseBackupPrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public LastSQLServerDatabaseBackupPrimaryKey(LastSQLServerDatabaseBackup lastSQLServerDatabaseBackup) : base(lastSQLServerDatabaseBackup){}

        public static implicit operator LastSQLServerDatabaseBackupPrimaryKey(int primaryKeyValue)
        {
            return new LastSQLServerDatabaseBackupPrimaryKey(primaryKeyValue);
        }

        public static implicit operator LastSQLServerDatabaseBackupPrimaryKey(LastSQLServerDatabaseBackup lastSQLServerDatabaseBackup)
        {
            return new LastSQLServerDatabaseBackupPrimaryKey(lastSQLServerDatabaseBackup);
        }
    }
}