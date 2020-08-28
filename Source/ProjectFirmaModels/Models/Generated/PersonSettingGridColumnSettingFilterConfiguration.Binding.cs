//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[PersonSettingGridColumnSettingFilter]
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ProjectFirmaModels.Models
{
    public class PersonSettingGridColumnSettingFilterConfiguration : EntityTypeConfiguration<PersonSettingGridColumnSettingFilter>
    {
        public PersonSettingGridColumnSettingFilterConfiguration() : this("dbo"){}

        public PersonSettingGridColumnSettingFilterConfiguration(string schema)
        {
            ToTable("PersonSettingGridColumnSettingFilter", schema);
            HasKey(x => x.PersonSettingGridColumnSettingFilterID);
            Property(x => x.PersonSettingGridColumnSettingFilterID).HasColumnName(@"PersonSettingGridColumnSettingFilterID").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.TenantID).HasColumnName(@"TenantID").HasColumnType("int").IsRequired();
            Property(x => x.PersonSettingGridColumnSettingID).HasColumnName(@"PersonSettingGridColumnSettingID").HasColumnType("int").IsRequired();
            Property(x => x.FilterText).HasColumnName(@"FilterText").HasColumnType("varchar").IsRequired().IsUnicode(false).HasMaxLength(256);

            // Foreign keys
            HasRequired(a => a.PersonSettingGridColumnSetting).WithMany(b => b.PersonSettingGridColumnSettingFilters).HasForeignKey(c => c.PersonSettingGridColumnSettingID).WillCascadeOnDelete(false); // FK_PersonSettingGridColumnSettingFilter_PersonSettingGridColumnSetting_PersonSettingGridColumnSettingID
        }
    }
}