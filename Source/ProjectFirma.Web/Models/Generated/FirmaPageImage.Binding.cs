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
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Models
{
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
        public FirmaPageImage(int firmaPageImageID, int firmaPageID, int fileResourceID) : this()
        {
            this.TenantID = HttpRequestStorage.Tenant.TenantID;
            
            this.FirmaPageImageID = firmaPageImageID;
            this.FirmaPageID = firmaPageID;
            this.FileResourceID = fileResourceID;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields in preparation for insert into database
        /// </summary>
        public FirmaPageImage(int firmaPageID, int fileResourceID) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.FirmaPageImageID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            
            this.TenantID = HttpRequestStorage.Tenant.TenantID;
            this.FirmaPageID = firmaPageID;
            this.FileResourceID = fileResourceID;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields, using objects whenever possible
        /// </summary>
        public FirmaPageImage(FirmaPage firmaPage, FileResource fileResource) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.FirmaPageImageID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            this.TenantID = HttpRequestStorage.Tenant.TenantID;
            this.FirmaPageID = firmaPage.FirmaPageID;
            this.FirmaPage = firmaPage;
            firmaPage.FirmaPageImages.Add(this);
            this.FileResourceID = fileResource.FileResourceID;
            this.FileResource = fileResource;
            fileResource.FirmaPageImages.Add(this);
        }

        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static FirmaPageImage CreateNewBlank(FirmaPage firmaPage, FileResource fileResource)
        {
            return new FirmaPageImage(firmaPage, fileResource);
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
        /// Dependent type names of this entity
        /// </summary>
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(FirmaPageImage).Name};

        [Key]
        public int FirmaPageImageID { get; set; }
        public int TenantID { get; private set; }
        public int FirmaPageID { get; set; }
        public int FileResourceID { get; set; }
        public int PrimaryKey { get { return FirmaPageImageID; } set { FirmaPageImageID = value; } }

        public Tenant Tenant { get { return Tenant.AllLookupDictionary[TenantID]; } }
        public virtual FirmaPage FirmaPage { get; set; }
        public virtual FileResource FileResource { get; set; }

        public static class FieldLengths
        {

        }
    }
}