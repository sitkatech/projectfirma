//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[Notification]
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ProjectFirmaModels.Models
{
    public class NotificationConfiguration : EntityTypeConfiguration<Notification>
    {
        public NotificationConfiguration() : this("dbo"){}

        public NotificationConfiguration(string schema)
        {
            ToTable("Notification", schema);
            HasKey(x => x.NotificationID);
            Property(x => x.NotificationID).HasColumnName(@"NotificationID").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.TenantID).HasColumnName(@"TenantID").HasColumnType("int").IsRequired();
            Property(x => x.NotificationTypeID).HasColumnName(@"NotificationTypeID").HasColumnType("int").IsRequired();
            Property(x => x.PersonID).HasColumnName(@"PersonID").HasColumnType("int").IsRequired();
            Property(x => x.NotificationDate).HasColumnName(@"NotificationDate").HasColumnType("datetime").IsRequired();

            // Foreign keys
            HasRequired(a => a.Person).WithMany(b => b.Notifications).HasForeignKey(c => c.PersonID).WillCascadeOnDelete(false); // FK_Notification_Person_PersonID
        }
    }
}