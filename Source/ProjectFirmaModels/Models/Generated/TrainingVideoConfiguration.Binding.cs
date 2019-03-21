//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[TrainingVideo]
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ProjectFirmaModels.Models
{
    public class TrainingVideoConfiguration : EntityTypeConfiguration<TrainingVideo>
    {
        public TrainingVideoConfiguration() : this("dbo"){}

        public TrainingVideoConfiguration(string schema)
        {
            ToTable("TrainingVideo", schema);
            HasKey(x => x.TrainingVideoID);
            Property(x => x.TrainingVideoID).HasColumnName(@"TrainingVideoID").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.TenantID).HasColumnName(@"TenantID").HasColumnType("int").IsRequired();
            Property(x => x.VideoName).HasColumnName(@"VideoName").HasColumnType("varchar").IsRequired().IsUnicode(false).HasMaxLength(100);
            Property(x => x.VideoDescription).HasColumnName(@"VideoDescription").HasColumnType("varchar").IsOptional().IsUnicode(false).HasMaxLength(500);
            Property(x => x.VideoUploadDate).HasColumnName(@"VideoUploadDate").HasColumnType("datetime").IsRequired();
            Property(x => x.VideoURL).HasColumnName(@"VideoURL").HasColumnType("varchar").IsRequired().IsUnicode(false).HasMaxLength(100);

            // Foreign keys

        }
    }
}