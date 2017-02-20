//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[StateProvince]
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
    [Table("[dbo].[StateProvince]")]
    public partial class StateProvince : IHavePrimaryKey, IHaveATenantID
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected StateProvince()
        {
            this.Counties = new HashSet<County>();
            this.ProjectLocationAreas = new HashSet<ProjectLocationArea>();
            this.ProjectLocationAreaStateProvinces = new HashSet<ProjectLocationAreaStateProvince>();
            this.TenantID = HttpRequestStorage.Tenant.TenantID;
        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public StateProvince(int stateProvinceID, string stateProvinceName, string stateProvinceAbbreviation, DbGeometry stateProvinceFeature, DbGeometry stateProvinceFeatureForAnalysis) : this()
        {
            this.StateProvinceID = stateProvinceID;
            this.StateProvinceName = stateProvinceName;
            this.StateProvinceAbbreviation = stateProvinceAbbreviation;
            this.StateProvinceFeature = stateProvinceFeature;
            this.StateProvinceFeatureForAnalysis = stateProvinceFeatureForAnalysis;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields in preparation for insert into database
        /// </summary>
        public StateProvince(string stateProvinceName, string stateProvinceAbbreviation, DbGeometry stateProvinceFeatureForAnalysis) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.StateProvinceID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            
            this.StateProvinceName = stateProvinceName;
            this.StateProvinceAbbreviation = stateProvinceAbbreviation;
            this.StateProvinceFeatureForAnalysis = stateProvinceFeatureForAnalysis;
        }


        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static StateProvince CreateNewBlank()
        {
            return new StateProvince(default(string), default(string), default(DbGeometry));
        }

        /// <summary>
        /// Does this object have any dependent objects? (If it does have dependent objects, these would need to be deleted before this object could be deleted.)
        /// </summary>
        /// <returns></returns>
        public bool HasDependentObjects()
        {
            return Counties.Any() || ProjectLocationAreas.Any() || ProjectLocationAreaStateProvinces.Any();
        }

        /// <summary>
        /// Dependent type names of this entity
        /// </summary>
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(StateProvince).Name, typeof(County).Name, typeof(ProjectLocationArea).Name, typeof(ProjectLocationAreaStateProvince).Name};

        [Key]
        public int StateProvinceID { get; set; }
        public int TenantID { get; private set; }
        public string StateProvinceName { get; set; }
        public string StateProvinceAbbreviation { get; set; }
        public DbGeometry StateProvinceFeature { get; set; }
        public DbGeometry StateProvinceFeatureForAnalysis { get; set; }
        public int PrimaryKey { get { return StateProvinceID; } set { StateProvinceID = value; } }

        public virtual ICollection<County> Counties { get; set; }
        public virtual ICollection<ProjectLocationArea> ProjectLocationAreas { get; set; }
        public virtual ICollection<ProjectLocationAreaStateProvince> ProjectLocationAreaStateProvinces { get; set; }
        public Tenant Tenant { get { return Tenant.AllLookupDictionary[TenantID]; } }

        public static class FieldLengths
        {
            public const int StateProvinceName = 100;
            public const int StateProvinceAbbreviation = 2;
        }
    }
}