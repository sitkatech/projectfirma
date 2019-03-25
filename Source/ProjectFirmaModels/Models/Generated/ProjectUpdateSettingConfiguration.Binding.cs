//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ProjectUpdateSetting]
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ProjectFirmaModels.Models
{
    public class ProjectUpdateSettingConfiguration : EntityTypeConfiguration<ProjectUpdateSetting>
    {
        public ProjectUpdateSettingConfiguration() : this("dbo"){}

        public ProjectUpdateSettingConfiguration(string schema)
        {
            ToTable("ProjectUpdateSetting", schema);
            HasKey(x => x.ProjectUpdateSettingID);
            Property(x => x.ProjectUpdateSettingID).HasColumnName(@"ProjectUpdateSettingID").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.TenantID).HasColumnName(@"TenantID").HasColumnType("int").IsRequired();
            Property(x => x.ProjectUpdateKickOffDate).HasColumnName(@"ProjectUpdateKickOffDate").HasColumnType("datetime").IsOptional();
            Property(x => x.ProjectUpdateCloseOutDate).HasColumnName(@"ProjectUpdateCloseOutDate").HasColumnType("datetime").IsOptional();
            Property(x => x.ProjectUpdateReminderInterval).HasColumnName(@"ProjectUpdateReminderInterval").HasColumnType("int").IsOptional();
            Property(x => x.EnableProjectUpdateReminders).HasColumnName(@"EnableProjectUpdateReminders").HasColumnType("bit").IsRequired();
            Property(x => x.SendPeriodicReminders).HasColumnName(@"SendPeriodicReminders").HasColumnType("bit").IsRequired();
            Property(x => x.SendCloseOutNotification).HasColumnName(@"SendCloseOutNotification").HasColumnType("bit").IsRequired();
            Property(x => x.ProjectUpdateKickOffIntroContent).HasColumnName(@"ProjectUpdateKickOffIntroContent").HasColumnType("varchar").IsOptional();
            Property(x => x.ProjectUpdateReminderIntroContent).HasColumnName(@"ProjectUpdateReminderIntroContent").HasColumnType("varchar").IsOptional();
            Property(x => x.ProjectUpdateCloseOutIntroContent).HasColumnName(@"ProjectUpdateCloseOutIntroContent").HasColumnType("varchar").IsOptional();

            // Foreign keys

        }
    }
}