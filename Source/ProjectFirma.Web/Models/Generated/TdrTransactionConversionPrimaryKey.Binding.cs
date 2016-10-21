//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.TdrTransactionConversion
using ProjectFirma.Web.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirma.Web.Models
{
    public class TdrTransactionConversionPrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<TdrTransactionConversion>
    {
        public TdrTransactionConversionPrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public TdrTransactionConversionPrimaryKey(TdrTransactionConversion tdrTransactionConversion) : base(tdrTransactionConversion){}

        public static implicit operator TdrTransactionConversionPrimaryKey(int primaryKeyValue)
        {
            return new TdrTransactionConversionPrimaryKey(primaryKeyValue);
        }

        public static implicit operator TdrTransactionConversionPrimaryKey(TdrTransactionConversion tdrTransactionConversion)
        {
            return new TdrTransactionConversionPrimaryKey(tdrTransactionConversion);
        }
    }
}