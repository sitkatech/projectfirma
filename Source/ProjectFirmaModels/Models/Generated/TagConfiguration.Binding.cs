//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[Tag]
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ProjectFirmaModels.Models
{
    public class TagConfiguration : EntityTypeConfiguration<Tag>
    {
        public TagConfiguration() : this("dbo"){}

        public TagConfiguration(string schema)
        {
            ToTable("Tag", schema);
            HasKey(x => x.TagID);
            Property(x => x.TagID).HasColumnName(@"TagID").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.TenantID).HasColumnName(@"TenantID").HasColumnType("int").IsRequired();
            Property(x => x.TagName).HasColumnName(@"TagName").HasColumnType("varchar").IsRequired().IsUnicode(false).HasMaxLength(100);
            Property(x => x.TagDescription).HasColumnName(@"TagDescription").HasColumnType("varchar").IsOptional().IsUnicode(false).HasMaxLength(1000);

            // Foreign keys

        }
    }
}