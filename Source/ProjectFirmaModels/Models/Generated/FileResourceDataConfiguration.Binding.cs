//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[FileResourceData]
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ProjectFirmaModels.Models
{
    public class FileResourceDataConfiguration : EntityTypeConfiguration<FileResourceData>
    {
        public FileResourceDataConfiguration() : this("dbo"){}

        public FileResourceDataConfiguration(string schema)
        {
            ToTable("FileResourceData", schema);
            HasKey(x => x.FileResourceDataID);
            Property(x => x.FileResourceDataID).HasColumnName(@"FileResourceDataID").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.TenantID).HasColumnName(@"TenantID").HasColumnType("int").IsRequired();
            Property(x => x.FileResourceInfoID).HasColumnName(@"FileResourceInfoID").HasColumnType("int").IsRequired();
            Property(x => x.Data).HasColumnName(@"Data").HasColumnType("varbinary").IsRequired();

            // Foreign keys
            HasRequired(a => a.FileResourceInfo).WithMany(b => b.FileResourceDatas).HasForeignKey(c => c.FileResourceInfoID).WillCascadeOnDelete(false); // FK_FileResourceData_FileResourceInfo_FileResourceInfoID
        }
    }
}