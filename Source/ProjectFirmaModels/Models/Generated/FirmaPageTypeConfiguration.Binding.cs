//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[FirmaPageType]
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ProjectFirmaModels.Models
{
    public class FirmaPageTypeConfiguration : EntityTypeConfiguration<FirmaPageType>
    {
        public FirmaPageTypeConfiguration() : this("dbo"){}

        public FirmaPageTypeConfiguration(string schema)
        {
            ToTable("FirmaPageType", schema);
            HasKey(x => x.FirmaPageTypeID);
            Property(x => x.FirmaPageTypeID).HasColumnName(@"FirmaPageTypeID").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(x => x.FirmaPageTypeName).HasColumnName(@"FirmaPageTypeName").HasColumnType("varchar").IsRequired().IsUnicode(false).HasMaxLength(100);
            Property(x => x.FirmaPageTypeDisplayName).HasColumnName(@"FirmaPageTypeDisplayName").HasColumnType("varchar").IsRequired().IsUnicode(false).HasMaxLength(100);
            Property(x => x.FirmaPageRenderTypeID).HasColumnName(@"FirmaPageRenderTypeID").HasColumnType("int").IsRequired();

            // Foreign keys

        }
    }
}