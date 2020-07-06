//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[FieldDefinitionDataImage]
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ProjectFirmaModels.Models
{
    public class FieldDefinitionDataImageConfiguration : EntityTypeConfiguration<FieldDefinitionDataImage>
    {
        public FieldDefinitionDataImageConfiguration() : this("dbo"){}

        public FieldDefinitionDataImageConfiguration(string schema)
        {
            ToTable("FieldDefinitionDataImage", schema);
            HasKey(x => x.FieldDefinitionDataImageID);
            Property(x => x.FieldDefinitionDataImageID).HasColumnName(@"FieldDefinitionDataImageID").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.TenantID).HasColumnName(@"TenantID").HasColumnType("int").IsRequired();
            Property(x => x.FieldDefinitionDataID).HasColumnName(@"FieldDefinitionDataID").HasColumnType("int").IsRequired();
            Property(x => x.FileResourceInfoID).HasColumnName(@"FileResourceInfoID").HasColumnType("int").IsRequired();

            // Foreign keys
            HasRequired(a => a.FieldDefinitionData).WithMany(b => b.FieldDefinitionDataImages).HasForeignKey(c => c.FieldDefinitionDataID).WillCascadeOnDelete(false); // FK_FieldDefinitionDataImage_FieldDefinitionData_FieldDefinitionDataID
            HasRequired(a => a.FileResourceInfo).WithMany(b => b.FieldDefinitionDataImages).HasForeignKey(c => c.FileResourceInfoID).WillCascadeOnDelete(false); // FK_FieldDefinitionDataImage_FileResourceInfo_FileResourceInfoID
        }
    }
}