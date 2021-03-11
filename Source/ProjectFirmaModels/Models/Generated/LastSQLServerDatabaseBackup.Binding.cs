//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[LastSQLServerDatabaseBackup]
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.Data.Entity.Spatial;
using System.Linq;
using System.Web;
using CodeFirstStoreFunctions;
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    // Table [dbo].[LastSQLServerDatabaseBackup] is NOT multi-tenant, so is attributed as ICanDeleteFull
    [Table("[dbo].[LastSQLServerDatabaseBackup]")]
    public partial class LastSQLServerDatabaseBackup : IHavePrimaryKey, ICanDeleteFull
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected LastSQLServerDatabaseBackup()
        {

        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public LastSQLServerDatabaseBackup(int lastSQLServerDatabaseBackupID, string backupName, string userName, string serverName, string databaseName, int? databaseVersion, DateTime? databaseCreationDate, decimal? backupSize, DateTime? backupStartDate, DateTime? backupFinishDate, string machineName, string collation, long? compressedBackupSize) : this()
        {
            this.LastSQLServerDatabaseBackupID = lastSQLServerDatabaseBackupID;
            this.BackupName = backupName;
            this.UserName = userName;
            this.ServerName = serverName;
            this.DatabaseName = databaseName;
            this.DatabaseVersion = databaseVersion;
            this.DatabaseCreationDate = databaseCreationDate;
            this.BackupSize = backupSize;
            this.BackupStartDate = backupStartDate;
            this.BackupFinishDate = backupFinishDate;
            this.MachineName = machineName;
            this.Collation = collation;
            this.CompressedBackupSize = compressedBackupSize;
        }



        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static LastSQLServerDatabaseBackup CreateNewBlank()
        {
            return new LastSQLServerDatabaseBackup();
        }

        /// <summary>
        /// Does this object have any dependent objects? (If it does have dependent objects, these would need to be deleted before this object could be deleted.)
        /// </summary>
        /// <returns></returns>
        public bool HasDependentObjects()
        {
            return false;
        }

        /// <summary>
        /// Active Dependent type names of this object
        /// </summary>
        public List<string> DependentObjectNames() 
        {
            var dependentObjects = new List<string>();
            
            return dependentObjects.Distinct().ToList();
        }

        /// <summary>
        /// Dependent type names of this entity
        /// </summary>
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(LastSQLServerDatabaseBackup).Name};


        /// <summary>
        /// Delete just the entity 
        /// </summary>
        public void Delete(DatabaseEntities dbContext)
        {
            dbContext.LastSQLServerDatabaseBackups.Remove(this);
        }
        
        /// <summary>
        /// Delete entity plus all children
        /// </summary>
        public void DeleteFull(DatabaseEntities dbContext)
        {
            
            Delete(dbContext);
        }

        [Key]
        public int LastSQLServerDatabaseBackupID { get; set; }
        public string BackupName { get; set; }
        public string UserName { get; set; }
        public string ServerName { get; set; }
        public string DatabaseName { get; set; }
        public int? DatabaseVersion { get; set; }
        public DateTime? DatabaseCreationDate { get; set; }
        public decimal? BackupSize { get; set; }
        public DateTime? BackupStartDate { get; set; }
        public DateTime? BackupFinishDate { get; set; }
        public string MachineName { get; set; }
        public string Collation { get; set; }
        public long? CompressedBackupSize { get; set; }
        [NotMapped]
        public int PrimaryKey { get { return LastSQLServerDatabaseBackupID; } set { LastSQLServerDatabaseBackupID = value; } }



        public static class FieldLengths
        {
            public const int BackupName = 128;
            public const int UserName = 128;
            public const int ServerName = 128;
            public const int DatabaseName = 128;
            public const int MachineName = 128;
            public const int Collation = 128;
        }
    }
}