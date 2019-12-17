//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[EvaluationVisibility]
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ProjectFirmaModels.Models
{
    public class EvaluationVisibilityConfiguration : EntityTypeConfiguration<EvaluationVisibility>
    {
        public EvaluationVisibilityConfiguration() : this("dbo"){}

        public EvaluationVisibilityConfiguration(string schema)
        {
            ToTable("EvaluationVisibility", schema);
            HasKey(x => x.EvaluationVisibilityID);
            Property(x => x.EvaluationVisibilityID).HasColumnName(@"EvaluationVisibilityID").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.EvaluationVisibilityName).HasColumnName(@"EvaluationVisibilityName").HasColumnType("varchar").IsRequired().IsUnicode(false).HasMaxLength(100);
            Property(x => x.EvaluationVisibilityDisplayName).HasColumnName(@"EvaluationVisibilityDisplayName").HasColumnType("varchar").IsRequired().IsUnicode(false).HasMaxLength(100);

            // Foreign keys

        }
    }
}