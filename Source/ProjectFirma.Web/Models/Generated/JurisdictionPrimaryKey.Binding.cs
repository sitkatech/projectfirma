//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.Jurisdiction
using ProjectFirma.Web.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirma.Web.Models
{
    public class JurisdictionPrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<Jurisdiction>
    {
        public JurisdictionPrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public JurisdictionPrimaryKey(Jurisdiction jurisdiction) : base(jurisdiction){}

        public static implicit operator JurisdictionPrimaryKey(int primaryKeyValue)
        {
            return new JurisdictionPrimaryKey(primaryKeyValue);
        }

        public static implicit operator JurisdictionPrimaryKey(Jurisdiction jurisdiction)
        {
            return new JurisdictionPrimaryKey(jurisdiction);
        }
    }
}