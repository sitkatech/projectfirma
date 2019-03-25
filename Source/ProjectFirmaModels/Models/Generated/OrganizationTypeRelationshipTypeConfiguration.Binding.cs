//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[OrganizationTypeRelationshipType]
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ProjectFirmaModels.Models
{
    public class OrganizationTypeRelationshipTypeConfiguration : EntityTypeConfiguration<OrganizationTypeRelationshipType>
    {
        public OrganizationTypeRelationshipTypeConfiguration() : this("dbo"){}

        public OrganizationTypeRelationshipTypeConfiguration(string schema)
        {
            ToTable("OrganizationTypeRelationshipType", schema);
            HasKey(x => x.OrganizationTypeRelationshipTypeID);
            Property(x => x.OrganizationTypeRelationshipTypeID).HasColumnName(@"OrganizationTypeRelationshipTypeID").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.TenantID).HasColumnName(@"TenantID").HasColumnType("int").IsRequired();
            Property(x => x.OrganizationTypeID).HasColumnName(@"OrganizationTypeID").HasColumnType("int").IsRequired();
            Property(x => x.RelationshipTypeID).HasColumnName(@"RelationshipTypeID").HasColumnType("int").IsRequired();

            // Foreign keys
            HasRequired(a => a.OrganizationType).WithMany(b => b.OrganizationTypeRelationshipTypes).HasForeignKey(c => c.OrganizationTypeID).WillCascadeOnDelete(false); // FK_OrganizationTypeRelationshipType_OrganizationType_OrganizationTypeID
            HasRequired(a => a.RelationshipType).WithMany(b => b.OrganizationTypeRelationshipTypes).HasForeignKey(c => c.RelationshipTypeID).WillCascadeOnDelete(false); // FK_OrganizationTypeRelationshipType_RelationshipType_RelationshipTypeID
        }
    }
}