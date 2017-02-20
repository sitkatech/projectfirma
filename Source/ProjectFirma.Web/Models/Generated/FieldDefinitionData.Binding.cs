//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[FieldDefinitionData]
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
    [Table("[dbo].[FieldDefinitionData]")]
    public partial class FieldDefinitionData : IHavePrimaryKey, IHaveATenantID
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected FieldDefinitionData()
        {

            this.TenantID = HttpRequestStorage.Tenant.TenantID;
        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public FieldDefinitionData(int fieldDefinitionDataID, int fieldDefinitionID, string fieldDefinitionDataValue) : this()
        {
            this.FieldDefinitionDataID = fieldDefinitionDataID;
            this.FieldDefinitionID = fieldDefinitionID;
            this.FieldDefinitionDataValue = fieldDefinitionDataValue;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields in preparation for insert into database
        /// </summary>
        public FieldDefinitionData(int fieldDefinitionID) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.FieldDefinitionDataID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            
            this.FieldDefinitionID = fieldDefinitionID;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields, using objects whenever possible
        /// </summary>
        public FieldDefinitionData(FieldDefinition fieldDefinition) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.FieldDefinitionDataID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            this.FieldDefinitionID = fieldDefinition.FieldDefinitionID;
        }

        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static FieldDefinitionData CreateNewBlank(FieldDefinition fieldDefinition)
        {
            return new FieldDefinitionData(fieldDefinition);
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
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(FieldDefinitionData).Name};

        [Key]
        public int FieldDefinitionDataID { get; set; }
        public int TenantID { get; private set; }
        public int FieldDefinitionID { get; set; }
        [NotMapped]
        private string FieldDefinitionDataValue { get; set; }
        public HtmlString FieldDefinitionDataValueHtmlString
        { 
            get { return FieldDefinitionDataValue == null ? null : new HtmlString(FieldDefinitionDataValue); }
            set { FieldDefinitionDataValue = value == null ? null : value.ToString(); }
        }
        public int PrimaryKey { get { return FieldDefinitionDataID; } set { FieldDefinitionDataID = value; } }

        public Tenant Tenant { get { return Tenant.AllLookupDictionary[TenantID]; } }
        public FieldDefinition FieldDefinition { get { return FieldDefinition.AllLookupDictionary[FieldDefinitionID]; } }

        public static class FieldLengths
        {

        }
    }
}