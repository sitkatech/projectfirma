//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[FieldDefinitionDefault]
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
    // Table [dbo].[FieldDefinitionDefault] is NOT multi-tenant, so is attributed as ICanDeleteFull
    [Table("[dbo].[FieldDefinitionDefault]")]
    public partial class FieldDefinitionDefault : IHavePrimaryKey, ICanDeleteFull
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected FieldDefinitionDefault()
        {

        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public FieldDefinitionDefault(int fieldDefinitionDefaultID, int fieldDefinitionID, string defaultDefinition) : this()
        {
            this.FieldDefinitionDefaultID = fieldDefinitionDefaultID;
            this.FieldDefinitionID = fieldDefinitionID;
            this.DefaultDefinition = defaultDefinition;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields in preparation for insert into database
        /// </summary>
        public FieldDefinitionDefault(int fieldDefinitionID, string defaultDefinition) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.FieldDefinitionDefaultID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            
            this.FieldDefinitionID = fieldDefinitionID;
            this.DefaultDefinition = defaultDefinition;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields, using objects whenever possible
        /// </summary>
        public FieldDefinitionDefault(FieldDefinition fieldDefinition, string defaultDefinition) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.FieldDefinitionDefaultID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            this.FieldDefinitionID = fieldDefinition.FieldDefinitionID;
            this.FieldDefinition = fieldDefinition;
            this.DefaultDefinition = defaultDefinition;
        }

        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static FieldDefinitionDefault CreateNewBlank(FieldDefinition fieldDefinition)
        {
            return new FieldDefinitionDefault(fieldDefinition, default(string));
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
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(FieldDefinitionDefault).Name};


        /// <summary>
        /// Delete just the entity 
        /// </summary>
        public void Delete(DatabaseEntities dbContext)
        {
            dbContext.FieldDefinitionDefaults.Remove(this);
        }
        
        /// <summary>
        /// Delete entity plus all children
        /// </summary>
        public void DeleteFull(DatabaseEntities dbContext)
        {
            
            Delete(dbContext);
        }

        [Key]
        public int FieldDefinitionDefaultID { get; set; }
        public int FieldDefinitionID { get; set; }
        public string DefaultDefinition { get; set; }
        [NotMapped]
        public HtmlString DefaultDefinitionHtmlString
        { 
            get { return DefaultDefinition == null ? null : new HtmlString(DefaultDefinition); }
            set { DefaultDefinition = value?.ToString(); }
        }
        [NotMapped]
        public int PrimaryKey { get { return FieldDefinitionDefaultID; } set { FieldDefinitionDefaultID = value; } }

        public virtual FieldDefinition FieldDefinition { get; set; }

        public static class FieldLengths
        {

        }
    }
}