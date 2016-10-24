//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[PersonArea]
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
        public static PersonArea GetPersonArea(this IQueryable<PersonArea> personAreas, int personAreaID)
        {
            var personArea = personAreas.SingleOrDefault(x => x.PersonAreaID == personAreaID);
            Check.RequireNotNullThrowNotFound(personArea, "PersonArea", personAreaID);
            return personArea;
        }

        public static void DeletePersonArea(this IQueryable<PersonArea> personAreas, List<int> personAreaIDList)
        {
            if(personAreaIDList.Any())
            {
                personAreas.Where(x => personAreaIDList.Contains(x.PersonAreaID)).Delete();
            }
        }

        public static void DeletePersonArea(this IQueryable<PersonArea> personAreas, ICollection<PersonArea> personAreasToDelete)
        {
            if(personAreasToDelete.Any())
            {
                var personAreaIDList = personAreasToDelete.Select(x => x.PersonAreaID).ToList();
                personAreas.Where(x => personAreaIDList.Contains(x.PersonAreaID)).Delete();
            }
        }

        public static void DeletePersonArea(this IQueryable<PersonArea> personAreas, int personAreaID)
        {
            DeletePersonArea(personAreas, new List<int> { personAreaID });
        }

        public static void DeletePersonArea(this IQueryable<PersonArea> personAreas, PersonArea personAreaToDelete)
        {
            DeletePersonArea(personAreas, new List<PersonArea> { personAreaToDelete });
        }
    }
}