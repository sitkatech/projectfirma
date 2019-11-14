//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ProjectProjectStatus]
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ProjectFirmaModels.Models
{
    public class ProjectProjectStatusConfiguration : EntityTypeConfiguration<ProjectProjectStatus>
    {
        public ProjectProjectStatusConfiguration() : this("dbo"){}

        public ProjectProjectStatusConfiguration(string schema)
        {
            ToTable("ProjectProjectStatus", schema);
            HasKey(x => x.ProjectProjectStatusID);
            Property(x => x.ProjectProjectStatusID).HasColumnName(@"ProjectProjectStatusID").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.ProjectID).HasColumnName(@"ProjectID").HasColumnType("int").IsRequired();
            Property(x => x.ProjectStatusID).HasColumnName(@"ProjectStatusID").HasColumnType("int").IsRequired();
            Property(x => x.ProjectProjectStatusComment).HasColumnName(@"ProjectProjectStatusComment").HasColumnType("varchar").IsRequired().IsUnicode(false).HasMaxLength(2500);
            Property(x => x.ProjectProjectStatusCreatePersonID).HasColumnName(@"ProjectProjectStatusCreatePersonID").HasColumnType("int").IsRequired();
            Property(x => x.ProjectProjectStatusCreateDate).HasColumnName(@"ProjectProjectStatusCreateDate").HasColumnType("datetime").IsRequired();
            Property(x => x.ProjectProjectStatusLastUpdatedPersonID).HasColumnName(@"ProjectProjectStatusLastUpdatedPersonID").HasColumnType("int").IsOptional();
            Property(x => x.ProjectProjectStatusLastUpdatedDate).HasColumnName(@"ProjectProjectStatusLastUpdatedDate").HasColumnType("datetime").IsOptional();

            // Foreign keys
            HasRequired(a => a.Project).WithMany(b => b.ProjectProjectStatuses).HasForeignKey(c => c.ProjectID).WillCascadeOnDelete(false); // FK_ProjectProjectStatus_Project_ProjectID
            HasRequired(a => a.ProjectProjectStatusCreatePerson).WithMany(b => b.ProjectProjectStatusesWhereYouAreTheProjectProjectStatusCreatePerson).HasForeignKey(c => c.ProjectProjectStatusCreatePersonID).WillCascadeOnDelete(false); // FK_ProjectProjectStatus_Person_ProjectProjectStatusCreatePersonID_PersonID
            HasOptional(a => a.ProjectProjectStatusLastUpdatedPerson).WithMany(b => b.ProjectProjectStatusesWhereYouAreTheProjectProjectStatusLastUpdatedPerson).HasForeignKey(c => c.ProjectProjectStatusLastUpdatedPersonID).WillCascadeOnDelete(false); // FK_ProjectProjectStatus_Person_ProjectProjectStatusLastUpdatedPersonID_PersonID
        }
    }
}