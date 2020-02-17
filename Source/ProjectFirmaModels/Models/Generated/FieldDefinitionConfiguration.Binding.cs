//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[FieldDefinition]
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ProjectFirmaModels.Models
{
    public class FieldDefinitionConfiguration : EntityTypeConfiguration<FieldDefinition>
    {
        public FieldDefinitionConfiguration() : this("dbo"){}

        public FieldDefinitionConfiguration(string schema)
        {
            ToTable("FieldDefinition", schema);
            HasKey(x => x.FieldDefinitionID);
            Property(x => x.FieldDefinitionID).HasColumnName(@"FieldDefinitionID").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(x => x.FieldDefinitionName).HasColumnName(@"FieldDefinitionName").HasColumnType("varchar").IsRequired().IsUnicode(false).HasMaxLength(300);
            Property(x => x.FieldDefinitionDisplayName).HasColumnName(@"FieldDefinitionDisplayName").HasColumnType("varchar").IsRequired().IsUnicode(false).HasMaxLength(300);

            // Foreign keys

        }
    }
}