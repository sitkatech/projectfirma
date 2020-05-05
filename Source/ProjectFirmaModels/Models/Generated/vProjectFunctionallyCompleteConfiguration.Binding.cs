//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source View: [dbo].[vProjectFunctionallyComplete]
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ProjectFirmaModels.Models
{
    public class vProjectFunctionallyCompleteConfiguration : EntityTypeConfiguration<vProjectFunctionallyComplete>
    {
        public vProjectFunctionallyCompleteConfiguration() : this("dbo"){}

        public vProjectFunctionallyCompleteConfiguration(string schema)
        {
            ToTable("vProjectFunctionallyComplete", schema);
            HasKey(x => x.PrimaryKey);
            
            
            
        }
    }
}