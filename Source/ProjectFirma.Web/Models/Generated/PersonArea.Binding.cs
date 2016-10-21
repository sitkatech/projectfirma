//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[PersonArea]
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.Data.Entity.Spatial;
using System.Linq;
using System.Web;
using ProjectFirma.Web.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirma.Web.Models
{
    [Table("[dbo].[PersonArea]")]
    public partial class PersonArea : IHavePrimaryKey
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected PersonArea()
        {

        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public PersonArea(int personAreaID, int personID, int lTInfoAreaID, bool receiveSupportEmails) : this()
        {
            this.PersonAreaID = personAreaID;
            this.PersonID = personID;
            this.LTInfoAreaID = lTInfoAreaID;
            this.ReceiveSupportEmails = receiveSupportEmails;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields in preparation for insert into database
        /// </summary>
        public PersonArea(int personID, int lTInfoAreaID, bool receiveSupportEmails) : this()
        {
            // Mark this as a new object by setting primary key with special value
            PersonAreaID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            
            this.PersonID = personID;
            this.LTInfoAreaID = lTInfoAreaID;
            this.ReceiveSupportEmails = receiveSupportEmails;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields, using objects whenever possible
        /// </summary>
        public PersonArea(Person person, LTInfoArea lTInfoArea, bool receiveSupportEmails) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.PersonAreaID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            this.PersonID = person.PersonID;
            this.Person = person;
            person.PersonAreas.Add(this);
            this.LTInfoAreaID = lTInfoArea.LTInfoAreaID;
            this.ReceiveSupportEmails = receiveSupportEmails;
        }

        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static PersonArea CreateNewBlank(Person person, LTInfoArea lTInfoArea)
        {
            return new PersonArea(person, lTInfoArea, default(bool));
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
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(PersonArea).Name};

        [Key]
        public int PersonAreaID { get; set; }
        public int PersonID { get; set; }
        public int LTInfoAreaID { get; set; }
        public bool ReceiveSupportEmails { get; set; }
        public int PrimaryKey { get { return PersonAreaID; } set { PersonAreaID = value; } }

        public virtual Person Person { get; set; }
        public LTInfoArea LTInfoArea { get { return LTInfoArea.AllLookupDictionary[LTInfoAreaID]; } }

        public static class FieldLengths
        {

        }
    }
}