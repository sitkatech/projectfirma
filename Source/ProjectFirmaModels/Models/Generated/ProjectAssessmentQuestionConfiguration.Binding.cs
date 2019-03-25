//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ProjectAssessmentQuestion]
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ProjectFirmaModels.Models
{
    public class ProjectAssessmentQuestionConfiguration : EntityTypeConfiguration<ProjectAssessmentQuestion>
    {
        public ProjectAssessmentQuestionConfiguration() : this("dbo"){}

        public ProjectAssessmentQuestionConfiguration(string schema)
        {
            ToTable("ProjectAssessmentQuestion", schema);
            HasKey(x => x.ProjectAssessmentQuestionID);
            Property(x => x.ProjectAssessmentQuestionID).HasColumnName(@"ProjectAssessmentQuestionID").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.TenantID).HasColumnName(@"TenantID").HasColumnType("int").IsRequired();
            Property(x => x.ProjectID).HasColumnName(@"ProjectID").HasColumnType("int").IsRequired();
            Property(x => x.AssessmentQuestionID).HasColumnName(@"AssessmentQuestionID").HasColumnType("int").IsRequired();
            Property(x => x.Answer).HasColumnName(@"Answer").HasColumnType("bit").IsOptional();

            // Foreign keys
            HasRequired(a => a.Project).WithMany(b => b.ProjectAssessmentQuestions).HasForeignKey(c => c.ProjectID).WillCascadeOnDelete(false); // FK_ProjectAssessmentQuestion_Project_ProjectID
            HasRequired(a => a.AssessmentQuestion).WithMany(b => b.ProjectAssessmentQuestions).HasForeignKey(c => c.AssessmentQuestionID).WillCascadeOnDelete(false); // FK_ProjectAssessmentQuestion_AssessmentQuestion_AssessmentQuestionID
        }
    }
}