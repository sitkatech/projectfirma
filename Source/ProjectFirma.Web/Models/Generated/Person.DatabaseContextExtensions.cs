//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[Person]
using System.Collections.Generic;
using System.Linq;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Models
{
    public static partial class DatabaseContextExtensions
    {
        public static Person GetPerson(this IQueryable<Person> people, int personID)
        {
            var person = people.SingleOrDefault(x => x.PersonID == personID);
            Check.RequireNotNullThrowNotFound(person, "Person", personID);
            return person;
        }

        public static void DeletePerson(this List<int> personIDList)
        {
            if(personIDList.Any())
            {
                HttpRequestStorage.DatabaseEntities.AllPeople.RemoveRange(HttpRequestStorage.DatabaseEntities.People.Where(x => personIDList.Contains(x.PersonID)));
            }
        }

        public static void DeletePerson(this ICollection<Person> peopleToDelete)
        {
            if(peopleToDelete.Any())
            {
                HttpRequestStorage.DatabaseEntities.AllPeople.RemoveRange(peopleToDelete);
            }
        }

        public static void DeletePerson(this int personID)
        {
            DeletePerson(new List<int> { personID });
        }

        public static void DeletePerson(this Person personToDelete)
        {
            DeletePerson(new List<Person> { personToDelete });
        }
    }
}