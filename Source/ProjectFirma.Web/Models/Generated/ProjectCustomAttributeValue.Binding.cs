//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ProjectCustomAttributeValue]
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
    [Table("[dbo].[ProjectCustomAttributeValue]")]
    public partial class ProjectCustomAttributeValue : IHavePrimaryKey, IHaveATenantID
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected ProjectCustomAttributeValue()
        {

            this.TenantID = HttpRequestStorage.Tenant.TenantID;
        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public ProjectCustomAttributeValue(int projectCustomAttributeValueID, int projectCustomAttributeID, string attributeValue) : this()
        {
            this.ProjectCustomAttributeValueID = projectCustomAttributeValueID;
            this.ProjectCustomAttributeID = projectCustomAttributeID;
            this.AttributeValue = attributeValue;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields in preparation for insert into database
        /// </summary>
        public ProjectCustomAttributeValue(int projectCustomAttributeID, string attributeValue) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.ProjectCustomAttributeValueID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            
            this.ProjectCustomAttributeID = projectCustomAttributeID;
            this.AttributeValue = attributeValue;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields, using objects whenever possible
        /// </summary>
        public ProjectCustomAttributeValue(ProjectCustomAttribute projectCustomAttribute, string attributeValue) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.ProjectCustomAttributeValueID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            this.ProjectCustomAttributeID = projectCustomAttribute.ProjectCustomAttributeID;
            this.ProjectCustomAttribute = projectCustomAttribute;
            projectCustomAttribute.ProjectCustomAttributeValues.Add(this);
            this.AttributeValue = attributeValue;
        }

        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static ProjectCustomAttributeValue CreateNewBlank(ProjectCustomAttribute projectCustomAttribute)
        {
            return new ProjectCustomAttributeValue(projectCustomAttribute, default(string));
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
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(ProjectCustomAttributeValue).Name};


        /// <summary>
        /// Dependent type names of this entity
        /// </summary>
        public void DeleteFull()
        {
            HttpRequestStorage.DatabaseEntities.AllProjectCustomAttributeValues.Remove(this);                
        }

        [Key]
        public int ProjectCustomAttributeValueID { get; set; }
        public int TenantID { get; private set; }
        public int ProjectCustomAttributeID { get; set; }
        public string AttributeValue { get; set; }
        [NotMapped]
        public int PrimaryKey { get { return ProjectCustomAttributeValueID; } set { ProjectCustomAttributeValueID = value; } }

        public Tenant Tenant { get { return Tenant.AllLookupDictionary[TenantID]; } }
        public virtual ProjectCustomAttribute ProjectCustomAttribute { get; set; }

        public static class FieldLengths
        {
            public const int AttributeValue = 1000;
        }
    }
}