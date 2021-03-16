//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[FirmaSystemAuthenticationType]
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
    // Table [dbo].[FirmaSystemAuthenticationType] is NOT multi-tenant, so is attributed as ICanDeleteFull
    [Table("[dbo].[FirmaSystemAuthenticationType]")]
    public partial class FirmaSystemAuthenticationType : IHavePrimaryKey, ICanDeleteFull
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected FirmaSystemAuthenticationType()
        {
            this.TenantAttributes = new HashSet<TenantAttribute>();
        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public FirmaSystemAuthenticationType(int firmaSystemAuthenticationTypeID, string firmaSystemAuthenticationTypeName, string firmaSystemAuthenticationTypeDisplayName) : this()
        {
            this.FirmaSystemAuthenticationTypeID = firmaSystemAuthenticationTypeID;
            this.FirmaSystemAuthenticationTypeName = firmaSystemAuthenticationTypeName;
            this.FirmaSystemAuthenticationTypeDisplayName = firmaSystemAuthenticationTypeDisplayName;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields in preparation for insert into database
        /// </summary>
        public FirmaSystemAuthenticationType(string firmaSystemAuthenticationTypeName, string firmaSystemAuthenticationTypeDisplayName) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.FirmaSystemAuthenticationTypeID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            
            this.FirmaSystemAuthenticationTypeName = firmaSystemAuthenticationTypeName;
            this.FirmaSystemAuthenticationTypeDisplayName = firmaSystemAuthenticationTypeDisplayName;
        }


        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static FirmaSystemAuthenticationType CreateNewBlank()
        {
            return new FirmaSystemAuthenticationType(default(string), default(string));
        }

        /// <summary>
        /// Does this object have any dependent objects? (If it does have dependent objects, these would need to be deleted before this object could be deleted.)
        /// </summary>
        /// <returns></returns>
        public bool HasDependentObjects()
        {
            return TenantAttributes.Any();
        }

        /// <summary>
        /// Active Dependent type names of this object
        /// </summary>
        public List<string> DependentObjectNames() 
        {
            var dependentObjects = new List<string>();
            
            if(TenantAttributes.Any())
            {
                dependentObjects.Add(typeof(TenantAttribute).Name);
            }
            return dependentObjects.Distinct().ToList();
        }

        /// <summary>
        /// Dependent type names of this entity
        /// </summary>
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(FirmaSystemAuthenticationType).Name, typeof(TenantAttribute).Name};


        /// <summary>
        /// Delete just the entity 
        /// </summary>
        public void Delete(DatabaseEntities dbContext)
        {
            dbContext.FirmaSystemAuthenticationTypes.Remove(this);
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

            foreach(var x in TenantAttributes.ToList())
            {
                x.DeleteFull(dbContext);
            }
        }

        [Key]
        public int FirmaSystemAuthenticationTypeID { get; set; }
        public string FirmaSystemAuthenticationTypeName { get; set; }
        public string FirmaSystemAuthenticationTypeDisplayName { get; set; }
        [NotMapped]
        public int PrimaryKey { get { return FirmaSystemAuthenticationTypeID; } set { FirmaSystemAuthenticationTypeID = value; } }

        public virtual ICollection<TenantAttribute> TenantAttributes { get; set; }

        public static class FieldLengths
        {
            public const int FirmaSystemAuthenticationTypeName = 100;
            public const int FirmaSystemAuthenticationTypeDisplayName = 100;
        }
    }
}