//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[RelationshipType]
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
    // Table [dbo].[RelationshipType] is multi-tenant, so is attributed as IHaveATenantID
    [Table("[dbo].[RelationshipType]")]
    public partial class RelationshipType : IHavePrimaryKey, IHaveATenantID
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected RelationshipType()
        {
            this.OrganizationTypeRelationshipTypes = new HashSet<OrganizationTypeRelationshipType>();
            this.ProjectOrganizations = new HashSet<ProjectOrganization>();
            this.ProjectOrganizationUpdates = new HashSet<ProjectOrganizationUpdate>();
            this.TenantID = HttpRequestStorage.Tenant.TenantID;
        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public RelationshipType(int relationshipTypeID, string relationshipTypeName, bool canStewardProjects, bool isPrimaryContact, bool canOnlyBeRelatedOnceToAProject, string relationshipTypeDescription, bool reportInAccomplishmentsDashboard, bool showOnFactSheet) : this()
        {
            this.RelationshipTypeID = relationshipTypeID;
            this.RelationshipTypeName = relationshipTypeName;
            this.CanStewardProjects = canStewardProjects;
            this.IsPrimaryContact = isPrimaryContact;
            this.CanOnlyBeRelatedOnceToAProject = canOnlyBeRelatedOnceToAProject;
            this.RelationshipTypeDescription = relationshipTypeDescription;
            this.ReportInAccomplishmentsDashboard = reportInAccomplishmentsDashboard;
            this.ShowOnFactSheet = showOnFactSheet;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields in preparation for insert into database
        /// </summary>
        public RelationshipType(string relationshipTypeName, bool canStewardProjects, bool isPrimaryContact, bool canOnlyBeRelatedOnceToAProject, bool reportInAccomplishmentsDashboard, bool showOnFactSheet) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.RelationshipTypeID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            
            this.RelationshipTypeName = relationshipTypeName;
            this.CanStewardProjects = canStewardProjects;
            this.IsPrimaryContact = isPrimaryContact;
            this.CanOnlyBeRelatedOnceToAProject = canOnlyBeRelatedOnceToAProject;
            this.ReportInAccomplishmentsDashboard = reportInAccomplishmentsDashboard;
            this.ShowOnFactSheet = showOnFactSheet;
        }


        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static RelationshipType CreateNewBlank()
        {
            return new RelationshipType(default(string), default(bool), default(bool), default(bool), default(bool), default(bool));
        }

        /// <summary>
        /// Does this object have any dependent objects? (If it does have dependent objects, these would need to be deleted before this object could be deleted.)
        /// </summary>
        /// <returns></returns>
        public bool HasDependentObjects()
        {
            return OrganizationTypeRelationshipTypes.Any() || ProjectOrganizations.Any() || ProjectOrganizationUpdates.Any();
        }

        /// <summary>
        /// Dependent type names of this entity
        /// </summary>
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(RelationshipType).Name, typeof(OrganizationTypeRelationshipType).Name, typeof(ProjectOrganization).Name, typeof(ProjectOrganizationUpdate).Name};


        /// <summary>
        /// Dependent type names of this entity
        /// </summary>
        public void DeleteFull(DatabaseEntities dbContext)
        {
            DeleteChildren(dbContext);
            dbContext.AllRelationshipTypes.Remove(this);
        }
        /// <summary>
        /// Dependent type names of this entity
        /// </summary>
        public void DeleteChildren(DatabaseEntities dbContext)
        {

            foreach(var x in OrganizationTypeRelationshipTypes.ToList())
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
        public int RelationshipTypeID { get; set; }
        public int TenantID { get; private set; }
        public string RelationshipTypeName { get; set; }
        public bool CanStewardProjects { get; set; }
        public bool IsPrimaryContact { get; set; }
        public bool CanOnlyBeRelatedOnceToAProject { get; set; }
        public string RelationshipTypeDescription { get; set; }
        public bool ReportInAccomplishmentsDashboard { get; set; }
        public bool ShowOnFactSheet { get; set; }
        [NotMapped]
        public int PrimaryKey { get { return RelationshipTypeID; } set { RelationshipTypeID = value; } }

        public virtual ICollection<OrganizationTypeRelationshipType> OrganizationTypeRelationshipTypes { get; set; }
        public virtual ICollection<ProjectOrganization> ProjectOrganizations { get; set; }
        public virtual ICollection<ProjectOrganizationUpdate> ProjectOrganizationUpdates { get; set; }
        public Tenant Tenant { get { return Tenant.AllLookupDictionary[TenantID]; } }

        public static class FieldLengths
        {
            public const int RelationshipTypeName = 200;
            public const int RelationshipTypeDescription = 360;
        }
    }
}