//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[PersonSettingGridColumn]
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ProjectFirmaModels.Models
{
    public class PersonSettingGridColumnConfiguration : EntityTypeConfiguration<PersonSettingGridColumn>
    {
        public PersonSettingGridColumnConfiguration() : this("dbo"){}

        public PersonSettingGridColumnConfiguration(string schema)
        {
            ToTable("PersonSettingGridColumn", schema);
            HasKey(x => x.PersonSettingGridColumnID);
            Property(x => x.PersonSettingGridColumnID).HasColumnName(@"PersonSettingGridColumnID").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.TenantID).HasColumnName(@"TenantID").HasColumnType("int").IsRequired();
            Property(x => x.PersonSettingGridTableID).HasColumnName(@"PersonSettingGridTableID").HasColumnType("int").IsRequired();
            Property(x => x.ColumnName).HasColumnName(@"ColumnName").HasColumnType("varchar").IsRequired().IsUnicode(false).HasMaxLength(256);
            Property(x => x.SortOrder).HasColumnName(@"SortOrder").HasColumnType("int").IsRequired();

            // Foreign keys
            HasRequired(a => a.PersonSettingGridTable).WithMany(b => b.PersonSettingGridColumns).HasForeignKey(c => c.PersonSettingGridTableID).WillCascadeOnDelete(false); // FK_PersonSettingGridColumn_PersonSettingGridTable_PersonSettingGridTableID
        }
    }
}