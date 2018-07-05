//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ProjectCustomAttributeUpdateValue]
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
    [Table("[dbo].[ProjectCustomAttributeUpdateValue]")]
    public partial class ProjectCustomAttributeUpdateValue : IHavePrimaryKey, IHaveATenantID
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected ProjectCustomAttributeUpdateValue()
        {

            this.TenantID = HttpRequestStorage.Tenant.TenantID;
        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public ProjectCustomAttributeUpdateValue(int projectCustomAttributeUpdateValueID, int projectCustomAttributeUpdateID, string attributeValue) : this()
        {
            this.ProjectCustomAttributeUpdateValueID = projectCustomAttributeUpdateValueID;
            this.ProjectCustomAttributeUpdateID = projectCustomAttributeUpdateID;
            this.AttributeValue = attributeValue;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields in preparation for insert into database
        /// </summary>
        public ProjectCustomAttributeUpdateValue(int projectCustomAttributeUpdateID, string attributeValue) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.ProjectCustomAttributeUpdateValueID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            
            this.ProjectCustomAttributeUpdateID = projectCustomAttributeUpdateID;
            this.AttributeValue = attributeValue;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields, using objects whenever possible
        /// </summary>
        public ProjectCustomAttributeUpdateValue(ProjectCustomAttributeUpdate projectCustomAttributeUpdate, string attributeValue) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.ProjectCustomAttributeUpdateValueID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            this.ProjectCustomAttributeUpdateID = projectCustomAttributeUpdate.ProjectCustomAttributeUpdateID;
            this.ProjectCustomAttributeUpdate = projectCustomAttributeUpdate;
            projectCustomAttributeUpdate.ProjectCustomAttributeUpdateValues.Add(this);
            this.AttributeValue = attributeValue;
        }

        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static ProjectCustomAttributeUpdateValue CreateNewBlank(ProjectCustomAttributeUpdate projectCustomAttributeUpdate)
        {
            return new ProjectCustomAttributeUpdateValue(projectCustomAttributeUpdate, default(string));
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
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(ProjectCustomAttributeUpdateValue).Name};


        /// <summary>
        /// Dependent type names of this entity
        /// </summary>
        public void DeleteFull()
        {
            HttpRequestStorage.DatabaseEntities.AllProjectCustomAttributeUpdateValues.Remove(this);                
        }

        [Key]
        public int ProjectCustomAttributeUpdateValueID { get; set; }
        public int TenantID { get; private set; }
        public int ProjectCustomAttributeUpdateID { get; set; }
        public string AttributeValue { get; set; }
        [NotMapped]
        public int PrimaryKey { get { return ProjectCustomAttributeUpdateValueID; } set { ProjectCustomAttributeUpdateValueID = value; } }

        public Tenant Tenant { get { return Tenant.AllLookupDictionary[TenantID]; } }
        public virtual ProjectCustomAttributeUpdate ProjectCustomAttributeUpdate { get; set; }

        public static class FieldLengths
        {
            public const int AttributeValue = 1000;
        }
    }
}