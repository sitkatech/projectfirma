//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ProjectFundingOrganization]
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
    [Table("[dbo].[ProjectFundingOrganization]")]
    public partial class ProjectFundingOrganization : IHavePrimaryKey, IHaveATenantID
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected ProjectFundingOrganization()
        {

        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public ProjectFundingOrganization(int projectFundingOrganizationID, int projectID, int organizationID) : this()
        {
            this.TenantID = HttpRequestStorage.Tenant.TenantID;
            
            this.ProjectFundingOrganizationID = projectFundingOrganizationID;
            this.ProjectID = projectID;
            this.OrganizationID = organizationID;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields in preparation for insert into database
        /// </summary>
        public ProjectFundingOrganization(int projectID, int organizationID) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.ProjectFundingOrganizationID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            
            this.TenantID = HttpRequestStorage.Tenant.TenantID;
            this.ProjectID = projectID;
            this.OrganizationID = organizationID;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields, using objects whenever possible
        /// </summary>
        public ProjectFundingOrganization(Project project, Organization organization) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.ProjectFundingOrganizationID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            this.Tenant = HttpRequestStorage.Tenant;
            this.ProjectID = project.ProjectID;
            this.Project = project;
            project.ProjectFundingOrganizations.Add(this);
            this.OrganizationID = organization.OrganizationID;
            this.Organization = organization;
            organization.ProjectFundingOrganizations.Add(this);
        }

        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static ProjectFundingOrganization CreateNewBlank(Project project, Organization organization)
        {
            return new ProjectFundingOrganization(project, organization);
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
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(ProjectFundingOrganization).Name};

        [Key]
        public int ProjectFundingOrganizationID { get; set; }
        public int ProjectID { get; set; }
        public int OrganizationID { get; set; }
        public int TenantID { get; set; }
        public int PrimaryKey { get { return ProjectFundingOrganizationID; } set { ProjectFundingOrganizationID = value; } }

        public virtual Project Project { get; set; }
        public virtual Organization Organization { get; set; }
        public virtual Tenant Tenant { get; set; }

        public static class FieldLengths
        {

        }
    }
}