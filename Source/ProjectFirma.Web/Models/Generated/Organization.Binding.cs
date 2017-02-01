//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[Organization]
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
    [Table("[dbo].[Organization]")]
    public partial class Organization : IHavePrimaryKey, IHaveATenantID
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected Organization()
        {
            this.FundingSources = new HashSet<FundingSource>();
            this.Jurisdictions = new HashSet<Jurisdiction>();
            this.MonitoringProgramPartners = new HashSet<MonitoringProgramPartner>();
            this.People = new HashSet<Person>();
            this.ProjectFundingOrganizations = new HashSet<ProjectFundingOrganization>();
            this.ProjectImplementingOrganizations = new HashSet<ProjectImplementingOrganization>();
            this.ProposedProjectsWhereYouAreTheLeadImplementerOrganization = new HashSet<ProposedProject>();
        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public Organization(int organizationID, Guid? organizationGuid, string organizationName, string organizationAbbreviation, int sectorID, int? primaryContactPersonID, bool isActive, string organizationUrl, int? logoFileResourceID) : this()
        {
            this.OrganizationID = organizationID;
            this.OrganizationGuid = organizationGuid;
            this.OrganizationName = organizationName;
            this.OrganizationAbbreviation = organizationAbbreviation;
            this.SectorID = sectorID;
            this.PrimaryContactPersonID = primaryContactPersonID;
            this.IsActive = isActive;
            this.OrganizationUrl = organizationUrl;
            this.LogoFileResourceID = logoFileResourceID;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields in preparation for insert into database
        /// </summary>
        public Organization(string organizationName, int sectorID, bool isActive) : this()
        {
            // Mark this as a new object by setting primary key with special value
            OrganizationID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            
            this.OrganizationName = organizationName;
            this.SectorID = sectorID;
            this.IsActive = isActive;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields, using objects whenever possible
        /// </summary>
        public Organization(string organizationName, Sector sector, bool isActive) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.OrganizationID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            this.OrganizationName = organizationName;
            this.SectorID = sector.SectorID;
            this.IsActive = isActive;
        }

        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static Organization CreateNewBlank(Sector sector)
        {
            return new Organization(default(string), sector, default(bool));
        }

        /// <summary>
        /// Does this object have any dependent objects? (If it does have dependent objects, these would need to be deleted before this object could be deleted.)
        /// </summary>
        /// <returns></returns>
        public bool HasDependentObjects()
        {
            return FundingSources.Any() || (Jurisdiction != null) || MonitoringProgramPartners.Any() || People.Any() || ProjectFundingOrganizations.Any() || ProjectImplementingOrganizations.Any() || ProposedProjectsWhereYouAreTheLeadImplementerOrganization.Any();
        }

        /// <summary>
        /// Dependent type names of this entity
        /// </summary>
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(Organization).Name, typeof(FundingSource).Name, typeof(Jurisdiction).Name, typeof(MonitoringProgramPartner).Name, typeof(Person).Name, typeof(ProjectFundingOrganization).Name, typeof(ProjectImplementingOrganization).Name, typeof(ProposedProject).Name};

        [Key]
        public int OrganizationID { get; set; }
        public Guid? OrganizationGuid { get; set; }
        public string OrganizationName { get; set; }
        public string OrganizationAbbreviation { get; set; }
        public int SectorID { get; set; }
        public int? PrimaryContactPersonID { get; set; }
        public bool IsActive { get; set; }
        public string OrganizationUrl { get; set; }
        public int? LogoFileResourceID { get; set; }
        public int TenantID { get; set; }
        public int PrimaryKey { get { return OrganizationID; } set { OrganizationID = value; } }

        public virtual ICollection<FundingSource> FundingSources { get; set; }
        protected virtual ICollection<Jurisdiction> Jurisdictions { get; set; }
        public Jurisdiction Jurisdiction { get { return Jurisdictions.SingleOrDefault(); } set { Jurisdictions = new List<Jurisdiction>{value};} }
        public virtual ICollection<MonitoringProgramPartner> MonitoringProgramPartners { get; set; }
        public virtual ICollection<Person> People { get; set; }
        public virtual ICollection<ProjectFundingOrganization> ProjectFundingOrganizations { get; set; }
        public virtual ICollection<ProjectImplementingOrganization> ProjectImplementingOrganizations { get; set; }
        public virtual ICollection<ProposedProject> ProposedProjectsWhereYouAreTheLeadImplementerOrganization { get; set; }
        public Sector Sector { get { return Sector.AllLookupDictionary[SectorID]; } }
        public virtual Person PrimaryContactPerson { get; set; }
        public virtual FileResource LogoFileResource { get; set; }
        public virtual Tenant Tenant { get; set; }

        public static class FieldLengths
        {
            public const int OrganizationName = 200;
            public const int OrganizationAbbreviation = 20;
            public const int OrganizationUrl = 200;
        }
    }
}