//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[AttachmentTypeTaxonomyTrunk]
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ProjectFirmaModels.Models
{
    public class AttachmentTypeTaxonomyTrunkConfiguration : EntityTypeConfiguration<AttachmentTypeTaxonomyTrunk>
    {
        public AttachmentTypeTaxonomyTrunkConfiguration() : this("dbo"){}

        public AttachmentTypeTaxonomyTrunkConfiguration(string schema)
        {
            ToTable("AttachmentTypeTaxonomyTrunk", schema);
            HasKey(x => x.AttachmentTypeTaxonomyTrunkID);
            Property(x => x.AttachmentTypeTaxonomyTrunkID).HasColumnName(@"AttachmentTypeTaxonomyTrunkID").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.TenantID).HasColumnName(@"TenantID").HasColumnType("int").IsRequired();
            Property(x => x.AttachmentTypeID).HasColumnName(@"AttachmentTypeID").HasColumnType("int").IsRequired();
            Property(x => x.TaxonomyTrunkID).HasColumnName(@"TaxonomyTrunkID").HasColumnType("int").IsRequired();

            // Foreign keys
            HasRequired(a => a.AttachmentType).WithMany(b => b.AttachmentTypeTaxonomyTrunks).HasForeignKey(c => c.AttachmentTypeID).WillCascadeOnDelete(false); // FK_AttachmentTypeTaxonomyTrunk_AttachmentType_AttachmentTypeID
            HasRequired(a => a.TaxonomyTrunk).WithMany(b => b.AttachmentTypeTaxonomyTrunks).HasForeignKey(c => c.TaxonomyTrunkID).WillCascadeOnDelete(false); // FK_AttachmentTypeTaxonomyTrunk_TaxonomyTrunk_TaxonomyTrunkID
        }
    }
}