//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[DocumentLibraryDocumentRole]
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
    // Table [dbo].[DocumentLibraryDocumentRole] is multi-tenant, so is attributed as IHaveATenantID
    [Table("[dbo].[DocumentLibraryDocumentRole]")]
    public partial class DocumentLibraryDocumentRole : IHavePrimaryKey, IHaveATenantID
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected DocumentLibraryDocumentRole()
        {

        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public DocumentLibraryDocumentRole(int documentLibraryDocumentRoleID, int documentLibraryDocumentID, int? roleID) : this()
        {
            this.DocumentLibraryDocumentRoleID = documentLibraryDocumentRoleID;
            this.DocumentLibraryDocumentID = documentLibraryDocumentID;
            this.RoleID = roleID;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields in preparation for insert into database
        /// </summary>
        public DocumentLibraryDocumentRole(int documentLibraryDocumentID) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.DocumentLibraryDocumentRoleID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            
            this.DocumentLibraryDocumentID = documentLibraryDocumentID;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields, using objects whenever possible
        /// </summary>
        public DocumentLibraryDocumentRole(DocumentLibraryDocument documentLibraryDocument) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.DocumentLibraryDocumentRoleID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            this.DocumentLibraryDocumentID = documentLibraryDocument.DocumentLibraryDocumentID;
            this.DocumentLibraryDocument = documentLibraryDocument;
            documentLibraryDocument.DocumentLibraryDocumentRoles.Add(this);
        }

        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static DocumentLibraryDocumentRole CreateNewBlank(DocumentLibraryDocument documentLibraryDocument)
        {
            return new DocumentLibraryDocumentRole(documentLibraryDocument);
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
            
            return dependentObjects.Distinct().ToList();
        }

        /// <summary>
        /// Dependent type names of this entity
        /// </summary>
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(DocumentLibraryDocumentRole).Name};


        /// <summary>
        /// Delete just the entity 
        /// </summary>
        public void Delete(DatabaseEntities dbContext)
        {
            dbContext.AllDocumentLibraryDocumentRoles.Remove(this);
        }
        
        /// <summary>
        /// Delete entity plus all children
        /// </summary>
        public void DeleteFull(DatabaseEntities dbContext)
        {
            
            Delete(dbContext);
        }

        [Key]
        public int DocumentLibraryDocumentRoleID { get; set; }
        public int TenantID { get; set; }
        public int DocumentLibraryDocumentID { get; set; }
        public int? RoleID { get; set; }
        [NotMapped]
        public int PrimaryKey { get { return DocumentLibraryDocumentRoleID; } set { DocumentLibraryDocumentRoleID = value; } }

        public Tenant Tenant { get { return Tenant.AllLookupDictionary[TenantID]; } }
        public virtual DocumentLibraryDocument DocumentLibraryDocument { get; set; }
        public Role Role { get { return RoleID.HasValue ? Role.AllLookupDictionary[RoleID.Value] : null; } }

        public static class FieldLengths
        {

        }
    }
}