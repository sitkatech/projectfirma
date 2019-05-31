//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[TechnicalAssistanceRequestUpdate]
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ProjectFirmaModels.Models
{
    public class TechnicalAssistanceRequestUpdateConfiguration : EntityTypeConfiguration<TechnicalAssistanceRequestUpdate>
    {
        public TechnicalAssistanceRequestUpdateConfiguration() : this("dbo"){}

        public TechnicalAssistanceRequestUpdateConfiguration(string schema)
        {
            ToTable("TechnicalAssistanceRequestUpdate", schema);
            HasKey(x => x.TechnicalAssistanceRequestUpdateID);
            Property(x => x.TechnicalAssistanceRequestUpdateID).HasColumnName(@"TechnicalAssistanceRequestUpdateID").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.TenantID).HasColumnName(@"TenantID").HasColumnType("int").IsRequired();
            Property(x => x.ProjectUpdateBatchID).HasColumnName(@"ProjectUpdateBatchID").HasColumnType("int").IsRequired();
            Property(x => x.FiscalYear).HasColumnName(@"FiscalYear").HasColumnType("int").IsRequired();
            Property(x => x.PersonID).HasColumnName(@"PersonID").HasColumnType("int").IsOptional();
            Property(x => x.TechnicalAssistanceTypeID).HasColumnName(@"TechnicalAssistanceTypeID").HasColumnType("int").IsRequired();
            Property(x => x.HoursRequested).HasColumnName(@"HoursRequested").HasColumnType("int").IsOptional();
            Property(x => x.HoursAllocated).HasColumnName(@"HoursAllocated").HasColumnType("int").IsOptional();
            Property(x => x.HoursProvided).HasColumnName(@"HoursProvided").HasColumnType("int").IsOptional();
            Property(x => x.Notes).HasColumnName(@"Notes").HasColumnType("varchar").IsOptional();

            // Foreign keys
            HasRequired(a => a.ProjectUpdateBatch).WithMany(b => b.TechnicalAssistanceRequestUpdates).HasForeignKey(c => c.ProjectUpdateBatchID).WillCascadeOnDelete(false); // FK_TechnicalAssistanceRequestUpdate_ProjectUpdateBatch_ProjectUpdateBatchID
            HasOptional(a => a.Person).WithMany(b => b.TechnicalAssistanceRequestUpdates).HasForeignKey(c => c.PersonID).WillCascadeOnDelete(false); // FK_TechnicalAssistanceRequestUpdate_Person_PersonID
        }
    }
}