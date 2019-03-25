//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[PerformanceMeasureNote]
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ProjectFirmaModels.Models
{
    public class PerformanceMeasureNoteConfiguration : EntityTypeConfiguration<PerformanceMeasureNote>
    {
        public PerformanceMeasureNoteConfiguration() : this("dbo"){}

        public PerformanceMeasureNoteConfiguration(string schema)
        {
            ToTable("PerformanceMeasureNote", schema);
            HasKey(x => x.PerformanceMeasureNoteID);
            Property(x => x.PerformanceMeasureNoteID).HasColumnName(@"PerformanceMeasureNoteID").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.TenantID).HasColumnName(@"TenantID").HasColumnType("int").IsRequired();
            Property(x => x.PerformanceMeasureID).HasColumnName(@"PerformanceMeasureID").HasColumnType("int").IsRequired();
            Property(x => x.Note).HasColumnName(@"Note").HasColumnType("varchar").IsRequired().IsUnicode(false).HasMaxLength(8000);
            Property(x => x.CreatePersonID).HasColumnName(@"CreatePersonID").HasColumnType("int").IsOptional();
            Property(x => x.CreateDate).HasColumnName(@"CreateDate").HasColumnType("datetime").IsRequired();
            Property(x => x.UpdatePersonID).HasColumnName(@"UpdatePersonID").HasColumnType("int").IsOptional();
            Property(x => x.UpdateDate).HasColumnName(@"UpdateDate").HasColumnType("datetime").IsOptional();

            // Foreign keys
            HasRequired(a => a.PerformanceMeasure).WithMany(b => b.PerformanceMeasureNotes).HasForeignKey(c => c.PerformanceMeasureID).WillCascadeOnDelete(false); // FK_PerformanceMeasureNote_PerformanceMeasure_PerformanceMeasureID
            HasOptional(a => a.CreatePerson).WithMany(b => b.PerformanceMeasureNotesWhereYouAreTheCreatePerson).HasForeignKey(c => c.CreatePersonID).WillCascadeOnDelete(false); // FK_PerformanceMeasureNote_Person_CreatePersonID_PersonID
            HasOptional(a => a.UpdatePerson).WithMany(b => b.PerformanceMeasureNotesWhereYouAreTheUpdatePerson).HasForeignKey(c => c.UpdatePersonID).WillCascadeOnDelete(false); // FK_PerformanceMeasureNote_Person_UpdatePersonID_PersonID
        }
    }
}