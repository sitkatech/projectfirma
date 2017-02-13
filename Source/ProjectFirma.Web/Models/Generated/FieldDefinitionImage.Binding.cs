//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[FieldDefinitionImage]
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
    [Table("[dbo].[FieldDefinitionImage]")]
    public partial class FieldDefinitionImage : IHavePrimaryKey, IHaveATenantID
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected FieldDefinitionImage()
        {

        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public FieldDefinitionImage(int fieldDefinitionImageID, int fieldDefinitionID, int fileResourceID) : this()
        {
            this.TenantID = HttpRequestStorage.Tenant.TenantID;
            
            this.FieldDefinitionImageID = fieldDefinitionImageID;
            this.FieldDefinitionID = fieldDefinitionID;
            this.FileResourceID = fileResourceID;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields in preparation for insert into database
        /// </summary>
        public FieldDefinitionImage(int fieldDefinitionID, int fileResourceID) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.FieldDefinitionImageID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            
            this.TenantID = HttpRequestStorage.Tenant.TenantID;
            this.FieldDefinitionID = fieldDefinitionID;
            this.FileResourceID = fileResourceID;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields, using objects whenever possible
        /// </summary>
        public FieldDefinitionImage(FieldDefinition fieldDefinition, FileResource fileResource) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.FieldDefinitionImageID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            this.TenantID = HttpRequestStorage.Tenant.TenantID;
            this.FieldDefinitionID = fieldDefinition.FieldDefinitionID;
            this.FileResourceID = fileResource.FileResourceID;
            this.FileResource = fileResource;
            fileResource.FieldDefinitionImages.Add(this);
        }

        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static FieldDefinitionImage CreateNewBlank(FieldDefinition fieldDefinition, FileResource fileResource)
        {
            return new FieldDefinitionImage(fieldDefinition, fileResource);
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
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(FieldDefinitionImage).Name};

        [Key]
        public int FieldDefinitionImageID { get; set; }
        public int TenantID { get; private set; }
        public int FieldDefinitionID { get; set; }
        public int FileResourceID { get; set; }
        public int PrimaryKey { get { return FieldDefinitionImageID; } set { FieldDefinitionImageID = value; } }

        public Tenant Tenant { get { return Tenant.AllLookupDictionary[TenantID]; } }
        public FieldDefinition FieldDefinition { get { return FieldDefinition.AllLookupDictionary[FieldDefinitionID]; } }
        public virtual FileResource FileResource { get; set; }

        public static class FieldLengths
        {

        }
    }
}