//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[EvaluationCriterion]
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ProjectFirmaModels.Models
{
    public class EvaluationCriterionConfiguration : EntityTypeConfiguration<EvaluationCriterion>
    {
        public EvaluationCriterionConfiguration() : this("dbo"){}

        public EvaluationCriterionConfiguration(string schema)
        {
            ToTable("EvaluationCriterion", schema);
            HasKey(x => x.EvaluationCriterionID);
            Property(x => x.EvaluationCriterionID).HasColumnName(@"EvaluationCriterionID").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.TenantID).HasColumnName(@"TenantID").HasColumnType("int").IsRequired();
            Property(x => x.EvaluationID).HasColumnName(@"EvaluationID").HasColumnType("int").IsRequired();
            Property(x => x.EvaluationCriterionName).HasColumnName(@"EvaluationCriterionName").HasColumnType("varchar").IsRequired().IsUnicode(false).HasMaxLength(120);
            Property(x => x.EvaluationCriterionDefinition).HasColumnName(@"EvaluationCriterionDefinition").HasColumnType("varchar").IsRequired().IsUnicode(false).HasMaxLength(1000);

            // Foreign keys
            HasRequired(a => a.Evaluation).WithMany(b => b.EvaluationCriterions).HasForeignKey(c => c.EvaluationID).WillCascadeOnDelete(false); // FK_EvaluationCriterion_Evaluation_EvaluationID
        }
    }
}