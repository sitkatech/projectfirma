//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source View: [dbo].[vProjectCustomAttributeValue]
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ProjectFirmaModels.Models
{
    public class vProjectCustomAttributeValueConfiguration : EntityTypeConfiguration<vProjectCustomAttributeValue>
    {
        public vProjectCustomAttributeValueConfiguration() : this("dbo"){}

        public vProjectCustomAttributeValueConfiguration(string schema)
        {
            ToTable("vProjectCustomAttributeValue", schema);
            HasKey(x => x.PrimaryKey);
            
            
            
            
            
            
        }
    }
}