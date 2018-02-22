//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ClassificationSystem]
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
    [Table("[dbo].[ClassificationSystem]")]
    public partial class ClassificationSystem : IHavePrimaryKey, IHaveATenantID
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected ClassificationSystem()
        {
            this.Classifications = new HashSet<Classification>();
            this.TenantID = HttpRequestStorage.Tenant.TenantID;
        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public ClassificationSystem(int classificationSystemID, string classificationSystemName, string classificationSystemDefinition, string classificationSystemListPageContent) : this()
        {
            this.ClassificationSystemID = classificationSystemID;
            this.ClassificationSystemName = classificationSystemName;
            this.ClassificationSystemDefinition = classificationSystemDefinition;
            this.ClassificationSystemListPageContent = classificationSystemListPageContent;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields in preparation for insert into database
        /// </summary>
        public ClassificationSystem(string classificationSystemName) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.ClassificationSystemID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            
            this.ClassificationSystemName = classificationSystemName;
        }


        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static ClassificationSystem CreateNewBlank()
        {
            return new ClassificationSystem(default(string));
        }

        /// <summary>
        /// Does this object have any dependent objects? (If it does have dependent objects, these would need to be deleted before this object could be deleted.)
        /// </summary>
        /// <returns></returns>
        public bool HasDependentObjects()
        {
            return Classifications.Any();
        }

        /// <summary>
        /// Dependent type names of this entity
        /// </summary>
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(ClassificationSystem).Name, typeof(Classification).Name};

        [Key]
        public int ClassificationSystemID { get; set; }
        public int TenantID { get; private set; }
        public string ClassificationSystemName { get; set; }
        public string ClassificationSystemDefinition { get; set; }
        [NotMapped]
        public HtmlString ClassificationSystemDefinitionHtmlString
        { 
            get { return ClassificationSystemDefinition == null ? null : new HtmlString(ClassificationSystemDefinition); }
            set { ClassificationSystemDefinition = value?.ToString(); }
        }
        public string ClassificationSystemListPageContent { get; set; }
        [NotMapped]
        public HtmlString ClassificationSystemListPageContentHtmlString
        { 
            get { return ClassificationSystemListPageContent == null ? null : new HtmlString(ClassificationSystemListPageContent); }
            set { ClassificationSystemListPageContent = value?.ToString(); }
        }
        [NotMapped]
        public int PrimaryKey { get { return ClassificationSystemID; } set { ClassificationSystemID = value; } }

        public virtual ICollection<Classification> Classifications { get; set; }
        public Tenant Tenant { get { return Tenant.AllLookupDictionary[TenantID]; } }

        public static class FieldLengths
        {
            public const int ClassificationSystemName = 200;
        }
    }
}