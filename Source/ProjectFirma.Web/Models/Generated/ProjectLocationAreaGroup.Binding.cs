//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ProjectLocationAreaGroup]
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
    [Table("[dbo].[ProjectLocationAreaGroup]")]
    public partial class ProjectLocationAreaGroup : IHavePrimaryKey
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected ProjectLocationAreaGroup()
        {
            this.ProjectLocationAreas = new HashSet<ProjectLocationArea>();
        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public ProjectLocationAreaGroup(int projectLocationAreaGroupID, int projectLocationAreaGroupTypeID) : this()
        {
            this.ProjectLocationAreaGroupID = projectLocationAreaGroupID;
            this.ProjectLocationAreaGroupTypeID = projectLocationAreaGroupTypeID;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields in preparation for insert into database
        /// </summary>
        public ProjectLocationAreaGroup(int projectLocationAreaGroupTypeID) : this()
        {
            // Mark this as a new object by setting primary key with special value
            ProjectLocationAreaGroupID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            
            this.ProjectLocationAreaGroupTypeID = projectLocationAreaGroupTypeID;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields, using objects whenever possible
        /// </summary>
        public ProjectLocationAreaGroup(ProjectLocationAreaGroupType projectLocationAreaGroupType) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.ProjectLocationAreaGroupID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            this.ProjectLocationAreaGroupTypeID = projectLocationAreaGroupType.ProjectLocationAreaGroupTypeID;
        }

        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static ProjectLocationAreaGroup CreateNewBlank(ProjectLocationAreaGroupType projectLocationAreaGroupType)
        {
            return new ProjectLocationAreaGroup(projectLocationAreaGroupType);
        }

        /// <summary>
        /// Does this object have any dependent objects? (If it does have dependent objects, these would need to be deleted before this object could be deleted.)
        /// </summary>
        /// <returns></returns>
        public bool HasDependentObjects()
        {
            return ProjectLocationAreas.Any();
        }

        /// <summary>
        /// Dependent type names of this entity
        /// </summary>
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(ProjectLocationAreaGroup).Name, typeof(ProjectLocationArea).Name};

        [Key]
        public int ProjectLocationAreaGroupID { get; set; }
        public int ProjectLocationAreaGroupTypeID { get; set; }
        public int PrimaryKey { get { return ProjectLocationAreaGroupID; } set { ProjectLocationAreaGroupID = value; } }

        public virtual ICollection<ProjectLocationArea> ProjectLocationAreas { get; set; }
        public ProjectLocationAreaGroupType ProjectLocationAreaGroupType { get { return ProjectLocationAreaGroupType.AllLookupDictionary[ProjectLocationAreaGroupTypeID]; } }

        public static class FieldLengths
        {

        }
    }
}