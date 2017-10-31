//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[FileResource]
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
    [Table("[dbo].[FileResource]")]
    public partial class FileResource : IHavePrimaryKey, IHaveATenantID
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected FileResource()
        {
            this.ClassificationsWhereYouAreTheKeyImageFileResource = new HashSet<Classification>();
            this.FieldDefinitionDataImages = new HashSet<FieldDefinitionDataImage>();
            this.FirmaHomePageImages = new HashSet<FirmaHomePageImage>();
            this.FirmaPageImages = new HashSet<FirmaPageImage>();
            this.MonitoringProgramDocuments = new HashSet<MonitoringProgramDocument>();
            this.OrganizationsWhereYouAreTheLogoFileResource = new HashSet<Organization>();
            this.ProjectImages = new HashSet<ProjectImage>();
            this.ProjectImageUpdates = new HashSet<ProjectImageUpdate>();
            this.TenantAttributesWhereYouAreTheTenantBannerLogoFileResource = new HashSet<TenantAttribute>();
            this.TenantAttributesWhereYouAreTheTenantSquareLogoFileResource = new HashSet<TenantAttribute>();
            this.TenantAttributesWhereYouAreTheTenantStyleSheetFileResource = new HashSet<TenantAttribute>();
            this.TenantID = HttpRequestStorage.Tenant.TenantID;
        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public FileResource(int fileResourceID, int fileResourceMimeTypeID, string originalBaseFilename, string originalFileExtension, Guid fileResourceGUID, byte[] fileResourceData, int createPersonID, DateTime createDate) : this()
        {
            this.FileResourceID = fileResourceID;
            this.FileResourceMimeTypeID = fileResourceMimeTypeID;
            this.OriginalBaseFilename = originalBaseFilename;
            this.OriginalFileExtension = originalFileExtension;
            this.FileResourceGUID = fileResourceGUID;
            this.FileResourceData = fileResourceData;
            this.CreatePersonID = createPersonID;
            this.CreateDate = createDate;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields in preparation for insert into database
        /// </summary>
        public FileResource(int fileResourceMimeTypeID, string originalBaseFilename, string originalFileExtension, Guid fileResourceGUID, byte[] fileResourceData, int createPersonID, DateTime createDate) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.FileResourceID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            
            this.FileResourceMimeTypeID = fileResourceMimeTypeID;
            this.OriginalBaseFilename = originalBaseFilename;
            this.OriginalFileExtension = originalFileExtension;
            this.FileResourceGUID = fileResourceGUID;
            this.FileResourceData = fileResourceData;
            this.CreatePersonID = createPersonID;
            this.CreateDate = createDate;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields, using objects whenever possible
        /// </summary>
        public FileResource(FileResourceMimeType fileResourceMimeType, string originalBaseFilename, string originalFileExtension, Guid fileResourceGUID, byte[] fileResourceData, Person createPerson, DateTime createDate) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.FileResourceID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            this.FileResourceMimeTypeID = fileResourceMimeType.FileResourceMimeTypeID;
            this.OriginalBaseFilename = originalBaseFilename;
            this.OriginalFileExtension = originalFileExtension;
            this.FileResourceGUID = fileResourceGUID;
            this.FileResourceData = fileResourceData;
            this.CreatePersonID = createPerson.PersonID;
            this.CreatePerson = createPerson;
            createPerson.FileResourcesWhereYouAreTheCreatePerson.Add(this);
            this.CreateDate = createDate;
        }

        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static FileResource CreateNewBlank(FileResourceMimeType fileResourceMimeType, Person createPerson)
        {
            return new FileResource(fileResourceMimeType, default(string), default(string), default(Guid), default(byte[]), createPerson, default(DateTime));
        }

        /// <summary>
        /// Does this object have any dependent objects? (If it does have dependent objects, these would need to be deleted before this object could be deleted.)
        /// </summary>
        /// <returns></returns>
        public bool HasDependentObjects()
        {
            return ClassificationsWhereYouAreTheKeyImageFileResource.Any() || FieldDefinitionDataImages.Any() || FirmaHomePageImages.Any() || FirmaPageImages.Any() || MonitoringProgramDocuments.Any() || OrganizationsWhereYouAreTheLogoFileResource.Any() || ProjectImages.Any() || ProjectImageUpdates.Any() || TenantAttributesWhereYouAreTheTenantBannerLogoFileResource.Any() || TenantAttributesWhereYouAreTheTenantSquareLogoFileResource.Any() || TenantAttributesWhereYouAreTheTenantStyleSheetFileResource.Any();
        }

        /// <summary>
        /// Dependent type names of this entity
        /// </summary>
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(FileResource).Name, typeof(Classification).Name, typeof(FieldDefinitionDataImage).Name, typeof(FirmaHomePageImage).Name, typeof(FirmaPageImage).Name, typeof(MonitoringProgramDocument).Name, typeof(Organization).Name, typeof(ProjectImage).Name, typeof(ProjectImageUpdate).Name, typeof(TenantAttribute).Name};

        [Key]
        public int FileResourceID { get; set; }
        public int TenantID { get; private set; }
        public int FileResourceMimeTypeID { get; set; }
        public string OriginalBaseFilename { get; set; }
        public string OriginalFileExtension { get; set; }
        public Guid FileResourceGUID { get; set; }
        public byte[] FileResourceData { get; set; }
        public int CreatePersonID { get; set; }
        public DateTime CreateDate { get; set; }
        public int PrimaryKey { get { return FileResourceID; } set { FileResourceID = value; } }

        public virtual ICollection<Classification> ClassificationsWhereYouAreTheKeyImageFileResource { get; set; }
        public virtual ICollection<FieldDefinitionDataImage> FieldDefinitionDataImages { get; set; }
        public virtual ICollection<FirmaHomePageImage> FirmaHomePageImages { get; set; }
        public virtual ICollection<FirmaPageImage> FirmaPageImages { get; set; }
        public virtual ICollection<MonitoringProgramDocument> MonitoringProgramDocuments { get; set; }
        public virtual ICollection<Organization> OrganizationsWhereYouAreTheLogoFileResource { get; set; }
        public virtual ICollection<ProjectImage> ProjectImages { get; set; }
        public virtual ICollection<ProjectImageUpdate> ProjectImageUpdates { get; set; }
        public virtual ICollection<TenantAttribute> TenantAttributesWhereYouAreTheTenantBannerLogoFileResource { get; set; }
        public virtual ICollection<TenantAttribute> TenantAttributesWhereYouAreTheTenantSquareLogoFileResource { get; set; }
        public virtual ICollection<TenantAttribute> TenantAttributesWhereYouAreTheTenantStyleSheetFileResource { get; set; }
        public Tenant Tenant { get { return Tenant.AllLookupDictionary[TenantID]; } }
        public FileResourceMimeType FileResourceMimeType { get { return FileResourceMimeType.AllLookupDictionary[FileResourceMimeTypeID]; } }
        public virtual Person CreatePerson { get; set; }

        public static class FieldLengths
        {
            public const int OriginalBaseFilename = 255;
            public const int OriginalFileExtension = 255;
        }
    }
}