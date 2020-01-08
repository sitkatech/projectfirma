//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ReportTemplateModelType]
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ProjectFirmaModels.Models
{
    public class ReportTemplateModelTypeConfiguration : EntityTypeConfiguration<ReportTemplateModelType>
    {
        public ReportTemplateModelTypeConfiguration() : this("dbo"){}

        public ReportTemplateModelTypeConfiguration(string schema)
        {
            ToTable("ReportTemplateModelType", schema);
            HasKey(x => x.ReportTemplateModelTypeID);
            Property(x => x.ReportTemplateModelTypeID).HasColumnName(@"ReportTemplateModelTypeID").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(x => x.ReportTemplateModelTypeName).HasColumnName(@"ReportTemplateModelTypeName").HasColumnType("varchar").IsRequired().IsUnicode(false).HasMaxLength(100);
            Property(x => x.ReportTemplateModelTypeDisplayName).HasColumnName(@"ReportTemplateModelTypeDisplayName").HasColumnType("varchar").IsRequired().IsUnicode(false).HasMaxLength(100);
            Property(x => x.ReportTemplateModelTypeDescription).HasColumnName(@"ReportTemplateModelTypeDescription").HasColumnType("varchar").IsRequired().IsUnicode(false).HasMaxLength(250);

            // Foreign keys

        }
    }
}