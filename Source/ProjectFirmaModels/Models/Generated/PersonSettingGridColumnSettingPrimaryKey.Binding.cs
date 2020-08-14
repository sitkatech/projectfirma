//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.PersonSettingGridColumnSetting
using CodeFirstStoreFunctions;
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public class PersonSettingGridColumnSettingPrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<PersonSettingGridColumnSetting>
    {
        public PersonSettingGridColumnSettingPrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public PersonSettingGridColumnSettingPrimaryKey(PersonSettingGridColumnSetting personSettingGridColumnSetting) : base(personSettingGridColumnSetting){}

        public static implicit operator PersonSettingGridColumnSettingPrimaryKey(int primaryKeyValue)
        {
            return new PersonSettingGridColumnSettingPrimaryKey(primaryKeyValue);
        }

        public static implicit operator PersonSettingGridColumnSettingPrimaryKey(PersonSettingGridColumnSetting personSettingGridColumnSetting)
        {
            return new PersonSettingGridColumnSettingPrimaryKey(personSettingGridColumnSetting);
        }
    }
}