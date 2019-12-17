//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[EvaluationStatus]
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ProjectFirmaModels.Models
{
    public class EvaluationStatusConfiguration : EntityTypeConfiguration<EvaluationStatus>
    {
        public EvaluationStatusConfiguration() : this("dbo"){}

        public EvaluationStatusConfiguration(string schema)
        {
            ToTable("EvaluationStatus", schema);
            HasKey(x => x.EvaluationStatusID);
            Property(x => x.EvaluationStatusID).HasColumnName(@"EvaluationStatusID").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.EvaluationStatusName).HasColumnName(@"EvaluationStatusName").HasColumnType("varchar").IsRequired().IsUnicode(false).HasMaxLength(100);
            Property(x => x.EvaluationStatusDisplayName).HasColumnName(@"EvaluationStatusDisplayName").HasColumnType("varchar").IsRequired().IsUnicode(false).HasMaxLength(100);

            // Foreign keys

        }
    }
}