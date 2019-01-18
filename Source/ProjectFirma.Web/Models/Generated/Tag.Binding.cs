//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[Tag]
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
    // Table [dbo].[Tag] is multi-tenant, so is attributed as IHaveATenantID
    [Table("[dbo].[Tag]")]
    public partial class Tag : IHavePrimaryKey, IHaveATenantID
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected Tag()
        {
            this.ProjectTags = new HashSet<ProjectTag>();
        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public Tag(int tagID, string tagName, string tagDescription) : this()
        {
            this.TagID = tagID;
            this.TagName = tagName;
            this.TagDescription = tagDescription;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields in preparation for insert into database
        /// </summary>
        public Tag(string tagName) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.TagID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            
            this.TagName = tagName;
        }


        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static Tag CreateNewBlank()
        {
            return new Tag(default(string));
        }

        /// <summary>
        /// Does this object have any dependent objects? (If it does have dependent objects, these would need to be deleted before this object could be deleted.)
        /// </summary>
        /// <returns></returns>
        public bool HasDependentObjects()
        {
            return ProjectTags.Any();
        }

        /// <summary>
        /// Dependent type names of this entity
        /// </summary>
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(Tag).Name, typeof(ProjectTag).Name};


        /// <summary>
        /// Dependent type names of this entity
        /// </summary>
        public void DeleteFull(DatabaseEntities dbContext)
        {
            DeleteChildren(dbContext);
            dbContext.AllTags.Remove(this);
        }
        /// <summary>
        /// Dependent type names of this entity
        /// </summary>
        public void DeleteChildren(DatabaseEntities dbContext)
        {

            foreach(var x in ProjectTags.ToList())
            {
                x.DeleteFull(dbContext);
            }
        }

        [Key]
        public int TagID { get; set; }
        public int TenantID { get; set; }
        public string TagName { get; set; }
        public string TagDescription { get; set; }
        [NotMapped]
        public int PrimaryKey { get { return TagID; } set { TagID = value; } }

        public virtual ICollection<ProjectTag> ProjectTags { get; set; }
        public Tenant Tenant { get { return Tenant.AllLookupDictionary[TenantID]; } }

        public static class FieldLengths
        {
            public const int TagName = 100;
            public const int TagDescription = 1000;
        }
    }
}