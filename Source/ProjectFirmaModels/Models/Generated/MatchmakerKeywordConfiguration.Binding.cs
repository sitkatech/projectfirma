//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[MatchmakerKeyword]
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ProjectFirmaModels.Models
{
    public class MatchmakerKeywordConfiguration : EntityTypeConfiguration<MatchmakerKeyword>
    {
        public MatchmakerKeywordConfiguration() : this("dbo"){}

        public MatchmakerKeywordConfiguration(string schema)
        {
            ToTable("MatchmakerKeyword", schema);
            HasKey(x => x.MatchmakerKeywordID);
            Property(x => x.MatchmakerKeywordID).HasColumnName(@"MatchmakerKeywordID").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.TenantID).HasColumnName(@"TenantID").HasColumnType("int").IsRequired();
            Property(x => x.MatchmakerKeywordName).HasColumnName(@"MatchmakerKeywordName").HasColumnType("varchar").IsRequired().IsUnicode(false).HasMaxLength(100);
            Property(x => x.MatchmakerKeywordDescription).HasColumnName(@"MatchmakerKeywordDescription").HasColumnType("varchar").IsOptional().IsUnicode(false).HasMaxLength(1000);

            // Foreign keys

        }
    }
}