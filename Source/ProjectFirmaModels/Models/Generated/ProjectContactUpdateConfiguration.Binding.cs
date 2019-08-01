//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ProjectContactUpdate]
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ProjectFirmaModels.Models
{
    public class ProjectContactUpdateConfiguration : EntityTypeConfiguration<ProjectContactUpdate>
    {
        public ProjectContactUpdateConfiguration() : this("dbo"){}

        public ProjectContactUpdateConfiguration(string schema)
        {
            ToTable("ProjectContactUpdate", schema);
            HasKey(x => x.ProjectContactUpdateID);
            Property(x => x.ProjectContactUpdateID).HasColumnName(@"ProjectContactUpdateID").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.TenantID).HasColumnName(@"TenantID").HasColumnType("int").IsRequired();
            Property(x => x.ProjectUpdateBatchID).HasColumnName(@"ProjectUpdateBatchID").HasColumnType("int").IsRequired();
            Property(x => x.ContactID).HasColumnName(@"ContactID").HasColumnType("int").IsRequired();
            Property(x => x.ContactRelationshipTypeID).HasColumnName(@"ContactRelationshipTypeID").HasColumnType("int").IsRequired();

            // Foreign keys
            HasRequired(a => a.ProjectUpdateBatch).WithMany(b => b.ProjectContactUpdates).HasForeignKey(c => c.ProjectUpdateBatchID).WillCascadeOnDelete(false); // FK_ProjectContactUpdate_ProjectUpdateBatch_ProjectUpdateBatchID
            HasRequired(a => a.Contact).WithMany(b => b.ProjectContactUpdatesWhereYouAreTheContact).HasForeignKey(c => c.ContactID).WillCascadeOnDelete(false); // FK_ProjectContactUpdate_Person_ContactID_PersonID
            HasRequired(a => a.ContactRelationshipType).WithMany(b => b.ProjectContactUpdates).HasForeignKey(c => c.ContactRelationshipTypeID).WillCascadeOnDelete(false); // FK_ProjectContactUpdate_ContactRelationshipType_ContactRelationshipTypeID
        }
    }
}