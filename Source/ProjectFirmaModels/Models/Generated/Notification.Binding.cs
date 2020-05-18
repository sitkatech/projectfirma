//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[Notification]
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.Data.Entity.Spatial;
using System.Linq;
using System.Web;
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    // Table [dbo].[Notification] is multi-tenant, so is attributed as IHaveATenantID
    [Table("[dbo].[Notification]")]
    public partial class Notification : IHavePrimaryKey, IHaveATenantID
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected Notification()
        {
            this.NotificationProjects = new HashSet<NotificationProject>();
        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public Notification(int notificationID, int notificationTypeID, int personID, DateTime notificationDate) : this()
        {
            this.NotificationID = notificationID;
            this.NotificationTypeID = notificationTypeID;
            this.PersonID = personID;
            this.NotificationDate = notificationDate;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields in preparation for insert into database
        /// </summary>
        public Notification(int notificationTypeID, int personID, DateTime notificationDate) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.NotificationID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            
            this.NotificationTypeID = notificationTypeID;
            this.PersonID = personID;
            this.NotificationDate = notificationDate;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields, using objects whenever possible
        /// </summary>
        public Notification(NotificationType notificationType, Person person, DateTime notificationDate) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.NotificationID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            this.NotificationTypeID = notificationType.NotificationTypeID;
            this.PersonID = person.PersonID;
            this.Person = person;
            person.Notifications.Add(this);
            this.NotificationDate = notificationDate;
        }

        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static Notification CreateNewBlank(NotificationType notificationType, Person person)
        {
            return new Notification(notificationType, person, default(DateTime));
        }

        /// <summary>
        /// Does this object have any dependent objects? (If it does have dependent objects, these would need to be deleted before this object could be deleted.)
        /// </summary>
        /// <returns></returns>
        public bool HasDependentObjects()
        {
            return NotificationProjects.Any();
        }

        /// <summary>
        /// Active Dependent type names of this object
        /// </summary>
        public List<string> DependentObjectNames() 
        {
            var dependentObjects = new List<string>();
            
            if(NotificationProjects.Any())
            {
                dependentObjects.Add(typeof(NotificationProject).Name);
            }
            return dependentObjects.Distinct().ToList();
        }

        /// <summary>
        /// Dependent type names of this entity
        /// </summary>
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(Notification).Name, typeof(NotificationProject).Name};


        /// <summary>
        /// Delete just the entity 
        /// </summary>
        public void Delete(DatabaseEntities dbContext)
        {
            dbContext.AllNotifications.Remove(this);
        }
        
        /// <summary>
        /// Delete entity plus all children
        /// </summary>
        public void DeleteFull(DatabaseEntities dbContext)
        {
            DeleteChildren(dbContext);
            Delete(dbContext);
        }
        /// <summary>
        /// Dependent type names of this entity
        /// </summary>
        public void DeleteChildren(DatabaseEntities dbContext)
        {

            foreach(var x in NotificationProjects.ToList())
            {
                x.DeleteFull(dbContext);
            }
        }

        [Key]
        public int NotificationID { get; set; }
        public int TenantID { get; set; }
        public int NotificationTypeID { get; set; }
        public int PersonID { get; set; }
        public DateTime NotificationDate { get; set; }
        [NotMapped]
        public int PrimaryKey { get { return NotificationID; } set { NotificationID = value; } }

        public virtual ICollection<NotificationProject> NotificationProjects { get; set; }
        public Tenant Tenant { get { return Tenant.AllLookupDictionary[TenantID]; } }
        public NotificationType NotificationType { get { return NotificationType.AllLookupDictionary[NotificationTypeID]; } }
        public virtual Person Person { get; set; }

        public static class FieldLengths
        {

        }
    }
}