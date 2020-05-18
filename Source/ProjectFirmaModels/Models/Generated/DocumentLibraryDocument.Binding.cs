//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[DocumentLibraryDocument]
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
    // Table [dbo].[DocumentLibraryDocument] is multi-tenant, so is attributed as IHaveATenantID
    [Table("[dbo].[DocumentLibraryDocument]")]
    public partial class DocumentLibraryDocument : IHavePrimaryKey, IHaveATenantID
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected DocumentLibraryDocument()
        {
            this.DocumentLibraryDocumentRoles = new HashSet<DocumentLibraryDocumentRole>();
        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public DocumentLibraryDocument(int documentLibraryDocumentID, int documentLibraryID, int documentCategoryID, string documentTitle, string documentDescription, int fileResourceID, int? sortOrder, DateTime lastUpdateDate, int lastUpdatePersonID) : this()
        {
            this.DocumentLibraryDocumentID = documentLibraryDocumentID;
            this.DocumentLibraryID = documentLibraryID;
            this.DocumentCategoryID = documentCategoryID;
            this.DocumentTitle = documentTitle;
            this.DocumentDescription = documentDescription;
            this.FileResourceID = fileResourceID;
            this.SortOrder = sortOrder;
            this.LastUpdateDate = lastUpdateDate;
            this.LastUpdatePersonID = lastUpdatePersonID;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields in preparation for insert into database
        /// </summary>
        public DocumentLibraryDocument(int documentLibraryID, int documentCategoryID, string documentTitle, int fileResourceID, DateTime lastUpdateDate, int lastUpdatePersonID) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.DocumentLibraryDocumentID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            
            this.DocumentLibraryID = documentLibraryID;
            this.DocumentCategoryID = documentCategoryID;
            this.DocumentTitle = documentTitle;
            this.FileResourceID = fileResourceID;
            this.LastUpdateDate = lastUpdateDate;
            this.LastUpdatePersonID = lastUpdatePersonID;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields, using objects whenever possible
        /// </summary>
        public DocumentLibraryDocument(DocumentLibrary documentLibrary, DocumentCategory documentCategory, string documentTitle, FileResource fileResource, DateTime lastUpdateDate, Person lastUpdatePerson) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.DocumentLibraryDocumentID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            this.DocumentLibraryID = documentLibrary.DocumentLibraryID;
            this.DocumentLibrary = documentLibrary;
            documentLibrary.DocumentLibraryDocuments.Add(this);
            this.DocumentCategoryID = documentCategory.DocumentCategoryID;
            this.DocumentTitle = documentTitle;
            this.FileResourceID = fileResource.FileResourceID;
            this.FileResource = fileResource;
            fileResource.DocumentLibraryDocuments.Add(this);
            this.LastUpdateDate = lastUpdateDate;
            this.LastUpdatePersonID = lastUpdatePerson.PersonID;
            this.LastUpdatePerson = lastUpdatePerson;
            lastUpdatePerson.DocumentLibraryDocumentsWhereYouAreTheLastUpdatePerson.Add(this);
        }

        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static DocumentLibraryDocument CreateNewBlank(DocumentLibrary documentLibrary, DocumentCategory documentCategory, FileResource fileResource, Person lastUpdatePerson)
        {
            return new DocumentLibraryDocument(documentLibrary, documentCategory, default(string), fileResource, default(DateTime), lastUpdatePerson);
        }

        /// <summary>
        /// Does this object have any dependent objects? (If it does have dependent objects, these would need to be deleted before this object could be deleted.)
        /// </summary>
        /// <returns></returns>
        public bool HasDependentObjects()
        {
            return DocumentLibraryDocumentRoles.Any();
        }

        /// <summary>
        /// Active Dependent type names of this object
        /// </summary>
        public List<string> DependentObjectNames() 
        {
            var dependentObjects = new List<string>();
            
            if(DocumentLibraryDocumentRoles.Any())
            {
                dependentObjects.Add(typeof(DocumentLibraryDocumentRole).Name);
            }
            return dependentObjects.Distinct().ToList();
        }

        /// <summary>
        /// Dependent type names of this entity
        /// </summary>
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(DocumentLibraryDocument).Name, typeof(DocumentLibraryDocumentRole).Name};


        /// <summary>
        /// Delete just the entity 
        /// </summary>
        public void Delete(DatabaseEntities dbContext)
        {
            dbContext.AllDocumentLibraryDocuments.Remove(this);
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

            foreach(var x in DocumentLibraryDocumentRoles.ToList())
            {
                x.DeleteFull(dbContext);
            }
        }

        [Key]
        public int DocumentLibraryDocumentID { get; set; }
        public int TenantID { get; set; }
        public int DocumentLibraryID { get; set; }
        public int DocumentCategoryID { get; set; }
        public string DocumentTitle { get; set; }
        public string DocumentDescription { get; set; }
        public int FileResourceID { get; set; }
        public int? SortOrder { get; set; }
        public DateTime LastUpdateDate { get; set; }
        public int LastUpdatePersonID { get; set; }
        [NotMapped]
        public int PrimaryKey { get { return DocumentLibraryDocumentID; } set { DocumentLibraryDocumentID = value; } }

        public virtual ICollection<DocumentLibraryDocumentRole> DocumentLibraryDocumentRoles { get; set; }
        public Tenant Tenant { get { return Tenant.AllLookupDictionary[TenantID]; } }
        public virtual DocumentLibrary DocumentLibrary { get; set; }
        public DocumentCategory DocumentCategory { get { return DocumentCategory.AllLookupDictionary[DocumentCategoryID]; } }
        public virtual FileResource FileResource { get; set; }
        public virtual Person LastUpdatePerson { get; set; }

        public static class FieldLengths
        {
            public const int DocumentTitle = 200;
            public const int DocumentDescription = 1000;
        }
    }
}