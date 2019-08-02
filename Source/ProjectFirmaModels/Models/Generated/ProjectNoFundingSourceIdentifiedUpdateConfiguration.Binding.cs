//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ProjectNoFundingSourceIdentifiedUpdate]
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ProjectFirmaModels.Models
{
    public class ProjectNoFundingSourceIdentifiedUpdateConfiguration : EntityTypeConfiguration<ProjectNoFundingSourceIdentifiedUpdate>
    {
        public ProjectNoFundingSourceIdentifiedUpdateConfiguration() : this("dbo"){}

        public ProjectNoFundingSourceIdentifiedUpdateConfiguration(string schema)
        {
            ToTable("ProjectNoFundingSourceIdentifiedUpdate", schema);
            HasKey(x => x.ProjectNoFundingSourceIdentifiedUpdateID);
            Property(x => x.ProjectNoFundingSourceIdentifiedUpdateID).HasColumnName(@"ProjectNoFundingSourceIdentifiedUpdateID").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.TenantID).HasColumnName(@"TenantID").HasColumnType("int").IsRequired();
            Property(x => x.ProjectUpdateBatchID).HasColumnName(@"ProjectUpdateBatchID").HasColumnType("int").IsRequired();
            Property(x => x.CalendarYear).HasColumnName(@"CalendarYear").HasColumnType("int").IsOptional();
            Property(x => x.NoFundingSourceIdentifiedYet).HasColumnName(@"NoFundingSourceIdentifiedYet").HasColumnType("money").IsOptional().HasPrecision(19,4);

            // Foreign keys
            HasRequired(a => a.ProjectUpdateBatch).WithMany(b => b.ProjectNoFundingSourceIdentifiedUpdates).HasForeignKey(c => c.ProjectUpdateBatchID).WillCascadeOnDelete(false); // FK_ProjectNoFundingSourceIdentifiedUpdate_ProjectUpdateBatch_ProjectUpdateBatchID
        }
    }
}