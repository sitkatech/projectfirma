//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ProjectUpdateCustomAttribute]
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
    [Table("[dbo].[ProjectUpdateCustomAttribute]")]
    public partial class ProjectUpdateCustomAttribute : IHavePrimaryKey, IHaveATenantID
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected ProjectUpdateCustomAttribute()
        {
            this.ProjectUpdateCustomAttributeValues = new HashSet<ProjectUpdateCustomAttributeValue>();
            this.TenantID = HttpRequestStorage.Tenant.TenantID;
        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public ProjectUpdateCustomAttribute(int projectUpdateCustomAttributeID, int projectUpdateID, int projectCustomAttributeTypeID) : this()
        {
            this.ProjectUpdateCustomAttributeID = projectUpdateCustomAttributeID;
            this.ProjectUpdateID = projectUpdateID;
            this.ProjectCustomAttributeTypeID = projectCustomAttributeTypeID;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields in preparation for insert into database
        /// </summary>
        public ProjectUpdateCustomAttribute(int projectUpdateID, int projectCustomAttributeTypeID) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.ProjectUpdateCustomAttributeID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            
            this.ProjectUpdateID = projectUpdateID;
            this.ProjectCustomAttributeTypeID = projectCustomAttributeTypeID;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields, using objects whenever possible
        /// </summary>
        public ProjectUpdateCustomAttribute(ProjectUpdate projectUpdate, ProjectCustomAttributeType projectCustomAttributeType) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.ProjectUpdateCustomAttributeID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            this.ProjectUpdateID = projectUpdate.ProjectUpdateID;
            this.ProjectUpdate = projectUpdate;
            projectUpdate.ProjectUpdateCustomAttributes.Add(this);
            this.ProjectCustomAttributeTypeID = projectCustomAttributeType.ProjectCustomAttributeTypeID;
            this.ProjectCustomAttributeType = projectCustomAttributeType;
            projectCustomAttributeType.ProjectUpdateCustomAttributes.Add(this);
        }

        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static ProjectUpdateCustomAttribute CreateNewBlank(ProjectUpdate projectUpdate, ProjectCustomAttributeType projectCustomAttributeType)
        {
            return new ProjectUpdateCustomAttribute(projectUpdate, projectCustomAttributeType);
        }

        /// <summary>
        /// Does this object have any dependent objects? (If it does have dependent objects, these would need to be deleted before this object could be deleted.)
        /// </summary>
        /// <returns></returns>
        public bool HasDependentObjects()
        {
            return ProjectUpdateCustomAttributeValues.Any();
        }

        /// <summary>
        /// Dependent type names of this entity
        /// </summary>
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(ProjectUpdateCustomAttribute).Name, typeof(ProjectUpdateCustomAttributeValue).Name};


        /// <summary>
        /// Dependent type names of this entity
        /// </summary>
        public void DeleteFull()
        {

            foreach(var x in ProjectUpdateCustomAttributeValues.ToList())
            {
                x.DeleteFull();
            }
            HttpRequestStorage.DatabaseEntities.AllProjectUpdateCustomAttributes.Remove(this);                
        }

        [Key]
        public int ProjectUpdateCustomAttributeID { get; set; }
        public int TenantID { get; private set; }
        public int ProjectUpdateID { get; set; }
        public int ProjectCustomAttributeTypeID { get; set; }
        [NotMapped]
        public int PrimaryKey { get { return ProjectUpdateCustomAttributeID; } set { ProjectUpdateCustomAttributeID = value; } }

        public virtual ICollection<ProjectUpdateCustomAttributeValue> ProjectUpdateCustomAttributeValues { get; set; }
        public Tenant Tenant { get { return Tenant.AllLookupDictionary[TenantID]; } }
        public virtual ProjectUpdate ProjectUpdate { get; set; }
        public virtual ProjectCustomAttributeType ProjectCustomAttributeType { get; set; }

        public static class FieldLengths
        {

        }
    }
}