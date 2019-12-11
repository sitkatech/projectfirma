//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[Classification]
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ProjectFirmaModels.Models
{
    public class ClassificationConfiguration : EntityTypeConfiguration<Classification>
    {
        public ClassificationConfiguration() : this("dbo"){}

        public ClassificationConfiguration(string schema)
        {
            ToTable("Classification", schema);
            HasKey(x => x.ClassificationID);
            Property(x => x.ClassificationID).HasColumnName(@"ClassificationID").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.TenantID).HasColumnName(@"TenantID").HasColumnType("int").IsRequired();
            Property(x => x.ClassificationDescription).HasColumnName(@"ClassificationDescription").HasColumnType("varchar").IsRequired().IsUnicode(false).HasMaxLength(300);
            Property(x => x.ThemeColor).HasColumnName(@"ThemeColor").HasColumnType("varchar").IsRequired().IsUnicode(false).HasMaxLength(7);
            Property(x => x.DisplayName).HasColumnName(@"DisplayName").HasColumnType("varchar").IsRequired().IsUnicode(false).HasMaxLength(75);
            Property(x => x.GoalStatement).HasColumnName(@"GoalStatement").HasColumnType("varchar").IsOptional().IsUnicode(false).HasMaxLength(200);
            Property(x => x.KeyImageFileResourceID).HasColumnName(@"KeyImageFileResourceID").HasColumnType("int").IsOptional();
            Property(x => x.ClassificationSystemID).HasColumnName(@"ClassificationSystemID").HasColumnType("int").IsRequired();
            Property(x => x.ClassificationSortOrder).HasColumnName(@"ClassificationSortOrder").HasColumnType("int").IsOptional();

            // Foreign keys
            HasOptional(a => a.KeyImageFileResource).WithMany(b => b.ClassificationsWhereYouAreTheKeyImageFileResource).HasForeignKey(c => c.KeyImageFileResourceID).WillCascadeOnDelete(false); // FK_Classification_FileResource_KeyImageFileResourceID_FileResourceID
            HasRequired(a => a.ClassificationSystem).WithMany(b => b.Classifications).HasForeignKey(c => c.ClassificationSystemID).WillCascadeOnDelete(false); // FK_Classification_ClassificationSystem_ClassificationSystemID
        }
    }
}