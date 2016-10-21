//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[TransportationStrategy]
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
    [Table("[dbo].[TransportationStrategy]")]
    public partial class TransportationStrategy : IHavePrimaryKey
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected TransportationStrategy()
        {
            this.TransportationObjectives = new HashSet<TransportationObjective>();
            this.TransportationStrategyImages = new HashSet<TransportationStrategyImage>();
        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public TransportationStrategy(int transportationStrategyID, string transportationStrategyName, string transportationStrategyDescription, string transportationStrategyColor, int? sortOrder) : this()
        {
            this.TransportationStrategyID = transportationStrategyID;
            this.TransportationStrategyName = transportationStrategyName;
            this.TransportationStrategyDescription = transportationStrategyDescription;
            this.TransportationStrategyColor = transportationStrategyColor;
            this.SortOrder = sortOrder;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields in preparation for insert into database
        /// </summary>
        public TransportationStrategy(string transportationStrategyName) : this()
        {
            // Mark this as a new object by setting primary key with special value
            TransportationStrategyID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            
            this.TransportationStrategyName = transportationStrategyName;
        }


        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static TransportationStrategy CreateNewBlank()
        {
            return new TransportationStrategy(default(string));
        }

        /// <summary>
        /// Does this object have any dependent objects? (If it does have dependent objects, these would need to be deleted before this object could be deleted.)
        /// </summary>
        /// <returns></returns>
        public bool HasDependentObjects()
        {
            return TransportationObjectives.Any() || TransportationStrategyImages.Any();
        }

        /// <summary>
        /// Dependent type names of this entity
        /// </summary>
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(TransportationStrategy).Name, typeof(TransportationObjective).Name, typeof(TransportationStrategyImage).Name};

        [Key]
        public int TransportationStrategyID { get; set; }
        public string TransportationStrategyName { get; set; }
        [NotMapped]
        private string TransportationStrategyDescription { get; set; }
        public HtmlString TransportationStrategyDescriptionHtmlString
        { 
            get { return TransportationStrategyDescription == null ? null : new HtmlString(TransportationStrategyDescription); }
            set { TransportationStrategyDescription = value == null ? null : value.ToString(); }
        }
        public string TransportationStrategyColor { get; set; }
        public int? SortOrder { get; set; }
        public int PrimaryKey { get { return TransportationStrategyID; } set { TransportationStrategyID = value; } }

        public virtual ICollection<TransportationObjective> TransportationObjectives { get; set; }
        public virtual ICollection<TransportationStrategyImage> TransportationStrategyImages { get; set; }

        public static class FieldLengths
        {
            public const int TransportationStrategyName = 100;
            public const int TransportationStrategyColor = 20;
        }
    }
}