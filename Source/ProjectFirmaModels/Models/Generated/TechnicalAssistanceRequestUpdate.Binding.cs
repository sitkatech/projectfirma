//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[TechnicalAssistanceRequestUpdate]
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
    // Table [dbo].[TechnicalAssistanceRequestUpdate] is multi-tenant, so is attributed as IHaveATenantID
    [Table("[dbo].[TechnicalAssistanceRequestUpdate]")]
    public partial class TechnicalAssistanceRequestUpdate : IHavePrimaryKey, IHaveATenantID
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected TechnicalAssistanceRequestUpdate()
        {

        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public TechnicalAssistanceRequestUpdate(int technicalAssistanceRequestUpdateID, int projectUpdateBatchID, int fiscalYear, int? personID, int technicalAssistanceTypeID, int? hoursRequested, int? hoursAllocated, int? hoursProvided, string notes) : this()
        {
            this.TechnicalAssistanceRequestUpdateID = technicalAssistanceRequestUpdateID;
            this.ProjectUpdateBatchID = projectUpdateBatchID;
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
        public TechnicalAssistanceRequestUpdate(int projectUpdateBatchID, int fiscalYear, int technicalAssistanceTypeID) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.TechnicalAssistanceRequestUpdateID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            
            this.ProjectUpdateBatchID = projectUpdateBatchID;
            this.FiscalYear = fiscalYear;
            this.TechnicalAssistanceTypeID = technicalAssistanceTypeID;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields, using objects whenever possible
        /// </summary>
        public TechnicalAssistanceRequestUpdate(ProjectUpdateBatch projectUpdateBatch, int fiscalYear, TechnicalAssistanceType technicalAssistanceType) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.TechnicalAssistanceRequestUpdateID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            this.ProjectUpdateBatchID = projectUpdateBatch.ProjectUpdateBatchID;
            this.ProjectUpdateBatch = projectUpdateBatch;
            projectUpdateBatch.TechnicalAssistanceRequestUpdates.Add(this);
            this.FiscalYear = fiscalYear;
            this.TechnicalAssistanceTypeID = technicalAssistanceType.TechnicalAssistanceTypeID;
        }

        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static TechnicalAssistanceRequestUpdate CreateNewBlank(ProjectUpdateBatch projectUpdateBatch, TechnicalAssistanceType technicalAssistanceType)
        {
            return new TechnicalAssistanceRequestUpdate(projectUpdateBatch, default(int), technicalAssistanceType);
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
            
            return dependentObjects.Distinct().ToList();
        }

        /// <summary>
        /// Dependent type names of this entity
        /// </summary>
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(TechnicalAssistanceRequestUpdate).Name};


        /// <summary>
        /// Delete just the entity 
        /// </summary>
        public void Delete(DatabaseEntities dbContext)
        {
            dbContext.AllTechnicalAssistanceRequestUpdates.Remove(this);
        }
        
        /// <summary>
        /// Delete entity plus all children
        /// </summary>
        public void DeleteFull(DatabaseEntities dbContext)
        {
            
            Delete(dbContext);
        }

        [Key]
        public int TechnicalAssistanceRequestUpdateID { get; set; }
        public int TenantID { get; set; }
        public int ProjectUpdateBatchID { get; set; }
        public int FiscalYear { get; set; }
        public int? PersonID { get; set; }
        public int TechnicalAssistanceTypeID { get; set; }
        public int? HoursRequested { get; set; }
        public int? HoursAllocated { get; set; }
        public int? HoursProvided { get; set; }
        public string Notes { get; set; }
        [NotMapped]
        public int PrimaryKey { get { return TechnicalAssistanceRequestUpdateID; } set { TechnicalAssistanceRequestUpdateID = value; } }

        public Tenant Tenant { get { return Tenant.AllLookupDictionary[TenantID]; } }
        public virtual ProjectUpdateBatch ProjectUpdateBatch { get; set; }
        public virtual Person Person { get; set; }
        public TechnicalAssistanceType TechnicalAssistanceType { get { return TechnicalAssistanceType.AllLookupDictionary[TechnicalAssistanceTypeID]; } }

        public static class FieldLengths
        {

        }
    }
}