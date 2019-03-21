//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[FirmaHomePageImage]
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ProjectFirmaModels.Models
{
    public class FirmaHomePageImageConfiguration : EntityTypeConfiguration<FirmaHomePageImage>
    {
        public FirmaHomePageImageConfiguration() : this("dbo"){}

        public FirmaHomePageImageConfiguration(string schema)
        {
            ToTable("FirmaHomePageImage", schema);
            HasKey(x => x.FirmaHomePageImageID);
            Property(x => x.FirmaHomePageImageID).HasColumnName(@"FirmaHomePageImageID").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.TenantID).HasColumnName(@"TenantID").HasColumnType("int").IsRequired();
            Property(x => x.FileResourceID).HasColumnName(@"FileResourceID").HasColumnType("int").IsRequired();
            Property(x => x.Caption).HasColumnName(@"Caption").HasColumnType("varchar").IsRequired().IsUnicode(false).HasMaxLength(300);
            Property(x => x.SortOrder).HasColumnName(@"SortOrder").HasColumnType("int").IsRequired();

            // Foreign keys
            HasRequired(a => a.FileResource).WithMany(b => b.FirmaHomePageImages).HasForeignKey(c => c.FileResourceID).WillCascadeOnDelete(false); // FK_FirmaHomePageImage_FileResource_FileResourceID
        }
    }
}