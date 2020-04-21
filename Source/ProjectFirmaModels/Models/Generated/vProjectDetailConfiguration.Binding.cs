//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source View: [dbo].[vProjectDetail]
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ProjectFirmaModels.Models
{
    public class vProjectDetailConfiguration : EntityTypeConfiguration<vProjectDetail>
    {
        public vProjectDetailConfiguration() : this("dbo"){}

        public vProjectDetailConfiguration(string schema)
        {
            ToTable("vProjectDetail", schema);
            HasKey(x => x.PrimaryKey);
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
        }
    }
}