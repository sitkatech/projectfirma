//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[DocumentLibraryDocumentCategory]
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ProjectFirmaModels.Models
{
    public class DocumentLibraryDocumentCategoryConfiguration : EntityTypeConfiguration<DocumentLibraryDocumentCategory>
    {
        public DocumentLibraryDocumentCategoryConfiguration() : this("dbo"){}

        public DocumentLibraryDocumentCategoryConfiguration(string schema)
        {
            ToTable("DocumentLibraryDocumentCategory", schema);
            HasKey(x => x.DocumentLibraryDocumentCategoryID);
            Property(x => x.DocumentLibraryDocumentCategoryID).HasColumnName(@"DocumentLibraryDocumentCategoryID").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.TenantID).HasColumnName(@"TenantID").HasColumnType("int").IsRequired();
            Property(x => x.DocumentLibraryID).HasColumnName(@"DocumentLibraryID").HasColumnType("int").IsRequired();
            Property(x => x.DocumentCategoryID).HasColumnName(@"DocumentCategoryID").HasColumnType("int").IsRequired();

            // Foreign keys
            HasRequired(a => a.DocumentLibrary).WithMany(b => b.DocumentLibraryDocumentCategories).HasForeignKey(c => c.DocumentLibraryID).WillCascadeOnDelete(false); // FK_DocumentLibraryDocumentCategory_DocumentLibrary_DocumentLibraryID
        }
    }
}