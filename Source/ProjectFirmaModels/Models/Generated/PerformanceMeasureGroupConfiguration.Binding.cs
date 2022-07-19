//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[PerformanceMeasureGroup]
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ProjectFirmaModels.Models
{
    public class PerformanceMeasureGroupConfiguration : EntityTypeConfiguration<PerformanceMeasureGroup>
    {
        public PerformanceMeasureGroupConfiguration() : this("dbo"){}

        public PerformanceMeasureGroupConfiguration(string schema)
        {
            ToTable("PerformanceMeasureGroup", schema);
            HasKey(x => x.PerformanceMeasureGroupID);
            Property(x => x.PerformanceMeasureGroupID).HasColumnName(@"PerformanceMeasureGroupID").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.TenantID).HasColumnName(@"TenantID").HasColumnType("int").IsRequired();
            Property(x => x.PerformanceMeasureGroupName).HasColumnName(@"PerformanceMeasureGroupName").HasColumnType("varchar").IsRequired().IsUnicode(false).HasMaxLength(200);
            Property(x => x.IconFileResourceInfoID).HasColumnName(@"IconFileResourceInfoID").HasColumnType("int").IsOptional();

            // Foreign keys
            HasOptional(a => a.IconFileResourceInfo).WithMany(b => b.PerformanceMeasureGroupsWhereYouAreTheIconFileResourceInfo).HasForeignKey(c => c.IconFileResourceInfoID).WillCascadeOnDelete(false); // FK_PerformanceMeasureGroup_FileResourceInfo_IconFileResourceInfoID_FileResourceInfoID
        }
    }
}