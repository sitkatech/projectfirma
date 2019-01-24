//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[StateProvince]
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ProjectFirmaModels.Models
{
    public class StateProvinceConfiguration : EntityTypeConfiguration<StateProvince>
    {
        public StateProvinceConfiguration() : this("dbo"){}

        public StateProvinceConfiguration(string schema)
        {
            ToTable("StateProvince", schema);
            HasKey(x => x.StateProvinceID);
            Property(x => x.StateProvinceID).HasColumnName(@"StateProvinceID").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(x => x.TenantID).HasColumnName(@"TenantID").HasColumnType("int").IsRequired();
            Property(x => x.StateProvinceName).HasColumnName(@"StateProvinceName").HasColumnType("varchar").IsRequired().IsUnicode(false).HasMaxLength(100);
            Property(x => x.StateProvinceAbbreviation).HasColumnName(@"StateProvinceAbbreviation").HasColumnType("char").IsRequired().IsFixedLength().IsUnicode(false).HasMaxLength(2);
            Property(x => x.StateProvinceFeature).HasColumnName(@"StateProvinceFeature").HasColumnType("geometry").IsOptional();
            Property(x => x.StateProvinceFeatureForAnalysis).HasColumnName(@"StateProvinceFeatureForAnalysis").HasColumnType("geometry").IsRequired();

            // Foreign keys

        }
    }
}