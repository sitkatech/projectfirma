//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ProjectUpdateHistory]
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ProjectFirmaModels.Models
{
    public class ProjectUpdateHistoryConfiguration : EntityTypeConfiguration<ProjectUpdateHistory>
    {
        public ProjectUpdateHistoryConfiguration() : this("dbo"){}

        public ProjectUpdateHistoryConfiguration(string schema)
        {
            ToTable("ProjectUpdateHistory", schema);
            HasKey(x => x.ProjectUpdateHistoryID);
            Property(x => x.ProjectUpdateHistoryID).HasColumnName(@"ProjectUpdateHistoryID").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.TenantID).HasColumnName(@"TenantID").HasColumnType("int").IsRequired();
            Property(x => x.ProjectUpdateBatchID).HasColumnName(@"ProjectUpdateBatchID").HasColumnType("int").IsRequired();
            Property(x => x.ProjectUpdateStateID).HasColumnName(@"ProjectUpdateStateID").HasColumnType("int").IsRequired();
            Property(x => x.UpdatePersonID).HasColumnName(@"UpdatePersonID").HasColumnType("int").IsRequired();
            Property(x => x.TransitionDate).HasColumnName(@"TransitionDate").HasColumnType("datetime").IsRequired();

            // Foreign keys
            HasRequired(a => a.ProjectUpdateBatch).WithMany(b => b.ProjectUpdateHistories).HasForeignKey(c => c.ProjectUpdateBatchID).WillCascadeOnDelete(false); // FK_ProjectUpdateHistory_ProjectUpdateBatch_ProjectUpdateBatchID
            HasRequired(a => a.UpdatePerson).WithMany(b => b.ProjectUpdateHistoriesWhereYouAreTheUpdatePerson).HasForeignKey(c => c.UpdatePersonID).WillCascadeOnDelete(false); // FK_ProjectUpdateHistory_Person_UpdatePersonID_PersonID
        }
    }
}