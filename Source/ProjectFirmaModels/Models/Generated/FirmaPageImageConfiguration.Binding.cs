//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[FirmaPageImage]
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ProjectFirmaModels.Models
{
    public class FirmaPageImageConfiguration : EntityTypeConfiguration<FirmaPageImage>
    {
        public FirmaPageImageConfiguration() : this("dbo"){}

        public FirmaPageImageConfiguration(string schema)
        {
            ToTable("FirmaPageImage", schema);
            HasKey(x => x.FirmaPageImageID);
            Property(x => x.FirmaPageImageID).HasColumnName(@"FirmaPageImageID").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.TenantID).HasColumnName(@"TenantID").HasColumnType("int").IsRequired();
            Property(x => x.FirmaPageID).HasColumnName(@"FirmaPageID").HasColumnType("int").IsRequired();
            Property(x => x.FileResourceID).HasColumnName(@"FileResourceID").HasColumnType("int").IsRequired();

            // Foreign keys
            HasRequired(a => a.FirmaPage).WithMany(b => b.FirmaPageImages).HasForeignKey(c => c.FirmaPageID).WillCascadeOnDelete(false); // FK_FirmaPageImage_FirmaPage_FirmaPageID
            HasRequired(a => a.FileResource).WithMany(b => b.FirmaPageImages).HasForeignKey(c => c.FileResourceID).WillCascadeOnDelete(false); // FK_FirmaPageImage_FileResource_FileResourceID
        }
    }
}