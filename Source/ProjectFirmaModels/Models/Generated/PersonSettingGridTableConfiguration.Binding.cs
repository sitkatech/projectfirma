//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[PersonSettingGridTable]
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ProjectFirmaModels.Models
{
    public class PersonSettingGridTableConfiguration : EntityTypeConfiguration<PersonSettingGridTable>
    {
        public PersonSettingGridTableConfiguration() : this("dbo"){}

        public PersonSettingGridTableConfiguration(string schema)
        {
            ToTable("PersonSettingGridTable", schema);
            HasKey(x => x.PersonSettingGridTableID);
            Property(x => x.PersonSettingGridTableID).HasColumnName(@"PersonSettingGridTableID").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.GridName).HasColumnName(@"GridName").HasColumnType("varchar").IsRequired().IsUnicode(false).HasMaxLength(256);

            // Foreign keys

        }
    }
}