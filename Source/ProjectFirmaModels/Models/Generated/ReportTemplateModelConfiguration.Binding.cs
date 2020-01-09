//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ReportTemplateModel]
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ProjectFirmaModels.Models
{
    public class ReportTemplateModelConfiguration : EntityTypeConfiguration<ReportTemplateModel>
    {
        public ReportTemplateModelConfiguration() : this("dbo"){}

        public ReportTemplateModelConfiguration(string schema)
        {
            ToTable("ReportTemplateModel", schema);
            HasKey(x => x.ReportTemplateModelID);
            Property(x => x.ReportTemplateModelID).HasColumnName(@"ReportTemplateModelID").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(x => x.ReportTemplateModelName).HasColumnName(@"ReportTemplateModelName").HasColumnType("varchar").IsRequired().IsUnicode(false).HasMaxLength(100);
            Property(x => x.ReportTemplateModelDisplayName).HasColumnName(@"ReportTemplateModelDisplayName").HasColumnType("varchar").IsRequired().IsUnicode(false).HasMaxLength(100);
            Property(x => x.ReportTemplateModelDescription).HasColumnName(@"ReportTemplateModelDescription").HasColumnType("varchar").IsRequired().IsUnicode(false).HasMaxLength(250);

            // Foreign keys

        }
    }
}