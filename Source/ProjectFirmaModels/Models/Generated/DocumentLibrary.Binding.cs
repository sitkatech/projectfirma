//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[DocumentLibrary]
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
    // Table [dbo].[DocumentLibrary] is multi-tenant, so is attributed as IHaveATenantID
    [Table("[dbo].[DocumentLibrary]")]
    public partial class DocumentLibrary : IHavePrimaryKey, IHaveATenantID
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected DocumentLibrary()
        {
            this.CustomPages = new HashSet<CustomPage>();
            this.DocumentLibraryDocuments = new HashSet<DocumentLibraryDocument>();
            this.DocumentLibraryDocumentCategories = new HashSet<DocumentLibraryDocumentCategory>();
        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public DocumentLibrary(int documentLibraryID, string documentLibraryName, string documentLibraryDescription) : this()
        {
            this.DocumentLibraryID = documentLibraryID;
            this.DocumentLibraryName = documentLibraryName;
            this.DocumentLibraryDescription = documentLibraryDescription;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields in preparation for insert into database
        /// </summary>
        public DocumentLibrary(string documentLibraryName) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.DocumentLibraryID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            
            this.DocumentLibraryName = documentLibraryName;
        }


        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static DocumentLibrary CreateNewBlank()
        {
            return new DocumentLibrary(default(string));
        }

        /// <summary>
        /// Does this object have any dependent objects? (If it does have dependent objects, these would need to be deleted before this object could be deleted.)
        /// </summary>
        /// <returns></returns>
        public bool HasDependentObjects()
        {
            return CustomPages.Any() || DocumentLibraryDocuments.Any() || DocumentLibraryDocumentCategories.Any();
        }

        /// <summary>
        /// Active Dependent type names of this object
        /// </summary>
        public List<string> DependentObjectNames() 
        {
            var dependentObjects = new List<string>();
            
            if(CustomPages.Any())
            {
                dependentObjects.Add(typeof(CustomPage).Name);
            }

            if(DocumentLibraryDocuments.Any())
            {
                dependentObjects.Add(typeof(DocumentLibraryDocument).Name);
            }

            if(DocumentLibraryDocumentCategories.Any())
            {
                dependentObjects.Add(typeof(DocumentLibraryDocumentCategory).Name);
            }
            return dependentObjects.Distinct().ToList();
        }

        /// <summary>
        /// Dependent type names of this entity
        /// </summary>
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(DocumentLibrary).Name, typeof(CustomPage).Name, typeof(DocumentLibraryDocument).Name, typeof(DocumentLibraryDocumentCategory).Name};


        /// <summary>
        /// Delete just the entity 
        /// </summary>
        public void Delete(DatabaseEntities dbContext)
        {
            dbContext.AllDocumentLibraries.Remove(this);
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

            foreach(var x in CustomPages.ToList())
            {
                x.DeleteFull(dbContext);
            }

            foreach(var x in DocumentLibraryDocuments.ToList())
            {
                x.DeleteFull(dbContext);
            }

            foreach(var x in DocumentLibraryDocumentCategories.ToList())
            {
                x.DeleteFull(dbContext);
            }
        }

        [Key]
        public int DocumentLibraryID { get; set; }
        public int TenantID { get; set; }
        public string DocumentLibraryName { get; set; }
        public string DocumentLibraryDescription { get; set; }
        [NotMapped]
        public int PrimaryKey { get { return DocumentLibraryID; } set { DocumentLibraryID = value; } }

        public virtual ICollection<CustomPage> CustomPages { get; set; }
        public virtual ICollection<DocumentLibraryDocument> DocumentLibraryDocuments { get; set; }
        public virtual ICollection<DocumentLibraryDocumentCategory> DocumentLibraryDocumentCategories { get; set; }
        public Tenant Tenant { get { return Tenant.AllLookupDictionary[TenantID]; } }

        public static class FieldLengths
        {
            public const int DocumentLibraryName = 200;
            public const int DocumentLibraryDescription = 500;
        }
    }
}