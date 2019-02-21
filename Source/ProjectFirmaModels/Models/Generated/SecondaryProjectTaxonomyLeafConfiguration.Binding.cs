//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[SecondaryProjectTaxonomyLeaf]
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ProjectFirmaModels.Models
{
    public class SecondaryProjectTaxonomyLeafConfiguration : EntityTypeConfiguration<SecondaryProjectTaxonomyLeaf>
    {
        public SecondaryProjectTaxonomyLeafConfiguration() : this("dbo"){}

        public SecondaryProjectTaxonomyLeafConfiguration(string schema)
        {
            ToTable("SecondaryProjectTaxonomyLeaf", schema);
            HasKey(x => x.SecondaryProjectTaxonomyLeafID);
            Property(x => x.SecondaryProjectTaxonomyLeafID).HasColumnName(@"SecondaryProjectTaxonomyLeafID").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.TenantID).HasColumnName(@"TenantID").HasColumnType("int").IsRequired();
            Property(x => x.ProjectID).HasColumnName(@"ProjectID").HasColumnType("int").IsRequired();
            Property(x => x.TaxonomyLeafID).HasColumnName(@"TaxonomyLeafID").HasColumnType("int").IsRequired();

            // Foreign keys
            HasRequired(a => a.Project).WithMany(b => b.SecondaryProjectTaxonomyLeafs).HasForeignKey(c => c.ProjectID).WillCascadeOnDelete(false); // FK_SecondaryProjectTaxonomyLeaf_Project_ProjectID
            HasRequired(a => a.TaxonomyLeaf).WithMany(b => b.SecondaryProjectTaxonomyLeafs).HasForeignKey(c => c.TaxonomyLeafID).WillCascadeOnDelete(false); // FK_SecondaryProjectTaxonomyLeaf_TaxonomyLeaf_TaxonomyLeafID
        }
    }
}