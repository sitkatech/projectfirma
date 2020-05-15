//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[TechnicalAssistanceRequest]
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
    // Table [dbo].[TechnicalAssistanceRequest] is multi-tenant, so is attributed as IHaveATenantID
    [Table("[dbo].[TechnicalAssistanceRequest]")]
    public partial class TechnicalAssistanceRequest : IHavePrimaryKey, IHaveATenantID
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected TechnicalAssistanceRequest()
        {

        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public TechnicalAssistanceRequest(int technicalAssistanceRequestID, int projectID, int fiscalYear, int? personID, int technicalAssistanceTypeID, int? hoursRequested, int? hoursAllocated, int? hoursProvided, string notes) : this()
        {
            this.TechnicalAssistanceRequestID = technicalAssistanceRequestID;
            this.ProjectID = projectID;
            this.FiscalYear = fiscalYear;
            this.PersonID = personID;
            this.TechnicalAssistanceTypeID = technicalAssistanceTypeID;
            this.HoursRequested = hoursRequested;
            this.HoursAllocated = hoursAllocated;
            this.HoursProvided = hoursProvided;
            this.Notes = notes;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields in preparation for insert into database
        /// </summary>
        public TechnicalAssistanceRequest(int projectID, int fiscalYear, int technicalAssistanceTypeID) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.TechnicalAssistanceRequestID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            
            this.ProjectID = projectID;
            this.FiscalYear = fiscalYear;
            this.TechnicalAssistanceTypeID = technicalAssistanceTypeID;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields, using objects whenever possible
        /// </summary>
        public TechnicalAssistanceRequest(Project project, int fiscalYear, TechnicalAssistanceType technicalAssistanceType) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.TechnicalAssistanceRequestID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            this.ProjectID = project.ProjectID;
            this.Project = project;
            project.TechnicalAssistanceRequests.Add(this);
            this.FiscalYear = fiscalYear;
            this.TechnicalAssistanceTypeID = technicalAssistanceType.TechnicalAssistanceTypeID;
        }

        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static TechnicalAssistanceRequest CreateNewBlank(Project project, TechnicalAssistanceType technicalAssistanceType)
        {
            return new TechnicalAssistanceRequest(project, default(int), technicalAssistanceType);
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
        /// Active Dependent type names of this object
        /// </summary>
        public List<string> DependentObjectNames() 
        {
            var dependentObjects = new List<string>();
            
            return dependentObjects;
        }

        /// <summary>
        /// Dependent type names of this entity
        /// </summary>
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(TechnicalAssistanceRequest).Name};


        /// <summary>
        /// Delete just the entity 
        /// </summary>
        public void Delete(DatabaseEntities dbContext)
        {
            dbContext.AllTechnicalAssistanceRequests.Remove(this);
        }
        
        /// <summary>
        /// Delete entity plus all children
        /// </summary>
        public void DeleteFull(DatabaseEntities dbContext)
        {
            
            Delete(dbContext);
        }

        [Key]
        public int TechnicalAssistanceRequestID { get; set; }
        public int TenantID { get; set; }
        public int ProjectID { get; set; }
        public int FiscalYear { get; set; }
        public int? PersonID { get; set; }
        public int TechnicalAssistanceTypeID { get; set; }
        public int? HoursRequested { get; set; }
        public int? HoursAllocated { get; set; }
        public int? HoursProvided { get; set; }
        public string Notes { get; set; }
        [NotMapped]
        public int PrimaryKey { get { return TechnicalAssistanceRequestID; } set { TechnicalAssistanceRequestID = value; } }

        public Tenant Tenant { get { return Tenant.AllLookupDictionary[TenantID]; } }
        public virtual Project Project { get; set; }
        public virtual Person Person { get; set; }
        public TechnicalAssistanceType TechnicalAssistanceType { get { return TechnicalAssistanceType.AllLookupDictionary[TechnicalAssistanceTypeID]; } }

        public static class FieldLengths
        {

        }
    }
}