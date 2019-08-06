//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ProjectOrganizationUpdate]
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ProjectFirmaModels.Models
{
    public class ProjectOrganizationUpdateConfiguration : EntityTypeConfiguration<ProjectOrganizationUpdate>
    {
        public ProjectOrganizationUpdateConfiguration() : this("dbo"){}

        public ProjectOrganizationUpdateConfiguration(string schema)
        {
            ToTable("ProjectOrganizationUpdate", schema);
            HasKey(x => x.ProjectOrganizationUpdateID);
            Property(x => x.ProjectOrganizationUpdateID).HasColumnName(@"ProjectOrganizationUpdateID").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.TenantID).HasColumnName(@"TenantID").HasColumnType("int").IsRequired();
            Property(x => x.ProjectUpdateBatchID).HasColumnName(@"ProjectUpdateBatchID").HasColumnType("int").IsRequired();
            Property(x => x.OrganizationID).HasColumnName(@"OrganizationID").HasColumnType("int").IsRequired();
            Property(x => x.OrganizationRelationshipTypeID).HasColumnName(@"OrganizationRelationshipTypeID").HasColumnType("int").IsRequired();

            // Foreign keys
            HasRequired(a => a.ProjectUpdateBatch).WithMany(b => b.ProjectOrganizationUpdates).HasForeignKey(c => c.ProjectUpdateBatchID).WillCascadeOnDelete(false); // FK_ProjectOrganizationUpdate_ProjectUpdateBatch_ProjectUpdateBatchID
            HasRequired(a => a.Organization).WithMany(b => b.ProjectOrganizationUpdates).HasForeignKey(c => c.OrganizationID).WillCascadeOnDelete(false); // FK_ProjectOrganizationUpdate_Organization_OrganizationID
            HasRequired(a => a.OrganizationRelationshipType).WithMany(b => b.ProjectOrganizationUpdates).HasForeignKey(c => c.OrganizationRelationshipTypeID).WillCascadeOnDelete(false); // FK_ProjectOrganizationUpdate_OrganizationRelationshipType_OrganizationRelationshipTypeID
        }
    }
}