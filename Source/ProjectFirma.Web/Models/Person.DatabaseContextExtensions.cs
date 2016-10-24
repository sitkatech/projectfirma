using System;
using System.Collections.Generic;
using System.Linq;
using LtInfo.Common.DesignByContract;

namespace ProjectFirma.Web.Models
{
    public static partial class DatabaseContextExtensions
    {
        public static Person GetPersonByEmail(this IQueryable<Person> people, string email)
        {
            return GetPersonByEmail(people, email, true);
        }

        public static Person GetPersonByEmail(this IQueryable<Person> people, string email, bool requireRecordFound)
        {
            var person = people.SingleOrDefault(x => x.Email == email);
            if (requireRecordFound)
            {
                Check.RequireNotNullThrowNotFound(person, email);
            }
            return person;
        }

        public static Person GetPersonByPersonGuid(this IQueryable<Person> people, Guid personGuid)
        {
            return GetPersonByPersonGuid(people, personGuid, false);
        }

        public static Person GetPersonByPersonGuid(this IQueryable<Person> people, Guid personGuid, bool requireRecordFound)
        {
            var person = people.SingleOrDefault(x => x.PersonGuid == personGuid);
            if (requireRecordFound)
            {
                Check.RequireNotNullThrowNotFound(person, personGuid.ToString());
            }
            return person;
        }

        public static Person GetPersonByWebServiceAccessToken(this IQueryable<Person> people, Guid webServiceAccessToken)
        {
            var person = people.SingleOrDefault(x => x.WebServiceAccessToken == webServiceAccessToken);
            return person;
        }

        public static List<Person> GetActivePeople(this IQueryable<Person> people)
        {
            return people.Where(x => x.IsActive).ToList().OrderBy(ht => ht.FullNameLastFirst).ToList();
        }

        public static List<Person> GetPeopleWhoReceiveEIPNotifications(this IQueryable<Person> people)
        {
            return people.ToList().Where(x => x.ShouldReceiveEIPNotifications()).OrderBy(ht => ht.FullNameLastFirst).ToList();
        }

        public static List<Person> GetPeopleWhoReceiveSupportEmails(this IQueryable<Person> people)
        {
            return people.ToList().Where(x => x.ReceiveSupportEmails && x.IsActive).OrderBy(ht => ht.FullNameLastFirst).ToList();
        }
    }
}