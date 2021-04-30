//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[GeospatialAreaRawData]
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ProjectFirmaModels.Models
{
    public class GeospatialAreaRawDataConfiguration : EntityTypeConfiguration<GeospatialAreaRawData>
    {
        public GeospatialAreaRawDataConfiguration() : this("dbo"){}

        public GeospatialAreaRawDataConfiguration(string schema)
        {
            ToTable("GeospatialAreaRawData", schema);
            HasKey(x => x.GeospatialAreaRawDataID);
            Property(x => x.GeospatialAreaRawDataID).HasColumnName(@"GeospatialAreaRawDataID").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.TenantID).HasColumnName(@"TenantID").HasColumnType("int").IsRequired();
            Property(x => x.GeospatialAreaTypeID).HasColumnName(@"GeospatialAreaTypeID").HasColumnType("int").IsRequired();
            Property(x => x.ResultJson).HasColumnName(@"ResultJson").HasColumnType("varchar").IsOptional();

            // Foreign keys
            HasRequired(a => a.GeospatialAreaType).WithMany(b => b.GeospatialAreaRawDatas).HasForeignKey(c => c.GeospatialAreaTypeID).WillCascadeOnDelete(false); // FK_GeospatialAreaRawData_GeospatialAreaType_GeospatialAreaTypeID
        }
    }
}