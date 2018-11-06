//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[NotificationProject]
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.Data.Entity.Spatial;
using System.Linq;
using System.Web;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Models
{
    [Table("[dbo].[NotificationProject]")]
    public partial class NotificationProject : IHavePrimaryKey, IHaveATenantID
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected NotificationProject()
        {

            this.TenantID = HttpRequestStorage.Tenant.TenantID;
        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public NotificationProject(int notificationProjectID, int notificationID, int projectID) : this()
        {
            this.NotificationProjectID = notificationProjectID;
            this.NotificationID = notificationID;
            this.ProjectID = projectID;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields in preparation for insert into database
        /// </summary>
        public NotificationProject(int notificationID, int projectID) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.NotificationProjectID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            
            this.NotificationID = notificationID;
            this.ProjectID = projectID;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields, using objects whenever possible
        /// </summary>
        public NotificationProject(Notification notification, Project project) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.NotificationProjectID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            this.NotificationID = notification.NotificationID;
            this.Notification = notification;
            notification.NotificationProjects.Add(this);
            this.ProjectID = project.ProjectID;
            this.Project = project;
            project.NotificationProjects.Add(this);
        }

        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static NotificationProject CreateNewBlank(Notification notification, Project project)
        {
            return new NotificationProject(notification, project);
        }

        /// <summary>
        /// Does this object have any dependent objects? (If it does have dependent objects, these would need to be deleted before this object could be deleted.)
        /// </summary>
        /// <returns></returns>
        public bool HasDependentObjects()
        {
            return false;
        }

        /// <summary>
        /// Dependent type names of this entity
        /// </summary>
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(NotificationProject).Name};


        /// <summary>
        /// Dependent type names of this entity
        /// </summary>
        public void DeleteFull()
        {
            DeleteFull(HttpRequestStorage.DatabaseEntities);
        }

        /// <summary>
        /// Dependent type names of this entity
        /// </summary>
        public void DeleteFull(DatabaseEntities dbContext)
        {
            dbContext.AllNotificationProjects.Remove(this);
        }

        [Key]
        public int NotificationProjectID { get; set; }
        public int TenantID { get; private set; }
        public int NotificationID { get; set; }
        public int ProjectID { get; set; }
        [NotMapped]
        public int PrimaryKey { get { return NotificationProjectID; } set { NotificationProjectID = value; } }

        public Tenant Tenant { get { return Tenant.AllLookupDictionary[TenantID]; } }
        public virtual Notification Notification { get; set; }
        public virtual Project Project { get; set; }

        public static class FieldLengths
        {

        }
    }
}