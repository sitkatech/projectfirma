using System.Collections.Generic;
using System.Linq;
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public static partial class DatabaseContextExtensions
    {
        public static Person GetPerson(this IQueryable<Person> people, int personID, bool throwIfNotFound)
        {
            var person = people.SingleOrDefault(x => x.PersonID == personID);
            if (throwIfNotFound)
            {
                Check.RequireNotNullThrowNotFound(person, "Person", personID);
            }
            return person;
        }
    }
}