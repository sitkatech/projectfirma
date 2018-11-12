//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[TechnicalAssistanceParameter]
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
    [Table("[dbo].[TechnicalAssistanceParameter]")]
    public partial class TechnicalAssistanceParameter : IHavePrimaryKey, IHaveATenantID
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected TechnicalAssistanceParameter()
        {

            this.TenantID = HttpRequestStorage.Tenant.TenantID;
        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public TechnicalAssistanceParameter(int technicalAssistanceParameterID, int year, decimal? engineeringHourlyCost, decimal? otherAssistanceHourlyCost) : this()
        {
            this.TechnicalAssistanceParameterID = technicalAssistanceParameterID;
            this.Year = year;
            this.EngineeringHourlyCost = engineeringHourlyCost;
            this.OtherAssistanceHourlyCost = otherAssistanceHourlyCost;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields in preparation for insert into database
        /// </summary>
        public TechnicalAssistanceParameter(int year) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.TechnicalAssistanceParameterID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            
            this.Year = year;
        }


        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static TechnicalAssistanceParameter CreateNewBlank()
        {
            return new TechnicalAssistanceParameter(default(int));
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
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(TechnicalAssistanceParameter).Name};


        /// <summary>
        /// Dependent type names of this entity
        /// </summary>
        public void DeleteFull()
        {
            DeleteFull(HttpRequestStorage.DatabaseEntities);
        }

        /// <summary>
        /// Dependent type names of this entity
        /// </summary>
        public void DeleteFull(DatabaseEntities dbContext)
        {
            dbContext.AllTechnicalAssistanceParameters.Remove(this);
        }

        [Key]
        public int TechnicalAssistanceParameterID { get; set; }
        public int TenantID { get; private set; }
        public int Year { get; set; }
        public decimal? EngineeringHourlyCost { get; set; }
        public decimal? OtherAssistanceHourlyCost { get; set; }
        [NotMapped]
        public int PrimaryKey { get { return TechnicalAssistanceParameterID; } set { TechnicalAssistanceParameterID = value; } }

        public Tenant Tenant { get { return Tenant.AllLookupDictionary[TenantID]; } }

        public static class FieldLengths
        {

        }
    }
}