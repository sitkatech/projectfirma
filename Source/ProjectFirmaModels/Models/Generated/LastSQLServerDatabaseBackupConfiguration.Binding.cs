//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[LastSQLServerDatabaseBackup]
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ProjectFirmaModels.Models
{
    public class LastSQLServerDatabaseBackupConfiguration : EntityTypeConfiguration<LastSQLServerDatabaseBackup>
    {
        public LastSQLServerDatabaseBackupConfiguration() : this("dbo"){}

        public LastSQLServerDatabaseBackupConfiguration(string schema)
        {
            ToTable("LastSQLServerDatabaseBackup", schema);
            HasKey(x => x.LastSQLServerDatabaseBackupID);
            Property(x => x.LastSQLServerDatabaseBackupID).HasColumnName(@"LastSQLServerDatabaseBackupID").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.BackupName).HasColumnName(@"BackupName").HasColumnType("nvarchar").IsOptional().HasMaxLength(128);
            Property(x => x.UserName).HasColumnName(@"UserName").HasColumnType("nvarchar").IsOptional().HasMaxLength(128);
            Property(x => x.ServerName).HasColumnName(@"ServerName").HasColumnType("nvarchar").IsOptional().HasMaxLength(128);
            Property(x => x.DatabaseName).HasColumnName(@"DatabaseName").HasColumnType("nvarchar").IsOptional().HasMaxLength(128);
            Property(x => x.DatabaseVersion).HasColumnName(@"DatabaseVersion").HasColumnType("int").IsOptional();
            Property(x => x.DatabaseCreationDate).HasColumnName(@"DatabaseCreationDate").HasColumnType("datetime").IsOptional();
            Property(x => x.BackupSize).HasColumnName(@"BackupSize").HasColumnType("decimal").IsOptional();
            Property(x => x.BackupStartDate).HasColumnName(@"BackupStartDate").HasColumnType("datetime").IsOptional();
            Property(x => x.BackupFinishDate).HasColumnName(@"BackupFinishDate").HasColumnType("datetime").IsOptional();
            Property(x => x.MachineName).HasColumnName(@"MachineName").HasColumnType("nvarchar").IsOptional().HasMaxLength(128);
            Property(x => x.Collation).HasColumnName(@"Collation").HasColumnType("nvarchar").IsOptional().HasMaxLength(128);
            Property(x => x.CompressedBackupSize).HasColumnName(@"CompressedBackupSize").HasColumnType("bigint").IsOptional();

        }
    }
}