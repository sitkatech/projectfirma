//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[AttachmentRelationshipTypeTaxonomyTrunk]
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ProjectFirmaModels.Models
{
    public class AttachmentRelationshipTypeTaxonomyTrunkConfiguration : EntityTypeConfiguration<AttachmentRelationshipTypeTaxonomyTrunk>
    {
        public AttachmentRelationshipTypeTaxonomyTrunkConfiguration() : this("dbo"){}

        public AttachmentRelationshipTypeTaxonomyTrunkConfiguration(string schema)
        {
            ToTable("AttachmentRelationshipTypeTaxonomyTrunk", schema);
            HasKey(x => x.AttachmentRelationshipTypeTaxonomyTrunkID);
            Property(x => x.AttachmentRelationshipTypeTaxonomyTrunkID).HasColumnName(@"AttachmentRelationshipTypeTaxonomyTrunkID").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.TenantID).HasColumnName(@"TenantID").HasColumnType("int").IsRequired();
            Property(x => x.AttachmentRelationshipTypeID).HasColumnName(@"AttachmentRelationshipTypeID").HasColumnType("int").IsRequired();
            Property(x => x.TaxonomyTrunkID).HasColumnName(@"TaxonomyTrunkID").HasColumnType("int").IsRequired();

            // Foreign keys
            HasRequired(a => a.AttachmentRelationshipType).WithMany(b => b.AttachmentRelationshipTypeTaxonomyTrunks).HasForeignKey(c => c.AttachmentRelationshipTypeID).WillCascadeOnDelete(false); // FK_AttachmentRelationshipTypeTaxonomyTrunk_AttachmentRelationshipType_AttachmentRelationshipTypeID
            HasRequired(a => a.TaxonomyTrunk).WithMany(b => b.AttachmentRelationshipTypeTaxonomyTrunks).HasForeignKey(c => c.TaxonomyTrunkID).WillCascadeOnDelete(false); // FK_AttachmentRelationshipTypeTaxonomyTrunk_TaxonomyTrunk_TaxonomyTrunkID
        }
    }
}