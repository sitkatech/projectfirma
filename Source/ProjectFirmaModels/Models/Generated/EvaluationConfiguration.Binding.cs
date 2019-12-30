//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[Evaluation]
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ProjectFirmaModels.Models
{
    public class EvaluationConfiguration : EntityTypeConfiguration<Evaluation>
    {
        public EvaluationConfiguration() : this("dbo"){}

        public EvaluationConfiguration(string schema)
        {
            ToTable("Evaluation", schema);
            HasKey(x => x.EvaluationID);
            Property(x => x.EvaluationID).HasColumnName(@"EvaluationID").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.TenantID).HasColumnName(@"TenantID").HasColumnType("int").IsRequired();
            Property(x => x.EvaluationVisibilityID).HasColumnName(@"EvaluationVisibilityID").HasColumnType("int").IsRequired();
            Property(x => x.EvaluationStatusID).HasColumnName(@"EvaluationStatusID").HasColumnType("int").IsRequired();
            Property(x => x.CreatePersonID).HasColumnName(@"CreatePersonID").HasColumnType("int").IsRequired();
            Property(x => x.EvaluationName).HasColumnName(@"EvaluationName").HasColumnType("varchar").IsRequired().IsUnicode(false).HasMaxLength(120);
            Property(x => x.EvaluationDefinition).HasColumnName(@"EvaluationDefinition").HasColumnType("varchar").IsRequired().IsUnicode(false).HasMaxLength(1000);
            Property(x => x.EvaluationStartDate).HasColumnName(@"EvaluationStartDate").HasColumnType("datetime").IsOptional();
            Property(x => x.EvaluationEndDate).HasColumnName(@"EvaluationEndDate").HasColumnType("datetime").IsOptional();
            Property(x => x.CreateDate).HasColumnName(@"CreateDate").HasColumnType("datetime").IsRequired();

            // Foreign keys
            HasRequired(a => a.CreatePerson).WithMany(b => b.EvaluationsWhereYouAreTheCreatePerson).HasForeignKey(c => c.CreatePersonID).WillCascadeOnDelete(false); // FK_Evaluation_Person_CreatePersonID_PersonID
        }
    }
}