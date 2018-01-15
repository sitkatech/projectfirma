//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[Classification]
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
    [Table("[dbo].[Classification]")]
    public partial class Classification : IHavePrimaryKey, IHaveATenantID
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected Classification()
        {
            this.ClassificationPerformanceMeasures = new HashSet<ClassificationPerformanceMeasure>();
            this.ProjectClassifications = new HashSet<ProjectClassification>();
            this.TenantID = HttpRequestStorage.Tenant.TenantID;
        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public Classification(int classificationID, string classificationName, string classificationDescription, string themeColor, string displayName, string goalStatement, int? keyImageFileResourceID) : this()
        {
            this.ClassificationID = classificationID;
            this.ClassificationName = classificationName;
            this.ClassificationDescription = classificationDescription;
            this.ThemeColor = themeColor;
            this.DisplayName = displayName;
            this.GoalStatement = goalStatement;
            this.KeyImageFileResourceID = keyImageFileResourceID;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields in preparation for insert into database
        /// </summary>
        public Classification(string classificationName, string classificationDescription, string themeColor, string displayName) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.ClassificationID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            
            this.ClassificationName = classificationName;
            this.ClassificationDescription = classificationDescription;
            this.ThemeColor = themeColor;
            this.DisplayName = displayName;
        }


        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static Classification CreateNewBlank()
        {
            return new Classification(default(string), default(string), default(string), default(string));
        }

        /// <summary>
        /// Does this object have any dependent objects? (If it does have dependent objects, these would need to be deleted before this object could be deleted.)
        /// </summary>
        /// <returns></returns>
        public bool HasDependentObjects()
        {
            return ClassificationPerformanceMeasures.Any() || ProjectClassifications.Any();
        }

        /// <summary>
        /// Dependent type names of this entity
        /// </summary>
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(Classification).Name, typeof(ClassificationPerformanceMeasure).Name, typeof(ProjectClassification).Name};

        [Key]
        public int ClassificationID { get; set; }
        public int TenantID { get; private set; }
        public string ClassificationName { get; set; }
        public string ClassificationDescription { get; set; }
        public string ThemeColor { get; set; }
        public string DisplayName { get; set; }
        public string GoalStatement { get; set; }
        public int? KeyImageFileResourceID { get; set; }
        [NotMapped]
        public int PrimaryKey { get { return ClassificationID; } set { ClassificationID = value; } }

        public virtual ICollection<ClassificationPerformanceMeasure> ClassificationPerformanceMeasures { get; set; }
        public virtual ICollection<ProjectClassification> ProjectClassifications { get; set; }
        public Tenant Tenant { get { return Tenant.AllLookupDictionary[TenantID]; } }
        public virtual FileResource KeyImageFileResource { get; set; }

        public static class FieldLengths
        {
            public const int ClassificationName = 100;
            public const int ClassificationDescription = 300;
            public const int ThemeColor = 7;
            public const int DisplayName = 50;
            public const int GoalStatement = 200;
        }
    }
}