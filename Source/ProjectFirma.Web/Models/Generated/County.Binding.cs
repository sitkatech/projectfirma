//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[County]
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
    [Table("[dbo].[County]")]
    public partial class County : IHavePrimaryKey, IHaveATenantID
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected County()
        {

            this.TenantID = HttpRequestStorage.Tenant.TenantID;
        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public County(int countyID, string countyName, int stateProvinceID, DbGeometry countyFeature) : this()
        {
            this.CountyID = countyID;
            this.CountyName = countyName;
            this.StateProvinceID = stateProvinceID;
            this.CountyFeature = countyFeature;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields in preparation for insert into database
        /// </summary>
        public County(string countyName, int stateProvinceID) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.CountyID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            
            this.CountyName = countyName;
            this.StateProvinceID = stateProvinceID;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields, using objects whenever possible
        /// </summary>
        public County(string countyName, StateProvince stateProvince) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.CountyID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            this.CountyName = countyName;
            this.StateProvinceID = stateProvince.StateProvinceID;
            this.StateProvince = stateProvince;
            stateProvince.Counties.Add(this);
        }

        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static County CreateNewBlank(StateProvince stateProvince)
        {
            return new County(default(string), stateProvince);
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
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(County).Name};


        /// <summary>
        /// Dependent type names of this entity
        /// </summary>
        public void DeleteFull(DatabaseEntities dbContext)
        {
            DeleteChildren(HttpRequestStorage.DatabaseEntities);
            dbContext.AllCounties.Remove(this);
        }

        /// <summary>
        /// Dependent type names of this entity
        /// </summary>
        public void DeleteChildren(DatabaseEntities dbContext)
        {

        }

        [Key]
        public int CountyID { get; set; }
        public int TenantID { get; private set; }
        public string CountyName { get; set; }
        public int StateProvinceID { get; set; }
        public DbGeometry CountyFeature { get; set; }
        [NotMapped]
        public int PrimaryKey { get { return CountyID; } set { CountyID = value; } }

        public Tenant Tenant { get { return Tenant.AllLookupDictionary[TenantID]; } }
        public virtual StateProvince StateProvince { get; set; }

        public static class FieldLengths
        {
            public const int CountyName = 100;
        }
    }
}