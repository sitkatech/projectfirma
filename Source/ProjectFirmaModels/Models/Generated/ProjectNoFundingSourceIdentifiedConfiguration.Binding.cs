//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ProjectNoFundingSourceIdentified]
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ProjectFirmaModels.Models
{
    public class ProjectNoFundingSourceIdentifiedConfiguration : EntityTypeConfiguration<ProjectNoFundingSourceIdentified>
    {
        public ProjectNoFundingSourceIdentifiedConfiguration() : this("dbo"){}

        public ProjectNoFundingSourceIdentifiedConfiguration(string schema)
        {
            ToTable("ProjectNoFundingSourceIdentified", schema);
            HasKey(x => x.ProjectNoFundingSourceIdentifiedID);
            Property(x => x.ProjectNoFundingSourceIdentifiedID).HasColumnName(@"ProjectNoFundingSourceIdentifiedID").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.TenantID).HasColumnName(@"TenantID").HasColumnType("int").IsRequired();
            Property(x => x.ProjectID).HasColumnName(@"ProjectID").HasColumnType("int").IsRequired();
            Property(x => x.CalendarYear).HasColumnName(@"CalendarYear").HasColumnType("int").IsOptional();
            Property(x => x.NoFundingSourceIdentifiedYet).HasColumnName(@"NoFundingSourceIdentifiedYet").HasColumnType("money").IsOptional().HasPrecision(19,4);

            // Foreign keys
            HasRequired(a => a.Project).WithMany(b => b.ProjectNoFundingSourceIdentifieds).HasForeignKey(c => c.ProjectID).WillCascadeOnDelete(false); // FK_ProjectNoFundingSourceIdentified_Project_ProjectID
        }
    }
}