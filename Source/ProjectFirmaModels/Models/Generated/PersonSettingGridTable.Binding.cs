//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[PersonSettingGridTable]
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
    // Table [dbo].[PersonSettingGridTable] is NOT multi-tenant, so is attributed as ICanDeleteFull
    [Table("[dbo].[PersonSettingGridTable]")]
    public partial class PersonSettingGridTable : IHavePrimaryKey, ICanDeleteFull
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected PersonSettingGridTable()
        {
            this.PersonSettingGridColumns = new HashSet<PersonSettingGridColumn>();
        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public PersonSettingGridTable(int personSettingGridTableID, string gridName) : this()
        {
            this.PersonSettingGridTableID = personSettingGridTableID;
            this.GridName = gridName;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields in preparation for insert into database
        /// </summary>
        public PersonSettingGridTable(string gridName) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.PersonSettingGridTableID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            
            this.GridName = gridName;
        }


        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static PersonSettingGridTable CreateNewBlank()
        {
            return new PersonSettingGridTable(default(string));
        }

        /// <summary>
        /// Does this object have any dependent objects? (If it does have dependent objects, these would need to be deleted before this object could be deleted.)
        /// </summary>
        /// <returns></returns>
        public bool HasDependentObjects()
        {
            return PersonSettingGridColumns.Any();
        }

        /// <summary>
        /// Active Dependent type names of this object
        /// </summary>
        public List<string> DependentObjectNames() 
        {
            var dependentObjects = new List<string>();
            
            if(PersonSettingGridColumns.Any())
            {
                dependentObjects.Add(typeof(PersonSettingGridColumn).Name);
            }
            return dependentObjects.Distinct().ToList();
        }

        /// <summary>
        /// Dependent type names of this entity
        /// </summary>
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(PersonSettingGridTable).Name, typeof(PersonSettingGridColumn).Name};


        /// <summary>
        /// Delete just the entity 
        /// </summary>
        public void Delete(DatabaseEntities dbContext)
        {
            dbContext.PersonSettingGridTables.Remove(this);
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

            foreach(var x in PersonSettingGridColumns.ToList())
            {
                x.DeleteFull(dbContext);
            }
        }

        [Key]
        public int PersonSettingGridTableID { get; set; }
        public string GridName { get; set; }
        [NotMapped]
        public int PrimaryKey { get { return PersonSettingGridTableID; } set { PersonSettingGridTableID = value; } }

        public virtual ICollection<PersonSettingGridColumn> PersonSettingGridColumns { get; set; }

        public static class FieldLengths
        {
            public const int GridName = 256;
        }
    }
}