//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[OrganizationType]
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ProjectFirmaModels.Models
{
    public class OrganizationTypeConfiguration : EntityTypeConfiguration<OrganizationType>
    {
        public OrganizationTypeConfiguration() : this("dbo"){}

        public OrganizationTypeConfiguration(string schema)
        {
            ToTable("OrganizationType", schema);
            HasKey(x => x.OrganizationTypeID);
            Property(x => x.OrganizationTypeID).HasColumnName(@"OrganizationTypeID").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.TenantID).HasColumnName(@"TenantID").HasColumnType("int").IsRequired();
            Property(x => x.OrganizationTypeName).HasColumnName(@"OrganizationTypeName").HasColumnType("varchar").IsRequired().IsUnicode(false).HasMaxLength(200);
            Property(x => x.OrganizationTypeAbbreviation).HasColumnName(@"OrganizationTypeAbbreviation").HasColumnType("varchar").IsRequired().IsUnicode(false).HasMaxLength(100);
            Property(x => x.LegendColor).HasColumnName(@"LegendColor").HasColumnType("varchar").IsRequired().IsUnicode(false).HasMaxLength(10);
            Property(x => x.ShowOnProjectMaps).HasColumnName(@"ShowOnProjectMaps").HasColumnType("bit").IsRequired();
            Property(x => x.IsDefaultOrganizationType).HasColumnName(@"IsDefaultOrganizationType").HasColumnType("bit").IsRequired();
            Property(x => x.IsFundingType).HasColumnName(@"IsFundingType").HasColumnType("bit").IsRequired();

            // Foreign keys

        }
    }
}