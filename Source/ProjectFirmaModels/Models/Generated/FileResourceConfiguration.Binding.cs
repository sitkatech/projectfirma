//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[FileResource]
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ProjectFirmaModels.Models
{
    public class FileResourceConfiguration : EntityTypeConfiguration<FileResource>
    {
        public FileResourceConfiguration() : this("dbo"){}

        public FileResourceConfiguration(string schema)
        {
            ToTable("FileResource", schema);
            HasKey(x => x.FileResourceID);
            Property(x => x.FileResourceID).HasColumnName(@"FileResourceID").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.TenantID).HasColumnName(@"TenantID").HasColumnType("int").IsRequired();
            Property(x => x.FileResourceMimeTypeID).HasColumnName(@"FileResourceMimeTypeID").HasColumnType("int").IsRequired();
            Property(x => x.OriginalBaseFilename).HasColumnName(@"OriginalBaseFilename").HasColumnType("varchar").IsRequired().IsUnicode(false).HasMaxLength(255);
            Property(x => x.OriginalFileExtension).HasColumnName(@"OriginalFileExtension").HasColumnType("varchar").IsRequired().IsUnicode(false).HasMaxLength(255);
            Property(x => x.FileResourceGUID).HasColumnName(@"FileResourceGUID").HasColumnType("uniqueidentifier").IsRequired();
            Property(x => x.CreatePersonID).HasColumnName(@"CreatePersonID").HasColumnType("int").IsRequired();
            Property(x => x.CreateDate).HasColumnName(@"CreateDate").HasColumnType("datetime").IsRequired();

            // Foreign keys
            HasRequired(a => a.CreatePerson).WithMany(b => b.FileResourcesWhereYouAreTheCreatePerson).HasForeignKey(c => c.CreatePersonID).WillCascadeOnDelete(false); // FK_FileResource_Person_CreatePersonID_PersonID
        }
    }
}