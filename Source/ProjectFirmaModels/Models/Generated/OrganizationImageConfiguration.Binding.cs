//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[OrganizationImage]
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ProjectFirmaModels.Models
{
    public class OrganizationImageConfiguration : EntityTypeConfiguration<OrganizationImage>
    {
        public OrganizationImageConfiguration() : this("dbo"){}

        public OrganizationImageConfiguration(string schema)
        {
            ToTable("OrganizationImage", schema);
            HasKey(x => x.OrganizationImageID);
            Property(x => x.OrganizationImageID).HasColumnName(@"OrganizationImageID").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.TenantID).HasColumnName(@"TenantID").HasColumnType("int").IsRequired();
            Property(x => x.OrganizationID).HasColumnName(@"OrganizationID").HasColumnType("int").IsRequired();
            Property(x => x.FileResourceInfoID).HasColumnName(@"FileResourceInfoID").HasColumnType("int").IsRequired();

            // Foreign keys
            HasRequired(a => a.Organization).WithMany(b => b.OrganizationImages).HasForeignKey(c => c.OrganizationID).WillCascadeOnDelete(false); // FK_OrganizationImage_Organization_OrganizationID
            HasRequired(a => a.FileResourceInfo).WithMany(b => b.OrganizationImages).HasForeignKey(c => c.FileResourceInfoID).WillCascadeOnDelete(false); // FK_OrganizationImage_FileResourceInfo_FileResourceInfoID
        }
    }
}