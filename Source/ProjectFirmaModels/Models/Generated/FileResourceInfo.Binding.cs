//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[FileResourceInfo]
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
    // Table [dbo].[FileResourceInfo] is multi-tenant, so is attributed as IHaveATenantID
    [Table("[dbo].[FileResourceInfo]")]
    public partial class FileResourceInfo : IHavePrimaryKey, IHaveATenantID
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected FileResourceInfo()
        {
            this.ClassificationsWhereYouAreTheKeyImageFileResourceInfo = new HashSet<Classification>();
            this.CustomPageImages = new HashSet<CustomPageImage>();
            this.DocumentLibraryDocuments = new HashSet<DocumentLibraryDocument>();
            this.FieldDefinitionDataImages = new HashSet<FieldDefinitionDataImage>();
            this.FileResourceDatas = new HashSet<FileResourceData>();
            this.FirmaHomePageImages = new HashSet<FirmaHomePageImage>();
            this.FirmaPageImages = new HashSet<FirmaPageImage>();
            this.GeospatialAreaImages = new HashSet<GeospatialAreaImage>();
            this.OrganizationsWhereYouAreTheLogoFileResourceInfo = new HashSet<Organization>();
            this.OrganizationImages = new HashSet<OrganizationImage>();
            this.PerformanceMeasureImages = new HashSet<PerformanceMeasureImage>();
            this.ProjectAttachmentsWhereYouAreTheAttachment = new HashSet<ProjectAttachment>();
            this.ProjectAttachmentUpdatesWhereYouAreTheAttachment = new HashSet<ProjectAttachmentUpdate>();
            this.ProjectImages = new HashSet<ProjectImage>();
            this.ProjectImageUpdates = new HashSet<ProjectImageUpdate>();
            this.ReportTemplates = new HashSet<ReportTemplate>();
            this.TenantAttributesWhereYouAreTheTenantBannerLogoFileResourceInfo = new HashSet<TenantAttribute>();
            this.TenantAttributesWhereYouAreTheTenantFactSheetLogoFileResourceInfo = new HashSet<TenantAttribute>();
            this.TenantAttributesWhereYouAreTheTenantSquareLogoFileResourceInfo = new HashSet<TenantAttribute>();
            this.TenantAttributesWhereYouAreTheTenantStyleSheetFileResourceInfo = new HashSet<TenantAttribute>();
        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public FileResourceInfo(int fileResourceInfoID, int fileResourceMimeTypeID, string originalBaseFilename, string originalFileExtension, Guid fileResourceGUID, int createPersonID, DateTime createDate) : this()
        {
            this.FileResourceInfoID = fileResourceInfoID;
            this.FileResourceMimeTypeID = fileResourceMimeTypeID;
            this.OriginalBaseFilename = originalBaseFilename;
            this.OriginalFileExtension = originalFileExtension;
            this.FileResourceGUID = fileResourceGUID;
            this.CreatePersonID = createPersonID;
            this.CreateDate = createDate;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields in preparation for insert into database
        /// </summary>
        public FileResourceInfo(int fileResourceMimeTypeID, string originalBaseFilename, string originalFileExtension, Guid fileResourceGUID, int createPersonID, DateTime createDate) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.FileResourceInfoID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            
            this.FileResourceMimeTypeID = fileResourceMimeTypeID;
            this.OriginalBaseFilename = originalBaseFilename;
            this.OriginalFileExtension = originalFileExtension;
            this.FileResourceGUID = fileResourceGUID;
            this.CreatePersonID = createPersonID;
            this.CreateDate = createDate;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields, using objects whenever possible
        /// </summary>
        public FileResourceInfo(FileResourceMimeType fileResourceMimeType, string originalBaseFilename, string originalFileExtension, Guid fileResourceGUID, Person createPerson, DateTime createDate) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.FileResourceInfoID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            this.FileResourceMimeTypeID = fileResourceMimeType.FileResourceMimeTypeID;
            this.OriginalBaseFilename = originalBaseFilename;
            this.OriginalFileExtension = originalFileExtension;
            this.FileResourceGUID = fileResourceGUID;
            this.CreatePersonID = createPerson.PersonID;
            this.CreatePerson = createPerson;
            createPerson.FileResourceInfosWhereYouAreTheCreatePerson.Add(this);
            this.CreateDate = createDate;
        }

        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static FileResourceInfo CreateNewBlank(FileResourceMimeType fileResourceMimeType, Person createPerson)
        {
            return new FileResourceInfo(fileResourceMimeType, default(string), default(string), default(Guid), createPerson, default(DateTime));
        }

        /// <summary>
        /// Does this object have any dependent objects? (If it does have dependent objects, these would need to be deleted before this object could be deleted.)
        /// </summary>
        /// <returns></returns>
        public bool HasDependentObjects()
        {
            return ClassificationsWhereYouAreTheKeyImageFileResourceInfo.Any() || CustomPageImages.Any() || DocumentLibraryDocuments.Any() || FieldDefinitionDataImages.Any() || FileResourceDatas.Any() || FirmaHomePageImages.Any() || FirmaPageImages.Any() || GeospatialAreaImages.Any() || OrganizationsWhereYouAreTheLogoFileResourceInfo.Any() || OrganizationImages.Any() || PerformanceMeasureImages.Any() || ProjectAttachmentsWhereYouAreTheAttachment.Any() || ProjectAttachmentUpdatesWhereYouAreTheAttachment.Any() || ProjectImages.Any() || ProjectImageUpdates.Any() || ReportTemplates.Any() || TenantAttributesWhereYouAreTheTenantBannerLogoFileResourceInfo.Any() || TenantAttributesWhereYouAreTheTenantFactSheetLogoFileResourceInfo.Any() || TenantAttributesWhereYouAreTheTenantSquareLogoFileResourceInfo.Any() || TenantAttributesWhereYouAreTheTenantStyleSheetFileResourceInfo.Any();
        }

        /// <summary>
        /// Active Dependent type names of this object
        /// </summary>
        public List<string> DependentObjectNames() 
        {
            var dependentObjects = new List<string>();
            
            if(ClassificationsWhereYouAreTheKeyImageFileResourceInfo.Any())
            {
                dependentObjects.Add(typeof(Classification).Name);
            }

            if(CustomPageImages.Any())
            {
                dependentObjects.Add(typeof(CustomPageImage).Name);
            }

            if(DocumentLibraryDocuments.Any())
            {
                dependentObjects.Add(typeof(DocumentLibraryDocument).Name);
            }

            if(FieldDefinitionDataImages.Any())
            {
                dependentObjects.Add(typeof(FieldDefinitionDataImage).Name);
            }

            if(FileResourceDatas.Any())
            {
                dependentObjects.Add(typeof(FileResourceData).Name);
            }

            if(FirmaHomePageImages.Any())
            {
                dependentObjects.Add(typeof(FirmaHomePageImage).Name);
            }

            if(FirmaPageImages.Any())
            {
                dependentObjects.Add(typeof(FirmaPageImage).Name);
            }

            if(GeospatialAreaImages.Any())
            {
                dependentObjects.Add(typeof(GeospatialAreaImage).Name);
            }

            if(OrganizationsWhereYouAreTheLogoFileResourceInfo.Any())
            {
                dependentObjects.Add(typeof(Organization).Name);
            }

            if(OrganizationImages.Any())
            {
                dependentObjects.Add(typeof(OrganizationImage).Name);
            }

            if(PerformanceMeasureImages.Any())
            {
                dependentObjects.Add(typeof(PerformanceMeasureImage).Name);
            }

            if(ProjectAttachmentsWhereYouAreTheAttachment.Any())
            {
                dependentObjects.Add(typeof(ProjectAttachment).Name);
            }

            if(ProjectAttachmentUpdatesWhereYouAreTheAttachment.Any())
            {
                dependentObjects.Add(typeof(ProjectAttachmentUpdate).Name);
            }

            if(ProjectImages.Any())
            {
                dependentObjects.Add(typeof(ProjectImage).Name);
            }

            if(ProjectImageUpdates.Any())
            {
                dependentObjects.Add(typeof(ProjectImageUpdate).Name);
            }

            if(ReportTemplates.Any())
            {
                dependentObjects.Add(typeof(ReportTemplate).Name);
            }

            if(TenantAttributesWhereYouAreTheTenantBannerLogoFileResourceInfo.Any())
            {
                dependentObjects.Add(typeof(TenantAttribute).Name);
            }

            if(TenantAttributesWhereYouAreTheTenantFactSheetLogoFileResourceInfo.Any())
            {
                dependentObjects.Add(typeof(TenantAttribute).Name);
            }

            if(TenantAttributesWhereYouAreTheTenantSquareLogoFileResourceInfo.Any())
            {
                dependentObjects.Add(typeof(TenantAttribute).Name);
            }

            if(TenantAttributesWhereYouAreTheTenantStyleSheetFileResourceInfo.Any())
            {
                dependentObjects.Add(typeof(TenantAttribute).Name);
            }
            return dependentObjects.Distinct().ToList();
        }

        /// <summary>
        /// Dependent type names of this entity
        /// </summary>
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(FileResourceInfo).Name, typeof(Classification).Name, typeof(CustomPageImage).Name, typeof(DocumentLibraryDocument).Name, typeof(FieldDefinitionDataImage).Name, typeof(FileResourceData).Name, typeof(FirmaHomePageImage).Name, typeof(FirmaPageImage).Name, typeof(GeospatialAreaImage).Name, typeof(Organization).Name, typeof(OrganizationImage).Name, typeof(PerformanceMeasureImage).Name, typeof(ProjectAttachment).Name, typeof(ProjectAttachmentUpdate).Name, typeof(ProjectImage).Name, typeof(ProjectImageUpdate).Name, typeof(ReportTemplate).Name, typeof(TenantAttribute).Name};


        /// <summary>
        /// Delete just the entity 
        /// </summary>
        public void Delete(DatabaseEntities dbContext)
        {
            dbContext.AllFileResourceInfos.Remove(this);
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

            foreach(var x in ClassificationsWhereYouAreTheKeyImageFileResourceInfo.ToList())
            {
                x.DeleteFull(dbContext);
            }

            foreach(var x in CustomPageImages.ToList())
            {
                x.DeleteFull(dbContext);
            }

            foreach(var x in DocumentLibraryDocuments.ToList())
            {
                x.DeleteFull(dbContext);
            }

            foreach(var x in FieldDefinitionDataImages.ToList())
            {
                x.DeleteFull(dbContext);
            }

            foreach(var x in FileResourceDatas.ToList())
            {
                x.DeleteFull(dbContext);
            }

            foreach(var x in FirmaHomePageImages.ToList())
            {
                x.DeleteFull(dbContext);
            }

            foreach(var x in FirmaPageImages.ToList())
            {
                x.DeleteFull(dbContext);
            }

            foreach(var x in GeospatialAreaImages.ToList())
            {
                x.DeleteFull(dbContext);
            }

            foreach(var x in OrganizationsWhereYouAreTheLogoFileResourceInfo.ToList())
            {
                x.DeleteFull(dbContext);
            }

            foreach(var x in OrganizationImages.ToList())
            {
                x.DeleteFull(dbContext);
            }

            foreach(var x in PerformanceMeasureImages.ToList())
            {
                x.DeleteFull(dbContext);
            }

            foreach(var x in ProjectAttachmentsWhereYouAreTheAttachment.ToList())
            {
                x.DeleteFull(dbContext);
            }

            foreach(var x in ProjectAttachmentUpdatesWhereYouAreTheAttachment.ToList())
            {
                x.DeleteFull(dbContext);
            }

            foreach(var x in ProjectImages.ToList())
            {
                x.DeleteFull(dbContext);
            }

            foreach(var x in ProjectImageUpdates.ToList())
            {
                x.DeleteFull(dbContext);
            }

            foreach(var x in ReportTemplates.ToList())
            {
                x.DeleteFull(dbContext);
            }

            foreach(var x in TenantAttributesWhereYouAreTheTenantBannerLogoFileResourceInfo.ToList())
            {
                x.DeleteFull(dbContext);
            }

            foreach(var x in TenantAttributesWhereYouAreTheTenantFactSheetLogoFileResourceInfo.ToList())
            {
                x.DeleteFull(dbContext);
            }

            foreach(var x in TenantAttributesWhereYouAreTheTenantSquareLogoFileResourceInfo.ToList())
            {
                x.DeleteFull(dbContext);
            }

            foreach(var x in TenantAttributesWhereYouAreTheTenantStyleSheetFileResourceInfo.ToList())
            {
                x.DeleteFull(dbContext);
            }
        }

        [Key]
        public int FileResourceInfoID { get; set; }
        public int TenantID { get; set; }
        public int FileResourceMimeTypeID { get; set; }
        public string OriginalBaseFilename { get; set; }
        public string OriginalFileExtension { get; set; }
        public Guid FileResourceGUID { get; set; }
        public int CreatePersonID { get; set; }
        public DateTime CreateDate { get; set; }
        [NotMapped]
        public int PrimaryKey { get { return FileResourceInfoID; } set { FileResourceInfoID = value; } }

        public virtual ICollection<Classification> ClassificationsWhereYouAreTheKeyImageFileResourceInfo { get; set; }
        public virtual ICollection<CustomPageImage> CustomPageImages { get; set; }
        public virtual ICollection<DocumentLibraryDocument> DocumentLibraryDocuments { get; set; }
        public virtual ICollection<FieldDefinitionDataImage> FieldDefinitionDataImages { get; set; }
        public virtual ICollection<FileResourceData> FileResourceDatas { get; set; }
        public virtual ICollection<FirmaHomePageImage> FirmaHomePageImages { get; set; }
        public virtual ICollection<FirmaPageImage> FirmaPageImages { get; set; }
        public virtual ICollection<GeospatialAreaImage> GeospatialAreaImages { get; set; }
        public virtual ICollection<Organization> OrganizationsWhereYouAreTheLogoFileResourceInfo { get; set; }
        public virtual ICollection<OrganizationImage> OrganizationImages { get; set; }
        public virtual ICollection<PerformanceMeasureImage> PerformanceMeasureImages { get; set; }
        public virtual ICollection<ProjectAttachment> ProjectAttachmentsWhereYouAreTheAttachment { get; set; }
        public virtual ICollection<ProjectAttachmentUpdate> ProjectAttachmentUpdatesWhereYouAreTheAttachment { get; set; }
        public virtual ICollection<ProjectImage> ProjectImages { get; set; }
        public virtual ICollection<ProjectImageUpdate> ProjectImageUpdates { get; set; }
        public virtual ICollection<ReportTemplate> ReportTemplates { get; set; }
        public virtual ICollection<TenantAttribute> TenantAttributesWhereYouAreTheTenantBannerLogoFileResourceInfo { get; set; }
        public virtual ICollection<TenantAttribute> TenantAttributesWhereYouAreTheTenantFactSheetLogoFileResourceInfo { get; set; }
        public virtual ICollection<TenantAttribute> TenantAttributesWhereYouAreTheTenantSquareLogoFileResourceInfo { get; set; }
        public virtual ICollection<TenantAttribute> TenantAttributesWhereYouAreTheTenantStyleSheetFileResourceInfo { get; set; }
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