//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.PersonStewardGeospatialArea
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Models
{
    public class PersonStewardGeospatialAreaPrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<PersonStewardGeospatialArea>
    {
        public PersonStewardGeospatialAreaPrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public PersonStewardGeospatialAreaPrimaryKey(PersonStewardGeospatialArea personStewardGeospatialArea) : base(personStewardGeospatialArea){}

        public static implicit operator PersonStewardGeospatialAreaPrimaryKey(int primaryKeyValue)
        {
            return new PersonStewardGeospatialAreaPrimaryKey(primaryKeyValue);
        }

        public static implicit operator PersonStewardGeospatialAreaPrimaryKey(PersonStewardGeospatialArea personStewardGeospatialArea)
        {
            return new PersonStewardGeospatialAreaPrimaryKey(personStewardGeospatialArea);
        }
    }
}