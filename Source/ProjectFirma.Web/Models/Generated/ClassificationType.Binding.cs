//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ClassificationType]
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
    [Table("[dbo].[ClassificationType]")]
    public partial class ClassificationType : IHavePrimaryKey, IHaveATenantID
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected ClassificationType()
        {
            this.Classifications = new HashSet<Classification>();
            this.TenantID = HttpRequestStorage.Tenant.TenantID;
        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public ClassificationType(int classificationTypeID, string classificationTypeName, string classificationTypeDescription) : this()
        {
            this.ClassificationTypeID = classificationTypeID;
            this.ClassificationTypeName = classificationTypeName;
            this.ClassificationTypeDescription = classificationTypeDescription;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields in preparation for insert into database
        /// </summary>
        public ClassificationType(string classificationTypeName, string classificationTypeDescription) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.ClassificationTypeID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            
            this.ClassificationTypeName = classificationTypeName;
            this.ClassificationTypeDescription = classificationTypeDescription;
        }


        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static ClassificationType CreateNewBlank()
        {
            return new ClassificationType(default(string), default(string));
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
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(ClassificationType).Name, typeof(Classification).Name};

        [Key]
        public int ClassificationTypeID { get; set; }
        public int TenantID { get; private set; }
        public string ClassificationTypeName { get; set; }
        public string ClassificationTypeDescription { get; set; }
        [NotMapped]
        public int PrimaryKey { get { return ClassificationTypeID; } set { ClassificationTypeID = value; } }

        public virtual ICollection<Classification> Classifications { get; set; }
        public Tenant Tenant { get { return Tenant.AllLookupDictionary[TenantID]; } }

        public static class FieldLengths
        {
            public const int ClassificationTypeName = 200;
        }
    }
}