//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ProjectOrganizationUpdate]
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
    [Table("[dbo].[ProjectOrganizationUpdate]")]
    public partial class ProjectOrganizationUpdate : IHavePrimaryKey, IHaveATenantID
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected ProjectOrganizationUpdate()
        {

            this.TenantID = HttpRequestStorage.Tenant.TenantID;
        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public ProjectOrganizationUpdate(int projectOrganizationUpdateID, int projectUpdateBatchID, int organizationID, int relationshipTypeID) : this()
        {
            this.ProjectOrganizationUpdateID = projectOrganizationUpdateID;
            this.ProjectUpdateBatchID = projectUpdateBatchID;
            this.OrganizationID = organizationID;
            this.RelationshipTypeID = relationshipTypeID;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields in preparation for insert into database
        /// </summary>
        public ProjectOrganizationUpdate(int projectUpdateBatchID, int organizationID, int relationshipTypeID) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.ProjectOrganizationUpdateID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            
            this.ProjectUpdateBatchID = projectUpdateBatchID;
            this.OrganizationID = organizationID;
            this.RelationshipTypeID = relationshipTypeID;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields, using objects whenever possible
        /// </summary>
        public ProjectOrganizationUpdate(ProjectUpdateBatch projectUpdateBatch, Organization organization, RelationshipType relationshipType) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.ProjectOrganizationUpdateID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            this.ProjectUpdateBatchID = projectUpdateBatch.ProjectUpdateBatchID;
            this.ProjectUpdateBatch = projectUpdateBatch;
            projectUpdateBatch.ProjectOrganizationUpdates.Add(this);
            this.OrganizationID = organization.OrganizationID;
            this.Organization = organization;
            organization.ProjectOrganizationUpdates.Add(this);
            this.RelationshipTypeID = relationshipType.RelationshipTypeID;
            this.RelationshipType = relationshipType;
            relationshipType.ProjectOrganizationUpdates.Add(this);
        }

        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static ProjectOrganizationUpdate CreateNewBlank(ProjectUpdateBatch projectUpdateBatch, Organization organization, RelationshipType relationshipType)
        {
            return new ProjectOrganizationUpdate(projectUpdateBatch, organization, relationshipType);
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
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(ProjectOrganizationUpdate).Name};


        /// <summary>
        /// Dependent type names of this entity
        /// </summary>
        public void DeleteFull(DatabaseEntities dbContext)
        {
            
            dbContext.AllProjectOrganizationUpdates.Remove(this);
        }

        [Key]
        public int ProjectOrganizationUpdateID { get; set; }
        public int TenantID { get; private set; }
        public int ProjectUpdateBatchID { get; set; }
        public int OrganizationID { get; set; }
        public int RelationshipTypeID { get; set; }
        [NotMapped]
        public int PrimaryKey { get { return ProjectOrganizationUpdateID; } set { ProjectOrganizationUpdateID = value; } }

        public Tenant Tenant { get { return Tenant.AllLookupDictionary[TenantID]; } }
        public virtual ProjectUpdateBatch ProjectUpdateBatch { get; set; }
        public virtual Organization Organization { get; set; }
        public virtual RelationshipType RelationshipType { get; set; }

        public static class FieldLengths
        {

        }
    }
}