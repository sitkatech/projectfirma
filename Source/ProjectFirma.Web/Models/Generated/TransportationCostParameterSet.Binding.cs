//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[TransportationCostParameterSet]
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.Data.Entity.Spatial;
using System.Linq;
using System.Web;
using ProjectFirma.Web.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirma.Web.Models
{
    [Table("[dbo].[TransportationCostParameterSet]")]
    public partial class TransportationCostParameterSet : IHavePrimaryKey
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected TransportationCostParameterSet()
        {

        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public TransportationCostParameterSet(int transportationCostParameterSetID, decimal inflationRate, int currentRTPYearForPVCalculations, string comment, DateTime createDate) : this()
        {
            this.TransportationCostParameterSetID = transportationCostParameterSetID;
            this.InflationRate = inflationRate;
            this.CurrentRTPYearForPVCalculations = currentRTPYearForPVCalculations;
            this.Comment = comment;
            this.CreateDate = createDate;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields in preparation for insert into database
        /// </summary>
        public TransportationCostParameterSet(decimal inflationRate, int currentRTPYearForPVCalculations, DateTime createDate) : this()
        {
            // Mark this as a new object by setting primary key with special value
            TransportationCostParameterSetID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            
            this.InflationRate = inflationRate;
            this.CurrentRTPYearForPVCalculations = currentRTPYearForPVCalculations;
            this.CreateDate = createDate;
        }


        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static TransportationCostParameterSet CreateNewBlank()
        {
            return new TransportationCostParameterSet(default(decimal), default(int), default(DateTime));
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
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(TransportationCostParameterSet).Name};

        [Key]
        public int TransportationCostParameterSetID { get; set; }
        public decimal InflationRate { get; set; }
        public int CurrentRTPYearForPVCalculations { get; set; }
        public string Comment { get; set; }
        public DateTime CreateDate { get; set; }
        public int PrimaryKey { get { return TransportationCostParameterSetID; } set { TransportationCostParameterSetID = value; } }



        public static class FieldLengths
        {
            public const int Comment = 2000;
        }
    }
}