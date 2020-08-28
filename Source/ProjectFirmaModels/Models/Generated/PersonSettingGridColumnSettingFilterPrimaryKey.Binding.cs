//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.PersonSettingGridColumnSettingFilter
using CodeFirstStoreFunctions;
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public class PersonSettingGridColumnSettingFilterPrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<PersonSettingGridColumnSettingFilter>
    {
        public PersonSettingGridColumnSettingFilterPrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public PersonSettingGridColumnSettingFilterPrimaryKey(PersonSettingGridColumnSettingFilter personSettingGridColumnSettingFilter) : base(personSettingGridColumnSettingFilter){}

        public static implicit operator PersonSettingGridColumnSettingFilterPrimaryKey(int primaryKeyValue)
        {
            return new PersonSettingGridColumnSettingFilterPrimaryKey(primaryKeyValue);
        }

        public static implicit operator PersonSettingGridColumnSettingFilterPrimaryKey(PersonSettingGridColumnSettingFilter personSettingGridColumnSettingFilter)
        {
            return new PersonSettingGridColumnSettingFilterPrimaryKey(personSettingGridColumnSettingFilter);
        }
    }
}