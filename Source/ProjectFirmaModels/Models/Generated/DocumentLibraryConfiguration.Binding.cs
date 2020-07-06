//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[DocumentLibrary]
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ProjectFirmaModels.Models
{
    public class DocumentLibraryConfiguration : EntityTypeConfiguration<DocumentLibrary>
    {
        public DocumentLibraryConfiguration() : this("dbo"){}

        public DocumentLibraryConfiguration(string schema)
        {
            ToTable("DocumentLibrary", schema);
            HasKey(x => x.DocumentLibraryID);
            Property(x => x.DocumentLibraryID).HasColumnName(@"DocumentLibraryID").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.TenantID).HasColumnName(@"TenantID").HasColumnType("int").IsRequired();
            Property(x => x.DocumentLibraryName).HasColumnName(@"DocumentLibraryName").HasColumnType("varchar").IsRequired().IsUnicode(false).HasMaxLength(200);
            Property(x => x.DocumentLibraryDescription).HasColumnName(@"DocumentLibraryDescription").HasColumnType("varchar").IsOptional().IsUnicode(false).HasMaxLength(500);

            // Foreign keys

        }
    }
}