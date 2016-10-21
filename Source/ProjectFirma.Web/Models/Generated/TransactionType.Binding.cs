//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[TransactionType]
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using ProjectFirma.Web.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirma.Web.Models
{
    public abstract partial class TransactionType : IHavePrimaryKey
    {
        public static readonly TransactionTypeAllocation Allocation = TransactionTypeAllocation.Instance;
        public static readonly TransactionTypeConversion Conversion = TransactionTypeConversion.Instance;
        public static readonly TransactionTypeECMRetirement ECMRetirement = TransactionTypeECMRetirement.Instance;
        public static readonly TransactionTypeLandBankAcquisition LandBankAcquisition = TransactionTypeLandBankAcquisition.Instance;
        public static readonly TransactionTypeTransfer Transfer = TransactionTypeTransfer.Instance;
        public static readonly TransactionTypeTransferWithBonusUnit TransferWithBonusUnit = TransactionTypeTransferWithBonusUnit.Instance;
        public static readonly TransactionTypeAllocationAssignment AllocationAssignment = TransactionTypeAllocationAssignment.Instance;
        public static readonly TransactionTypeConversionWithTransfer ConversionWithTransfer = TransactionTypeConversionWithTransfer.Instance;

        public static readonly List<TransactionType> All;
        public static readonly ReadOnlyDictionary<int, TransactionType> AllLookupDictionary;

        /// <summary>
        /// Static type constructor to coordinate static initialization order
        /// </summary>
        static TransactionType()
        {
            All = new List<TransactionType> { Allocation, Conversion, ECMRetirement, LandBankAcquisition, Transfer, TransferWithBonusUnit, AllocationAssignment, ConversionWithTransfer };
            AllLookupDictionary = new ReadOnlyDictionary<int, TransactionType>(All.ToDictionary(x => x.TransactionTypeID));
        }

        /// <summary>
        /// Protected constructor only for use in instantiating the set of static lookup values that match database
        /// </summary>
        protected TransactionType(int transactionTypeID, string transactionTypeName, string transactionTypeDisplayName, string transactionTypeAbbreviation)
        {
            TransactionTypeID = transactionTypeID;
            TransactionTypeName = transactionTypeName;
            TransactionTypeDisplayName = transactionTypeDisplayName;
            TransactionTypeAbbreviation = transactionTypeAbbreviation;
        }

        [Key]
        public int TransactionTypeID { get; private set; }
        public string TransactionTypeName { get; private set; }
        public string TransactionTypeDisplayName { get; private set; }
        public string TransactionTypeAbbreviation { get; private set; }
        public int PrimaryKey { get { return TransactionTypeID; } }

        /// <summary>
        /// Enum types are equal by primary key
        /// </summary>
        public bool Equals(TransactionType other)
        {
            if (other == null)
            {
                return false;
            }
            return other.TransactionTypeID == TransactionTypeID;
        }

        /// <summary>
        /// Enum types are equal by primary key
        /// </summary>
        public override bool Equals(object obj)
        {
            return Equals(obj as TransactionType);
        }

        /// <summary>
        /// Enum types are equal by primary key
        /// </summary>
        public override int GetHashCode()
        {
            return TransactionTypeID;
        }

        public static bool operator ==(TransactionType left, TransactionType right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(TransactionType left, TransactionType right)
        {
            return !Equals(left, right);
        }

        public TransactionTypeEnum ToEnum { get { return (TransactionTypeEnum)GetHashCode(); } }

        public static TransactionType ToType(int enumValue)
        {
            return ToType((TransactionTypeEnum)enumValue);
        }

        public static TransactionType ToType(TransactionTypeEnum enumValue)
        {
            switch (enumValue)
            {
                case TransactionTypeEnum.Allocation:
                    return Allocation;
                case TransactionTypeEnum.AllocationAssignment:
                    return AllocationAssignment;
                case TransactionTypeEnum.Conversion:
                    return Conversion;
                case TransactionTypeEnum.ConversionWithTransfer:
                    return ConversionWithTransfer;
                case TransactionTypeEnum.ECMRetirement:
                    return ECMRetirement;
                case TransactionTypeEnum.LandBankAcquisition:
                    return LandBankAcquisition;
                case TransactionTypeEnum.Transfer:
                    return Transfer;
                case TransactionTypeEnum.TransferWithBonusUnit:
                    return TransferWithBonusUnit;
                default:
                    throw new ArgumentException(string.Format("Unable to map Enum: {0}", enumValue));
            }
        }
    }

    public enum TransactionTypeEnum
    {
        Allocation = 1,
        Conversion = 2,
        ECMRetirement = 3,
        LandBankAcquisition = 4,
        Transfer = 5,
        TransferWithBonusUnit = 6,
        AllocationAssignment = 7,
        ConversionWithTransfer = 8
    }

    public partial class TransactionTypeAllocation : TransactionType
    {
        private TransactionTypeAllocation(int transactionTypeID, string transactionTypeName, string transactionTypeDisplayName, string transactionTypeAbbreviation) : base(transactionTypeID, transactionTypeName, transactionTypeDisplayName, transactionTypeAbbreviation) {}
        public static readonly TransactionTypeAllocation Instance = new TransactionTypeAllocation(1, @"Allocation", @"Allocation", @"ALLOC");
    }

    public partial class TransactionTypeConversion : TransactionType
    {
        private TransactionTypeConversion(int transactionTypeID, string transactionTypeName, string transactionTypeDisplayName, string transactionTypeAbbreviation) : base(transactionTypeID, transactionTypeName, transactionTypeDisplayName, transactionTypeAbbreviation) {}
        public static readonly TransactionTypeConversion Instance = new TransactionTypeConversion(2, @"Conversion", @"Conversion", @"CONV");
    }

    public partial class TransactionTypeECMRetirement : TransactionType
    {
        private TransactionTypeECMRetirement(int transactionTypeID, string transactionTypeName, string transactionTypeDisplayName, string transactionTypeAbbreviation) : base(transactionTypeID, transactionTypeName, transactionTypeDisplayName, transactionTypeAbbreviation) {}
        public static readonly TransactionTypeECMRetirement Instance = new TransactionTypeECMRetirement(3, @"ECM Retirement", @"ECM Retirement", @"ECM");
    }

    public partial class TransactionTypeLandBankAcquisition : TransactionType
    {
        private TransactionTypeLandBankAcquisition(int transactionTypeID, string transactionTypeName, string transactionTypeDisplayName, string transactionTypeAbbreviation) : base(transactionTypeID, transactionTypeName, transactionTypeDisplayName, transactionTypeAbbreviation) {}
        public static readonly TransactionTypeLandBankAcquisition Instance = new TransactionTypeLandBankAcquisition(4, @"Land Bank Acquisition", @"Land Bank Acquisition", @"LBA");
    }

    public partial class TransactionTypeTransfer : TransactionType
    {
        private TransactionTypeTransfer(int transactionTypeID, string transactionTypeName, string transactionTypeDisplayName, string transactionTypeAbbreviation) : base(transactionTypeID, transactionTypeName, transactionTypeDisplayName, transactionTypeAbbreviation) {}
        public static readonly TransactionTypeTransfer Instance = new TransactionTypeTransfer(5, @"Transfer", @"Transfer", @"TRF");
    }

    public partial class TransactionTypeTransferWithBonusUnit : TransactionType
    {
        private TransactionTypeTransferWithBonusUnit(int transactionTypeID, string transactionTypeName, string transactionTypeDisplayName, string transactionTypeAbbreviation) : base(transactionTypeID, transactionTypeName, transactionTypeDisplayName, transactionTypeAbbreviation) {}
        public static readonly TransactionTypeTransferWithBonusUnit Instance = new TransactionTypeTransferWithBonusUnit(6, @"Transfer With Bonus Unit", @"Transfer + Bonus Units", @"TRFB");
    }

    public partial class TransactionTypeAllocationAssignment : TransactionType
    {
        private TransactionTypeAllocationAssignment(int transactionTypeID, string transactionTypeName, string transactionTypeDisplayName, string transactionTypeAbbreviation) : base(transactionTypeID, transactionTypeName, transactionTypeDisplayName, transactionTypeAbbreviation) {}
        public static readonly TransactionTypeAllocationAssignment Instance = new TransactionTypeAllocationAssignment(7, @"Allocation Assignment", @"Allocation Assignment", @"ALLOCASSGN");
    }

    public partial class TransactionTypeConversionWithTransfer : TransactionType
    {
        private TransactionTypeConversionWithTransfer(int transactionTypeID, string transactionTypeName, string transactionTypeDisplayName, string transactionTypeAbbreviation) : base(transactionTypeID, transactionTypeName, transactionTypeDisplayName, transactionTypeAbbreviation) {}
        public static readonly TransactionTypeConversionWithTransfer Instance = new TransactionTypeConversionWithTransfer(8, @"Conversion With Transfer", @"Conversion With Transfer", @"CONVTRF");
    }
}