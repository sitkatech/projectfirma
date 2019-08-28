//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ProjectCustomAttributeType]
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
    // Table [dbo].[ProjectCustomAttributeType] is multi-tenant, so is attributed as IHaveATenantID
    [Table("[dbo].[ProjectCustomAttributeType]")]
    public partial class ProjectCustomAttributeType : IHavePrimaryKey, IHaveATenantID
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected ProjectCustomAttributeType()
        {
            this.ProjectCustomAttributes = new HashSet<ProjectCustomAttribute>();
            this.ProjectCustomAttributeTypeRoles = new HashSet<ProjectCustomAttributeTypeRole>();
            this.ProjectCustomAttributeUpdates = new HashSet<ProjectCustomAttributeUpdate>();
            this.ProjectCustomGridConfigurations = new HashSet<ProjectCustomGridConfiguration>();
        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public ProjectCustomAttributeType(int projectCustomAttributeTypeID, string projectCustomAttributeTypeName, int projectCustomAttributeDataTypeID, int? measurementUnitTypeID, bool isRequired, string projectCustomAttributeTypeDescription, string projectCustomAttributeTypeOptionsSchema) : this()
        {
            this.ProjectCustomAttributeTypeID = projectCustomAttributeTypeID;
            this.ProjectCustomAttributeTypeName = projectCustomAttributeTypeName;
            this.ProjectCustomAttributeDataTypeID = projectCustomAttributeDataTypeID;
            this.MeasurementUnitTypeID = measurementUnitTypeID;
            this.IsRequired = isRequired;
            this.ProjectCustomAttributeTypeDescription = projectCustomAttributeTypeDescription;
            this.ProjectCustomAttributeTypeOptionsSchema = projectCustomAttributeTypeOptionsSchema;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields in preparation for insert into database
        /// </summary>
        public ProjectCustomAttributeType(string projectCustomAttributeTypeName, int projectCustomAttributeDataTypeID, bool isRequired) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.ProjectCustomAttributeTypeID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            
            this.ProjectCustomAttributeTypeName = projectCustomAttributeTypeName;
            this.ProjectCustomAttributeDataTypeID = projectCustomAttributeDataTypeID;
            this.IsRequired = isRequired;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields, using objects whenever possible
        /// </summary>
        public ProjectCustomAttributeType(string projectCustomAttributeTypeName, ProjectCustomAttributeDataType projectCustomAttributeDataType, bool isRequired) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.ProjectCustomAttributeTypeID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            this.ProjectCustomAttributeTypeName = projectCustomAttributeTypeName;
            this.ProjectCustomAttributeDataTypeID = projectCustomAttributeDataType.ProjectCustomAttributeDataTypeID;
            this.IsRequired = isRequired;
        }

        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static ProjectCustomAttributeType CreateNewBlank(ProjectCustomAttributeDataType projectCustomAttributeDataType)
        {
            return new ProjectCustomAttributeType(default(string), projectCustomAttributeDataType, default(bool));
        }

        /// <summary>
        /// Does this object have any dependent objects? (If it does have dependent objects, these would need to be deleted before this object could be deleted.)
        /// </summary>
        /// <returns></returns>
        public bool HasDependentObjects()
        {
            return ProjectCustomAttributes.Any() || ProjectCustomAttributeTypeRoles.Any() || ProjectCustomAttributeUpdates.Any() || ProjectCustomGridConfigurations.Any();
        }

        /// <summary>
        /// Dependent type names of this entity
        /// </summary>
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(ProjectCustomAttributeType).Name, typeof(ProjectCustomAttribute).Name, typeof(ProjectCustomAttributeTypeRole).Name, typeof(ProjectCustomAttributeUpdate).Name, typeof(ProjectCustomGridConfiguration).Name};


        /// <summary>
        /// Delete just the entity 
        /// </summary>
        public void Delete(DatabaseEntities dbContext)
        {
            dbContext.AllProjectCustomAttributeTypes.Remove(this);
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

            foreach(var x in ProjectCustomAttributes.ToList())
            {
                x.DeleteFull(dbContext);
            }

            foreach(var x in ProjectCustomAttributeTypeRoles.ToList())
            {
                x.DeleteFull(dbContext);
            }

            foreach(var x in ProjectCustomAttributeUpdates.ToList())
            {
                x.DeleteFull(dbContext);
            }

            foreach(var x in ProjectCustomGridConfigurations.ToList())
            {
                x.DeleteFull(dbContext);
            }
        }

        [Key]
        public int ProjectCustomAttributeTypeID { get; set; }
        public int TenantID { get; set; }
        public string ProjectCustomAttributeTypeName { get; set; }
        public int ProjectCustomAttributeDataTypeID { get; set; }
        public int? MeasurementUnitTypeID { get; set; }
        public bool IsRequired { get; set; }
        public string ProjectCustomAttributeTypeDescription { get; set; }
        public string ProjectCustomAttributeTypeOptionsSchema { get; set; }
        [NotMapped]
        public int PrimaryKey { get { return ProjectCustomAttributeTypeID; } set { ProjectCustomAttributeTypeID = value; } }

        public virtual ICollection<ProjectCustomAttribute> ProjectCustomAttributes { get; set; }
        public virtual ICollection<ProjectCustomAttributeTypeRole> ProjectCustomAttributeTypeRoles { get; set; }
        public virtual ICollection<ProjectCustomAttributeUpdate> ProjectCustomAttributeUpdates { get; set; }
        public virtual ICollection<ProjectCustomGridConfiguration> ProjectCustomGridConfigurations { get; set; }
        public Tenant Tenant { get { return Tenant.AllLookupDictionary[TenantID]; } }
        public ProjectCustomAttributeDataType ProjectCustomAttributeDataType { get { return ProjectCustomAttributeDataType.AllLookupDictionary[ProjectCustomAttributeDataTypeID]; } }
        public MeasurementUnitType MeasurementUnitType { get { return MeasurementUnitTypeID.HasValue ? MeasurementUnitType.AllLookupDictionary[MeasurementUnitTypeID.Value] : null; } }

        public static class FieldLengths
        {
            public const int ProjectCustomAttributeTypeName = 100;
            public const int ProjectCustomAttributeTypeDescription = 200;
        }
    }
}