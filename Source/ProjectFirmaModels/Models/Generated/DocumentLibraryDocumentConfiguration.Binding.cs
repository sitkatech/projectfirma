//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[DocumentLibraryDocument]
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ProjectFirmaModels.Models
{
    public class DocumentLibraryDocumentConfiguration : EntityTypeConfiguration<DocumentLibraryDocument>
    {
        public DocumentLibraryDocumentConfiguration() : this("dbo"){}

        public DocumentLibraryDocumentConfiguration(string schema)
        {
            ToTable("DocumentLibraryDocument", schema);
            HasKey(x => x.DocumentLibraryDocumentID);
            Property(x => x.DocumentLibraryDocumentID).HasColumnName(@"DocumentLibraryDocumentID").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.TenantID).HasColumnName(@"TenantID").HasColumnType("int").IsRequired();
            Property(x => x.DocumentLibraryID).HasColumnName(@"DocumentLibraryID").HasColumnType("int").IsRequired();
            Property(x => x.DocumentCategoryID).HasColumnName(@"DocumentCategoryID").HasColumnType("int").IsRequired();
            Property(x => x.DocumentTitle).HasColumnName(@"DocumentTitle").HasColumnType("varchar").IsRequired().IsUnicode(false).HasMaxLength(200);
            Property(x => x.DocumentDescription).HasColumnName(@"DocumentDescription").HasColumnType("varchar").IsOptional().IsUnicode(false).HasMaxLength(1000);
            Property(x => x.FileResourceInfoID).HasColumnName(@"FileResourceInfoID").HasColumnType("int").IsRequired();
            Property(x => x.SortOrder).HasColumnName(@"SortOrder").HasColumnType("int").IsOptional();
            Property(x => x.LastUpdateDate).HasColumnName(@"LastUpdateDate").HasColumnType("datetime").IsRequired();
            Property(x => x.LastUpdatePersonID).HasColumnName(@"LastUpdatePersonID").HasColumnType("int").IsRequired();

            // Foreign keys
            HasRequired(a => a.DocumentLibrary).WithMany(b => b.DocumentLibraryDocuments).HasForeignKey(c => c.DocumentLibraryID).WillCascadeOnDelete(false); // FK_DocumentLibraryDocument_DocumentLibrary_DocumentLibraryID
            HasRequired(a => a.FileResourceInfo).WithMany(b => b.DocumentLibraryDocuments).HasForeignKey(c => c.FileResourceInfoID).WillCascadeOnDelete(false); // FK_DocumentLibraryDocument_FileResourceInfo_FileResourceInfoID
            HasRequired(a => a.LastUpdatePerson).WithMany(b => b.DocumentLibraryDocumentsWhereYouAreTheLastUpdatePerson).HasForeignKey(c => c.LastUpdatePersonID).WillCascadeOnDelete(false); // FK_DocumentLibraryDocument_Person_LastUpdatePersonID_PersonID
        }
    }
}