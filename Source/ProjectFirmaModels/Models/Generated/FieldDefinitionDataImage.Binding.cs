//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[FieldDefinitionDataImage]
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
    // Table [dbo].[FieldDefinitionDataImage] is multi-tenant, so is attributed as IHaveATenantID
    [Table("[dbo].[FieldDefinitionDataImage]")]
    public partial class FieldDefinitionDataImage : IHavePrimaryKey, IHaveATenantID
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected FieldDefinitionDataImage()
        {

        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public FieldDefinitionDataImage(int fieldDefinitionDataImageID, int fieldDefinitionDataID, int fileResourceInfoID) : this()
        {
            this.FieldDefinitionDataImageID = fieldDefinitionDataImageID;
            this.FieldDefinitionDataID = fieldDefinitionDataID;
            this.FileResourceInfoID = fileResourceInfoID;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields in preparation for insert into database
        /// </summary>
        public FieldDefinitionDataImage(int fieldDefinitionDataID, int fileResourceInfoID) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.FieldDefinitionDataImageID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            
            this.FieldDefinitionDataID = fieldDefinitionDataID;
            this.FileResourceInfoID = fileResourceInfoID;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields, using objects whenever possible
        /// </summary>
        public FieldDefinitionDataImage(FieldDefinitionData fieldDefinitionData, FileResourceInfo fileResourceInfo) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.FieldDefinitionDataImageID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            this.FieldDefinitionDataID = fieldDefinitionData.FieldDefinitionDataID;
            this.FieldDefinitionData = fieldDefinitionData;
            fieldDefinitionData.FieldDefinitionDataImages.Add(this);
            this.FileResourceInfoID = fileResourceInfo.FileResourceInfoID;
            this.FileResourceInfo = fileResourceInfo;
            fileResourceInfo.FieldDefinitionDataImages.Add(this);
        }

        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static FieldDefinitionDataImage CreateNewBlank(FieldDefinitionData fieldDefinitionData, FileResourceInfo fileResourceInfo)
        {
            return new FieldDefinitionDataImage(fieldDefinitionData, fileResourceInfo);
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
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(FieldDefinitionDataImage).Name};


        /// <summary>
        /// Delete just the entity 
        /// </summary>
        public void Delete(DatabaseEntities dbContext)
        {
            dbContext.AllFieldDefinitionDataImages.Remove(this);
        }
        
        /// <summary>
        /// Delete entity plus all children
        /// </summary>
        public void DeleteFull(DatabaseEntities dbContext)
        {
            
            Delete(dbContext);
        }

        [Key]
        public int FieldDefinitionDataImageID { get; set; }
        public int TenantID { get; set; }
        public int FieldDefinitionDataID { get; set; }
        public int FileResourceInfoID { get; set; }
        [NotMapped]
        public int PrimaryKey { get { return FieldDefinitionDataImageID; } set { FieldDefinitionDataImageID = value; } }

        public Tenant Tenant { get { return Tenant.AllLookupDictionary[TenantID]; } }
        public virtual FieldDefinitionData FieldDefinitionData { get; set; }
        public virtual FileResourceInfo FileResourceInfo { get; set; }

        public static class FieldLengths
        {

        }
    }
}