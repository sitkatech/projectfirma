//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[RelationshipType]
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ProjectFirmaModels.Models
{
    public class RelationshipTypeConfiguration : EntityTypeConfiguration<RelationshipType>
    {
        public RelationshipTypeConfiguration() : this("dbo"){}

        public RelationshipTypeConfiguration(string schema)
        {
            ToTable("RelationshipType", schema);
            HasKey(x => x.RelationshipTypeID);
            Property(x => x.RelationshipTypeID).HasColumnName(@"RelationshipTypeID").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.TenantID).HasColumnName(@"TenantID").HasColumnType("int").IsRequired();
            Property(x => x.RelationshipTypeName).HasColumnName(@"RelationshipTypeName").HasColumnType("varchar").IsRequired().IsUnicode(false).HasMaxLength(200);
            Property(x => x.CanStewardProjects).HasColumnName(@"CanStewardProjects").HasColumnType("bit").IsRequired();
            Property(x => x.IsPrimaryContact).HasColumnName(@"IsPrimaryContact").HasColumnType("bit").IsRequired();
            Property(x => x.CanOnlyBeRelatedOnceToAProject).HasColumnName(@"CanOnlyBeRelatedOnceToAProject").HasColumnType("bit").IsRequired();
            Property(x => x.RelationshipTypeDescription).HasColumnName(@"RelationshipTypeDescription").HasColumnType("varchar").IsOptional().IsUnicode(false).HasMaxLength(360);
            Property(x => x.ReportInAccomplishmentsDashboard).HasColumnName(@"ReportInAccomplishmentsDashboard").HasColumnType("bit").IsRequired();
            Property(x => x.ShowOnFactSheet).HasColumnName(@"ShowOnFactSheet").HasColumnType("bit").IsRequired();

            // Foreign keys

        }
    }
}