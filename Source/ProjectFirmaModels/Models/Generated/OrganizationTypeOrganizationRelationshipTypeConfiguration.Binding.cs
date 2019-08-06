//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[OrganizationTypeOrganizationRelationshipType]
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ProjectFirmaModels.Models
{
    public class OrganizationTypeOrganizationRelationshipTypeConfiguration : EntityTypeConfiguration<OrganizationTypeOrganizationRelationshipType>
    {
        public OrganizationTypeOrganizationRelationshipTypeConfiguration() : this("dbo"){}

        public OrganizationTypeOrganizationRelationshipTypeConfiguration(string schema)
        {
            ToTable("OrganizationTypeOrganizationRelationshipType", schema);
            HasKey(x => x.OrganizationTypeOrganizationRelationshipTypeID);
            Property(x => x.OrganizationTypeOrganizationRelationshipTypeID).HasColumnName(@"OrganizationTypeOrganizationRelationshipTypeID").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.TenantID).HasColumnName(@"TenantID").HasColumnType("int").IsRequired();
            Property(x => x.OrganizationTypeID).HasColumnName(@"OrganizationTypeID").HasColumnType("int").IsRequired();
            Property(x => x.OrganizationRelationshipTypeID).HasColumnName(@"OrganizationRelationshipTypeID").HasColumnType("int").IsRequired();

            // Foreign keys
            HasRequired(a => a.OrganizationType).WithMany(b => b.OrganizationTypeOrganizationRelationshipTypes).HasForeignKey(c => c.OrganizationTypeID).WillCascadeOnDelete(false); // FK_OrganizationTypeOrganizationRelationshipType_OrganizationType_OrganizationTypeID
            HasRequired(a => a.OrganizationRelationshipType).WithMany(b => b.OrganizationTypeOrganizationRelationshipTypes).HasForeignKey(c => c.OrganizationRelationshipTypeID).WillCascadeOnDelete(false); // FK_OrganizationTypeOrganizationRelationshipType_OrganizationRelationshipType_OrganizationRelationshipTypeID
        }
    }
}