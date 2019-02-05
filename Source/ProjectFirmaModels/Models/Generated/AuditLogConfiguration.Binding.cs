//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[AuditLog]
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ProjectFirmaModels.Models
{
    public class AuditLogConfiguration : EntityTypeConfiguration<AuditLog>
    {
        public AuditLogConfiguration() : this("dbo"){}

        public AuditLogConfiguration(string schema)
        {
            ToTable("AuditLog", schema);
            HasKey(x => x.AuditLogID);
            Property(x => x.AuditLogID).HasColumnName(@"AuditLogID").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.TenantID).HasColumnName(@"TenantID").HasColumnType("int").IsRequired();
            Property(x => x.PersonID).HasColumnName(@"PersonID").HasColumnType("int").IsRequired();
            Property(x => x.AuditLogDate).HasColumnName(@"AuditLogDate").HasColumnType("datetime").IsRequired();
            Property(x => x.AuditLogEventTypeID).HasColumnName(@"AuditLogEventTypeID").HasColumnType("int").IsRequired();
            Property(x => x.TableName).HasColumnName(@"TableName").HasColumnType("varchar").IsRequired().IsUnicode(false).HasMaxLength(500);
            Property(x => x.RecordID).HasColumnName(@"RecordID").HasColumnType("int").IsRequired();
            Property(x => x.ColumnName).HasColumnName(@"ColumnName").HasColumnType("varchar").IsRequired().IsUnicode(false).HasMaxLength(500);
            Property(x => x.OriginalValue).HasColumnName(@"OriginalValue").HasColumnType("varchar").IsOptional();
            Property(x => x.NewValue).HasColumnName(@"NewValue").HasColumnType("varchar").IsRequired();
            Property(x => x.AuditDescription).HasColumnName(@"AuditDescription").HasColumnType("varchar").IsOptional();
            Property(x => x.ProjectID).HasColumnName(@"ProjectID").HasColumnType("int").IsOptional();

            // Foreign keys
            HasRequired(a => a.Person).WithMany(b => b.AuditLogs).HasForeignKey(c => c.PersonID).WillCascadeOnDelete(false); // FK_AuditLog_Person_PersonID
        }
    }
}