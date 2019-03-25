//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[County]
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ProjectFirmaModels.Models
{
    public class CountyConfiguration : EntityTypeConfiguration<County>
    {
        public CountyConfiguration() : this("dbo"){}

        public CountyConfiguration(string schema)
        {
            ToTable("County", schema);
            HasKey(x => x.CountyID);
            Property(x => x.CountyID).HasColumnName(@"CountyID").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(x => x.TenantID).HasColumnName(@"TenantID").HasColumnType("int").IsRequired();
            Property(x => x.CountyName).HasColumnName(@"CountyName").HasColumnType("varchar").IsRequired().IsUnicode(false).HasMaxLength(100);
            Property(x => x.StateProvinceID).HasColumnName(@"StateProvinceID").HasColumnType("int").IsRequired();
            Property(x => x.CountyFeature).HasColumnName(@"CountyFeature").HasColumnType("geometry").IsOptional();

            // Foreign keys
            HasRequired(a => a.StateProvince).WithMany(b => b.Counties).HasForeignKey(c => c.StateProvinceID).WillCascadeOnDelete(false); // FK_County_StateProvince_StateProvinceID
        }
    }
}