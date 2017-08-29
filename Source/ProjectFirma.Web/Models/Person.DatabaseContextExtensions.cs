/*-----------------------------------------------------------------------
<copyright file="Person.DatabaseContextExtensions.cs" company="Tahoe Regional Planning Agency">
Copyright (c) Tahoe Regional Planning Agency. All rights reserved.
<author>Sitka Technology Group</author>
</copyright>

<license>
This program is free software: you can redistribute it and/or modify
it under the terms of the GNU Affero General Public License as published by
the Free Software Foundation, either version 3 of the License, or
(at your option) any later version.

This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU Affero General Public License <http://www.gnu.org/licenses/> for more details.

Source code is available upon request via <support@sitkatech.com>.
</license>
-----------------------------------------------------------------------*/
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

        public static List<Person> GetPeopleWhoReceiveNotifications(this IQueryable<Person> people)
        {
            return people.ToList().Where(x => x.ShouldReceiveNotifications()).OrderBy(ht => ht.FullNameLastFirst).ToList();
        }

        public static List<Person> GetPeopleWhoReceiveSupportEmails(this IQueryable<Person> people)
        {
            return people.ToList().Where(x => x.ReceiveSupportEmails && x.IsActive).OrderBy(ht => ht.FullNameLastFirst).ToList();
        }
    }
}
