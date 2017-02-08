//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[Person]
using System.Collections.Generic;
using System.Linq;
using EntityFramework.Extensions;
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

        public static void DeletePerson(this IQueryable<Person> people, List<int> personIDList)
        {
            if(personIDList.Any())
            {
                people.Where(x => personIDList.Contains(x.PersonID)).Delete();
            }
        }

        public static void DeletePerson(this IQueryable<Person> people, ICollection<Person> peopleToDelete)
        {
            if(peopleToDelete.Any())
            {
                var personIDList = peopleToDelete.Select(x => x.PersonID).ToList();
                people.Where(x => personIDList.Contains(x.PersonID)).Delete();
            }
        }

        public static void DeletePerson(this IQueryable<Person> people, int personID)
        {
            DeletePerson(people, new List<int> { personID });
        }

        public static void DeletePerson(this IQueryable<Person> people, Person personToDelete)
        {
            DeletePerson(people, new List<Person> { personToDelete });
        }
    }
}