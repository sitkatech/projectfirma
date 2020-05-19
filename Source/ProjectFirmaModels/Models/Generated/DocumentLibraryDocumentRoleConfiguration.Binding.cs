//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[DocumentLibraryDocumentRole]
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ProjectFirmaModels.Models
{
    public class DocumentLibraryDocumentRoleConfiguration : EntityTypeConfiguration<DocumentLibraryDocumentRole>
    {
        public DocumentLibraryDocumentRoleConfiguration() : this("dbo"){}

        public DocumentLibraryDocumentRoleConfiguration(string schema)
        {
            ToTable("DocumentLibraryDocumentRole", schema);
            HasKey(x => x.DocumentLibraryDocumentRoleID);
            Property(x => x.DocumentLibraryDocumentRoleID).HasColumnName(@"DocumentLibraryDocumentRoleID").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.TenantID).HasColumnName(@"TenantID").HasColumnType("int").IsRequired();
            Property(x => x.DocumentLibraryDocumentID).HasColumnName(@"DocumentLibraryDocumentID").HasColumnType("int").IsRequired();
            Property(x => x.RoleID).HasColumnName(@"RoleID").HasColumnType("int").IsOptional();

            // Foreign keys
            HasRequired(a => a.DocumentLibraryDocument).WithMany(b => b.DocumentLibraryDocumentRoles).HasForeignKey(c => c.DocumentLibraryDocumentID).WillCascadeOnDelete(false); // FK_DocumentLibraryDocumentRole_DocumentLibraryDocument_DocumentLibraryDocumentID
        }
    }
}