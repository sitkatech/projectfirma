//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[FieldDefinitionDefault]
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ProjectFirmaModels.Models
{
    public class FieldDefinitionDefaultConfiguration : EntityTypeConfiguration<FieldDefinitionDefault>
    {
        public FieldDefinitionDefaultConfiguration() : this("dbo"){}

        public FieldDefinitionDefaultConfiguration(string schema)
        {
            ToTable("FieldDefinitionDefault", schema);
            HasKey(x => x.FieldDefinitionDefaultID);
            Property(x => x.FieldDefinitionDefaultID).HasColumnName(@"FieldDefinitionDefaultID").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.FieldDefinitionID).HasColumnName(@"FieldDefinitionID").HasColumnType("int").IsRequired();
            Property(x => x.DefaultDefinition).HasColumnName(@"DefaultDefinition").HasColumnType("varchar").IsRequired();

            // Foreign keys
            HasRequired(a => a.FieldDefinition).WithMany(b => b.FieldDefinitionDefaults).HasForeignKey(c => c.FieldDefinitionID).WillCascadeOnDelete(false); // FK_FieldDefinitionDefault_FieldDefinition_FieldDefinitionID
        }
    }
}