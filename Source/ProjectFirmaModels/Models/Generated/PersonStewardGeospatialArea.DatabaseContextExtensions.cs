//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[PersonStewardGeospatialArea]
using System.Collections.Generic;
using System.Linq;
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public static partial class DatabaseContextExtensions
    {
        public static PersonStewardGeospatialArea GetPersonStewardGeospatialArea(this IQueryable<PersonStewardGeospatialArea> personStewardGeospatialAreas, int personStewardGeospatialAreaID)
        {
            var personStewardGeospatialArea = personStewardGeospatialAreas.SingleOrDefault(x => x.PersonStewardGeospatialAreaID == personStewardGeospatialAreaID);
            Check.RequireNotNullThrowNotFound(personStewardGeospatialArea, "PersonStewardGeospatialArea", personStewardGeospatialAreaID);
            return personStewardGeospatialArea;
        }

    }
}