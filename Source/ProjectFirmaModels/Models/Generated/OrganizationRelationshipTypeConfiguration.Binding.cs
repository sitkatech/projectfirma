//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[OrganizationRelationshipType]
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ProjectFirmaModels.Models
{
    public class OrganizationRelationshipTypeConfiguration : EntityTypeConfiguration<OrganizationRelationshipType>
    {
        public OrganizationRelationshipTypeConfiguration() : this("dbo"){}

        public OrganizationRelationshipTypeConfiguration(string schema)
        {
            ToTable("OrganizationRelationshipType", schema);
            HasKey(x => x.OrganizationRelationshipTypeID);
            Property(x => x.OrganizationRelationshipTypeID).HasColumnName(@"OrganizationRelationshipTypeID").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.TenantID).HasColumnName(@"TenantID").HasColumnType("int").IsRequired();
            Property(x => x.OrganizationRelationshipTypeName).HasColumnName(@"OrganizationRelationshipTypeName").HasColumnType("varchar").IsRequired().IsUnicode(false).HasMaxLength(200);
            Property(x => x.CanStewardProjects).HasColumnName(@"CanStewardProjects").HasColumnType("bit").IsRequired();
            Property(x => x.IsPrimaryContact).HasColumnName(@"IsPrimaryContact").HasColumnType("bit").IsRequired();
            Property(x => x.IsOrganizationRelationshipTypeRequired).HasColumnName(@"IsOrganizationRelationshipTypeRequired").HasColumnType("bit").IsRequired();
            Property(x => x.OrganizationRelationshipTypeDescription).HasColumnName(@"OrganizationRelationshipTypeDescription").HasColumnType("varchar").IsOptional().IsUnicode(false).HasMaxLength(360);
            Property(x => x.ReportInAccomplishmentsDashboard).HasColumnName(@"ReportInAccomplishmentsDashboard").HasColumnType("bit").IsRequired();
            Property(x => x.ShowOnFactSheet).HasColumnName(@"ShowOnFactSheet").HasColumnType("bit").IsRequired();

            // Foreign keys

        }
    }
}