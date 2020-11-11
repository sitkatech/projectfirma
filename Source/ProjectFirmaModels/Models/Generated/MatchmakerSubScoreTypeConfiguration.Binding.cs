//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[MatchmakerSubScoreType]
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ProjectFirmaModels.Models
{
    public class MatchmakerSubScoreTypeConfiguration : EntityTypeConfiguration<MatchmakerSubScoreType>
    {
        public MatchmakerSubScoreTypeConfiguration() : this("dbo"){}

        public MatchmakerSubScoreTypeConfiguration(string schema)
        {
            ToTable("MatchmakerSubScoreType", schema);
            HasKey(x => x.MatchmakerSubScoreTypeID);
            Property(x => x.MatchmakerSubScoreTypeID).HasColumnName(@"MatchmakerSubScoreTypeID").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(x => x.MatchmakerSubScoreTypeName).HasColumnName(@"MatchmakerSubScoreTypeName").HasColumnType("varchar").IsRequired().IsUnicode(false).HasMaxLength(200);
            Property(x => x.MatchmakerSubScoreTypeDisplayName).HasColumnName(@"MatchmakerSubScoreTypeDisplayName").HasColumnType("varchar").IsRequired().IsUnicode(false).HasMaxLength(200);

        }
    }
}