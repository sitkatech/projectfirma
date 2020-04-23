//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source View: [dbo].[vProjectAttachment]
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ProjectFirmaModels.Models
{
    public class vProjectAttachmentConfiguration : EntityTypeConfiguration<vProjectAttachment>
    {
        public vProjectAttachmentConfiguration() : this("dbo"){}

        public vProjectAttachmentConfiguration(string schema)
        {
            ToTable("vProjectAttachment", schema);
            HasKey(x => x.PrimaryKey);
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
        }
    }
}