//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[TechnicalAssistanceParameter]
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ProjectFirmaModels.Models
{
    public class TechnicalAssistanceParameterConfiguration : EntityTypeConfiguration<TechnicalAssistanceParameter>
    {
        public TechnicalAssistanceParameterConfiguration() : this("dbo"){}

        public TechnicalAssistanceParameterConfiguration(string schema)
        {
            ToTable("TechnicalAssistanceParameter", schema);
            HasKey(x => x.TechnicalAssistanceParameterID);
            Property(x => x.TechnicalAssistanceParameterID).HasColumnName(@"TechnicalAssistanceParameterID").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.TenantID).HasColumnName(@"TenantID").HasColumnType("int").IsRequired();
            Property(x => x.Year).HasColumnName(@"Year").HasColumnType("int").IsRequired();
            Property(x => x.EngineeringHourlyCost).HasColumnName(@"EngineeringHourlyCost").HasColumnType("money").IsOptional().HasPrecision(19,4);
            Property(x => x.OtherAssistanceHourlyCost).HasColumnName(@"OtherAssistanceHourlyCost").HasColumnType("money").IsOptional().HasPrecision(19,4);

            // Foreign keys

        }
    }
}