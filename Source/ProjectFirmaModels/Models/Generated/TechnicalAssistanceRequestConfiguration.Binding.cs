//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[TechnicalAssistanceRequest]
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ProjectFirmaModels.Models
{
    public class TechnicalAssistanceRequestConfiguration : EntityTypeConfiguration<TechnicalAssistanceRequest>
    {
        public TechnicalAssistanceRequestConfiguration() : this("dbo"){}

        public TechnicalAssistanceRequestConfiguration(string schema)
        {
            ToTable("TechnicalAssistanceRequest", schema);
            HasKey(x => x.TechnicalAssistanceRequestID);
            Property(x => x.TechnicalAssistanceRequestID).HasColumnName(@"TechnicalAssistanceRequestID").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.ProjectID).HasColumnName(@"ProjectID").HasColumnType("int").IsRequired();
            Property(x => x.FiscalYear).HasColumnName(@"FiscalYear").HasColumnType("int").IsRequired();
            Property(x => x.PersonID).HasColumnName(@"PersonID").HasColumnType("int").IsOptional();
            Property(x => x.TechnicalAssistanceTypeID).HasColumnName(@"TechnicalAssistanceTypeID").HasColumnType("int").IsRequired();
            Property(x => x.HoursRequested).HasColumnName(@"HoursRequested").HasColumnType("int").IsOptional();
            Property(x => x.HoursAllocated).HasColumnName(@"HoursAllocated").HasColumnType("int").IsOptional();
            Property(x => x.HoursProvided).HasColumnName(@"HoursProvided").HasColumnType("int").IsOptional();
            Property(x => x.Notes).HasColumnName(@"Notes").HasColumnType("varchar").IsOptional();

            // Foreign keys
            HasRequired(a => a.Project).WithMany(b => b.TechnicalAssistanceRequests).HasForeignKey(c => c.ProjectID).WillCascadeOnDelete(false); // FK_TechnicalAssistanceRequest_Project_ProjectID
            HasOptional(a => a.Person).WithMany(b => b.TechnicalAssistanceRequests).HasForeignKey(c => c.PersonID).WillCascadeOnDelete(false); // FK_TechnicalAssistanceRequest_Person_PersonID
        }
    }
}