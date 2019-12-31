//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ProjectEvaluation]
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ProjectFirmaModels.Models
{
    public class ProjectEvaluationConfiguration : EntityTypeConfiguration<ProjectEvaluation>
    {
        public ProjectEvaluationConfiguration() : this("dbo"){}

        public ProjectEvaluationConfiguration(string schema)
        {
            ToTable("ProjectEvaluation", schema);
            HasKey(x => x.ProjectEvaluationID);
            Property(x => x.ProjectEvaluationID).HasColumnName(@"ProjectEvaluationID").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.TenantID).HasColumnName(@"TenantID").HasColumnType("int").IsRequired();
            Property(x => x.ProjectID).HasColumnName(@"ProjectID").HasColumnType("int").IsRequired();
            Property(x => x.EvaluationID).HasColumnName(@"EvaluationID").HasColumnType("int").IsRequired();
            Property(x => x.Comments).HasColumnName(@"Comments").HasColumnType("varchar").IsOptional().IsUnicode(false).HasMaxLength(1000);

            // Foreign keys
            HasRequired(a => a.Project).WithMany(b => b.ProjectEvaluations).HasForeignKey(c => c.ProjectID).WillCascadeOnDelete(false); // FK_ProjectEvaluation_Project_ProjectID
            HasRequired(a => a.Evaluation).WithMany(b => b.ProjectEvaluations).HasForeignKey(c => c.EvaluationID).WillCascadeOnDelete(false); // FK_ProjectEvaluation_Evaluation_EvaluationID
        }
    }
}