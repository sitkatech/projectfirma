//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[FileResourceInfo]
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ProjectFirmaModels.Models
{
    public class FileResourceInfoConfiguration : EntityTypeConfiguration<FileResourceInfo>
    {
        public FileResourceInfoConfiguration() : this("dbo"){}

        public FileResourceInfoConfiguration(string schema)
        {
            ToTable("FileResourceInfo", schema);
            HasKey(x => x.FileResourceInfoID);
            Property(x => x.FileResourceInfoID).HasColumnName(@"FileResourceInfoID").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.TenantID).HasColumnName(@"TenantID").HasColumnType("int").IsRequired();
            Property(x => x.FileResourceMimeTypeID).HasColumnName(@"FileResourceMimeTypeID").HasColumnType("int").IsRequired();
            Property(x => x.OriginalBaseFilename).HasColumnName(@"OriginalBaseFilename").HasColumnType("varchar").IsRequired().IsUnicode(false).HasMaxLength(255);
            Property(x => x.OriginalFileExtension).HasColumnName(@"OriginalFileExtension").HasColumnType("varchar").IsRequired().IsUnicode(false).HasMaxLength(255);
            Property(x => x.FileResourceGUID).HasColumnName(@"FileResourceGUID").HasColumnType("uniqueidentifier").IsRequired();
            Property(x => x.CreatePersonID).HasColumnName(@"CreatePersonID").HasColumnType("int").IsRequired();
            Property(x => x.CreateDate).HasColumnName(@"CreateDate").HasColumnType("datetime").IsRequired();

            // Foreign keys
            HasRequired(a => a.CreatePerson).WithMany(b => b.FileResourceInfosWhereYouAreTheCreatePerson).HasForeignKey(c => c.CreatePersonID).WillCascadeOnDelete(false); // FK_FileResourceInfo_Person_CreatePersonID_PersonID
        }
    }
}