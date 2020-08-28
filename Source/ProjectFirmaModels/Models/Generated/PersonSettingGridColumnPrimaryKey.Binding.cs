//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.PersonSettingGridColumn
using CodeFirstStoreFunctions;
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public class PersonSettingGridColumnPrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<PersonSettingGridColumn>
    {
        public PersonSettingGridColumnPrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public PersonSettingGridColumnPrimaryKey(PersonSettingGridColumn personSettingGridColumn) : base(personSettingGridColumn){}

        public static implicit operator PersonSettingGridColumnPrimaryKey(int primaryKeyValue)
        {
            return new PersonSettingGridColumnPrimaryKey(primaryKeyValue);
        }

        public static implicit operator PersonSettingGridColumnPrimaryKey(PersonSettingGridColumn personSettingGridColumn)
        {
            return new PersonSettingGridColumnPrimaryKey(personSettingGridColumn);
        }
    }
}