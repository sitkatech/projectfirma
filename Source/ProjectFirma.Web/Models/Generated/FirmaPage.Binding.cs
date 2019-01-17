//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[FirmaPage]
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
    // Table [dbo].[FirmaPage] is multi-tenant, so is attributed as IHaveATenantID
    [Table("[dbo].[FirmaPage]")]
    public partial class FirmaPage : IHavePrimaryKey, IHaveATenantID
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected FirmaPage()
        {
            this.FirmaPageImages = new HashSet<FirmaPageImage>();
        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public FirmaPage(int firmaPageID, int firmaPageTypeID, string firmaPageContent) : this()
        {
            this.FirmaPageID = firmaPageID;
            this.FirmaPageTypeID = firmaPageTypeID;
            this.FirmaPageContent = firmaPageContent;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields in preparation for insert into database
        /// </summary>
        public FirmaPage(int firmaPageTypeID) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.FirmaPageID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            
            this.FirmaPageTypeID = firmaPageTypeID;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields, using objects whenever possible
        /// </summary>
        public FirmaPage(FirmaPageType firmaPageType) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.FirmaPageID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            this.FirmaPageTypeID = firmaPageType.FirmaPageTypeID;
        }

        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static FirmaPage CreateNewBlank(FirmaPageType firmaPageType)
        {
            return new FirmaPage(firmaPageType);
        }

        /// <summary>
        /// Does this object have any dependent objects? (If it does have dependent objects, these would need to be deleted before this object could be deleted.)
        /// </summary>
        /// <returns></returns>
        public bool HasDependentObjects()
        {
            return FirmaPageImages.Any();
        }

        /// <summary>
        /// Dependent type names of this entity
        /// </summary>
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(FirmaPage).Name, typeof(FirmaPageImage).Name};


        /// <summary>
        /// Dependent type names of this entity
        /// </summary>
        public void DeleteFull(DatabaseEntities dbContext)
        {
            DeleteChildren(dbContext);
            dbContext.AllFirmaPages.Remove(this);
        }
        /// <summary>
        /// Dependent type names of this entity
        /// </summary>
        public void DeleteChildren(DatabaseEntities dbContext)
        {

            foreach(var x in FirmaPageImages.ToList())
            {
                x.DeleteFull(dbContext);
            }
        }

        [Key]
        public int FirmaPageID { get; set; }
        public int TenantID { get; set; }
        public int FirmaPageTypeID { get; set; }
        public string FirmaPageContent { get; set; }
        [NotMapped]
        public HtmlString FirmaPageContentHtmlString
        { 
            get { return FirmaPageContent == null ? null : new HtmlString(FirmaPageContent); }
            set { FirmaPageContent = value?.ToString(); }
        }
        [NotMapped]
        public int PrimaryKey { get { return FirmaPageID; } set { FirmaPageID = value; } }

        public virtual ICollection<FirmaPageImage> FirmaPageImages { get; set; }
        public Tenant Tenant { get { return Tenant.AllLookupDictionary[TenantID]; } }
        public FirmaPageType FirmaPageType { get { return FirmaPageType.AllLookupDictionary[FirmaPageTypeID]; } }

        public static class FieldLengths
        {

        }
    }
}