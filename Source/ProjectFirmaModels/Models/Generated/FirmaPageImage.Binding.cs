//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[FirmaPageImage]
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
    // Table [dbo].[FirmaPageImage] is multi-tenant, so is attributed as IHaveATenantID
    [Table("[dbo].[FirmaPageImage]")]
    public partial class FirmaPageImage : IHavePrimaryKey, IHaveATenantID
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected FirmaPageImage()
        {

        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public FirmaPageImage(int firmaPageImageID, int firmaPageID, int fileResourceInfoID) : this()
        {
            this.FirmaPageImageID = firmaPageImageID;
            this.FirmaPageID = firmaPageID;
            this.FileResourceInfoID = fileResourceInfoID;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields in preparation for insert into database
        /// </summary>
        public FirmaPageImage(int firmaPageID, int fileResourceInfoID) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.FirmaPageImageID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            
            this.FirmaPageID = firmaPageID;
            this.FileResourceInfoID = fileResourceInfoID;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields, using objects whenever possible
        /// </summary>
        public FirmaPageImage(FirmaPage firmaPage, FileResourceInfo fileResourceInfo) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.FirmaPageImageID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            this.FirmaPageID = firmaPage.FirmaPageID;
            this.FirmaPage = firmaPage;
            firmaPage.FirmaPageImages.Add(this);
            this.FileResourceInfoID = fileResourceInfo.FileResourceInfoID;
            this.FileResourceInfo = fileResourceInfo;
            fileResourceInfo.FirmaPageImages.Add(this);
        }

        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static FirmaPageImage CreateNewBlank(FirmaPage firmaPage, FileResourceInfo fileResourceInfo)
        {
            return new FirmaPageImage(firmaPage, fileResourceInfo);
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
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(FirmaPageImage).Name};


        /// <summary>
        /// Delete just the entity 
        /// </summary>
        public void Delete(DatabaseEntities dbContext)
        {
            dbContext.AllFirmaPageImages.Remove(this);
        }
        
        /// <summary>
        /// Delete entity plus all children
        /// </summary>
        public void DeleteFull(DatabaseEntities dbContext)
        {
            
            Delete(dbContext);
        }

        [Key]
        public int FirmaPageImageID { get; set; }
        public int TenantID { get; set; }
        public int FirmaPageID { get; set; }
        public int FileResourceInfoID { get; set; }
        [NotMapped]
        public int PrimaryKey { get { return FirmaPageImageID; } set { FirmaPageImageID = value; } }

        public Tenant Tenant { get { return Tenant.AllLookupDictionary[TenantID]; } }
        public virtual FirmaPage FirmaPage { get; set; }
        public virtual FileResourceInfo FileResourceInfo { get; set; }

        public static class FieldLengths
        {

        }
    }
}