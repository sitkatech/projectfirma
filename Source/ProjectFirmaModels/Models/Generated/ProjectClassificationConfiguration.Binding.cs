//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ProjectClassification]
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ProjectFirmaModels.Models
{
    public class ProjectClassificationConfiguration : EntityTypeConfiguration<ProjectClassification>
    {
        public ProjectClassificationConfiguration() : this("dbo"){}

        public ProjectClassificationConfiguration(string schema)
        {
            ToTable("ProjectClassification", schema);
            HasKey(x => x.ProjectClassificationID);
            Property(x => x.ProjectClassificationID).HasColumnName(@"ProjectClassificationID").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.TenantID).HasColumnName(@"TenantID").HasColumnType("int").IsRequired();
            Property(x => x.ProjectID).HasColumnName(@"ProjectID").HasColumnType("int").IsRequired();
            Property(x => x.ClassificationID).HasColumnName(@"ClassificationID").HasColumnType("int").IsRequired();
            Property(x => x.ProjectClassificationNotes).HasColumnName(@"ProjectClassificationNotes").HasColumnType("varchar").IsOptional().IsUnicode(false).HasMaxLength(600);

            // Foreign keys
            HasRequired(a => a.Project).WithMany(b => b.ProjectClassifications).HasForeignKey(c => c.ProjectID).WillCascadeOnDelete(false); // FK_ProjectClassification_Project_ProjectID
            HasRequired(a => a.Classification).WithMany(b => b.ProjectClassifications).HasForeignKey(c => c.ClassificationID).WillCascadeOnDelete(false); // FK_ProjectClassification_Classification_ClassificationID
        }
    }
}