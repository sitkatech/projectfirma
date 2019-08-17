//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[OrganizationRelationshipType]
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
    // Table [dbo].[OrganizationRelationshipType] is multi-tenant, so is attributed as IHaveATenantID
    [Table("[dbo].[OrganizationRelationshipType]")]
    public partial class OrganizationRelationshipType : IHavePrimaryKey, IHaveATenantID
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected OrganizationRelationshipType()
        {
            this.OrganizationTypeOrganizationRelationshipTypes = new HashSet<OrganizationTypeOrganizationRelationshipType>();
            this.ProjectOrganizations = new HashSet<ProjectOrganization>();
            this.ProjectOrganizationUpdates = new HashSet<ProjectOrganizationUpdate>();
        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public OrganizationRelationshipType(int organizationRelationshipTypeID, string organizationRelationshipTypeName, bool canStewardProjects, bool isPrimaryContact, bool canOnlyBeRelatedOnceToAProject, string organizationRelationshipTypeDescription, bool reportInAccomplishmentsDashboard, bool showOnFactSheet) : this()
        {
            this.OrganizationRelationshipTypeID = organizationRelationshipTypeID;
            this.OrganizationRelationshipTypeName = organizationRelationshipTypeName;
            this.CanStewardProjects = canStewardProjects;
            this.IsPrimaryContact = isPrimaryContact;
            this.CanOnlyBeRelatedOnceToAProject = canOnlyBeRelatedOnceToAProject;
            this.OrganizationRelationshipTypeDescription = organizationRelationshipTypeDescription;
            this.ReportInAccomplishmentsDashboard = reportInAccomplishmentsDashboard;
            this.ShowOnFactSheet = showOnFactSheet;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields in preparation for insert into database
        /// </summary>
        public OrganizationRelationshipType(string organizationRelationshipTypeName, bool canStewardProjects, bool isPrimaryContact, bool canOnlyBeRelatedOnceToAProject, bool reportInAccomplishmentsDashboard, bool showOnFactSheet) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.OrganizationRelationshipTypeID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            
            this.OrganizationRelationshipTypeName = organizationRelationshipTypeName;
            this.CanStewardProjects = canStewardProjects;
            this.IsPrimaryContact = isPrimaryContact;
            this.CanOnlyBeRelatedOnceToAProject = canOnlyBeRelatedOnceToAProject;
            this.ReportInAccomplishmentsDashboard = reportInAccomplishmentsDashboard;
            this.ShowOnFactSheet = showOnFactSheet;
        }


        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static OrganizationRelationshipType CreateNewBlank()
        {
            return new OrganizationRelationshipType(default(string), default(bool), default(bool), default(bool), default(bool), default(bool));
        }

        /// <summary>
        /// Does this object have any dependent objects? (If it does have dependent objects, these would need to be deleted before this object could be deleted.)
        /// </summary>
        /// <returns></returns>
        public bool HasDependentObjects()
        {
            return OrganizationTypeOrganizationRelationshipTypes.Any() || ProjectOrganizations.Any() || ProjectOrganizationUpdates.Any();
        }

        /// <summary>
        /// Dependent type names of this entity
        /// </summary>
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(OrganizationRelationshipType).Name, typeof(OrganizationTypeOrganizationRelationshipType).Name, typeof(ProjectOrganization).Name, typeof(ProjectOrganizationUpdate).Name};


        /// <summary>
        /// Delete just the entity 
        /// </summary>
        public void Delete(DatabaseEntities dbContext)
        {
            dbContext.AllOrganizationRelationshipTypes.Remove(this);
        }
        
        /// <summary>
        /// Delete entity plus all children
        /// </summary>
        public void DeleteFull(DatabaseEntities dbContext)
        {
            DeleteChildren(dbContext);
            Delete(dbContext);
        }
        /// <summary>
        /// Dependent type names of this entity
        /// </summary>
        public void DeleteChildren(DatabaseEntities dbContext)
        {

            foreach(var x in OrganizationTypeOrganizationRelationshipTypes.ToList())
            {
                x.DeleteFull(dbContext);
            }

            foreach(var x in ProjectOrganizations.ToList())
            {
                x.DeleteFull(dbContext);
            }

            foreach(var x in ProjectOrganizationUpdates.ToList())
            {
                x.DeleteFull(dbContext);
            }
        }

        [Key]
        public int OrganizationRelationshipTypeID { get; set; }
        public int TenantID { get; set; }
        public string OrganizationRelationshipTypeName { get; set; }
        public bool CanStewardProjects { get; set; }
        public bool IsPrimaryContact { get; set; }
        public bool CanOnlyBeRelatedOnceToAProject { get; set; }
        public string OrganizationRelationshipTypeDescription { get; set; }
        public bool ReportInAccomplishmentsDashboard { get; set; }
        public bool ShowOnFactSheet { get; set; }
        [NotMapped]
        public int PrimaryKey { get { return OrganizationRelationshipTypeID; } set { OrganizationRelationshipTypeID = value; } }

        public virtual ICollection<OrganizationTypeOrganizationRelationshipType> OrganizationTypeOrganizationRelationshipTypes { get; set; }
        public virtual ICollection<ProjectOrganization> ProjectOrganizations { get; set; }
        public virtual ICollection<ProjectOrganizationUpdate> ProjectOrganizationUpdates { get; set; }
        public Tenant Tenant { get { return Tenant.AllLookupDictionary[TenantID]; } }

        public static class FieldLengths
        {
            public const int OrganizationRelationshipTypeName = 200;
            public const int OrganizationRelationshipTypeDescription = 360;
        }
    }
}