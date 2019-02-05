//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ProjectFundingSourceRequest]
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ProjectFirmaModels.Models
{
    public class ProjectFundingSourceRequestConfiguration : EntityTypeConfiguration<ProjectFundingSourceRequest>
    {
        public ProjectFundingSourceRequestConfiguration() : this("dbo"){}

        public ProjectFundingSourceRequestConfiguration(string schema)
        {
            ToTable("ProjectFundingSourceRequest", schema);
            HasKey(x => x.ProjectFundingSourceRequestID);
            Property(x => x.ProjectFundingSourceRequestID).HasColumnName(@"ProjectFundingSourceRequestID").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.TenantID).HasColumnName(@"TenantID").HasColumnType("int").IsRequired();
            Property(x => x.ProjectID).HasColumnName(@"ProjectID").HasColumnType("int").IsRequired();
            Property(x => x.FundingSourceID).HasColumnName(@"FundingSourceID").HasColumnType("int").IsRequired();
            Property(x => x.SecuredAmount).HasColumnName(@"SecuredAmount").HasColumnType("money").IsOptional().HasPrecision(19,4);
            Property(x => x.UnsecuredAmount).HasColumnName(@"UnsecuredAmount").HasColumnType("money").IsOptional().HasPrecision(19,4);

            // Foreign keys
            HasRequired(a => a.Project).WithMany(b => b.ProjectFundingSourceRequests).HasForeignKey(c => c.ProjectID).WillCascadeOnDelete(false); // FK_ProjectFundingSourceRequest_Project_ProjectID
            HasRequired(a => a.FundingSource).WithMany(b => b.ProjectFundingSourceRequests).HasForeignKey(c => c.FundingSourceID).WillCascadeOnDelete(false); // FK_ProjectFundingSourceRequest_FundingSource_FundingSourceID
        }
    }
}