//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[PerformanceMeasureImage]
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ProjectFirmaModels.Models
{
    public class PerformanceMeasureImageConfiguration : EntityTypeConfiguration<PerformanceMeasureImage>
    {
        public PerformanceMeasureImageConfiguration() : this("dbo"){}

        public PerformanceMeasureImageConfiguration(string schema)
        {
            ToTable("PerformanceMeasureImage", schema);
            HasKey(x => x.PerformanceMeasureImageID);
            Property(x => x.PerformanceMeasureImageID).HasColumnName(@"PerformanceMeasureImageID").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.TenantID).HasColumnName(@"TenantID").HasColumnType("int").IsRequired();
            Property(x => x.PerformanceMeasureID).HasColumnName(@"PerformanceMeasureID").HasColumnType("int").IsRequired();
            Property(x => x.FileResourceInfoID).HasColumnName(@"FileResourceInfoID").HasColumnType("int").IsRequired();

            // Foreign keys
            HasRequired(a => a.PerformanceMeasure).WithMany(b => b.PerformanceMeasureImages).HasForeignKey(c => c.PerformanceMeasureID).WillCascadeOnDelete(false); // FK_PerformanceMeasureImage_PerformanceMeasure_PerformanceMeasureID
            HasRequired(a => a.FileResourceInfo).WithMany(b => b.PerformanceMeasureImages).HasForeignKey(c => c.FileResourceInfoID).WillCascadeOnDelete(false); // FK_PerformanceMeasureImage_FileResourceInfo_FileResourceInfoID
        }
    }
}