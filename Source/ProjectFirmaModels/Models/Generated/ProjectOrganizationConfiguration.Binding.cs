//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ProjectOrganization]
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ProjectFirmaModels.Models
{
    public class ProjectOrganizationConfiguration : EntityTypeConfiguration<ProjectOrganization>
    {
        public ProjectOrganizationConfiguration() : this("dbo"){}

        public ProjectOrganizationConfiguration(string schema)
        {
            ToTable("ProjectOrganization", schema);
            HasKey(x => x.ProjectOrganizationID);
            Property(x => x.ProjectOrganizationID).HasColumnName(@"ProjectOrganizationID").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.TenantID).HasColumnName(@"TenantID").HasColumnType("int").IsRequired();
            Property(x => x.ProjectID).HasColumnName(@"ProjectID").HasColumnType("int").IsRequired();
            Property(x => x.OrganizationID).HasColumnName(@"OrganizationID").HasColumnType("int").IsRequired();
            Property(x => x.OrganizationRelationshipTypeID).HasColumnName(@"OrganizationRelationshipTypeID").HasColumnType("int").IsRequired();

            // Foreign keys
            HasRequired(a => a.Project).WithMany(b => b.ProjectOrganizations).HasForeignKey(c => c.ProjectID).WillCascadeOnDelete(false); // FK_ProjectOrganization_Project_ProjectID
            HasRequired(a => a.Organization).WithMany(b => b.ProjectOrganizations).HasForeignKey(c => c.OrganizationID).WillCascadeOnDelete(false); // FK_ProjectOrganization_Organization_OrganizationID
            HasRequired(a => a.OrganizationRelationshipType).WithMany(b => b.ProjectOrganizations).HasForeignKey(c => c.OrganizationRelationshipTypeID).WillCascadeOnDelete(false); // FK_ProjectOrganization_OrganizationRelationshipType_OrganizationRelationshipTypeID
        }
    }
}