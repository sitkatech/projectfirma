//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[AccelaJurisdictionToJurisdictionMapping]
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
    [Table("[dbo].[AccelaJurisdictionToJurisdictionMapping]")]
    public partial class AccelaJurisdictionToJurisdictionMapping : IHavePrimaryKey
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected AccelaJurisdictionToJurisdictionMapping()
        {

        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public AccelaJurisdictionToJurisdictionMapping(int accelaJurisdictionToJurisdictionMappingID, string accelaJurisdictionName, int? jurisdictionID) : this()
        {
            this.AccelaJurisdictionToJurisdictionMappingID = accelaJurisdictionToJurisdictionMappingID;
            this.AccelaJurisdictionName = accelaJurisdictionName;
            this.JurisdictionID = jurisdictionID;
        }



        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static AccelaJurisdictionToJurisdictionMapping CreateNewBlank()
        {
            return new AccelaJurisdictionToJurisdictionMapping();
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
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(AccelaJurisdictionToJurisdictionMapping).Name};

        [Key]
        public int AccelaJurisdictionToJurisdictionMappingID { get; set; }
        public string AccelaJurisdictionName { get; set; }
        public int? JurisdictionID { get; set; }
        public int PrimaryKey { get { return AccelaJurisdictionToJurisdictionMappingID; } set { AccelaJurisdictionToJurisdictionMappingID = value; } }

        public virtual Jurisdiction Jurisdiction { get; set; }

        public static class FieldLengths
        {
            public const int AccelaJurisdictionName = 50;
        }
    }
}