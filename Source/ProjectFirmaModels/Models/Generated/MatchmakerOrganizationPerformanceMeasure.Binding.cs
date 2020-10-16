//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[MatchmakerOrganizationPerformanceMeasure]
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.Data.Entity.Spatial;
using System.Linq;
using System.Web;
using CodeFirstStoreFunctions;
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    // Table [dbo].[MatchmakerOrganizationPerformanceMeasure] is multi-tenant, so is attributed as IHaveATenantID
    [Table("[dbo].[MatchmakerOrganizationPerformanceMeasure]")]
    public partial class MatchmakerOrganizationPerformanceMeasure : IHavePrimaryKey, IHaveATenantID
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected MatchmakerOrganizationPerformanceMeasure()
        {

        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public MatchmakerOrganizationPerformanceMeasure(int matchmakerOrganizationPerformanceMeasureID, int organizationID, int performanceMeasureID) : this()
        {
            this.MatchmakerOrganizationPerformanceMeasureID = matchmakerOrganizationPerformanceMeasureID;
            this.OrganizationID = organizationID;
            this.PerformanceMeasureID = performanceMeasureID;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields in preparation for insert into database
        /// </summary>
        public MatchmakerOrganizationPerformanceMeasure(int organizationID, int performanceMeasureID) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.MatchmakerOrganizationPerformanceMeasureID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            
            this.OrganizationID = organizationID;
            this.PerformanceMeasureID = performanceMeasureID;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields, using objects whenever possible
        /// </summary>
        public MatchmakerOrganizationPerformanceMeasure(Organization organization, PerformanceMeasure performanceMeasure) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.MatchmakerOrganizationPerformanceMeasureID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            this.OrganizationID = organization.OrganizationID;
            this.Organization = organization;
            organization.MatchmakerOrganizationPerformanceMeasures.Add(this);
            this.PerformanceMeasureID = performanceMeasure.PerformanceMeasureID;
            this.PerformanceMeasure = performanceMeasure;
            performanceMeasure.MatchmakerOrganizationPerformanceMeasures.Add(this);
        }

        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static MatchmakerOrganizationPerformanceMeasure CreateNewBlank(Organization organization, PerformanceMeasure performanceMeasure)
        {
            return new MatchmakerOrganizationPerformanceMeasure(organization, performanceMeasure);
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
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(MatchmakerOrganizationPerformanceMeasure).Name};


        /// <summary>
        /// Delete just the entity 
        /// </summary>
        public void Delete(DatabaseEntities dbContext)
        {
            dbContext.AllMatchmakerOrganizationPerformanceMeasures.Remove(this);
        }
        
        /// <summary>
        /// Delete entity plus all children
        /// </summary>
        public void DeleteFull(DatabaseEntities dbContext)
        {
            
            Delete(dbContext);
        }

        [Key]
        public int MatchmakerOrganizationPerformanceMeasureID { get; set; }
        public int TenantID { get; set; }
        public int OrganizationID { get; set; }
        public int PerformanceMeasureID { get; set; }
        [NotMapped]
        public int PrimaryKey { get { return MatchmakerOrganizationPerformanceMeasureID; } set { MatchmakerOrganizationPerformanceMeasureID = value; } }

        public Tenant Tenant { get { return Tenant.AllLookupDictionary[TenantID]; } }
        public virtual Organization Organization { get; set; }
        public virtual PerformanceMeasure PerformanceMeasure { get; set; }

        public static class FieldLengths
        {

        }
    }
}