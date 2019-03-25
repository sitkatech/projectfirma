//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[AssessmentSubGoal]
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ProjectFirmaModels.Models
{
    public class AssessmentSubGoalConfiguration : EntityTypeConfiguration<AssessmentSubGoal>
    {
        public AssessmentSubGoalConfiguration() : this("dbo"){}

        public AssessmentSubGoalConfiguration(string schema)
        {
            ToTable("AssessmentSubGoal", schema);
            HasKey(x => x.AssessmentSubGoalID);
            Property(x => x.AssessmentSubGoalID).HasColumnName(@"AssessmentSubGoalID").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.TenantID).HasColumnName(@"TenantID").HasColumnType("int").IsRequired();
            Property(x => x.AssessmentGoalID).HasColumnName(@"AssessmentGoalID").HasColumnType("int").IsRequired();
            Property(x => x.AssessmentSubGoalNumber).HasColumnName(@"AssessmentSubGoalNumber").HasColumnType("int").IsRequired();
            Property(x => x.AssessmentSubGoalTitle).HasColumnName(@"AssessmentSubGoalTitle").HasColumnType("varchar").IsOptional().IsUnicode(false).HasMaxLength(100);
            Property(x => x.AssessmentSubGoalDescription).HasColumnName(@"AssessmentSubGoalDescription").HasColumnType("varchar").IsOptional().IsUnicode(false).HasMaxLength(300);

            // Foreign keys
            HasRequired(a => a.AssessmentGoal).WithMany(b => b.AssessmentSubGoals).HasForeignKey(c => c.AssessmentGoalID).WillCascadeOnDelete(false); // FK_AssessmentSubGoal_AssessmentGoal_AssessmentGoalID
        }
    }
}