//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[TreatmentActivity]
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
    [Table("[dbo].[TreatmentActivity]")]
    public partial class TreatmentActivity : IHavePrimaryKey, IHaveATenantID
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected TreatmentActivity()
        {

            this.TenantID = HttpRequestStorage.Tenant.TenantID;
        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public TreatmentActivity(int treatmentActivityID, int projectID, int treatmentActivityTypeID, decimal treatmentActivityAcresTreated, DateTime treatmentActivityStartDate, DateTime? treatmentActivityEndDate, string treatmentActivityNotes) : this()
        {
            this.TreatmentActivityID = treatmentActivityID;
            this.ProjectID = projectID;
            this.TreatmentActivityTypeID = treatmentActivityTypeID;
            this.TreatmentActivityAcresTreated = treatmentActivityAcresTreated;
            this.TreatmentActivityStartDate = treatmentActivityStartDate;
            this.TreatmentActivityEndDate = treatmentActivityEndDate;
            this.TreatmentActivityNotes = treatmentActivityNotes;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields in preparation for insert into database
        /// </summary>
        public TreatmentActivity(int projectID, int treatmentActivityTypeID, decimal treatmentActivityAcresTreated, DateTime treatmentActivityStartDate, string treatmentActivityNotes) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.TreatmentActivityID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            
            this.ProjectID = projectID;
            this.TreatmentActivityTypeID = treatmentActivityTypeID;
            this.TreatmentActivityAcresTreated = treatmentActivityAcresTreated;
            this.TreatmentActivityStartDate = treatmentActivityStartDate;
            this.TreatmentActivityNotes = treatmentActivityNotes;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields, using objects whenever possible
        /// </summary>
        public TreatmentActivity(Project project, TreatmentType treatmentActivityType, decimal treatmentActivityAcresTreated, DateTime treatmentActivityStartDate, string treatmentActivityNotes) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.TreatmentActivityID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            this.ProjectID = project.ProjectID;
            this.Project = project;
            project.TreatmentActivities.Add(this);
            this.TreatmentActivityTypeID = treatmentActivityType.TreatmentTypeID;
            this.TreatmentActivityAcresTreated = treatmentActivityAcresTreated;
            this.TreatmentActivityStartDate = treatmentActivityStartDate;
            this.TreatmentActivityNotes = treatmentActivityNotes;
        }

        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static TreatmentActivity CreateNewBlank(Project project, TreatmentType treatmentActivityType)
        {
            return new TreatmentActivity(project, treatmentActivityType, default(decimal), default(DateTime), default(string));
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
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(TreatmentActivity).Name};


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
            dbContext.AllTreatmentActivities.Remove(this);
        }

        [Key]
        public int TreatmentActivityID { get; set; }
        public int TenantID { get; private set; }
        public int ProjectID { get; set; }
        public int TreatmentActivityTypeID { get; set; }
        public decimal TreatmentActivityAcresTreated { get; set; }
        public DateTime TreatmentActivityStartDate { get; set; }
        public DateTime? TreatmentActivityEndDate { get; set; }
        public string TreatmentActivityNotes { get; set; }
        [NotMapped]
        public int PrimaryKey { get { return TreatmentActivityID; } set { TreatmentActivityID = value; } }

        public Tenant Tenant { get { return Tenant.AllLookupDictionary[TenantID]; } }
        public virtual Project Project { get; set; }
        public TreatmentType TreatmentActivityType { get { return TreatmentType.AllLookupDictionary[TreatmentActivityTypeID]; } }

        public static class FieldLengths
        {

        }
    }
}