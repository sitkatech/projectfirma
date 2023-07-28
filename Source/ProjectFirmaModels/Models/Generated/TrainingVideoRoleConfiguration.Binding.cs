//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[TrainingVideoRole]
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ProjectFirmaModels.Models
{
    public class TrainingVideoRoleConfiguration : EntityTypeConfiguration<TrainingVideoRole>
    {
        public TrainingVideoRoleConfiguration() : this("dbo"){}

        public TrainingVideoRoleConfiguration(string schema)
        {
            ToTable("TrainingVideoRole", schema);
            HasKey(x => x.TrainingVideoRoleID);
            Property(x => x.TrainingVideoRoleID).HasColumnName(@"TrainingVideoRoleID").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.TenantID).HasColumnName(@"TenantID").HasColumnType("int").IsRequired();
            Property(x => x.TrainingVideoID).HasColumnName(@"TrainingVideoID").HasColumnType("int").IsRequired();
            Property(x => x.RoleID).HasColumnName(@"RoleID").HasColumnType("int").IsOptional();

            // Foreign keys
            HasRequired(a => a.TrainingVideo).WithMany(b => b.TrainingVideoRoles).HasForeignKey(c => c.TrainingVideoID).WillCascadeOnDelete(false); // FK_TrainingVideoRole_TrainingVideo_TrainingVideoID
        }
    }
}