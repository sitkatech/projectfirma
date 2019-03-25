//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[CostParameterSet]
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ProjectFirmaModels.Models
{
    public class CostParameterSetConfiguration : EntityTypeConfiguration<CostParameterSet>
    {
        public CostParameterSetConfiguration() : this("dbo"){}

        public CostParameterSetConfiguration(string schema)
        {
            ToTable("CostParameterSet", schema);
            HasKey(x => x.CostParameterSetID);
            Property(x => x.CostParameterSetID).HasColumnName(@"CostParameterSetID").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.TenantID).HasColumnName(@"TenantID").HasColumnType("int").IsRequired();
            Property(x => x.InflationRate).HasColumnName(@"InflationRate").HasColumnType("decimal").IsRequired().HasPrecision(9,6);
            Property(x => x.CurrentYearForPVCalculations).HasColumnName(@"CurrentYearForPVCalculations").HasColumnType("int").IsRequired();
            Property(x => x.Comment).HasColumnName(@"Comment").HasColumnType("varchar").IsOptional().IsUnicode(false).HasMaxLength(2000);
            Property(x => x.CreateDate).HasColumnName(@"CreateDate").HasColumnType("datetime").IsRequired();

            // Foreign keys

        }
    }
}