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
using CodeFirstStoreFunctions;
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    // Table [dbo].[ClassificationSystem] is multi-tenant, so is attributed as IHaveATenantID
    [Table("[dbo].[ClassificationSystem]")]
    public partial class ClassificationSystem : IHavePrimaryKey, IHaveATenantID
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected ClassificationSystem()
        {
            this.Classifications = new HashSet<Classification>();
            this.ProjectCustomGridConfigurations = new HashSet<ProjectCustomGridConfiguration>();
            this.ProjectUpdateBatchClassificationSystems = new HashSet<ProjectUpdateBatchClassificationSystem>();
        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public ClassificationSystem(int classificationSystemID, string classificationSystemName, string classificationSystemDefinition, string classificationSystemListPageContent, bool isRequired, string classificationSystemNamePlural) : this()
        {
            this.ClassificationSystemID = classificationSystemID;
            this.ClassificationSystemName = classificationSystemName;
            this.ClassificationSystemDefinition = classificationSystemDefinition;
            this.ClassificationSystemListPageContent = classificationSystemListPageContent;
            this.IsRequired = isRequired;
            this.ClassificationSystemNamePlural = classificationSystemNamePlural;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields in preparation for insert into database
        /// </summary>
        public ClassificationSystem(string classificationSystemName, bool isRequired) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.ClassificationSystemID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            
            this.ClassificationSystemName = classificationSystemName;
            this.IsRequired = isRequired;
        }


        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static ClassificationSystem CreateNewBlank()
        {
            return new ClassificationSystem(default(string), default(bool));
        }

        /// <summary>
        /// Does this object have any dependent objects? (If it does have dependent objects, these would need to be deleted before this object could be deleted.)
        /// </summary>
        /// <returns></returns>
        public bool HasDependentObjects()
        {
            return Classifications.Any() || ProjectCustomGridConfigurations.Any() || ProjectUpdateBatchClassificationSystems.Any();
        }

        /// <summary>
        /// Active Dependent type names of this object
        /// </summary>
        public List<string> DependentObjectNames() 
        {
            var dependentObjects = new List<string>();
            
            if(Classifications.Any())
            {
                dependentObjects.Add(typeof(Classification).Name);
            }

            if(ProjectCustomGridConfigurations.Any())
            {
                dependentObjects.Add(typeof(ProjectCustomGridConfiguration).Name);
            }

            if(ProjectUpdateBatchClassificationSystems.Any())
            {
                dependentObjects.Add(typeof(ProjectUpdateBatchClassificationSystem).Name);
            }
            return dependentObjects.Distinct().ToList();
        }

        /// <summary>
        /// Dependent type names of this entity
        /// </summary>
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(ClassificationSystem).Name, typeof(Classification).Name, typeof(ProjectCustomGridConfiguration).Name, typeof(ProjectUpdateBatchClassificationSystem).Name};


        /// <summary>
        /// Delete just the entity 
        /// </summary>
        public void Delete(DatabaseEntities dbContext)
        {
            dbContext.AllClassificationSystems.Remove(this);
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

            foreach(var x in Classifications.ToList())
            {
                x.DeleteFull(dbContext);
            }

            foreach(var x in ProjectCustomGridConfigurations.ToList())
            {
                x.DeleteFull(dbContext);
            }

            foreach(var x in ProjectUpdateBatchClassificationSystems.ToList())
            {
                x.DeleteFull(dbContext);
            }
        }

        [Key]
        public int ClassificationSystemID { get; set; }
        public int TenantID { get; set; }
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
        public bool IsRequired { get; set; }
        public string ClassificationSystemNamePlural { get; set; }
        [NotMapped]
        public int PrimaryKey { get { return ClassificationSystemID; } set { ClassificationSystemID = value; } }

        public virtual ICollection<Classification> Classifications { get; set; }
        public virtual ICollection<ProjectCustomGridConfiguration> ProjectCustomGridConfigurations { get; set; }
        public virtual ICollection<ProjectUpdateBatchClassificationSystem> ProjectUpdateBatchClassificationSystems { get; set; }
        public Tenant Tenant { get { return Tenant.AllLookupDictionary[TenantID]; } }

        public static class FieldLengths
        {
            public const int ClassificationSystemName = 200;
            public const int ClassificationSystemNamePlural = 210;
        }
    }
}