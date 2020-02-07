//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ReportTemplate]
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ProjectFirmaModels.Models
{
    public class ReportTemplateConfiguration : EntityTypeConfiguration<ReportTemplate>
    {
        public ReportTemplateConfiguration() : this("dbo"){}

        public ReportTemplateConfiguration(string schema)
        {
            ToTable("ReportTemplate", schema);
            HasKey(x => x.ReportTemplateID);
            Property(x => x.ReportTemplateID).HasColumnName(@"ReportTemplateID").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.TenantID).HasColumnName(@"TenantID").HasColumnType("int").IsRequired();
            Property(x => x.FileResourceID).HasColumnName(@"FileResourceID").HasColumnType("int").IsRequired();
            Property(x => x.DisplayName).HasColumnName(@"DisplayName").HasColumnType("varchar").IsRequired().IsUnicode(false).HasMaxLength(50);
            Property(x => x.Description).HasColumnName(@"Description").HasColumnType("varchar").IsOptional().IsUnicode(false).HasMaxLength(250);
            Property(x => x.ReportTemplateModelTypeID).HasColumnName(@"ReportTemplateModelTypeID").HasColumnType("int").IsRequired();
            Property(x => x.ReportTemplateModelID).HasColumnName(@"ReportTemplateModelID").HasColumnType("int").IsRequired();

            // Foreign keys
            HasRequired(a => a.FileResource).WithMany(b => b.ReportTemplates).HasForeignKey(c => c.FileResourceID).WillCascadeOnDelete(false); // FK_ReportTemplate_FileResource_FileResourceID
        }
    }
}