//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[EvaluationCriteria]
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ProjectFirmaModels.Models
{
    public class EvaluationCriteriaConfiguration : EntityTypeConfiguration<EvaluationCriteria>
    {
        public EvaluationCriteriaConfiguration() : this("dbo"){}

        public EvaluationCriteriaConfiguration(string schema)
        {
            ToTable("EvaluationCriteria", schema);
            HasKey(x => x.EvaluationCriteriaID);
            Property(x => x.EvaluationCriteriaID).HasColumnName(@"EvaluationCriteriaID").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.TenantID).HasColumnName(@"TenantID").HasColumnType("int").IsRequired();
            Property(x => x.EvaluationID).HasColumnName(@"EvaluationID").HasColumnType("int").IsRequired();
            Property(x => x.EvaluationCriteriaName).HasColumnName(@"EvaluationCriteriaName").HasColumnType("varchar").IsRequired().IsUnicode(false).HasMaxLength(120);
            Property(x => x.EvaluationCriteriaDefinition).HasColumnName(@"EvaluationCriteriaDefinition").HasColumnType("varchar").IsRequired().IsUnicode(false).HasMaxLength(1000);

            // Foreign keys
            HasRequired(a => a.Evaluation).WithMany(b => b.EvaluationCriterias).HasForeignKey(c => c.EvaluationID).WillCascadeOnDelete(false); // FK_EvaluationCriteria_Evaluation_EvaluationID
        }
    }
}