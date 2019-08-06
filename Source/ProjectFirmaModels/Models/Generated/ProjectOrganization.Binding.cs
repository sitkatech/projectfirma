//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ProjectOrganization]
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
    // Table [dbo].[ProjectOrganization] is multi-tenant, so is attributed as IHaveATenantID
    [Table("[dbo].[ProjectOrganization]")]
    public partial class ProjectOrganization : IHavePrimaryKey, IHaveATenantID
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected ProjectOrganization()
        {

        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public ProjectOrganization(int projectOrganizationID, int projectID, int organizationID, int organizationRelationshipTypeID) : this()
        {
            this.ProjectOrganizationID = projectOrganizationID;
            this.ProjectID = projectID;
            this.OrganizationID = organizationID;
            this.OrganizationRelationshipTypeID = organizationRelationshipTypeID;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields in preparation for insert into database
        /// </summary>
        public ProjectOrganization(int projectID, int organizationID, int organizationRelationshipTypeID) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.ProjectOrganizationID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            
            this.ProjectID = projectID;
            this.OrganizationID = organizationID;
            this.OrganizationRelationshipTypeID = organizationRelationshipTypeID;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields, using objects whenever possible
        /// </summary>
        public ProjectOrganization(Project project, Organization organization, OrganizationRelationshipType organizationRelationshipType) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.ProjectOrganizationID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            this.ProjectID = project.ProjectID;
            this.Project = project;
            project.ProjectOrganizations.Add(this);
            this.OrganizationID = organization.OrganizationID;
            this.Organization = organization;
            organization.ProjectOrganizations.Add(this);
            this.OrganizationRelationshipTypeID = organizationRelationshipType.OrganizationRelationshipTypeID;
            this.OrganizationRelationshipType = organizationRelationshipType;
            organizationRelationshipType.ProjectOrganizations.Add(this);
        }

        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static ProjectOrganization CreateNewBlank(Project project, Organization organization, OrganizationRelationshipType organizationRelationshipType)
        {
            return new ProjectOrganization(project, organization, organizationRelationshipType);
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
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(ProjectOrganization).Name};


        /// <summary>
        /// Delete just the entity 
        /// </summary>
        public void Delete(DatabaseEntities dbContext)
        {
            dbContext.AllProjectOrganizations.Remove(this);
        }
        
        /// <summary>
        /// Delete entity plus all children
        /// </summary>
        public void DeleteFull(DatabaseEntities dbContext)
        {
            
            Delete(dbContext);
        }

        [Key]
        public int ProjectOrganizationID { get; set; }
        public int TenantID { get; set; }
        public int ProjectID { get; set; }
        public int OrganizationID { get; set; }
        public int OrganizationRelationshipTypeID { get; set; }
        [NotMapped]
        public int PrimaryKey { get { return ProjectOrganizationID; } set { ProjectOrganizationID = value; } }

        public Tenant Tenant { get { return Tenant.AllLookupDictionary[TenantID]; } }
        public virtual Project Project { get; set; }
        public virtual Organization Organization { get; set; }
        public virtual OrganizationRelationshipType OrganizationRelationshipType { get; set; }

        public static class FieldLengths
        {

        }
    }
}