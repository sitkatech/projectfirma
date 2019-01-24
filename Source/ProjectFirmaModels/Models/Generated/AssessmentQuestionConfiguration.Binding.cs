//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[AssessmentQuestion]
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ProjectFirmaModels.Models
{
    public class AssessmentQuestionConfiguration : EntityTypeConfiguration<AssessmentQuestion>
    {
        public AssessmentQuestionConfiguration() : this("dbo"){}

        public AssessmentQuestionConfiguration(string schema)
        {
            ToTable("AssessmentQuestion", schema);
            HasKey(x => x.AssessmentQuestionID);
            Property(x => x.AssessmentQuestionID).HasColumnName(@"AssessmentQuestionID").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.TenantID).HasColumnName(@"TenantID").HasColumnType("int").IsRequired();
            Property(x => x.AssessmentSubGoalID).HasColumnName(@"AssessmentSubGoalID").HasColumnType("int").IsRequired();
            Property(x => x.AssessmentQuestionText).HasColumnName(@"AssessmentQuestionText").HasColumnType("varchar").IsRequired().IsUnicode(false).HasMaxLength(300);
            Property(x => x.ArchiveDate).HasColumnName(@"ArchiveDate").HasColumnType("date").IsOptional();

            // Foreign keys
            HasRequired(a => a.AssessmentSubGoal).WithMany(b => b.AssessmentQuestions).HasForeignKey(c => c.AssessmentSubGoalID).WillCascadeOnDelete(false); // FK_AssessmentQuestion_AssessmentSubGoal_AssessmentSubGoalID
        }
    }
}