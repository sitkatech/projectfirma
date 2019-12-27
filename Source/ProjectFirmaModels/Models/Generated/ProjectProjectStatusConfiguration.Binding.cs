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
            Property(x => x.TenantID).HasColumnName(@"TenantID").HasColumnType("int").IsRequired();
            Property(x => x.ProjectID).HasColumnName(@"ProjectID").HasColumnType("int").IsRequired();
            Property(x => x.ProjectStatusID).HasColumnName(@"ProjectStatusID").HasColumnType("int").IsRequired();
            Property(x => x.ProjectProjectStatusUpdateDate).HasColumnName(@"ProjectProjectStatusUpdateDate").HasColumnType("datetime").IsRequired();
            Property(x => x.ProjectProjectStatusComment).HasColumnName(@"ProjectProjectStatusComment").HasColumnType("varchar").IsRequired().IsUnicode(false).HasMaxLength(2500);
            Property(x => x.ProjectProjectStatusCreatePersonID).HasColumnName(@"ProjectProjectStatusCreatePersonID").HasColumnType("int").IsRequired();
            Property(x => x.ProjectProjectStatusCreateDate).HasColumnName(@"ProjectProjectStatusCreateDate").HasColumnType("datetime").IsRequired();
            Property(x => x.ProjectProjectStatusLastEditedPersonID).HasColumnName(@"ProjectProjectStatusLastEditedPersonID").HasColumnType("int").IsOptional();
            Property(x => x.ProjectProjectStatusLastEditedDate).HasColumnName(@"ProjectProjectStatusLastEditedDate").HasColumnType("datetime").IsOptional();
            Property(x => x.IsFinalStatusUpdate).HasColumnName(@"IsFinalStatusUpdate").HasColumnType("bit").IsRequired();
            Property(x => x.LessonsLearned).HasColumnName(@"LessonsLearned").HasColumnType("varchar").IsOptional().IsUnicode(false).HasMaxLength(2500);

            // Foreign keys
            HasRequired(a => a.Project).WithMany(b => b.ProjectProjectStatuses).HasForeignKey(c => c.ProjectID).WillCascadeOnDelete(false); // FK_ProjectProjectStatus_Project_ProjectID
            HasRequired(a => a.ProjectStatus).WithMany(b => b.ProjectProjectStatuses).HasForeignKey(c => c.ProjectStatusID).WillCascadeOnDelete(false); // FK_ProjectProjectStatus_ProjectStatus_ProjectStatusID
            HasRequired(a => a.ProjectProjectStatusCreatePerson).WithMany(b => b.ProjectProjectStatusesWhereYouAreTheProjectProjectStatusCreatePerson).HasForeignKey(c => c.ProjectProjectStatusCreatePersonID).WillCascadeOnDelete(false); // FK_ProjectProjectStatus_Person_ProjectProjectStatusCreatePersonID_PersonID
            HasOptional(a => a.ProjectProjectStatusLastEditedPerson).WithMany(b => b.ProjectProjectStatusesWhereYouAreTheProjectProjectStatusLastEditedPerson).HasForeignKey(c => c.ProjectProjectStatusLastEditedPersonID).WillCascadeOnDelete(false); // FK_ProjectProjectStatus_Person_ProjectProjectStatusLastEditedPersonID_PersonID
        }
    }
}