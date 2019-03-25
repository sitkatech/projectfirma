//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source View: [dbo].[vGeoServerGeospatialArea]
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ProjectFirmaModels.Models
{
    public class vGeoServerGeospatialAreaConfiguration : EntityTypeConfiguration<vGeoServerGeospatialArea>
    {
        public vGeoServerGeospatialAreaConfiguration() : this("dbo"){}

        public vGeoServerGeospatialAreaConfiguration(string schema)
        {
            ToTable("vGeoServerGeospatialArea", schema);
            HasKey(x => x.PrimaryKey);
            
            
            
            
            
            
        }
    }
}