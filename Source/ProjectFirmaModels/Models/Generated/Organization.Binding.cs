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
using CodeFirstStoreFunctions;
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    // Table [dbo].[Organization] is multi-tenant, so is attributed as IHaveATenantID
    [Table("[dbo].[Organization]")]
    public partial class Organization : IHavePrimaryKey, IHaveATenantID
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected Organization()
        {
            this.FundingSources = new HashSet<FundingSource>();
            this.MatchMakerAreaOfInterestLocations = new HashSet<MatchMakerAreaOfInterestLocation>();
            this.MatchmakerOrganizationClassifications = new HashSet<MatchmakerOrganizationClassification>();
            this.MatchmakerOrganizationTaxonomyBranches = new HashSet<MatchmakerOrganizationTaxonomyBranch>();
            this.MatchmakerOrganizationTaxonomyLeafs = new HashSet<MatchmakerOrganizationTaxonomyLeaf>();
            this.MatchmakerOrganizationTaxonomyTrunks = new HashSet<MatchmakerOrganizationTaxonomyTrunk>();
            this.OrganizationBoundaryStagings = new HashSet<OrganizationBoundaryStaging>();
            this.OrganizationImages = new HashSet<OrganizationImage>();
            this.OrganizationMatchmakerKeywords = new HashSet<OrganizationMatchmakerKeyword>();
            this.People = new HashSet<Person>();
            this.PersonStewardOrganizations = new HashSet<PersonStewardOrganization>();
            this.ProjectOrganizations = new HashSet<ProjectOrganization>();
            this.ProjectOrganizationUpdates = new HashSet<ProjectOrganizationUpdate>();
        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public Organization(int organizationID, Guid? organizationGuid, string organizationName, string organizationShortName, int? primaryContactPersonID, bool isActive, string organizationUrl, int? logoFileResourceInfoID, int organizationTypeID, DbGeometry organizationBoundary, string description, bool? matchmakerOptIn, bool useOrganizationBoundaryForMatchmaker, bool? matchmakerCash, bool? matchmakerInKindServices, bool? matchmakerCommercialServices, string matchmakerCashDescription, string matchmakerInKindServicesDescription, string matchmakerCommercialServicesDescription, string matchmakerConstraints, string matchmakerAdditionalInformation) : this()
        {
            this.OrganizationID = organizationID;
            this.OrganizationGuid = organizationGuid;
            this.OrganizationName = organizationName;
            this.OrganizationShortName = organizationShortName;
            this.PrimaryContactPersonID = primaryContactPersonID;
            this.IsActive = isActive;
            this.OrganizationUrl = organizationUrl;
            this.LogoFileResourceInfoID = logoFileResourceInfoID;
            this.OrganizationTypeID = organizationTypeID;
            this.OrganizationBoundary = organizationBoundary;
            this.Description = description;
            this.MatchmakerOptIn = matchmakerOptIn;
            this.UseOrganizationBoundaryForMatchmaker = useOrganizationBoundaryForMatchmaker;
            this.MatchmakerCash = matchmakerCash;
            this.MatchmakerInKindServices = matchmakerInKindServices;
            this.MatchmakerCommercialServices = matchmakerCommercialServices;
            this.MatchmakerCashDescription = matchmakerCashDescription;
            this.MatchmakerInKindServicesDescription = matchmakerInKindServicesDescription;
            this.MatchmakerCommercialServicesDescription = matchmakerCommercialServicesDescription;
            this.MatchmakerConstraints = matchmakerConstraints;
            this.MatchmakerAdditionalInformation = matchmakerAdditionalInformation;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields in preparation for insert into database
        /// </summary>
        public Organization(string organizationName, bool isActive, int organizationTypeID, bool useOrganizationBoundaryForMatchmaker) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.OrganizationID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            
            this.OrganizationName = organizationName;
            this.IsActive = isActive;
            this.OrganizationTypeID = organizationTypeID;
            this.UseOrganizationBoundaryForMatchmaker = useOrganizationBoundaryForMatchmaker;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields, using objects whenever possible
        /// </summary>
        public Organization(string organizationName, bool isActive, OrganizationType organizationType, bool useOrganizationBoundaryForMatchmaker) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.OrganizationID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            this.OrganizationName = organizationName;
            this.IsActive = isActive;
            this.OrganizationTypeID = organizationType.OrganizationTypeID;
            this.OrganizationType = organizationType;
            organizationType.Organizations.Add(this);
            this.UseOrganizationBoundaryForMatchmaker = useOrganizationBoundaryForMatchmaker;
        }

        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static Organization CreateNewBlank(OrganizationType organizationType)
        {
            return new Organization(default(string), default(bool), organizationType, default(bool));
        }

        /// <summary>
        /// Does this object have any dependent objects? (If it does have dependent objects, these would need to be deleted before this object could be deleted.)
        /// </summary>
        /// <returns></returns>
        public bool HasDependentObjects()
        {
            return FundingSources.Any() || MatchMakerAreaOfInterestLocations.Any() || MatchmakerOrganizationClassifications.Any() || MatchmakerOrganizationTaxonomyBranches.Any() || MatchmakerOrganizationTaxonomyLeafs.Any() || MatchmakerOrganizationTaxonomyTrunks.Any() || OrganizationBoundaryStagings.Any() || OrganizationImages.Any() || OrganizationMatchmakerKeywords.Any() || People.Any() || PersonStewardOrganizations.Any() || ProjectOrganizations.Any() || ProjectOrganizationUpdates.Any();
        }

        /// <summary>
        /// Active Dependent type names of this object
        /// </summary>
        public List<string> DependentObjectNames() 
        {
            var dependentObjects = new List<string>();
            
            if(FundingSources.Any())
            {
                dependentObjects.Add(typeof(FundingSource).Name);
            }

            if(MatchMakerAreaOfInterestLocations.Any())
            {
                dependentObjects.Add(typeof(MatchMakerAreaOfInterestLocation).Name);
            }

            if(MatchmakerOrganizationClassifications.Any())
            {
                dependentObjects.Add(typeof(MatchmakerOrganizationClassification).Name);
            }

            if(MatchmakerOrganizationTaxonomyBranches.Any())
            {
                dependentObjects.Add(typeof(MatchmakerOrganizationTaxonomyBranch).Name);
            }

            if(MatchmakerOrganizationTaxonomyLeafs.Any())
            {
                dependentObjects.Add(typeof(MatchmakerOrganizationTaxonomyLeaf).Name);
            }

            if(MatchmakerOrganizationTaxonomyTrunks.Any())
            {
                dependentObjects.Add(typeof(MatchmakerOrganizationTaxonomyTrunk).Name);
            }

            if(OrganizationBoundaryStagings.Any())
            {
                dependentObjects.Add(typeof(OrganizationBoundaryStaging).Name);
            }

            if(OrganizationImages.Any())
            {
                dependentObjects.Add(typeof(OrganizationImage).Name);
            }

            if(OrganizationMatchmakerKeywords.Any())
            {
                dependentObjects.Add(typeof(OrganizationMatchmakerKeyword).Name);
            }

            if(People.Any())
            {
                dependentObjects.Add(typeof(Person).Name);
            }

            if(PersonStewardOrganizations.Any())
            {
                dependentObjects.Add(typeof(PersonStewardOrganization).Name);
            }

            if(ProjectOrganizations.Any())
            {
                dependentObjects.Add(typeof(ProjectOrganization).Name);
            }

            if(ProjectOrganizationUpdates.Any())
            {
                dependentObjects.Add(typeof(ProjectOrganizationUpdate).Name);
            }
            return dependentObjects.Distinct().ToList();
        }

        /// <summary>
        /// Dependent type names of this entity
        /// </summary>
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(Organization).Name, typeof(FundingSource).Name, typeof(MatchMakerAreaOfInterestLocation).Name, typeof(MatchmakerOrganizationClassification).Name, typeof(MatchmakerOrganizationTaxonomyBranch).Name, typeof(MatchmakerOrganizationTaxonomyLeaf).Name, typeof(MatchmakerOrganizationTaxonomyTrunk).Name, typeof(OrganizationBoundaryStaging).Name, typeof(OrganizationImage).Name, typeof(OrganizationMatchmakerKeyword).Name, typeof(Person).Name, typeof(PersonStewardOrganization).Name, typeof(ProjectOrganization).Name, typeof(ProjectOrganizationUpdate).Name};


        /// <summary>
        /// Delete just the entity 
        /// </summary>
        public void Delete(DatabaseEntities dbContext)
        {
            dbContext.AllOrganizations.Remove(this);
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

            foreach(var x in FundingSources.ToList())
            {
                x.DeleteFull(dbContext);
            }

            foreach(var x in MatchMakerAreaOfInterestLocations.ToList())
            {
                x.DeleteFull(dbContext);
            }

            foreach(var x in MatchmakerOrganizationClassifications.ToList())
            {
                x.DeleteFull(dbContext);
            }

            foreach(var x in MatchmakerOrganizationTaxonomyBranches.ToList())
            {
                x.DeleteFull(dbContext);
            }

            foreach(var x in MatchmakerOrganizationTaxonomyLeafs.ToList())
            {
                x.DeleteFull(dbContext);
            }

            foreach(var x in MatchmakerOrganizationTaxonomyTrunks.ToList())
            {
                x.DeleteFull(dbContext);
            }

            foreach(var x in OrganizationBoundaryStagings.ToList())
            {
                x.DeleteFull(dbContext);
            }

            foreach(var x in OrganizationImages.ToList())
            {
                x.DeleteFull(dbContext);
            }

            foreach(var x in OrganizationMatchmakerKeywords.ToList())
            {
                x.DeleteFull(dbContext);
            }

            foreach(var x in People.ToList())
            {
                x.DeleteFull(dbContext);
            }

            foreach(var x in PersonStewardOrganizations.ToList())
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
        public int OrganizationID { get; set; }
        public int TenantID { get; set; }
        public Guid? OrganizationGuid { get; set; }
        public string OrganizationName { get; set; }
        public string OrganizationShortName { get; set; }
        public int? PrimaryContactPersonID { get; set; }
        public bool IsActive { get; set; }
        public string OrganizationUrl { get; set; }
        public int? LogoFileResourceInfoID { get; set; }
        public int OrganizationTypeID { get; set; }
        public DbGeometry OrganizationBoundary { get; set; }
        public string Description { get; set; }
        [NotMapped]
        public HtmlString DescriptionHtmlString
        { 
            get { return Description == null ? null : new HtmlString(Description); }
            set { Description = value?.ToString(); }
        }
        public bool? MatchmakerOptIn { get; set; }
        public bool UseOrganizationBoundaryForMatchmaker { get; set; }
        public bool? MatchmakerCash { get; set; }
        public bool? MatchmakerInKindServices { get; set; }
        public bool? MatchmakerCommercialServices { get; set; }
        public string MatchmakerCashDescription { get; set; }
        public string MatchmakerInKindServicesDescription { get; set; }
        public string MatchmakerCommercialServicesDescription { get; set; }
        public string MatchmakerConstraints { get; set; }
        public string MatchmakerAdditionalInformation { get; set; }
        [NotMapped]
        public int PrimaryKey { get { return OrganizationID; } set { OrganizationID = value; } }

        public virtual ICollection<FundingSource> FundingSources { get; set; }
        public virtual ICollection<MatchMakerAreaOfInterestLocation> MatchMakerAreaOfInterestLocations { get; set; }
        public virtual ICollection<MatchmakerOrganizationClassification> MatchmakerOrganizationClassifications { get; set; }
        public virtual ICollection<MatchmakerOrganizationTaxonomyBranch> MatchmakerOrganizationTaxonomyBranches { get; set; }
        public virtual ICollection<MatchmakerOrganizationTaxonomyLeaf> MatchmakerOrganizationTaxonomyLeafs { get; set; }
        public virtual ICollection<MatchmakerOrganizationTaxonomyTrunk> MatchmakerOrganizationTaxonomyTrunks { get; set; }
        public virtual ICollection<OrganizationBoundaryStaging> OrganizationBoundaryStagings { get; set; }
        public virtual ICollection<OrganizationImage> OrganizationImages { get; set; }
        public virtual ICollection<OrganizationMatchmakerKeyword> OrganizationMatchmakerKeywords { get; set; }
        public virtual ICollection<Person> People { get; set; }
        public virtual ICollection<PersonStewardOrganization> PersonStewardOrganizations { get; set; }
        public virtual ICollection<ProjectOrganization> ProjectOrganizations { get; set; }
        public virtual ICollection<ProjectOrganizationUpdate> ProjectOrganizationUpdates { get; set; }
        public Tenant Tenant { get { return Tenant.AllLookupDictionary[TenantID]; } }
        public virtual Person PrimaryContactPerson { get; set; }
        public virtual FileResourceInfo LogoFileResourceInfo { get; set; }
        public virtual OrganizationType OrganizationType { get; set; }

        public static class FieldLengths
        {
            public const int OrganizationName = 200;
            public const int OrganizationShortName = 50;
            public const int OrganizationUrl = 200;
            public const int MatchmakerCashDescription = 300;
            public const int MatchmakerInKindServicesDescription = 300;
            public const int MatchmakerCommercialServicesDescription = 300;
            public const int MatchmakerConstraints = 300;
            public const int MatchmakerAdditionalInformation = 300;
        }
    }
}