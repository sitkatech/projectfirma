//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.AccelaJurisdictionToJurisdictionMapping
using ProjectFirma.Web.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirma.Web.Models
{
    public class AccelaJurisdictionToJurisdictionMappingPrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<AccelaJurisdictionToJurisdictionMapping>
    {
        public AccelaJurisdictionToJurisdictionMappingPrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public AccelaJurisdictionToJurisdictionMappingPrimaryKey(AccelaJurisdictionToJurisdictionMapping accelaJurisdictionToJurisdictionMapping) : base(accelaJurisdictionToJurisdictionMapping){}

        public static implicit operator AccelaJurisdictionToJurisdictionMappingPrimaryKey(int primaryKeyValue)
        {
            return new AccelaJurisdictionToJurisdictionMappingPrimaryKey(primaryKeyValue);
        }

        public static implicit operator AccelaJurisdictionToJurisdictionMappingPrimaryKey(AccelaJurisdictionToJurisdictionMapping accelaJurisdictionToJurisdictionMapping)
        {
            return new AccelaJurisdictionToJurisdictionMappingPrimaryKey(accelaJurisdictionToJurisdictionMapping);
        }
    }
}