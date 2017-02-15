//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ProjectImplementingOrganization]
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
    [Table("[dbo].[ProjectImplementingOrganization]")]
    public partial class ProjectImplementingOrganization : IHavePrimaryKey, IHaveATenantID
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected ProjectImplementingOrganization()
        {

        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public ProjectImplementingOrganization(int projectImplementingOrganizationID, int projectID, int organizationID, bool isLeadOrganization) : this()
        {
            this.TenantID = HttpRequestStorage.Tenant.TenantID;
            
            this.ProjectImplementingOrganizationID = projectImplementingOrganizationID;
            this.ProjectID = projectID;
            this.OrganizationID = organizationID;
            this.IsLeadOrganization = isLeadOrganization;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields in preparation for insert into database
        /// </summary>
        public ProjectImplementingOrganization(int projectID, int organizationID, bool isLeadOrganization) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.ProjectImplementingOrganizationID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            
            this.TenantID = HttpRequestStorage.Tenant.TenantID;
            this.ProjectID = projectID;
            this.OrganizationID = organizationID;
            this.IsLeadOrganization = isLeadOrganization;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields, using objects whenever possible
        /// </summary>
        public ProjectImplementingOrganization(Project project, Organization organization, bool isLeadOrganization) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.ProjectImplementingOrganizationID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            this.TenantID = HttpRequestStorage.Tenant.TenantID;
            this.ProjectID = project.ProjectID;
            this.Project = project;
            project.ProjectImplementingOrganizations.Add(this);
            this.OrganizationID = organization.OrganizationID;
            this.Organization = organization;
            organization.ProjectImplementingOrganizations.Add(this);
            this.IsLeadOrganization = isLeadOrganization;
        }

        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static ProjectImplementingOrganization CreateNewBlank(Project project, Organization organization)
        {
            return new ProjectImplementingOrganization(project, organization, default(bool));
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
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(ProjectImplementingOrganization).Name};

        [Key]
        public int ProjectImplementingOrganizationID { get; set; }
        public int TenantID { get; private set; }
        public int ProjectID { get; set; }
        public int OrganizationID { get; set; }
        public bool IsLeadOrganization { get; set; }
        public int PrimaryKey { get { return ProjectImplementingOrganizationID; } set { ProjectImplementingOrganizationID = value; } }

        public Tenant Tenant { get { return Tenant.AllLookupDictionary[TenantID]; } }
        public virtual Project Project { get; set; }
        public virtual Organization Organization { get; set; }

        public static class FieldLengths
        {

        }
    }
}