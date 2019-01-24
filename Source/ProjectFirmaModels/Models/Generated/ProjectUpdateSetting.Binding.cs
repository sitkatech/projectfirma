//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ProjectUpdateSetting]
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
    // Table [dbo].[ProjectUpdateSetting] is multi-tenant, so is attributed as IHaveATenantID
    [Table("[dbo].[ProjectUpdateSetting]")]
    public partial class ProjectUpdateSetting : IHavePrimaryKey, IHaveATenantID
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected ProjectUpdateSetting()
        {

        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public ProjectUpdateSetting(int projectUpdateSettingID, DateTime? projectUpdateKickOffDate, DateTime? projectUpdateCloseOutDate, int? projectUpdateReminderInterval, bool enableProjectUpdateReminders, bool sendPeriodicReminders, bool sendCloseOutNotification, string projectUpdateKickOffIntroContent, string projectUpdateReminderIntroContent, string projectUpdateCloseOutIntroContent) : this()
        {
            this.ProjectUpdateSettingID = projectUpdateSettingID;
            this.ProjectUpdateKickOffDate = projectUpdateKickOffDate;
            this.ProjectUpdateCloseOutDate = projectUpdateCloseOutDate;
            this.ProjectUpdateReminderInterval = projectUpdateReminderInterval;
            this.EnableProjectUpdateReminders = enableProjectUpdateReminders;
            this.SendPeriodicReminders = sendPeriodicReminders;
            this.SendCloseOutNotification = sendCloseOutNotification;
            this.ProjectUpdateKickOffIntroContent = projectUpdateKickOffIntroContent;
            this.ProjectUpdateReminderIntroContent = projectUpdateReminderIntroContent;
            this.ProjectUpdateCloseOutIntroContent = projectUpdateCloseOutIntroContent;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields in preparation for insert into database
        /// </summary>
        public ProjectUpdateSetting(bool enableProjectUpdateReminders, bool sendPeriodicReminders, bool sendCloseOutNotification) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.ProjectUpdateSettingID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            
            this.EnableProjectUpdateReminders = enableProjectUpdateReminders;
            this.SendPeriodicReminders = sendPeriodicReminders;
            this.SendCloseOutNotification = sendCloseOutNotification;
        }


        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static ProjectUpdateSetting CreateNewBlank()
        {
            return new ProjectUpdateSetting(default(bool), default(bool), default(bool));
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
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(ProjectUpdateSetting).Name};


        /// <summary>
        /// Dependent type names of this entity
        /// </summary>
        public void DeleteFull(DatabaseEntities dbContext)
        {
            
            dbContext.AllProjectUpdateSettings.Remove(this);
        }

        [Key]
        public int ProjectUpdateSettingID { get; set; }
        public int TenantID { get; set; }
        public DateTime? ProjectUpdateKickOffDate { get; set; }
        public DateTime? ProjectUpdateCloseOutDate { get; set; }
        public int? ProjectUpdateReminderInterval { get; set; }
        public bool EnableProjectUpdateReminders { get; set; }
        public bool SendPeriodicReminders { get; set; }
        public bool SendCloseOutNotification { get; set; }
        public string ProjectUpdateKickOffIntroContent { get; set; }
        [NotMapped]
        public HtmlString ProjectUpdateKickOffIntroContentHtmlString
        { 
            get { return ProjectUpdateKickOffIntroContent == null ? null : new HtmlString(ProjectUpdateKickOffIntroContent); }
            set { ProjectUpdateKickOffIntroContent = value?.ToString(); }
        }
        public string ProjectUpdateReminderIntroContent { get; set; }
        [NotMapped]
        public HtmlString ProjectUpdateReminderIntroContentHtmlString
        { 
            get { return ProjectUpdateReminderIntroContent == null ? null : new HtmlString(ProjectUpdateReminderIntroContent); }
            set { ProjectUpdateReminderIntroContent = value?.ToString(); }
        }
        public string ProjectUpdateCloseOutIntroContent { get; set; }
        [NotMapped]
        public HtmlString ProjectUpdateCloseOutIntroContentHtmlString
        { 
            get { return ProjectUpdateCloseOutIntroContent == null ? null : new HtmlString(ProjectUpdateCloseOutIntroContent); }
            set { ProjectUpdateCloseOutIntroContent = value?.ToString(); }
        }
        [NotMapped]
        public int PrimaryKey { get { return ProjectUpdateSettingID; } set { ProjectUpdateSettingID = value; } }

        public Tenant Tenant { get { return Tenant.AllLookupDictionary[TenantID]; } }

        public static class FieldLengths
        {

        }
    }
}