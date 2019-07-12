//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[FundingSourceCustomAttributeTypeRole]
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ProjectFirmaModels.Models
{
    public class FundingSourceCustomAttributeTypeRoleConfiguration : EntityTypeConfiguration<FundingSourceCustomAttributeTypeRole>
    {
        public FundingSourceCustomAttributeTypeRoleConfiguration() : this("dbo"){}

        public FundingSourceCustomAttributeTypeRoleConfiguration(string schema)
        {
            ToTable("FundingSourceCustomAttributeTypeRole", schema);
            HasKey(x => x.FundingSourceCustomAttributeTypeRoleID);
            Property(x => x.FundingSourceCustomAttributeTypeRoleID).HasColumnName(@"FundingSourceCustomAttributeTypeRoleID").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.TenantID).HasColumnName(@"TenantID").HasColumnType("int").IsRequired();
            Property(x => x.FundingSourceCustomAttributeTypeID).HasColumnName(@"FundingSourceCustomAttributeTypeID").HasColumnType("int").IsRequired();
            Property(x => x.RoleID).HasColumnName(@"RoleID").HasColumnType("int").IsRequired();
            Property(x => x.FundingSourceCustomAttributeTypeRolePermissionTypeID).HasColumnName(@"FundingSourceCustomAttributeTypeRolePermissionTypeID").HasColumnType("int").IsRequired();

            // Foreign keys
            HasRequired(a => a.FundingSourceCustomAttributeType).WithMany(b => b.FundingSourceCustomAttributeTypeRoles).HasForeignKey(c => c.FundingSourceCustomAttributeTypeID).WillCascadeOnDelete(false); // FK_FundingSourceCustomAttributeTypeRole_FundingSourceCustomAttributeType_FundingSourceCustomAttributeTypeID
        }
    }
}