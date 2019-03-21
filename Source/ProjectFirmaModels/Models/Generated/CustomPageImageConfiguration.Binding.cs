//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[CustomPageImage]
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ProjectFirmaModels.Models
{
    public class CustomPageImageConfiguration : EntityTypeConfiguration<CustomPageImage>
    {
        public CustomPageImageConfiguration() : this("dbo"){}

        public CustomPageImageConfiguration(string schema)
        {
            ToTable("CustomPageImage", schema);
            HasKey(x => x.CustomPageImageID);
            Property(x => x.CustomPageImageID).HasColumnName(@"CustomPageImageID").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.TenantID).HasColumnName(@"TenantID").HasColumnType("int").IsRequired();
            Property(x => x.CustomPageID).HasColumnName(@"CustomPageID").HasColumnType("int").IsRequired();
            Property(x => x.FileResourceID).HasColumnName(@"FileResourceID").HasColumnType("int").IsRequired();

            // Foreign keys
            HasRequired(a => a.CustomPage).WithMany(b => b.CustomPageImages).HasForeignKey(c => c.CustomPageID).WillCascadeOnDelete(false); // FK_CustomPageImage_CustomPage_CustomPageID
            HasRequired(a => a.FileResource).WithMany(b => b.CustomPageImages).HasForeignKey(c => c.FileResourceID).WillCascadeOnDelete(false); // FK_CustomPageImage_FileResource_FileResourceID
        }
    }
}