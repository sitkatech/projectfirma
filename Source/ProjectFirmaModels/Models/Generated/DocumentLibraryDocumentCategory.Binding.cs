//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[DocumentLibraryDocumentCategory]
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
    // Table [dbo].[DocumentLibraryDocumentCategory] is multi-tenant, so is attributed as IHaveATenantID
    [Table("[dbo].[DocumentLibraryDocumentCategory]")]
    public partial class DocumentLibraryDocumentCategory : IHavePrimaryKey, IHaveATenantID
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected DocumentLibraryDocumentCategory()
        {

        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public DocumentLibraryDocumentCategory(int documentLibraryDocumentCategoryID, int documentLibraryID, int documentCategoryID) : this()
        {
            this.DocumentLibraryDocumentCategoryID = documentLibraryDocumentCategoryID;
            this.DocumentLibraryID = documentLibraryID;
            this.DocumentCategoryID = documentCategoryID;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields in preparation for insert into database
        /// </summary>
        public DocumentLibraryDocumentCategory(int documentLibraryID, int documentCategoryID) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.DocumentLibraryDocumentCategoryID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            
            this.DocumentLibraryID = documentLibraryID;
            this.DocumentCategoryID = documentCategoryID;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields, using objects whenever possible
        /// </summary>
        public DocumentLibraryDocumentCategory(DocumentLibrary documentLibrary, DocumentCategory documentCategory) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.DocumentLibraryDocumentCategoryID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            this.DocumentLibraryID = documentLibrary.DocumentLibraryID;
            this.DocumentLibrary = documentLibrary;
            documentLibrary.DocumentLibraryDocumentCategories.Add(this);
            this.DocumentCategoryID = documentCategory.DocumentCategoryID;
        }

        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static DocumentLibraryDocumentCategory CreateNewBlank(DocumentLibrary documentLibrary, DocumentCategory documentCategory)
        {
            return new DocumentLibraryDocumentCategory(documentLibrary, documentCategory);
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
        /// Active Dependent type names of this object
        /// </summary>
        public List<string> DependentObjectNames() 
        {
            var dependentObjects = new List<string>();
            
            return dependentObjects;
        }

        /// <summary>
        /// Dependent type names of this entity
        /// </summary>
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(DocumentLibraryDocumentCategory).Name};


        /// <summary>
        /// Delete just the entity 
        /// </summary>
        public void Delete(DatabaseEntities dbContext)
        {
            dbContext.AllDocumentLibraryDocumentCategories.Remove(this);
        }
        
        /// <summary>
        /// Delete entity plus all children
        /// </summary>
        public void DeleteFull(DatabaseEntities dbContext)
        {
            
            Delete(dbContext);
        }

        [Key]
        public int DocumentLibraryDocumentCategoryID { get; set; }
        public int TenantID { get; set; }
        public int DocumentLibraryID { get; set; }
        public int DocumentCategoryID { get; set; }
        [NotMapped]
        public int PrimaryKey { get { return DocumentLibraryDocumentCategoryID; } set { DocumentLibraryDocumentCategoryID = value; } }

        public Tenant Tenant { get { return Tenant.AllLookupDictionary[TenantID]; } }
        public virtual DocumentLibrary DocumentLibrary { get; set; }
        public DocumentCategory DocumentCategory { get { return DocumentCategory.AllLookupDictionary[DocumentCategoryID]; } }

        public static class FieldLengths
        {

        }
    }
}