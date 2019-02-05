//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[FirmaPage]
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ProjectFirmaModels.Models
{
    public class FirmaPageConfiguration : EntityTypeConfiguration<FirmaPage>
    {
        public FirmaPageConfiguration() : this("dbo"){}

        public FirmaPageConfiguration(string schema)
        {
            ToTable("FirmaPage", schema);
            HasKey(x => x.FirmaPageID);
            Property(x => x.FirmaPageID).HasColumnName(@"FirmaPageID").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.TenantID).HasColumnName(@"TenantID").HasColumnType("int").IsRequired();
            Property(x => x.FirmaPageTypeID).HasColumnName(@"FirmaPageTypeID").HasColumnType("int").IsRequired();
            Property(x => x.FirmaPageContent).HasColumnName(@"FirmaPageContent").HasColumnType("varchar").IsOptional();

            // Foreign keys
            HasRequired(a => a.FirmaPageType).WithMany(b => b.FirmaPages).HasForeignKey(c => c.FirmaPageTypeID).WillCascadeOnDelete(false); // FK_FirmaPage_FirmaPageType_FirmaPageTypeID
        }
    }
}