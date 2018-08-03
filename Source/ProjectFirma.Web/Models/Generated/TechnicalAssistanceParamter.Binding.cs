//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[TechnicalAssistanceParamter]
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
    [Table("[dbo].[TechnicalAssistanceParamter]")]
    public partial class TechnicalAssistanceParamter : IHavePrimaryKey, IHaveATenantID
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected TechnicalAssistanceParamter()
        {

            this.TenantID = HttpRequestStorage.Tenant.TenantID;
        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public TechnicalAssistanceParamter(int technicalAssistanceParamter, int year, decimal engineeringHourlyCost, decimal otherAssistanceHourlyCost) : this()
        {
            this.TechnicalAssistanceParamter = technicalAssistanceParamter;
            this.Year = year;
            this.EngineeringHourlyCost = engineeringHourlyCost;
            this.OtherAssistanceHourlyCost = otherAssistanceHourlyCost;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields in preparation for insert into database
        /// </summary>
        public TechnicalAssistanceParamter(int year, decimal engineeringHourlyCost, decimal otherAssistanceHourlyCost) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.TechnicalAssistanceParamter = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            
            this.Year = year;
            this.EngineeringHourlyCost = engineeringHourlyCost;
            this.OtherAssistanceHourlyCost = otherAssistanceHourlyCost;
        }


        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static TechnicalAssistanceParamter CreateNewBlank()
        {
            return new TechnicalAssistanceParamter(default(int), default(decimal), default(decimal));
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
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(TechnicalAssistanceParamter).Name};


        /// <summary>
        /// Dependent type names of this entity
        /// </summary>
        public void DeleteFull()
        {
            HttpRequestStorage.DatabaseEntities.AllTechnicalAssistanceParamters.Remove(this);                
        }

        [Key]
        public int TechnicalAssistanceParamter { get; set; }
        public int TenantID { get; private set; }
        public int Year { get; set; }
        public decimal EngineeringHourlyCost { get; set; }
        public decimal OtherAssistanceHourlyCost { get; set; }
        [NotMapped]
        public int PrimaryKey { get { return TechnicalAssistanceParamter; } set { TechnicalAssistanceParamter = value; } }

        public Tenant Tenant { get { return Tenant.AllLookupDictionary[TenantID]; } }

        public static class FieldLengths
        {

        }
    }
}