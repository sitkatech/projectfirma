//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[EvaluationCriterionValue]
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ProjectFirmaModels.Models
{
    public class EvaluationCriterionValueConfiguration : EntityTypeConfiguration<EvaluationCriterionValue>
    {
        public EvaluationCriterionValueConfiguration() : this("dbo"){}

        public EvaluationCriterionValueConfiguration(string schema)
        {
            ToTable("EvaluationCriterionValue", schema);
            HasKey(x => x.EvaluationCriterionValueID);
            Property(x => x.EvaluationCriterionValueID).HasColumnName(@"EvaluationCriterionValueID").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.TenantID).HasColumnName(@"TenantID").HasColumnType("int").IsRequired();
            Property(x => x.EvaluationCriterionID).HasColumnName(@"EvaluationCriterionID").HasColumnType("int").IsRequired();
            Property(x => x.EvaluationCriterionValueRating).HasColumnName(@"EvaluationCriterionValueRating").HasColumnType("varchar").IsRequired().IsUnicode(false).HasMaxLength(60);
            Property(x => x.EvaluationCriterionValueDescription).HasColumnName(@"EvaluationCriterionValueDescription").HasColumnType("varchar").IsRequired().IsUnicode(false).HasMaxLength(500);
            Property(x => x.SortOrder).HasColumnName(@"SortOrder").HasColumnType("int").IsOptional();

            // Foreign keys
            HasRequired(a => a.EvaluationCriterion).WithMany(b => b.EvaluationCriterionValues).HasForeignKey(c => c.EvaluationCriterionID).WillCascadeOnDelete(false); // FK_EvaluationCriterionValue_EvaluationCriterion_EvaluationCriterionID
        }
    }
}