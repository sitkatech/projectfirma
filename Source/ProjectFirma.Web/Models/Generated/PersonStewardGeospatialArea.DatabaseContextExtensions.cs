//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[PersonStewardGeospatialArea]
using System.Collections.Generic;
using System.Linq;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Models
{
    public static partial class DatabaseContextExtensions
    {
        public static PersonStewardGeospatialArea GetPersonStewardGeospatialArea(this IQueryable<PersonStewardGeospatialArea> personStewardGeospatialAreas, int personStewardGeospatialAreaID)
        {
            var personStewardGeospatialArea = personStewardGeospatialAreas.SingleOrDefault(x => x.PersonStewardGeospatialAreaID == personStewardGeospatialAreaID);
            Check.RequireNotNullThrowNotFound(personStewardGeospatialArea, "PersonStewardGeospatialArea", personStewardGeospatialAreaID);
            return personStewardGeospatialArea;
        }

        public static void DeletePersonStewardGeospatialArea(this List<int> personStewardGeospatialAreaIDList)
        {
            if(personStewardGeospatialAreaIDList.Any())
            {
                HttpRequestStorage.DatabaseEntities.AllPersonStewardGeospatialAreas.RemoveRange(HttpRequestStorage.DatabaseEntities.PersonStewardGeospatialAreas.Where(x => personStewardGeospatialAreaIDList.Contains(x.PersonStewardGeospatialAreaID)));
            }
        }

        public static void DeletePersonStewardGeospatialArea(this ICollection<PersonStewardGeospatialArea> personStewardGeospatialAreasToDelete)
        {
            if(personStewardGeospatialAreasToDelete.Any())
            {
                HttpRequestStorage.DatabaseEntities.AllPersonStewardGeospatialAreas.RemoveRange(personStewardGeospatialAreasToDelete);
            }
        }

        public static void DeletePersonStewardGeospatialArea(this int personStewardGeospatialAreaID)
        {
            DeletePersonStewardGeospatialArea(new List<int> { personStewardGeospatialAreaID });
        }

        public static void DeletePersonStewardGeospatialArea(this PersonStewardGeospatialArea personStewardGeospatialAreaToDelete)
        {
            DeletePersonStewardGeospatialArea(new List<PersonStewardGeospatialArea> { personStewardGeospatialAreaToDelete });
        }
    }
}