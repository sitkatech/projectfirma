//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.PersonGridSetting
using CodeFirstStoreFunctions;
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public class PersonGridSettingPrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<PersonGridSetting>
    {
        public PersonGridSettingPrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public PersonGridSettingPrimaryKey(PersonGridSetting personGridSetting) : base(personGridSetting){}

        public static implicit operator PersonGridSettingPrimaryKey(int primaryKeyValue)
        {
            return new PersonGridSettingPrimaryKey(primaryKeyValue);
        }

        public static implicit operator PersonGridSettingPrimaryKey(PersonGridSetting personGridSetting)
        {
            return new PersonGridSettingPrimaryKey(personGridSetting);
        }
    }
}