//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[StaffTimeActivity]
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
    [Table("[dbo].[StaffTimeActivity]")]
    public partial class StaffTimeActivity : IHavePrimaryKey, IHaveATenantID
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected StaffTimeActivity()
        {

            this.TenantID = HttpRequestStorage.Tenant.TenantID;
        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public StaffTimeActivity(int staffTimeActivityID, int projectID, int staffTimeActivityHours, decimal staffTimeActivityRate, decimal staffTimeActivityTotalAmount, DateTime staffTimeActivityStartDate, DateTime? staffTimeActivityEndDate, string staffTimeActivityNotes) : this()
        {
            this.StaffTimeActivityID = staffTimeActivityID;
            this.ProjectID = projectID;
            this.StaffTimeActivityHours = staffTimeActivityHours;
            this.StaffTimeActivityRate = staffTimeActivityRate;
            this.StaffTimeActivityTotalAmount = staffTimeActivityTotalAmount;
            this.StaffTimeActivityStartDate = staffTimeActivityStartDate;
            this.StaffTimeActivityEndDate = staffTimeActivityEndDate;
            this.StaffTimeActivityNotes = staffTimeActivityNotes;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields in preparation for insert into database
        /// </summary>
        public StaffTimeActivity(int projectID, int staffTimeActivityHours, decimal staffTimeActivityRate, decimal staffTimeActivityTotalAmount, DateTime staffTimeActivityStartDate, string staffTimeActivityNotes) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.StaffTimeActivityID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            
            this.ProjectID = projectID;
            this.StaffTimeActivityHours = staffTimeActivityHours;
            this.StaffTimeActivityRate = staffTimeActivityRate;
            this.StaffTimeActivityTotalAmount = staffTimeActivityTotalAmount;
            this.StaffTimeActivityStartDate = staffTimeActivityStartDate;
            this.StaffTimeActivityNotes = staffTimeActivityNotes;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields, using objects whenever possible
        /// </summary>
        public StaffTimeActivity(Project project, int staffTimeActivityHours, decimal staffTimeActivityRate, decimal staffTimeActivityTotalAmount, DateTime staffTimeActivityStartDate, string staffTimeActivityNotes) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.StaffTimeActivityID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            this.ProjectID = project.ProjectID;
            this.Project = project;
            project.StaffTimeActivities.Add(this);
            this.StaffTimeActivityHours = staffTimeActivityHours;
            this.StaffTimeActivityRate = staffTimeActivityRate;
            this.StaffTimeActivityTotalAmount = staffTimeActivityTotalAmount;
            this.StaffTimeActivityStartDate = staffTimeActivityStartDate;
            this.StaffTimeActivityNotes = staffTimeActivityNotes;
        }

        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static StaffTimeActivity CreateNewBlank(Project project)
        {
            return new StaffTimeActivity(project, default(int), default(decimal), default(decimal), default(DateTime), default(string));
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
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(StaffTimeActivity).Name};


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
            dbContext.AllStaffTimeActivities.Remove(this);
        }

        [Key]
        public int StaffTimeActivityID { get; set; }
        public int TenantID { get; private set; }
        public int ProjectID { get; set; }
        public int StaffTimeActivityHours { get; set; }
        public decimal StaffTimeActivityRate { get; set; }
        public decimal StaffTimeActivityTotalAmount { get; set; }
        public DateTime StaffTimeActivityStartDate { get; set; }
        public DateTime? StaffTimeActivityEndDate { get; set; }
        public string StaffTimeActivityNotes { get; set; }
        [NotMapped]
        public int PrimaryKey { get { return StaffTimeActivityID; } set { StaffTimeActivityID = value; } }

        public Tenant Tenant { get { return Tenant.AllLookupDictionary[TenantID]; } }
        public virtual Project Project { get; set; }

        public static class FieldLengths
        {

        }
    }
}