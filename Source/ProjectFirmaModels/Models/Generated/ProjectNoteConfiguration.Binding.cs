//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ProjectNote]
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ProjectFirmaModels.Models
{
    public class ProjectNoteConfiguration : EntityTypeConfiguration<ProjectNote>
    {
        public ProjectNoteConfiguration() : this("dbo"){}

        public ProjectNoteConfiguration(string schema)
        {
            ToTable("ProjectNote", schema);
            HasKey(x => x.ProjectNoteID);
            Property(x => x.ProjectNoteID).HasColumnName(@"ProjectNoteID").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.TenantID).HasColumnName(@"TenantID").HasColumnType("int").IsRequired();
            Property(x => x.ProjectID).HasColumnName(@"ProjectID").HasColumnType("int").IsRequired();
            Property(x => x.Note).HasColumnName(@"Note").HasColumnType("varchar").IsRequired().IsUnicode(false).HasMaxLength(8000);
            Property(x => x.CreatePersonID).HasColumnName(@"CreatePersonID").HasColumnType("int").IsOptional();
            Property(x => x.CreateDate).HasColumnName(@"CreateDate").HasColumnType("datetime").IsRequired();
            Property(x => x.UpdatePersonID).HasColumnName(@"UpdatePersonID").HasColumnType("int").IsOptional();
            Property(x => x.UpdateDate).HasColumnName(@"UpdateDate").HasColumnType("datetime").IsOptional();

            // Foreign keys
            HasRequired(a => a.Project).WithMany(b => b.ProjectNotes).HasForeignKey(c => c.ProjectID).WillCascadeOnDelete(false); // FK_ProjectNote_Project_ProjectID
            HasOptional(a => a.CreatePerson).WithMany(b => b.ProjectNotesWhereYouAreTheCreatePerson).HasForeignKey(c => c.CreatePersonID).WillCascadeOnDelete(false); // FK_ProjectNote_Person_CreatePersonID_PersonID
            HasOptional(a => a.UpdatePerson).WithMany(b => b.ProjectNotesWhereYouAreTheUpdatePerson).HasForeignKey(c => c.UpdatePersonID).WillCascadeOnDelete(false); // FK_ProjectNote_Person_UpdatePersonID_PersonID
        }
    }
}