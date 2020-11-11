//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[MatchmakerSubScoreType]
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
    // Table [dbo].[MatchmakerSubScoreType] is NOT multi-tenant, so is attributed as ICanDeleteFull
    [Table("[dbo].[MatchmakerSubScoreType]")]
    public partial class MatchmakerSubScoreType : IHavePrimaryKey, ICanDeleteFull
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected MatchmakerSubScoreType()
        {

        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public MatchmakerSubScoreType(int matchmakerSubScoreTypeID, string matchmakerSubScoreTypeName, string matchmakerSubScoreTypeDisplayName) : this()
        {
            this.MatchmakerSubScoreTypeID = matchmakerSubScoreTypeID;
            this.MatchmakerSubScoreTypeName = matchmakerSubScoreTypeName;
            this.MatchmakerSubScoreTypeDisplayName = matchmakerSubScoreTypeDisplayName;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields in preparation for insert into database
        /// </summary>
        public MatchmakerSubScoreType(string matchmakerSubScoreTypeName, string matchmakerSubScoreTypeDisplayName) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.MatchmakerSubScoreTypeID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            
            this.MatchmakerSubScoreTypeName = matchmakerSubScoreTypeName;
            this.MatchmakerSubScoreTypeDisplayName = matchmakerSubScoreTypeDisplayName;
        }


        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static MatchmakerSubScoreType CreateNewBlank()
        {
            return new MatchmakerSubScoreType(default(string), default(string));
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
        /// Active Dependent type names of this object
        /// </summary>
        public List<string> DependentObjectNames() 
        {
            var dependentObjects = new List<string>();
            
            return dependentObjects.Distinct().ToList();
        }

        /// <summary>
        /// Dependent type names of this entity
        /// </summary>
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(MatchmakerSubScoreType).Name};


        /// <summary>
        /// Delete just the entity 
        /// </summary>
        public void Delete(DatabaseEntities dbContext)
        {
            dbContext.MatchmakerSubScoreTypes.Remove(this);
        }
        
        /// <summary>
        /// Delete entity plus all children
        /// </summary>
        public void DeleteFull(DatabaseEntities dbContext)
        {
            
            Delete(dbContext);
        }

        [Key]
        public int MatchmakerSubScoreTypeID { get; set; }
        public string MatchmakerSubScoreTypeName { get; set; }
        public string MatchmakerSubScoreTypeDisplayName { get; set; }
        [NotMapped]
        public int PrimaryKey { get { return MatchmakerSubScoreTypeID; } set { MatchmakerSubScoreTypeID = value; } }



        public static class FieldLengths
        {
            public const int MatchmakerSubScoreTypeName = 200;
            public const int MatchmakerSubScoreTypeDisplayName = 200;
        }
    }
}