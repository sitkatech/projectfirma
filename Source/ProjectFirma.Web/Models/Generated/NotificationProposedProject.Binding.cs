//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[NotificationProposedProject]
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
    [Table("[dbo].[NotificationProposedProject]")]
    public partial class NotificationProposedProject : IHavePrimaryKey, IHaveATenantID
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected NotificationProposedProject()
        {

        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public NotificationProposedProject(int notificationProposedProjectID, int proposedProjectID, int notificationID) : this()
        {
            this.TenantID = HttpRequestStorage.Tenant.TenantID;
            
            this.NotificationProposedProjectID = notificationProposedProjectID;
            this.ProposedProjectID = proposedProjectID;
            this.NotificationID = notificationID;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields in preparation for insert into database
        /// </summary>
        public NotificationProposedProject(int proposedProjectID, int notificationID) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.NotificationProposedProjectID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            
            this.TenantID = HttpRequestStorage.Tenant.TenantID;
            this.ProposedProjectID = proposedProjectID;
            this.NotificationID = notificationID;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields, using objects whenever possible
        /// </summary>
        public NotificationProposedProject(ProposedProject proposedProject, Notification notification) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.NotificationProposedProjectID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            this.Tenant = HttpRequestStorage.Tenant;
            this.ProposedProjectID = proposedProject.ProposedProjectID;
            this.ProposedProject = proposedProject;
            proposedProject.NotificationProposedProjects.Add(this);
            this.NotificationID = notification.NotificationID;
            this.Notification = notification;
            notification.NotificationProposedProjects.Add(this);
        }

        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static NotificationProposedProject CreateNewBlank(ProposedProject proposedProject, Notification notification)
        {
            return new NotificationProposedProject(proposedProject, notification);
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
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(NotificationProposedProject).Name};

        [Key]
        public int NotificationProposedProjectID { get; set; }
        public int ProposedProjectID { get; set; }
        public int NotificationID { get; set; }
        public int TenantID { get; set; }
        public int PrimaryKey { get { return NotificationProposedProjectID; } set { NotificationProposedProjectID = value; } }

        public virtual ProposedProject ProposedProject { get; set; }
        public virtual Notification Notification { get; set; }
        public virtual Tenant Tenant { get; set; }

        public static class FieldLengths
        {

        }
    }
}