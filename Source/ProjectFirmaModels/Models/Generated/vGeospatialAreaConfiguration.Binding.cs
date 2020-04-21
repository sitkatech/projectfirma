//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source View: [dbo].[vGeospatialArea]
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ProjectFirmaModels.Models
{
    public class vGeospatialAreaConfiguration : EntityTypeConfiguration<vGeospatialArea>
    {
        public vGeospatialAreaConfiguration() : this("dbo"){}

        public vGeospatialAreaConfiguration(string schema)
        {
            ToTable("vGeospatialArea", schema);
            HasKey(x => x.PrimaryKey);
            
            
            
            
            
            
            
        }
    }
}