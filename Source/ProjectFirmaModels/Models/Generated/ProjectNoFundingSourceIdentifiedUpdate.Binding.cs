//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ProjectNoFundingSourceIdentifiedUpdate]
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
    // Table [dbo].[ProjectNoFundingSourceIdentifiedUpdate] is multi-tenant, so is attributed as IHaveATenantID
    [Table("[dbo].[ProjectNoFundingSourceIdentifiedUpdate]")]
    public partial class ProjectNoFundingSourceIdentifiedUpdate : IHavePrimaryKey, IHaveATenantID
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected ProjectNoFundingSourceIdentifiedUpdate()
        {

        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public ProjectNoFundingSourceIdentifiedUpdate(int projectNoFundingSourceIdentifiedUpdateID, int projectUpdateBatchID, int? calendarYear, decimal? noFundingSourceIdentifiedYet) : this()
        {
            this.ProjectNoFundingSourceIdentifiedUpdateID = projectNoFundingSourceIdentifiedUpdateID;
            this.ProjectUpdateBatchID = projectUpdateBatchID;
            this.CalendarYear = calendarYear;
            this.NoFundingSourceIdentifiedYet = noFundingSourceIdentifiedYet;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields in preparation for insert into database
        /// </summary>
        public ProjectNoFundingSourceIdentifiedUpdate(int projectUpdateBatchID) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.ProjectNoFundingSourceIdentifiedUpdateID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            
            this.ProjectUpdateBatchID = projectUpdateBatchID;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields, using objects whenever possible
        /// </summary>
        public ProjectNoFundingSourceIdentifiedUpdate(ProjectUpdateBatch projectUpdateBatch) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.ProjectNoFundingSourceIdentifiedUpdateID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            this.ProjectUpdateBatchID = projectUpdateBatch.ProjectUpdateBatchID;
            this.ProjectUpdateBatch = projectUpdateBatch;
            projectUpdateBatch.ProjectNoFundingSourceIdentifiedUpdates.Add(this);
        }

        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static ProjectNoFundingSourceIdentifiedUpdate CreateNewBlank(ProjectUpdateBatch projectUpdateBatch)
        {
            return new ProjectNoFundingSourceIdentifiedUpdate(projectUpdateBatch);
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
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(ProjectNoFundingSourceIdentifiedUpdate).Name};


        /// <summary>
        /// Delete just the entity 
        /// </summary>
        public void Delete(DatabaseEntities dbContext)
        {
            dbContext.AllProjectNoFundingSourceIdentifiedUpdates.Remove(this);
        }
        
        /// <summary>
        /// Delete entity plus all children
        /// </summary>
        public void DeleteFull(DatabaseEntities dbContext)
        {
            
            Delete(dbContext);
        }

        [Key]
        public int ProjectNoFundingSourceIdentifiedUpdateID { get; set; }
        public int TenantID { get; set; }
        public int ProjectUpdateBatchID { get; set; }
        public int? CalendarYear { get; set; }
        public decimal? NoFundingSourceIdentifiedYet { get; set; }
        [NotMapped]
        public int PrimaryKey { get { return ProjectNoFundingSourceIdentifiedUpdateID; } set { ProjectNoFundingSourceIdentifiedUpdateID = value; } }

        public Tenant Tenant { get { return Tenant.AllLookupDictionary[TenantID]; } }
        public virtual ProjectUpdateBatch ProjectUpdateBatch { get; set; }

        public static class FieldLengths
        {

        }
    }
}