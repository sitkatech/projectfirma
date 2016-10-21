//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ResidentialAllocationType]
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
    public abstract partial class ResidentialAllocationType : IHavePrimaryKey
    {
        public static readonly ResidentialAllocationTypeOriginal Original = ResidentialAllocationTypeOriginal.Instance;
        public static readonly ResidentialAllocationTypeReissued Reissued = ResidentialAllocationTypeReissued.Instance;
        public static readonly ResidentialAllocationTypeLitigationSettlement LitigationSettlement = ResidentialAllocationTypeLitigationSettlement.Instance;
        public static readonly ResidentialAllocationTypeAllocationPool AllocationPool = ResidentialAllocationTypeAllocationPool.Instance;

        public static readonly List<ResidentialAllocationType> All;
        public static readonly ReadOnlyDictionary<int, ResidentialAllocationType> AllLookupDictionary;

        /// <summary>
        /// Static type constructor to coordinate static initialization order
        /// </summary>
        static ResidentialAllocationType()
        {
            All = new List<ResidentialAllocationType> { Original, Reissued, LitigationSettlement, AllocationPool };
            AllLookupDictionary = new ReadOnlyDictionary<int, ResidentialAllocationType>(All.ToDictionary(x => x.ResidentialAllocationTypeID));
        }

        /// <summary>
        /// Protected constructor only for use in instantiating the set of static lookup values that match database
        /// </summary>
        protected ResidentialAllocationType(int residentialAllocationTypeID, string residentialAllocationTypeName, string residentialAllocationTypeCode, string description)
        {
            ResidentialAllocationTypeID = residentialAllocationTypeID;
            ResidentialAllocationTypeName = residentialAllocationTypeName;
            ResidentialAllocationTypeCode = residentialAllocationTypeCode;
            Description = description;
        }

        [Key]
        public int ResidentialAllocationTypeID { get; private set; }
        public string ResidentialAllocationTypeName { get; private set; }
        public string ResidentialAllocationTypeCode { get; private set; }
        public string Description { get; private set; }
        public int PrimaryKey { get { return ResidentialAllocationTypeID; } }

        /// <summary>
        /// Enum types are equal by primary key
        /// </summary>
        public bool Equals(ResidentialAllocationType other)
        {
            if (other == null)
            {
                return false;
            }
            return other.ResidentialAllocationTypeID == ResidentialAllocationTypeID;
        }

        /// <summary>
        /// Enum types are equal by primary key
        /// </summary>
        public override bool Equals(object obj)
        {
            return Equals(obj as ResidentialAllocationType);
        }

        /// <summary>
        /// Enum types are equal by primary key
        /// </summary>
        public override int GetHashCode()
        {
            return ResidentialAllocationTypeID;
        }

        public static bool operator ==(ResidentialAllocationType left, ResidentialAllocationType right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(ResidentialAllocationType left, ResidentialAllocationType right)
        {
            return !Equals(left, right);
        }

        public ResidentialAllocationTypeEnum ToEnum { get { return (ResidentialAllocationTypeEnum)GetHashCode(); } }

        public static ResidentialAllocationType ToType(int enumValue)
        {
            return ToType((ResidentialAllocationTypeEnum)enumValue);
        }

        public static ResidentialAllocationType ToType(ResidentialAllocationTypeEnum enumValue)
        {
            switch (enumValue)
            {
                case ResidentialAllocationTypeEnum.AllocationPool:
                    return AllocationPool;
                case ResidentialAllocationTypeEnum.LitigationSettlement:
                    return LitigationSettlement;
                case ResidentialAllocationTypeEnum.Original:
                    return Original;
                case ResidentialAllocationTypeEnum.Reissued:
                    return Reissued;
                default:
                    throw new ArgumentException(string.Format("Unable to map Enum: {0}", enumValue));
            }
        }
    }

    public enum ResidentialAllocationTypeEnum
    {
        Original = 1,
        Reissued = 2,
        LitigationSettlement = 3,
        AllocationPool = 4
    }

    public partial class ResidentialAllocationTypeOriginal : ResidentialAllocationType
    {
        private ResidentialAllocationTypeOriginal(int residentialAllocationTypeID, string residentialAllocationTypeName, string residentialAllocationTypeCode, string description) : base(residentialAllocationTypeID, residentialAllocationTypeName, residentialAllocationTypeCode, description) {}
        public static readonly ResidentialAllocationTypeOriginal Instance = new ResidentialAllocationTypeOriginal(1, @"Original", @"O", @"Original");
    }

    public partial class ResidentialAllocationTypeReissued : ResidentialAllocationType
    {
        private ResidentialAllocationTypeReissued(int residentialAllocationTypeID, string residentialAllocationTypeName, string residentialAllocationTypeCode, string description) : base(residentialAllocationTypeID, residentialAllocationTypeName, residentialAllocationTypeCode, description) {}
        public static readonly ResidentialAllocationTypeReissued Instance = new ResidentialAllocationTypeReissued(2, @"Reissued", @"R", @"Reissued");
    }

    public partial class ResidentialAllocationTypeLitigationSettlement : ResidentialAllocationType
    {
        private ResidentialAllocationTypeLitigationSettlement(int residentialAllocationTypeID, string residentialAllocationTypeName, string residentialAllocationTypeCode, string description) : base(residentialAllocationTypeID, residentialAllocationTypeName, residentialAllocationTypeCode, description) {}
        public static readonly ResidentialAllocationTypeLitigationSettlement Instance = new ResidentialAllocationTypeLitigationSettlement(3, @"LitigationSettlement", @"LS", @"Litigation Settlement");
    }

    public partial class ResidentialAllocationTypeAllocationPool : ResidentialAllocationType
    {
        private ResidentialAllocationTypeAllocationPool(int residentialAllocationTypeID, string residentialAllocationTypeName, string residentialAllocationTypeCode, string description) : base(residentialAllocationTypeID, residentialAllocationTypeName, residentialAllocationTypeCode, description) {}
        public static readonly ResidentialAllocationTypeAllocationPool Instance = new ResidentialAllocationTypeAllocationPool(4, @"AllocationPool", @"AP", @"Allocation Pool");
    }
}