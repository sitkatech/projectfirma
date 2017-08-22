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
            this.TenantID = HttpRequestStorage.Tenant.TenantID;
        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public RelationshipType(int relationshipTypeID, string relationshipTypeName, bool canApproveProjects) : this()
        {
            this.RelationshipTypeID = relationshipTypeID;
            this.RelationshipTypeName = relationshipTypeName;
            this.CanApproveProjects = canApproveProjects;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields in preparation for insert into database
        /// </summary>
        public RelationshipType(string relationshipTypeName, bool canApproveProjects) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.RelationshipTypeID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            
            this.RelationshipTypeName = relationshipTypeName;
            this.CanApproveProjects = canApproveProjects;
        }


        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static RelationshipType CreateNewBlank()
        {
            return new RelationshipType(default(string), default(bool));
        }

        /// <summary>
        /// Does this object have any dependent objects? (If it does have dependent objects, these would need to be deleted before this object could be deleted.)
        /// </summary>
        /// <returns></returns>
        public bool HasDependentObjects()
        {
            return OrganizationTypeRelationshipTypes.Any() || ProjectOrganizations.Any();
        }

        /// <summary>
        /// Dependent type names of this entity
        /// </summary>
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(RelationshipType).Name, typeof(OrganizationTypeRelationshipType).Name, typeof(ProjectOrganization).Name};

        [Key]
        public int RelationshipTypeID { get; set; }
        public int TenantID { get; private set; }
        public string RelationshipTypeName { get; set; }
        public bool CanApproveProjects { get; set; }
        public int PrimaryKey { get { return RelationshipTypeID; } set { RelationshipTypeID = value; } }

        public virtual ICollection<OrganizationTypeRelationshipType> OrganizationTypeRelationshipTypes { get; set; }
        public virtual ICollection<ProjectOrganization> ProjectOrganizations { get; set; }
        public Tenant Tenant { get { return Tenant.AllLookupDictionary[TenantID]; } }

        public static class FieldLengths
        {
            public const int RelationshipTypeName = 200;
        }
    }
}