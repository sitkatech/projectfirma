//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[NotificationProject]
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ProjectFirmaModels.Models
{
    public class NotificationProjectConfiguration : EntityTypeConfiguration<NotificationProject>
    {
        public NotificationProjectConfiguration() : this("dbo"){}

        public NotificationProjectConfiguration(string schema)
        {
            ToTable("NotificationProject", schema);
            HasKey(x => x.NotificationProjectID);
            Property(x => x.NotificationProjectID).HasColumnName(@"NotificationProjectID").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.TenantID).HasColumnName(@"TenantID").HasColumnType("int").IsRequired();
            Property(x => x.NotificationID).HasColumnName(@"NotificationID").HasColumnType("int").IsRequired();
            Property(x => x.ProjectID).HasColumnName(@"ProjectID").HasColumnType("int").IsRequired();

            // Foreign keys
            HasRequired(a => a.Notification).WithMany(b => b.NotificationProjects).HasForeignKey(c => c.NotificationID).WillCascadeOnDelete(false); // FK_NotificationProject_Notification_NotificationID
            HasRequired(a => a.Project).WithMany(b => b.NotificationProjects).HasForeignKey(c => c.ProjectID).WillCascadeOnDelete(false); // FK_NotificationProject_Project_ProjectID
        }
    }
}