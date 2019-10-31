/*-----------------------------------------------------------------------
<copyright file="PersonModelExtensions.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
Copyright (c) Tahoe Regional Planning Agency and Sitka Technology Group. All rights reserved.
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
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Models
{
    /// <summary>
    /// These have been implemented as extension methods on <see cref="Person"/> so we can handle the anonymous user as a null person object
    /// </summary>
    public static class FirmaSessionModelExtensions
    {
        /// <summary>
        /// Mimicking the pattern for GetAnonymousPerson, but we'll see if that's the right approach. -- SLG & SG
        /// </summary>
        /// <returns></returns>
        public static FirmaSession GetAnonymousFirmaSession()
        {
            var anonymousFirmaSession = new FirmaSession(Guid.NewGuid(), DateTime.Now);
            return anonymousFirmaSession;
        }

        public static List<FirmaSession> GetFirmaSessionsByPersonID(this IQueryable<FirmaSession> firmaSessions, int personID, bool requireRecordFound)
        {
            var firmaSessionsForPersonID = firmaSessions.Where(x => x.PersonID == personID);
            if (requireRecordFound)
            {
                Check.RequireNotNullThrowNotFound(firmaSessions, personID.ToString());
                Check.Require(firmaSessions.Any(), personID.ToString());
            }
            return firmaSessionsForPersonID.ToList();
        }

        //public static FirmaSession (this IQueryable<FirmaSession> firmaSessions, int personID)
        //{
        //    return GetPersonByPersonGuid(people, personGuid, false);
        //}

        //public static Person GetPersonByPersonGuid(this IQueryable<Person> people, Guid personGuid, bool requireRecordFound)
        //{
        //    var person = people.SingleOrDefault(x => x.PersonGuid == personGuid);
        //    if (requireRecordFound)
        //    {
        //        Check.RequireNotNullThrowNotFound(person, personGuid.ToString());
        //    }
        //    return person;
        //}

    }
}
