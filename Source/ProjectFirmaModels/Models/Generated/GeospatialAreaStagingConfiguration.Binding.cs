//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[GeospatialAreaStaging]
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ProjectFirmaModels.Models
{
    public class GeospatialAreaStagingConfiguration : EntityTypeConfiguration<GeospatialAreaStaging>
    {
        public GeospatialAreaStagingConfiguration() : this("dbo"){}

        public GeospatialAreaStagingConfiguration(string schema)
        {
            ToTable("GeospatialAreaStaging", schema);
            HasKey(x => x.GeospatialAreaStagingID);
            Property(x => x.GeospatialAreaStagingID).HasColumnName(@"GeospatialAreaStagingID").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.TenantID).HasColumnName(@"TenantID").HasColumnType("int").IsRequired();
            Property(x => x.Name).HasColumnName(@"Name").HasColumnType("varchar").IsRequired().IsUnicode(false).HasMaxLength(100);
            Property(x => x.ExternalID).HasColumnName(@"ExternalID").HasColumnType("varchar").IsRequired().IsUnicode(false).HasMaxLength(100);
            Property(x => x.Geometry).HasColumnName(@"Geometry").HasColumnType("geometry").IsRequired();

            // Foreign keys

        }
    }
}