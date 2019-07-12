//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[FundingType]
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.Data.Entity.Spatial;
using System.Linq;
using System.Web;
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    [Table("[dbo].[FundingType]")]
    public partial class FundingType : IHavePrimaryKey
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected FundingType()
        {
            this.Projects = new HashSet<Project>();
        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public FundingType(int fundingTypeID, string fundingTypeName, string fundingTypeDisplayName) : this()
        {
            this.FundingTypeID = fundingTypeID;
            this.FundingTypeName = fundingTypeName;
            this.FundingTypeDisplayName = fundingTypeDisplayName;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields in preparation for insert into database
        /// </summary>
        public FundingType(string fundingTypeName, string fundingTypeDisplayName) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.FundingTypeID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            
            this.FundingTypeName = fundingTypeName;
            this.FundingTypeDisplayName = fundingTypeDisplayName;
        }


        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static FundingType CreateNewBlank()
        {
            return new FundingType(default(string), default(string));
        }

        /// <summary>
        /// Does this object have any dependent objects? (If it does have dependent objects, these would need to be deleted before this object could be deleted.)
        /// </summary>
        /// <returns></returns>
        public bool HasDependentObjects()
        {
            return Projects.Any();
        }

        /// <summary>
        /// Dependent type names of this entity
        /// </summary>
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(FundingType).Name, typeof(Project).Name};


        /// <summary>
        /// Delete just the entity 
        /// </summary>
        public void Delete(DatabaseEntities dbContext)
        {
            dbContext.FundingTypes.Remove(this);
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

            foreach(var x in Projects.ToList())
            {
                x.DeleteFull(dbContext);
            }
        }

        [Key]
        public int FundingTypeID { get; set; }
        public string FundingTypeName { get; set; }
        public string FundingTypeDisplayName { get; set; }
        [NotMapped]
        public int PrimaryKey { get { return FundingTypeID; } set { FundingTypeID = value; } }

        public virtual ICollection<Project> Projects { get; set; }

        public static class FieldLengths
        {
            public const int FundingTypeName = 100;
            public const int FundingTypeDisplayName = 100;
        }
    }

    
    public enum FundingTypeEnum
    {
        BudgetVariesByYear = 1,
        BudgetSameEachYear = 2
    }
}