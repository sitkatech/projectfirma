//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ProjectClassificationUpdate]
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ProjectFirmaModels.Models
{
    public class ProjectClassificationUpdateConfiguration : EntityTypeConfiguration<ProjectClassificationUpdate>
    {
        public ProjectClassificationUpdateConfiguration() : this("dbo"){}

        public ProjectClassificationUpdateConfiguration(string schema)
        {
            ToTable("ProjectClassificationUpdate", schema);
            HasKey(x => x.ProjectClassificationUpdateID);
            Property(x => x.ProjectClassificationUpdateID).HasColumnName(@"ProjectClassificationUpdateID").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.TenantID).HasColumnName(@"TenantID").HasColumnType("int").IsRequired();
            Property(x => x.ProjectUpdateBatchID).HasColumnName(@"ProjectUpdateBatchID").HasColumnType("int").IsRequired();
            Property(x => x.ClassificationID).HasColumnName(@"ClassificationID").HasColumnType("int").IsRequired();
            Property(x => x.ProjectClassificationUpdateNotes).HasColumnName(@"ProjectClassificationUpdateNotes").HasColumnType("varchar").IsOptional().IsUnicode(false).HasMaxLength(600);

            // Foreign keys
            HasRequired(a => a.ProjectUpdateBatch).WithMany(b => b.ProjectClassificationUpdates).HasForeignKey(c => c.ProjectUpdateBatchID).WillCascadeOnDelete(false); // FK_ProjectClassificationUpdate_ProjectUpdateBatch_ProjectUpdateBatchID
            HasRequired(a => a.Classification).WithMany(b => b.ProjectClassificationUpdates).HasForeignKey(c => c.ClassificationID).WillCascadeOnDelete(false); // FK_ProjectClassificationUpdate_Classification_ClassificationID
        }
    }
}