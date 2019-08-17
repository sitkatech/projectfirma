//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ProjectNoFundingSourceIdentified]
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
    // Table [dbo].[ProjectNoFundingSourceIdentified] is multi-tenant, so is attributed as IHaveATenantID
    [Table("[dbo].[ProjectNoFundingSourceIdentified]")]
    public partial class ProjectNoFundingSourceIdentified : IHavePrimaryKey, IHaveATenantID
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected ProjectNoFundingSourceIdentified()
        {

        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public ProjectNoFundingSourceIdentified(int projectNoFundingSourceIdentifiedID, int projectID, int? calendarYear, decimal? noFundingSourceIdentifiedYet) : this()
        {
            this.ProjectNoFundingSourceIdentifiedID = projectNoFundingSourceIdentifiedID;
            this.ProjectID = projectID;
            this.CalendarYear = calendarYear;
            this.NoFundingSourceIdentifiedYet = noFundingSourceIdentifiedYet;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields in preparation for insert into database
        /// </summary>
        public ProjectNoFundingSourceIdentified(int projectID) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.ProjectNoFundingSourceIdentifiedID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            
            this.ProjectID = projectID;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields, using objects whenever possible
        /// </summary>
        public ProjectNoFundingSourceIdentified(Project project) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.ProjectNoFundingSourceIdentifiedID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            this.ProjectID = project.ProjectID;
            this.Project = project;
            project.ProjectNoFundingSourceIdentifieds.Add(this);
        }

        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static ProjectNoFundingSourceIdentified CreateNewBlank(Project project)
        {
            return new ProjectNoFundingSourceIdentified(project);
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
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(ProjectNoFundingSourceIdentified).Name};


        /// <summary>
        /// Delete just the entity 
        /// </summary>
        public void Delete(DatabaseEntities dbContext)
        {
            dbContext.AllProjectNoFundingSourceIdentifieds.Remove(this);
        }
        
        /// <summary>
        /// Delete entity plus all children
        /// </summary>
        public void DeleteFull(DatabaseEntities dbContext)
        {
            
            Delete(dbContext);
        }

        [Key]
        public int ProjectNoFundingSourceIdentifiedID { get; set; }
        public int TenantID { get; set; }
        public int ProjectID { get; set; }
        public int? CalendarYear { get; set; }
        public decimal? NoFundingSourceIdentifiedYet { get; set; }
        [NotMapped]
        public int PrimaryKey { get { return ProjectNoFundingSourceIdentifiedID; } set { ProjectNoFundingSourceIdentifiedID = value; } }

        public Tenant Tenant { get { return Tenant.AllLookupDictionary[TenantID]; } }
        public virtual Project Project { get; set; }

        public static class FieldLengths
        {

        }
    }
}