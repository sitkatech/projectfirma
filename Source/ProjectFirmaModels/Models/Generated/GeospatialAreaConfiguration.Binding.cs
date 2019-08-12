//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[GeospatialArea]
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ProjectFirmaModels.Models
{
    public class GeospatialAreaConfiguration : EntityTypeConfiguration<GeospatialArea>
    {
        public GeospatialAreaConfiguration() : this("dbo"){}

        public GeospatialAreaConfiguration(string schema)
        {
            ToTable("GeospatialArea", schema);
            HasKey(x => x.GeospatialAreaID);
            Property(x => x.GeospatialAreaID).HasColumnName(@"GeospatialAreaID").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.TenantID).HasColumnName(@"TenantID").HasColumnType("int").IsRequired();
            Property(x => x.GeospatialAreaName).HasColumnName(@"GeospatialAreaName").HasColumnType("varchar").IsRequired().IsUnicode(false).HasMaxLength(100);
            Property(x => x.GeospatialAreaFeature).HasColumnName(@"GeospatialAreaFeature").HasColumnType("geometry").IsOptional();
            Property(x => x.GeospatialAreaTypeID).HasColumnName(@"GeospatialAreaTypeID").HasColumnType("int").IsRequired();
            Property(x => x.GeospatialAreaDescriptionContent).HasColumnName(@"GeospatialAreaDescriptionContent").HasColumnType("varchar").IsOptional();

            // Foreign keys
            HasRequired(a => a.GeospatialAreaType).WithMany(b => b.GeospatialAreas).HasForeignKey(c => c.GeospatialAreaTypeID).WillCascadeOnDelete(false); // FK_GeospatialArea_GeospatialAreaType_GeospatialAreaTypeID
        }
    }
}