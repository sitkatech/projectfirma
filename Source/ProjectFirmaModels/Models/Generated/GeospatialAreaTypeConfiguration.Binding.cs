//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[GeospatialAreaType]
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ProjectFirmaModels.Models
{
    public class GeospatialAreaTypeConfiguration : EntityTypeConfiguration<GeospatialAreaType>
    {
        public GeospatialAreaTypeConfiguration() : this("dbo"){}

        public GeospatialAreaTypeConfiguration(string schema)
        {
            ToTable("GeospatialAreaType", schema);
            HasKey(x => x.GeospatialAreaTypeID);
            Property(x => x.GeospatialAreaTypeID).HasColumnName(@"GeospatialAreaTypeID").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.TenantID).HasColumnName(@"TenantID").HasColumnType("int").IsRequired();
            Property(x => x.GeospatialAreaTypeName).HasColumnName(@"GeospatialAreaTypeName").HasColumnType("varchar").IsRequired().IsUnicode(false).HasMaxLength(200);
            Property(x => x.GeospatialAreaTypeNamePluralized).HasColumnName(@"GeospatialAreaTypeNamePluralized").HasColumnType("varchar").IsRequired().IsUnicode(false).HasMaxLength(200);
            Property(x => x.GeospatialAreaIntroContent).HasColumnName(@"GeospatialAreaIntroContent").HasColumnType("varchar").IsOptional();
            Property(x => x.GeospatialAreaTypeDefinition).HasColumnName(@"GeospatialAreaTypeDefinition").HasColumnType("varchar").IsOptional();
            Property(x => x.GeospatialAreaLayerName).HasColumnName(@"GeospatialAreaLayerName").HasColumnType("varchar").IsRequired().IsUnicode(false).HasMaxLength(255);

            // Foreign keys

        }
    }
}