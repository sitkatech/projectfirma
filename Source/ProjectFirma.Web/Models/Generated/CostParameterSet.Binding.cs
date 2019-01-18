//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[CostParameterSet]
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
    // Table [dbo].[CostParameterSet] is multi-tenant, so is attributed as IHaveATenantID
    [Table("[dbo].[CostParameterSet]")]
    public partial class CostParameterSet : IHavePrimaryKey, IHaveATenantID
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected CostParameterSet()
        {

        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public CostParameterSet(int costParameterSetID, decimal inflationRate, int currentYearForPVCalculations, string comment, DateTime createDate) : this()
        {
            this.CostParameterSetID = costParameterSetID;
            this.InflationRate = inflationRate;
            this.CurrentYearForPVCalculations = currentYearForPVCalculations;
            this.Comment = comment;
            this.CreateDate = createDate;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields in preparation for insert into database
        /// </summary>
        public CostParameterSet(decimal inflationRate, int currentYearForPVCalculations, DateTime createDate) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.CostParameterSetID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            
            this.InflationRate = inflationRate;
            this.CurrentYearForPVCalculations = currentYearForPVCalculations;
            this.CreateDate = createDate;
        }


        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static CostParameterSet CreateNewBlank()
        {
            return new CostParameterSet(default(decimal), default(int), default(DateTime));
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
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(CostParameterSet).Name};


        /// <summary>
        /// Dependent type names of this entity
        /// </summary>
        public void DeleteFull(DatabaseEntities dbContext)
        {
            
            dbContext.AllCostParameterSets.Remove(this);
        }

        [Key]
        public int CostParameterSetID { get; set; }
        public int TenantID { get; set; }
        public decimal InflationRate { get; set; }
        public int CurrentYearForPVCalculations { get; set; }
        public string Comment { get; set; }
        public DateTime CreateDate { get; set; }
        [NotMapped]
        public int PrimaryKey { get { return CostParameterSetID; } set { CostParameterSetID = value; } }

        public Tenant Tenant { get { return Tenant.AllLookupDictionary[TenantID]; } }

        public static class FieldLengths
        {
            public const int Comment = 2000;
        }
    }
}