//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[OrganizationBoundaryStaging]
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ProjectFirmaModels.Models
{
    public class OrganizationBoundaryStagingConfiguration : EntityTypeConfiguration<OrganizationBoundaryStaging>
    {
        public OrganizationBoundaryStagingConfiguration() : this("dbo"){}

        public OrganizationBoundaryStagingConfiguration(string schema)
        {
            ToTable("OrganizationBoundaryStaging", schema);
            HasKey(x => x.OrganizationBoundaryStagingID);
            Property(x => x.OrganizationBoundaryStagingID).HasColumnName(@"OrganizationBoundaryStagingID").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.TenantID).HasColumnName(@"TenantID").HasColumnType("int").IsRequired();
            Property(x => x.OrganizationID).HasColumnName(@"OrganizationID").HasColumnType("int").IsRequired();
            Property(x => x.FeatureClassName).HasColumnName(@"FeatureClassName").HasColumnType("varchar").IsRequired().IsUnicode(false).HasMaxLength(255);
            Property(x => x.GeoJson).HasColumnName(@"GeoJson").HasColumnType("varchar").IsRequired();

            // Foreign keys
            HasRequired(a => a.Organization).WithMany(b => b.OrganizationBoundaryStagings).HasForeignKey(c => c.OrganizationID).WillCascadeOnDelete(false); // FK_OrganizationBoundaryStaging_Organization_OrganizationID
        }
    }
}