//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ContactType]
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ProjectFirmaModels.Models
{
    public class ContactTypeConfiguration : EntityTypeConfiguration<ContactType>
    {
        public ContactTypeConfiguration() : this("dbo"){}

        public ContactTypeConfiguration(string schema)
        {
            ToTable("ContactType", schema);
            HasKey(x => x.ContactTypeID);
            Property(x => x.ContactTypeID).HasColumnName(@"ContactTypeID").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.TenantID).HasColumnName(@"TenantID").HasColumnType("int").IsRequired();
            Property(x => x.ContactTypeName).HasColumnName(@"ContactTypeName").HasColumnType("varchar").IsRequired().IsUnicode(false).HasMaxLength(200);
            Property(x => x.ContactTypeAbbreviation).HasColumnName(@"ContactTypeAbbreviation").HasColumnType("varchar").IsRequired().IsUnicode(false).HasMaxLength(100);
            Property(x => x.IsDefaultContactType).HasColumnName(@"IsDefaultContactType").HasColumnType("bit").IsRequired();

            // Foreign keys

        }
    }
}