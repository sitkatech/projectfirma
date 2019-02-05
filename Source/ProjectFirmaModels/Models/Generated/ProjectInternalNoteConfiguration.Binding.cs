//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ProjectInternalNote]
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ProjectFirmaModels.Models
{
    public class ProjectInternalNoteConfiguration : EntityTypeConfiguration<ProjectInternalNote>
    {
        public ProjectInternalNoteConfiguration() : this("dbo"){}

        public ProjectInternalNoteConfiguration(string schema)
        {
            ToTable("ProjectInternalNote", schema);
            HasKey(x => x.ProjectInternalNoteID);
            Property(x => x.ProjectInternalNoteID).HasColumnName(@"ProjectInternalNoteID").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.TenantID).HasColumnName(@"TenantID").HasColumnType("int").IsRequired();
            Property(x => x.ProjectID).HasColumnName(@"ProjectID").HasColumnType("int").IsRequired();
            Property(x => x.Note).HasColumnName(@"Note").HasColumnType("varchar").IsRequired().IsUnicode(false).HasMaxLength(8000);
            Property(x => x.CreatePersonID).HasColumnName(@"CreatePersonID").HasColumnType("int").IsOptional();
            Property(x => x.CreateDate).HasColumnName(@"CreateDate").HasColumnType("datetime").IsRequired();
            Property(x => x.UpdatePersonID).HasColumnName(@"UpdatePersonID").HasColumnType("int").IsOptional();
            Property(x => x.UpdateDate).HasColumnName(@"UpdateDate").HasColumnType("datetime").IsOptional();

            // Foreign keys
            HasRequired(a => a.Project).WithMany(b => b.ProjectInternalNotes).HasForeignKey(c => c.ProjectID).WillCascadeOnDelete(false); // FK_ProjectInternalNote_Project_ProjectID
            HasOptional(a => a.CreatePerson).WithMany(b => b.ProjectInternalNotesWhereYouAreTheCreatePerson).HasForeignKey(c => c.CreatePersonID).WillCascadeOnDelete(false); // FK_ProjectInternalNote_Person_CreatePersonID_PersonID
            HasOptional(a => a.UpdatePerson).WithMany(b => b.ProjectInternalNotesWhereYouAreTheUpdatePerson).HasForeignKey(c => c.UpdatePersonID).WillCascadeOnDelete(false); // FK_ProjectInternalNote_Person_UpdatePersonID_PersonID
        }
    }
}