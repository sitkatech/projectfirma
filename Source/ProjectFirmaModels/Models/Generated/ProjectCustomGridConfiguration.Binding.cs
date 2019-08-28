//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ProjectCustomGridConfiguration]
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
    // Table [dbo].[ProjectCustomGridConfiguration] is multi-tenant, so is attributed as IHaveATenantID
    [Table("[dbo].[ProjectCustomGridConfiguration]")]
    public partial class ProjectCustomGridConfiguration : IHavePrimaryKey, IHaveATenantID
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected ProjectCustomGridConfiguration()
        {

        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public ProjectCustomGridConfiguration(int projectCustomGridConfigurationID, int projectCustomGridTypeID, int projectCustomGridColumnID, int? projectCustomAttributeTypeID, int? geospatialAreaTypeID, bool isEnabled, int? sortOrder) : this()
        {
            this.ProjectCustomGridConfigurationID = projectCustomGridConfigurationID;
            this.ProjectCustomGridTypeID = projectCustomGridTypeID;
            this.ProjectCustomGridColumnID = projectCustomGridColumnID;
            this.ProjectCustomAttributeTypeID = projectCustomAttributeTypeID;
            this.GeospatialAreaTypeID = geospatialAreaTypeID;
            this.IsEnabled = isEnabled;
            this.SortOrder = sortOrder;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields in preparation for insert into database
        /// </summary>
        public ProjectCustomGridConfiguration(int projectCustomGridTypeID, int projectCustomGridColumnID, bool isEnabled) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.ProjectCustomGridConfigurationID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            
            this.ProjectCustomGridTypeID = projectCustomGridTypeID;
            this.ProjectCustomGridColumnID = projectCustomGridColumnID;
            this.IsEnabled = isEnabled;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields, using objects whenever possible
        /// </summary>
        public ProjectCustomGridConfiguration(ProjectCustomGridType projectCustomGridType, ProjectCustomGridColumn projectCustomGridColumn, bool isEnabled) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.ProjectCustomGridConfigurationID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            this.ProjectCustomGridTypeID = projectCustomGridType.ProjectCustomGridTypeID;
            this.ProjectCustomGridColumnID = projectCustomGridColumn.ProjectCustomGridColumnID;
            this.IsEnabled = isEnabled;
        }

        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static ProjectCustomGridConfiguration CreateNewBlank(ProjectCustomGridType projectCustomGridType, ProjectCustomGridColumn projectCustomGridColumn)
        {
            return new ProjectCustomGridConfiguration(projectCustomGridType, projectCustomGridColumn, default(bool));
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
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(ProjectCustomGridConfiguration).Name};


        /// <summary>
        /// Delete just the entity 
        /// </summary>
        public void Delete(DatabaseEntities dbContext)
        {
            dbContext.AllProjectCustomGridConfigurations.Remove(this);
        }
        
        /// <summary>
        /// Delete entity plus all children
        /// </summary>
        public void DeleteFull(DatabaseEntities dbContext)
        {
            
            Delete(dbContext);
        }

        [Key]
        public int ProjectCustomGridConfigurationID { get; set; }
        public int TenantID { get; set; }
        public int ProjectCustomGridTypeID { get; set; }
        public int ProjectCustomGridColumnID { get; set; }
        public int? ProjectCustomAttributeTypeID { get; set; }
        public int? GeospatialAreaTypeID { get; set; }
        public bool IsEnabled { get; set; }
        public int? SortOrder { get; set; }
        [NotMapped]
        public int PrimaryKey { get { return ProjectCustomGridConfigurationID; } set { ProjectCustomGridConfigurationID = value; } }

        public Tenant Tenant { get { return Tenant.AllLookupDictionary[TenantID]; } }
        public ProjectCustomGridType ProjectCustomGridType { get { return ProjectCustomGridType.AllLookupDictionary[ProjectCustomGridTypeID]; } }
        public ProjectCustomGridColumn ProjectCustomGridColumn { get { return ProjectCustomGridColumn.AllLookupDictionary[ProjectCustomGridColumnID]; } }
        public virtual ProjectCustomAttributeType ProjectCustomAttributeType { get; set; }
        public virtual GeospatialAreaType GeospatialAreaType { get; set; }

        public static class FieldLengths
        {

        }
    }
}