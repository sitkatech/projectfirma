//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[PersonGridSetting]
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ProjectFirmaModels.Models
{
    public class PersonGridSettingConfiguration : EntityTypeConfiguration<PersonGridSetting>
    {
        public PersonGridSettingConfiguration() : this("dbo"){}

        public PersonGridSettingConfiguration(string schema)
        {
            ToTable("PersonGridSetting", schema);
            HasKey(x => x.PersonGridSettingID);
            Property(x => x.PersonGridSettingID).HasColumnName(@"PersonGridSettingID").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.TenantID).HasColumnName(@"TenantID").HasColumnType("int").IsRequired();
            Property(x => x.PersonID).HasColumnName(@"PersonID").HasColumnType("int").IsRequired();
            Property(x => x.GridName).HasColumnName(@"GridName").HasColumnType("varchar").IsRequired().IsUnicode(false).HasMaxLength(250);
            Property(x => x.FilterState).HasColumnName(@"FilterState").HasColumnType("nvarchar").IsOptional();
            Property(x => x.ColumnState).HasColumnName(@"ColumnState").HasColumnType("nvarchar").IsOptional();

            // Foreign keys
            HasRequired(a => a.Person).WithMany(b => b.PersonGridSettings).HasForeignKey(c => c.PersonID).WillCascadeOnDelete(false); // FK_PersonGridSetting_Person_PersonID
        }
    }
}