//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[GeospatialAreaImage]
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ProjectFirmaModels.Models
{
    public class GeospatialAreaImageConfiguration : EntityTypeConfiguration<GeospatialAreaImage>
    {
        public GeospatialAreaImageConfiguration() : this("dbo"){}

        public GeospatialAreaImageConfiguration(string schema)
        {
            ToTable("GeospatialAreaImage", schema);
            HasKey(x => x.GeospatialAreaImageID);
            Property(x => x.GeospatialAreaImageID).HasColumnName(@"GeospatialAreaImageID").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.TenantID).HasColumnName(@"TenantID").HasColumnType("int").IsRequired();
            Property(x => x.GeospatialAreaID).HasColumnName(@"GeospatialAreaID").HasColumnType("int").IsRequired();
            Property(x => x.FileResourceID).HasColumnName(@"FileResourceID").HasColumnType("int").IsRequired();

            // Foreign keys
            HasRequired(a => a.GeospatialArea).WithMany(b => b.GeospatialAreaImages).HasForeignKey(c => c.GeospatialAreaID).WillCascadeOnDelete(false); // FK_GeospatialAreaImage_GeospatialArea_GeospatialAreaID
            HasRequired(a => a.FileResource).WithMany(b => b.GeospatialAreaImages).HasForeignKey(c => c.FileResourceID).WillCascadeOnDelete(false); // FK_GeospatialAreaImage_FileResource_FileResourceID
        }
    }
}