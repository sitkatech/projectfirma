//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ContactTypeContactRelationshipType]
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ProjectFirmaModels.Models
{
    public class ContactTypeContactRelationshipTypeConfiguration : EntityTypeConfiguration<ContactTypeContactRelationshipType>
    {
        public ContactTypeContactRelationshipTypeConfiguration() : this("dbo"){}

        public ContactTypeContactRelationshipTypeConfiguration(string schema)
        {
            ToTable("ContactTypeContactRelationshipType", schema);
            HasKey(x => x.ContactTypeContactRelationshipTypeID);
            Property(x => x.ContactTypeContactRelationshipTypeID).HasColumnName(@"ContactTypeContactRelationshipTypeID").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.TenantID).HasColumnName(@"TenantID").HasColumnType("int").IsRequired();
            Property(x => x.ContactTypeID).HasColumnName(@"ContactTypeID").HasColumnType("int").IsRequired();
            Property(x => x.ContactRelationshipTypeID).HasColumnName(@"ContactRelationshipTypeID").HasColumnType("int").IsRequired();

            // Foreign keys
            HasRequired(a => a.ContactType).WithMany(b => b.ContactTypeContactRelationshipTypes).HasForeignKey(c => c.ContactTypeID).WillCascadeOnDelete(false); // FK_ContactTypeContactRelationshipType_ContactType_ContactTypeID
            HasRequired(a => a.ContactRelationshipType).WithMany(b => b.ContactTypeContactRelationshipTypes).HasForeignKey(c => c.ContactRelationshipTypeID).WillCascadeOnDelete(false); // FK_ContactTypeContactRelationshipType_ContactRelationshipType_ContactRelationshipTypeID
        }
    }
}