//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[FirmaSystemAuthenticationType]
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ProjectFirmaModels.Models
{
    public class FirmaSystemAuthenticationTypeConfiguration : EntityTypeConfiguration<FirmaSystemAuthenticationType>
    {
        public FirmaSystemAuthenticationTypeConfiguration() : this("dbo"){}

        public FirmaSystemAuthenticationTypeConfiguration(string schema)
        {
            ToTable("FirmaSystemAuthenticationType", schema);
            HasKey(x => x.FirmaSystemAuthenticationTypeID);
            Property(x => x.FirmaSystemAuthenticationTypeID).HasColumnName(@"FirmaSystemAuthenticationTypeID").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(x => x.FirmaSystemAuthenticationTypeName).HasColumnName(@"FirmaSystemAuthenticationTypeName").HasColumnType("varchar").IsRequired().IsUnicode(false).HasMaxLength(100);
            Property(x => x.FirmaSystemAuthenticationTypeDisplayName).HasColumnName(@"FirmaSystemAuthenticationTypeDisplayName").HasColumnType("varchar").IsRequired().IsUnicode(false).HasMaxLength(100);

            // Foreign keys

        }
    }
}