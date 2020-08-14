//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[PersonSettingGridColumnSetting]
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
    // Table [dbo].[PersonSettingGridColumnSetting] is NOT multi-tenant, so is attributed as ICanDeleteFull
    [Table("[dbo].[PersonSettingGridColumnSetting]")]
    public partial class PersonSettingGridColumnSetting : IHavePrimaryKey, ICanDeleteFull
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected PersonSettingGridColumnSetting()
        {

        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public PersonSettingGridColumnSetting(int personSettingGridColumnSettingID, int personID, int personSettingGridColumnID, string filterText) : this()
        {
            this.PersonSettingGridColumnSettingID = personSettingGridColumnSettingID;
            this.PersonID = personID;
            this.PersonSettingGridColumnID = personSettingGridColumnID;
            this.FilterText = filterText;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields in preparation for insert into database
        /// </summary>
        public PersonSettingGridColumnSetting(int personID, int personSettingGridColumnID, string filterText) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.PersonSettingGridColumnSettingID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            
            this.PersonID = personID;
            this.PersonSettingGridColumnID = personSettingGridColumnID;
            this.FilterText = filterText;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields, using objects whenever possible
        /// </summary>
        public PersonSettingGridColumnSetting(Person person, PersonSettingGridColumn personSettingGridColumn, string filterText) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.PersonSettingGridColumnSettingID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            this.PersonID = person.PersonID;
            this.Person = person;
            person.PersonSettingGridColumnSettings.Add(this);
            this.PersonSettingGridColumnID = personSettingGridColumn.PersonSettingGridColumnID;
            this.PersonSettingGridColumn = personSettingGridColumn;
            personSettingGridColumn.PersonSettingGridColumnSettings.Add(this);
            this.FilterText = filterText;
        }

        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static PersonSettingGridColumnSetting CreateNewBlank(Person person, PersonSettingGridColumn personSettingGridColumn)
        {
            return new PersonSettingGridColumnSetting(person, personSettingGridColumn, default(string));
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
        /// Active Dependent type names of this object
        /// </summary>
        public List<string> DependentObjectNames() 
        {
            var dependentObjects = new List<string>();
            
            return dependentObjects.Distinct().ToList();
        }

        /// <summary>
        /// Dependent type names of this entity
        /// </summary>
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(PersonSettingGridColumnSetting).Name};


        /// <summary>
        /// Delete just the entity 
        /// </summary>
        public void Delete(DatabaseEntities dbContext)
        {
            dbContext.PersonSettingGridColumnSettings.Remove(this);
        }
        
        /// <summary>
        /// Delete entity plus all children
        /// </summary>
        public void DeleteFull(DatabaseEntities dbContext)
        {
            
            Delete(dbContext);
        }

        [Key]
        public int PersonSettingGridColumnSettingID { get; set; }
        public int PersonID { get; set; }
        public int PersonSettingGridColumnID { get; set; }
        public string FilterText { get; set; }
        [NotMapped]
        public int PrimaryKey { get { return PersonSettingGridColumnSettingID; } set { PersonSettingGridColumnSettingID = value; } }

        public virtual Person Person { get; set; }
        public virtual PersonSettingGridColumn PersonSettingGridColumn { get; set; }

        public static class FieldLengths
        {
            public const int FilterText = 256;
        }
    }
}