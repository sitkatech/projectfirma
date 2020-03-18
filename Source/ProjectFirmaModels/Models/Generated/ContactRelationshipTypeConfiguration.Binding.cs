//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ContactRelationshipType]
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ProjectFirmaModels.Models
{
    public class ContactRelationshipTypeConfiguration : EntityTypeConfiguration<ContactRelationshipType>
    {
        public ContactRelationshipTypeConfiguration() : this("dbo"){}

        public ContactRelationshipTypeConfiguration(string schema)
        {
            ToTable("ContactRelationshipType", schema);
            HasKey(x => x.ContactRelationshipTypeID);
            Property(x => x.ContactRelationshipTypeID).HasColumnName(@"ContactRelationshipTypeID").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.TenantID).HasColumnName(@"TenantID").HasColumnType("int").IsRequired();
            Property(x => x.ContactRelationshipTypeName).HasColumnName(@"ContactRelationshipTypeName").HasColumnType("varchar").IsRequired().IsUnicode(false).HasMaxLength(200);
            Property(x => x.IsContactRelationshipTypeRequired).HasColumnName(@"IsContactRelationshipTypeRequired").HasColumnType("bit").IsRequired();
            Property(x => x.ContactRelationshipTypeDescription).HasColumnName(@"ContactRelationshipTypeDescription").HasColumnType("varchar").IsOptional().IsUnicode(false).HasMaxLength(360);

            // Foreign keys

        }
    }
}