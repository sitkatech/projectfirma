//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[PersonStewardWatershed]
using System.Collections.Generic;
using System.Linq;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Models
{
    public static partial class DatabaseContextExtensions
    {
        public static PersonStewardWatershed GetPersonStewardWatershed(this IQueryable<PersonStewardWatershed> personStewardWatersheds, int personStewardWatershedID)
        {
            var personStewardWatershed = personStewardWatersheds.SingleOrDefault(x => x.PersonStewardWatershedID == personStewardWatershedID);
            Check.RequireNotNullThrowNotFound(personStewardWatershed, "PersonStewardWatershed", personStewardWatershedID);
            return personStewardWatershed;
        }

        public static void DeletePersonStewardWatershed(this List<int> personStewardWatershedIDList)
        {
            if(personStewardWatershedIDList.Any())
            {
                HttpRequestStorage.DatabaseEntities.AllPersonStewardWatersheds.RemoveRange(HttpRequestStorage.DatabaseEntities.PersonStewardWatersheds.Where(x => personStewardWatershedIDList.Contains(x.PersonStewardWatershedID)));
            }
        }

        public static void DeletePersonStewardWatershed(this ICollection<PersonStewardWatershed> personStewardWatershedsToDelete)
        {
            if(personStewardWatershedsToDelete.Any())
            {
                HttpRequestStorage.DatabaseEntities.AllPersonStewardWatersheds.RemoveRange(personStewardWatershedsToDelete);
            }
        }

        public static void DeletePersonStewardWatershed(this int personStewardWatershedID)
        {
            DeletePersonStewardWatershed(new List<int> { personStewardWatershedID });
        }

        public static void DeletePersonStewardWatershed(this PersonStewardWatershed personStewardWatershedToDelete)
        {
            DeletePersonStewardWatershed(new List<PersonStewardWatershed> { personStewardWatershedToDelete });
        }
    }
}