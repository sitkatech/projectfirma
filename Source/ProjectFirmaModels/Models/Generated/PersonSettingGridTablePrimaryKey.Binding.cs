//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.PersonSettingGridTable
using CodeFirstStoreFunctions;
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public class PersonSettingGridTablePrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<PersonSettingGridTable>
    {
        public PersonSettingGridTablePrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public PersonSettingGridTablePrimaryKey(PersonSettingGridTable personSettingGridTable) : base(personSettingGridTable){}

        public static implicit operator PersonSettingGridTablePrimaryKey(int primaryKeyValue)
        {
            return new PersonSettingGridTablePrimaryKey(primaryKeyValue);
        }

        public static implicit operator PersonSettingGridTablePrimaryKey(PersonSettingGridTable personSettingGridTable)
        {
            return new PersonSettingGridTablePrimaryKey(personSettingGridTable);
        }
    }
}