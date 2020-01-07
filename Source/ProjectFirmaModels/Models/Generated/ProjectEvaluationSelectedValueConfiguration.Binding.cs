//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ProjectEvaluationSelectedValue]
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ProjectFirmaModels.Models
{
    public class ProjectEvaluationSelectedValueConfiguration : EntityTypeConfiguration<ProjectEvaluationSelectedValue>
    {
        public ProjectEvaluationSelectedValueConfiguration() : this("dbo"){}

        public ProjectEvaluationSelectedValueConfiguration(string schema)
        {
            ToTable("ProjectEvaluationSelectedValue", schema);
            HasKey(x => x.ProjectEvaluationSelectedValueID);
            Property(x => x.ProjectEvaluationSelectedValueID).HasColumnName(@"ProjectEvaluationSelectedValueID").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.TenantID).HasColumnName(@"TenantID").HasColumnType("int").IsRequired();
            Property(x => x.ProjectEvaluationID).HasColumnName(@"ProjectEvaluationID").HasColumnType("int").IsRequired();
            Property(x => x.EvaluationCriterionValueID).HasColumnName(@"EvaluationCriterionValueID").HasColumnType("int").IsRequired();

            // Foreign keys
            HasRequired(a => a.ProjectEvaluation).WithMany(b => b.ProjectEvaluationSelectedValues).HasForeignKey(c => c.ProjectEvaluationID).WillCascadeOnDelete(false); // FK_ProjectEvaluationSelectedValue_ProjectEvaluation_ProjectEvaluationID
            HasRequired(a => a.EvaluationCriterionValue).WithMany(b => b.ProjectEvaluationSelectedValues).HasForeignKey(c => c.EvaluationCriterionValueID).WillCascadeOnDelete(false); // FK_ProjectEvaluationSelectedValue_EvaluationCriterionValue_EvaluationCriterionValueID
        }
    }
}