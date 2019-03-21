//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[SupportRequestLog]
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ProjectFirmaModels.Models
{
    public class SupportRequestLogConfiguration : EntityTypeConfiguration<SupportRequestLog>
    {
        public SupportRequestLogConfiguration() : this("dbo"){}

        public SupportRequestLogConfiguration(string schema)
        {
            ToTable("SupportRequestLog", schema);
            HasKey(x => x.SupportRequestLogID);
            Property(x => x.SupportRequestLogID).HasColumnName(@"SupportRequestLogID").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.TenantID).HasColumnName(@"TenantID").HasColumnType("int").IsRequired();
            Property(x => x.RequestDate).HasColumnName(@"RequestDate").HasColumnType("datetime").IsRequired();
            Property(x => x.RequestPersonName).HasColumnName(@"RequestPersonName").HasColumnType("varchar").IsRequired().IsUnicode(false).HasMaxLength(200);
            Property(x => x.RequestPersonEmail).HasColumnName(@"RequestPersonEmail").HasColumnType("varchar").IsRequired().IsUnicode(false).HasMaxLength(256);
            Property(x => x.RequestPersonID).HasColumnName(@"RequestPersonID").HasColumnType("int").IsOptional();
            Property(x => x.SupportRequestTypeID).HasColumnName(@"SupportRequestTypeID").HasColumnType("int").IsRequired();
            Property(x => x.RequestDescription).HasColumnName(@"RequestDescription").HasColumnType("varchar").IsRequired().IsUnicode(false).HasMaxLength(2000);
            Property(x => x.RequestPersonOrganization).HasColumnName(@"RequestPersonOrganization").HasColumnType("varchar").IsOptional().IsUnicode(false).HasMaxLength(500);
            Property(x => x.RequestPersonPhone).HasColumnName(@"RequestPersonPhone").HasColumnType("varchar").IsOptional().IsUnicode(false).HasMaxLength(50);

            // Foreign keys
            HasOptional(a => a.RequestPerson).WithMany(b => b.SupportRequestLogsWhereYouAreTheRequestPerson).HasForeignKey(c => c.RequestPersonID).WillCascadeOnDelete(false); // FK_SupportRequestLog_Person_RequestPersonID_PersonID
        }
    }
}