//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[PersonSettingGridColumnSetting]
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ProjectFirmaModels.Models
{
    public class PersonSettingGridColumnSettingConfiguration : EntityTypeConfiguration<PersonSettingGridColumnSetting>
    {
        public PersonSettingGridColumnSettingConfiguration() : this("dbo"){}

        public PersonSettingGridColumnSettingConfiguration(string schema)
        {
            ToTable("PersonSettingGridColumnSetting", schema);
            HasKey(x => x.PersonSettingGridColumnSettingID);
            Property(x => x.PersonSettingGridColumnSettingID).HasColumnName(@"PersonSettingGridColumnSettingID").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.PersonID).HasColumnName(@"PersonID").HasColumnType("int").IsRequired();
            Property(x => x.PersonSettingGridColumnID).HasColumnName(@"PersonSettingGridColumnID").HasColumnType("int").IsRequired();
            Property(x => x.FilterText).HasColumnName(@"FilterText").HasColumnType("nvarchar").IsRequired().HasMaxLength(256);

            // Foreign keys
            HasRequired(a => a.Person).WithMany(b => b.PersonSettingGridColumnSettings).HasForeignKey(c => c.PersonID).WillCascadeOnDelete(false); // FK_PersonSettingGridColumnSetting_Person_PersonID
            HasRequired(a => a.PersonSettingGridColumn).WithMany(b => b.PersonSettingGridColumnSettings).HasForeignKey(c => c.PersonSettingGridColumnID).WillCascadeOnDelete(false); // FK_PersonSettingGridColumnSetting_PersonSettingGridColumn_PersonSettingGridColumnID
        }
    }
}