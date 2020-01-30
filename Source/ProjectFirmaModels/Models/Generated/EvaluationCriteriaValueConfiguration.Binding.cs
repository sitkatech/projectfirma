//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[EvaluationCriteriaValue]
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ProjectFirmaModels.Models
{
    public class EvaluationCriteriaValueConfiguration : EntityTypeConfiguration<EvaluationCriteriaValue>
    {
        public EvaluationCriteriaValueConfiguration() : this("dbo"){}

        public EvaluationCriteriaValueConfiguration(string schema)
        {
            ToTable("EvaluationCriteriaValue", schema);
            HasKey(x => x.EvaluationCriteriaValueID);
            Property(x => x.EvaluationCriteriaValueID).HasColumnName(@"EvaluationCriteriaValueID").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.TenantID).HasColumnName(@"TenantID").HasColumnType("int").IsRequired();
            Property(x => x.EvaluationCriteriaID).HasColumnName(@"EvaluationCriteriaID").HasColumnType("int").IsRequired();
            Property(x => x.EvaluationCriteriaValueRating).HasColumnName(@"EvaluationCriteriaValueRating").HasColumnType("varchar").IsRequired().IsUnicode(false).HasMaxLength(60);
            Property(x => x.EvaluationCriteriaValueDescription).HasColumnName(@"EvaluationCriteriaValueDescription").HasColumnType("varchar").IsRequired().IsUnicode(false).HasMaxLength(500);
            Property(x => x.SortOrder).HasColumnName(@"SortOrder").HasColumnType("int").IsOptional();

            // Foreign keys
            HasRequired(a => a.EvaluationCriteria).WithMany(b => b.EvaluationCriteriaValues).HasForeignKey(c => c.EvaluationCriteriaID).WillCascadeOnDelete(false); // FK_EvaluationCriteriaValue_EvaluationCriteria_EvaluationCriteriaID
        }
    }
}