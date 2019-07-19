//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ProjectContact]
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ProjectFirmaModels.Models
{
    public class ProjectContactConfiguration : EntityTypeConfiguration<ProjectContact>
    {
        public ProjectContactConfiguration() : this("dbo"){}

        public ProjectContactConfiguration(string schema)
        {
            ToTable("ProjectContact", schema);
            HasKey(x => x.ProjectContactID);
            Property(x => x.ProjectContactID).HasColumnName(@"ProjectContactID").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.TenantID).HasColumnName(@"TenantID").HasColumnType("int").IsRequired();
            Property(x => x.ProjectID).HasColumnName(@"ProjectID").HasColumnType("int").IsRequired();
            Property(x => x.ContactID).HasColumnName(@"ContactID").HasColumnType("int").IsRequired();
            Property(x => x.ContactRelationshipTypeID).HasColumnName(@"ContactRelationshipTypeID").HasColumnType("int").IsRequired();

            // Foreign keys
            HasRequired(a => a.Project).WithMany(b => b.ProjectContacts).HasForeignKey(c => c.ProjectID).WillCascadeOnDelete(false); // FK_ProjectContact_Project_ProjectID
            HasRequired(a => a.Contact).WithMany(b => b.ProjectContactsWhereYouAreTheContact).HasForeignKey(c => c.ContactID).WillCascadeOnDelete(false); // FK_ProjectContact_Person_ContactID_PersonID
            HasRequired(a => a.ContactRelationshipType).WithMany(b => b.ProjectContacts).HasForeignKey(c => c.ContactRelationshipTypeID).WillCascadeOnDelete(false); // FK_ProjectContact_ContactRelationshipType_ContactRelationshipTypeID
        }
    }
}