//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[AssessmentGoal]
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ProjectFirmaModels.Models
{
    public class AssessmentGoalConfiguration : EntityTypeConfiguration<AssessmentGoal>
    {
        public AssessmentGoalConfiguration() : this("dbo"){}

        public AssessmentGoalConfiguration(string schema)
        {
            ToTable("AssessmentGoal", schema);
            HasKey(x => x.AssessmentGoalID);
            Property(x => x.AssessmentGoalID).HasColumnName(@"AssessmentGoalID").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.TenantID).HasColumnName(@"TenantID").HasColumnType("int").IsRequired();
            Property(x => x.AssessmentGoalNumber).HasColumnName(@"AssessmentGoalNumber").HasColumnType("int").IsRequired();
            Property(x => x.AssessmentGoalTitle).HasColumnName(@"AssessmentGoalTitle").HasColumnType("varchar").IsOptional().IsUnicode(false).HasMaxLength(100);
            Property(x => x.AssessmentGoalDescription).HasColumnName(@"AssessmentGoalDescription").HasColumnType("varchar").IsOptional().IsUnicode(false).HasMaxLength(300);

            // Foreign keys

        }
    }
}