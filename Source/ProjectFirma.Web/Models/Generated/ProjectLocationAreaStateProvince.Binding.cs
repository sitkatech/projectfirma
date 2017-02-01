//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ProjectLocationAreaStateProvince]
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
    [Table("[dbo].[ProjectLocationAreaStateProvince]")]
    public partial class ProjectLocationAreaStateProvince : IHavePrimaryKey, IHaveATenantID
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected ProjectLocationAreaStateProvince()
        {

        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public ProjectLocationAreaStateProvince(int projectLocationAreaStateProvinceID, int projectLocationAreaID, int stateProvinceID) : this()
        {
            this.ProjectLocationAreaStateProvinceID = projectLocationAreaStateProvinceID;
            this.ProjectLocationAreaID = projectLocationAreaID;
            this.StateProvinceID = stateProvinceID;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields in preparation for insert into database
        /// </summary>
        public ProjectLocationAreaStateProvince(int projectLocationAreaID, int stateProvinceID) : this()
        {
            // Mark this as a new object by setting primary key with special value
            ProjectLocationAreaStateProvinceID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            
            this.ProjectLocationAreaID = projectLocationAreaID;
            this.StateProvinceID = stateProvinceID;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields, using objects whenever possible
        /// </summary>
        public ProjectLocationAreaStateProvince(ProjectLocationArea projectLocationArea, StateProvince stateProvince) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.ProjectLocationAreaStateProvinceID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            this.ProjectLocationAreaID = projectLocationArea.ProjectLocationAreaID;
            this.ProjectLocationArea = projectLocationArea;
            projectLocationArea.ProjectLocationAreaStateProvinces.Add(this);
            this.StateProvinceID = stateProvince.StateProvinceID;
            this.StateProvince = stateProvince;
            stateProvince.ProjectLocationAreaStateProvinces.Add(this);
        }

        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static ProjectLocationAreaStateProvince CreateNewBlank(ProjectLocationArea projectLocationArea, StateProvince stateProvince)
        {
            return new ProjectLocationAreaStateProvince(projectLocationArea, stateProvince);
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
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(ProjectLocationAreaStateProvince).Name};

        [Key]
        public int ProjectLocationAreaStateProvinceID { get; set; }
        public int ProjectLocationAreaID { get; set; }
        public int StateProvinceID { get; set; }
        public int TenantID { get; set; }
        public int PrimaryKey { get { return ProjectLocationAreaStateProvinceID; } set { ProjectLocationAreaStateProvinceID = value; } }

        public virtual ProjectLocationArea ProjectLocationArea { get; set; }
        public virtual StateProvince StateProvince { get; set; }
        public virtual Tenant Tenant { get; set; }

        public static class FieldLengths
        {

        }
    }
}