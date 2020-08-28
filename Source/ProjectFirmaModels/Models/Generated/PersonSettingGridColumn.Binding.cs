//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[PersonSettingGridColumn]
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.Data.Entity.Spatial;
using System.Linq;
using System.Web;
using CodeFirstStoreFunctions;
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    // Table [dbo].[PersonSettingGridColumn] is multi-tenant, so is attributed as IHaveATenantID
    [Table("[dbo].[PersonSettingGridColumn]")]
    public partial class PersonSettingGridColumn : IHavePrimaryKey, IHaveATenantID
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected PersonSettingGridColumn()
        {
            this.PersonSettingGridColumnSettings = new HashSet<PersonSettingGridColumnSetting>();
        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public PersonSettingGridColumn(int personSettingGridColumnID, int personSettingGridTableID, string columnName, int sortOrder) : this()
        {
            this.PersonSettingGridColumnID = personSettingGridColumnID;
            this.PersonSettingGridTableID = personSettingGridTableID;
            this.ColumnName = columnName;
            this.SortOrder = sortOrder;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields in preparation for insert into database
        /// </summary>
        public PersonSettingGridColumn(int personSettingGridTableID, string columnName, int sortOrder) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.PersonSettingGridColumnID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            
            this.PersonSettingGridTableID = personSettingGridTableID;
            this.ColumnName = columnName;
            this.SortOrder = sortOrder;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields, using objects whenever possible
        /// </summary>
        public PersonSettingGridColumn(PersonSettingGridTable personSettingGridTable, string columnName, int sortOrder) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.PersonSettingGridColumnID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            this.PersonSettingGridTableID = personSettingGridTable.PersonSettingGridTableID;
            this.PersonSettingGridTable = personSettingGridTable;
            personSettingGridTable.PersonSettingGridColumns.Add(this);
            this.ColumnName = columnName;
            this.SortOrder = sortOrder;
        }

        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static PersonSettingGridColumn CreateNewBlank(PersonSettingGridTable personSettingGridTable)
        {
            return new PersonSettingGridColumn(personSettingGridTable, default(string), default(int));
        }

        /// <summary>
        /// Does this object have any dependent objects? (If it does have dependent objects, these would need to be deleted before this object could be deleted.)
        /// </summary>
        /// <returns></returns>
        public bool HasDependentObjects()
        {
            return PersonSettingGridColumnSettings.Any();
        }

        /// <summary>
        /// Active Dependent type names of this object
        /// </summary>
        public List<string> DependentObjectNames() 
        {
            var dependentObjects = new List<string>();
            
            if(PersonSettingGridColumnSettings.Any())
            {
                dependentObjects.Add(typeof(PersonSettingGridColumnSetting).Name);
            }
            return dependentObjects.Distinct().ToList();
        }

        /// <summary>
        /// Dependent type names of this entity
        /// </summary>
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(PersonSettingGridColumn).Name, typeof(PersonSettingGridColumnSetting).Name};


        /// <summary>
        /// Delete just the entity 
        /// </summary>
        public void Delete(DatabaseEntities dbContext)
        {
            dbContext.AllPersonSettingGridColumns.Remove(this);
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

            foreach(var x in PersonSettingGridColumnSettings.ToList())
            {
                x.DeleteFull(dbContext);
            }
        }

        [Key]
        public int PersonSettingGridColumnID { get; set; }
        public int TenantID { get; set; }
        public int PersonSettingGridTableID { get; set; }
        public string ColumnName { get; set; }
        public int SortOrder { get; set; }
        [NotMapped]
        public int PrimaryKey { get { return PersonSettingGridColumnID; } set { PersonSettingGridColumnID = value; } }

        public virtual ICollection<PersonSettingGridColumnSetting> PersonSettingGridColumnSettings { get; set; }
        public Tenant Tenant { get { return Tenant.AllLookupDictionary[TenantID]; } }
        public virtual PersonSettingGridTable PersonSettingGridTable { get; set; }

        public static class FieldLengths
        {
            public const int ColumnName = 256;
        }
    }
}