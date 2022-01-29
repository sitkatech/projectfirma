//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.Solicitation
using CodeFirstStoreFunctions;
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public class SolicitationPrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<Solicitation>
    {
        public SolicitationPrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public SolicitationPrimaryKey(Solicitation solicitation) : base(solicitation){}

        public static implicit operator SolicitationPrimaryKey(int primaryKeyValue)
        {
            return new SolicitationPrimaryKey(primaryKeyValue);
        }

        public static implicit operator SolicitationPrimaryKey(Solicitation solicitation)
        {
            return new SolicitationPrimaryKey(solicitation);
        }
    }
}