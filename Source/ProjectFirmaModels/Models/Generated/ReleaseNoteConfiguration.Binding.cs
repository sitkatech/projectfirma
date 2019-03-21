//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ReleaseNote]
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ProjectFirmaModels.Models
{
    public class ReleaseNoteConfiguration : EntityTypeConfiguration<ReleaseNote>
    {
        public ReleaseNoteConfiguration() : this("dbo"){}

        public ReleaseNoteConfiguration(string schema)
        {
            ToTable("ReleaseNote", schema);
            HasKey(x => x.ReleaseNoteID);
            Property(x => x.ReleaseNoteID).HasColumnName(@"ReleaseNoteID").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.Note).HasColumnName(@"Note").HasColumnType("varchar").IsRequired();
            Property(x => x.CreatePersonID).HasColumnName(@"CreatePersonID").HasColumnType("int").IsRequired();
            Property(x => x.CreateDate).HasColumnName(@"CreateDate").HasColumnType("datetime").IsRequired();
            Property(x => x.UpdatePersonID).HasColumnName(@"UpdatePersonID").HasColumnType("int").IsOptional();
            Property(x => x.UpdateDate).HasColumnName(@"UpdateDate").HasColumnType("datetime").IsOptional();

            // Foreign keys
            HasRequired(a => a.CreatePerson).WithMany(b => b.ReleaseNotesWhereYouAreTheCreatePerson).HasForeignKey(c => c.CreatePersonID).WillCascadeOnDelete(false); // FK_ReleaseNote_Person_CreatePersonID_PersonID
            HasOptional(a => a.UpdatePerson).WithMany(b => b.ReleaseNotesWhereYouAreTheUpdatePerson).HasForeignKey(c => c.UpdatePersonID).WillCascadeOnDelete(false); // FK_ReleaseNote_Person_UpdatePersonID_PersonID
        }
    }
}