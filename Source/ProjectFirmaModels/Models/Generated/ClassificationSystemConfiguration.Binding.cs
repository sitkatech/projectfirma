//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ClassificationSystem]
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ProjectFirmaModels.Models
{
    public class ClassificationSystemConfiguration : EntityTypeConfiguration<ClassificationSystem>
    {
        public ClassificationSystemConfiguration() : this("dbo"){}

        public ClassificationSystemConfiguration(string schema)
        {
            ToTable("ClassificationSystem", schema);
            HasKey(x => x.ClassificationSystemID);
            Property(x => x.ClassificationSystemID).HasColumnName(@"ClassificationSystemID").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.TenantID).HasColumnName(@"TenantID").HasColumnType("int").IsRequired();
            Property(x => x.ClassificationSystemName).HasColumnName(@"ClassificationSystemName").HasColumnType("varchar").IsRequired().IsUnicode(false).HasMaxLength(200);
            Property(x => x.ClassificationSystemDefinition).HasColumnName(@"ClassificationSystemDefinition").HasColumnType("varchar").IsOptional();
            Property(x => x.ClassificationSystemListPageContent).HasColumnName(@"ClassificationSystemListPageContent").HasColumnType("varchar").IsOptional();

            // Foreign keys

        }
    }
}