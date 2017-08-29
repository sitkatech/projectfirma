//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ProposedProjectOrganization]
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
    [Table("[dbo].[ProposedProjectOrganization]")]
    public partial class ProposedProjectOrganization : IHavePrimaryKey, IHaveATenantID
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected ProposedProjectOrganization()
        {

            this.TenantID = HttpRequestStorage.Tenant.TenantID;
        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public ProposedProjectOrganization(int proposedProjectOrganizationID, int proposedProjectID, int organizationID, int relationshipTypeID) : this()
        {
            this.ProposedProjectOrganizationID = proposedProjectOrganizationID;
            this.ProposedProjectID = proposedProjectID;
            this.OrganizationID = organizationID;
            this.RelationshipTypeID = relationshipTypeID;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields in preparation for insert into database
        /// </summary>
        public ProposedProjectOrganization(int proposedProjectID, int organizationID, int relationshipTypeID) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.ProposedProjectOrganizationID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            
            this.ProposedProjectID = proposedProjectID;
            this.OrganizationID = organizationID;
            this.RelationshipTypeID = relationshipTypeID;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields, using objects whenever possible
        /// </summary>
        public ProposedProjectOrganization(ProposedProject proposedProject, Organization organization, RelationshipType relationshipType) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.ProposedProjectOrganizationID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            this.ProposedProjectID = proposedProject.ProposedProjectID;
            this.ProposedProject = proposedProject;
            proposedProject.ProposedProjectOrganizations.Add(this);
            this.OrganizationID = organization.OrganizationID;
            this.Organization = organization;
            organization.ProposedProjectOrganizations.Add(this);
            this.RelationshipTypeID = relationshipType.RelationshipTypeID;
            this.RelationshipType = relationshipType;
            relationshipType.ProposedProjectOrganizations.Add(this);
        }

        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static ProposedProjectOrganization CreateNewBlank(ProposedProject proposedProject, Organization organization, RelationshipType relationshipType)
        {
            return new ProposedProjectOrganization(proposedProject, organization, relationshipType);
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
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(ProposedProjectOrganization).Name};

        [Key]
        public int ProposedProjectOrganizationID { get; set; }
        public int TenantID { get; private set; }
        public int ProposedProjectID { get; set; }
        public int OrganizationID { get; set; }
        public int RelationshipTypeID { get; set; }
        public int PrimaryKey { get { return ProposedProjectOrganizationID; } set { ProposedProjectOrganizationID = value; } }

        public Tenant Tenant { get { return Tenant.AllLookupDictionary[TenantID]; } }
        public virtual ProposedProject ProposedProject { get; set; }
        public virtual Organization Organization { get; set; }
        public virtual RelationshipType RelationshipType { get; set; }

        public static class FieldLengths
        {

        }
    }
}