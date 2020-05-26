//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[CustomPageImage]
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
    // Table [dbo].[CustomPageImage] is multi-tenant, so is attributed as IHaveATenantID
    [Table("[dbo].[CustomPageImage]")]
    public partial class CustomPageImage : IHavePrimaryKey, IHaveATenantID
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected CustomPageImage()
        {

        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public CustomPageImage(int customPageImageID, int customPageID, int fileResourceInfoID) : this()
        {
            this.CustomPageImageID = customPageImageID;
            this.CustomPageID = customPageID;
            this.FileResourceInfoID = fileResourceInfoID;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields in preparation for insert into database
        /// </summary>
        public CustomPageImage(int customPageID, int fileResourceInfoID) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.CustomPageImageID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            
            this.CustomPageID = customPageID;
            this.FileResourceInfoID = fileResourceInfoID;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields, using objects whenever possible
        /// </summary>
        public CustomPageImage(CustomPage customPage, FileResourceInfo fileResourceInfo) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.CustomPageImageID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            this.CustomPageID = customPage.CustomPageID;
            this.CustomPage = customPage;
            customPage.CustomPageImages.Add(this);
            this.FileResourceInfoID = fileResourceInfo.FileResourceInfoID;
            this.FileResourceInfo = fileResourceInfo;
            fileResourceInfo.CustomPageImages.Add(this);
        }

        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static CustomPageImage CreateNewBlank(CustomPage customPage, FileResourceInfo fileResourceInfo)
        {
            return new CustomPageImage(customPage, fileResourceInfo);
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
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(CustomPageImage).Name};


        /// <summary>
        /// Delete just the entity 
        /// </summary>
        public void Delete(DatabaseEntities dbContext)
        {
            dbContext.AllCustomPageImages.Remove(this);
        }
        
        /// <summary>
        /// Delete entity plus all children
        /// </summary>
        public void DeleteFull(DatabaseEntities dbContext)
        {
            
            Delete(dbContext);
        }

        [Key]
        public int CustomPageImageID { get; set; }
        public int TenantID { get; set; }
        public int CustomPageID { get; set; }
        public int FileResourceInfoID { get; set; }
        [NotMapped]
        public int PrimaryKey { get { return CustomPageImageID; } set { CustomPageImageID = value; } }

        public Tenant Tenant { get { return Tenant.AllLookupDictionary[TenantID]; } }
        public virtual CustomPage CustomPage { get; set; }
        public virtual FileResourceInfo FileResourceInfo { get; set; }

        public static class FieldLengths
        {

        }
    }
}