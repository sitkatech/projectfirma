//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[Commodity]
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
    public abstract partial class Commodity : IHavePrimaryKey
    {
        public static readonly CommodityCommercialFloorArea CommercialFloorArea = CommodityCommercialFloorArea.Instance;
        public static readonly CommodityCoverageHard CoverageHard = CommodityCoverageHard.Instance;
        public static readonly CommodityCoverageSoft CoverageSoft = CommodityCoverageSoft.Instance;
        public static readonly CommodityCoveragePotential CoveragePotential = CommodityCoveragePotential.Instance;
        public static readonly CommodityExistingResidentialUnit ExistingResidentialUnit = CommodityExistingResidentialUnit.Instance;
        public static readonly CommodityPersonsAtOneTime PersonsAtOneTime = CommodityPersonsAtOneTime.Instance;
        public static readonly CommodityResidentialDevelopmentRight ResidentialDevelopmentRight = CommodityResidentialDevelopmentRight.Instance;
        public static readonly CommodityResidentialAllocation ResidentialAllocation = CommodityResidentialAllocation.Instance;
        public static readonly CommodityResidentialBonusUnit ResidentialBonusUnit = CommodityResidentialBonusUnit.Instance;
        public static readonly CommodityRestorationCredit RestorationCredit = CommodityRestorationCredit.Instance;
        public static readonly CommodityTouristAccommodationUnit TouristAccommodationUnit = CommodityTouristAccommodationUnit.Instance;
        public static readonly CommodityResidentialFloorArea ResidentialFloorArea = CommodityResidentialFloorArea.Instance;
        public static readonly CommodityTouristFloorArea TouristFloorArea = CommodityTouristFloorArea.Instance;

        public static readonly List<Commodity> All;
        public static readonly ReadOnlyDictionary<int, Commodity> AllLookupDictionary;

        /// <summary>
        /// Static type constructor to coordinate static initialization order
        /// </summary>
        static Commodity()
        {
            All = new List<Commodity> { CommercialFloorArea, CoverageHard, CoverageSoft, CoveragePotential, ExistingResidentialUnit, PersonsAtOneTime, ResidentialDevelopmentRight, ResidentialAllocation, ResidentialBonusUnit, RestorationCredit, TouristAccommodationUnit, ResidentialFloorArea, TouristFloorArea };
            AllLookupDictionary = new ReadOnlyDictionary<int, Commodity>(All.ToDictionary(x => x.CommodityID));
        }

        /// <summary>
        /// Protected constructor only for use in instantiating the set of static lookup values that match database
        /// </summary>
        protected Commodity(int commodityID, string commodityName, string commodityDisplayName, int commodityUnitTypeID, bool isCoverage, bool canHaveLandCapability, string commodityShortName, int sortOrder, bool canHaveCommodityPool)
        {
            CommodityID = commodityID;
            CommodityName = commodityName;
            CommodityDisplayName = commodityDisplayName;
            CommodityUnitTypeID = commodityUnitTypeID;
            IsCoverage = isCoverage;
            CanHaveLandCapability = canHaveLandCapability;
            CommodityShortName = commodityShortName;
            SortOrder = sortOrder;
            CanHaveCommodityPool = canHaveCommodityPool;
        }
        public CommodityUnitType CommodityUnitType { get { return CommodityUnitType.AllLookupDictionary[CommodityUnitTypeID]; } }
        [Key]
        public int CommodityID { get; private set; }
        public string CommodityName { get; private set; }
        public string CommodityDisplayName { get; private set; }
        public int CommodityUnitTypeID { get; private set; }
        public bool IsCoverage { get; private set; }
        public bool CanHaveLandCapability { get; private set; }
        public string CommodityShortName { get; private set; }
        public int SortOrder { get; private set; }
        public bool CanHaveCommodityPool { get; private set; }
        public int PrimaryKey { get { return CommodityID; } }

        /// <summary>
        /// Enum types are equal by primary key
        /// </summary>
        public bool Equals(Commodity other)
        {
            if (other == null)
            {
                return false;
            }
            return other.CommodityID == CommodityID;
        }

        /// <summary>
        /// Enum types are equal by primary key
        /// </summary>
        public override bool Equals(object obj)
        {
            return Equals(obj as Commodity);
        }

        /// <summary>
        /// Enum types are equal by primary key
        /// </summary>
        public override int GetHashCode()
        {
            return CommodityID;
        }

        public static bool operator ==(Commodity left, Commodity right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Commodity left, Commodity right)
        {
            return !Equals(left, right);
        }

        public CommodityEnum ToEnum { get { return (CommodityEnum)GetHashCode(); } }

        public static Commodity ToType(int enumValue)
        {
            return ToType((CommodityEnum)enumValue);
        }

        public static Commodity ToType(CommodityEnum enumValue)
        {
            switch (enumValue)
            {
                case CommodityEnum.CommercialFloorArea:
                    return CommercialFloorArea;
                case CommodityEnum.CoverageHard:
                    return CoverageHard;
                case CommodityEnum.CoveragePotential:
                    return CoveragePotential;
                case CommodityEnum.CoverageSoft:
                    return CoverageSoft;
                case CommodityEnum.ExistingResidentialUnit:
                    return ExistingResidentialUnit;
                case CommodityEnum.PersonsAtOneTime:
                    return PersonsAtOneTime;
                case CommodityEnum.ResidentialAllocation:
                    return ResidentialAllocation;
                case CommodityEnum.ResidentialBonusUnit:
                    return ResidentialBonusUnit;
                case CommodityEnum.ResidentialDevelopmentRight:
                    return ResidentialDevelopmentRight;
                case CommodityEnum.ResidentialFloorArea:
                    return ResidentialFloorArea;
                case CommodityEnum.RestorationCredit:
                    return RestorationCredit;
                case CommodityEnum.TouristAccommodationUnit:
                    return TouristAccommodationUnit;
                case CommodityEnum.TouristFloorArea:
                    return TouristFloorArea;
                default:
                    throw new ArgumentException(string.Format("Unable to map Enum: {0}", enumValue));
            }
        }
    }

    public enum CommodityEnum
    {
        CommercialFloorArea = 1,
        CoverageHard = 2,
        CoverageSoft = 3,
        CoveragePotential = 4,
        ExistingResidentialUnit = 5,
        PersonsAtOneTime = 6,
        ResidentialDevelopmentRight = 7,
        ResidentialAllocation = 8,
        ResidentialBonusUnit = 9,
        RestorationCredit = 10,
        TouristAccommodationUnit = 11,
        ResidentialFloorArea = 12,
        TouristFloorArea = 13
    }

    public partial class CommodityCommercialFloorArea : Commodity
    {
        private CommodityCommercialFloorArea(int commodityID, string commodityName, string commodityDisplayName, int commodityUnitTypeID, bool isCoverage, bool canHaveLandCapability, string commodityShortName, int sortOrder, bool canHaveCommodityPool) : base(commodityID, commodityName, commodityDisplayName, commodityUnitTypeID, isCoverage, canHaveLandCapability, commodityShortName, sortOrder, canHaveCommodityPool) {}
        public static readonly CommodityCommercialFloorArea Instance = new CommodityCommercialFloorArea(1, @"CommercialFloorArea", @"Commercial Floor Area (CFA)", 2, false, true, @"CFA", 7, true);
    }

    public partial class CommodityCoverageHard : Commodity
    {
        private CommodityCoverageHard(int commodityID, string commodityName, string commodityDisplayName, int commodityUnitTypeID, bool isCoverage, bool canHaveLandCapability, string commodityShortName, int sortOrder, bool canHaveCommodityPool) : base(commodityID, commodityName, commodityDisplayName, commodityUnitTypeID, isCoverage, canHaveLandCapability, commodityShortName, sortOrder, canHaveCommodityPool) {}
        public static readonly CommodityCoverageHard Instance = new CommodityCoverageHard(2, @"CoverageHard", @"Coverage (hard)", 2, true, true, @"Hard Cover.", 1, false);
    }

    public partial class CommodityCoverageSoft : Commodity
    {
        private CommodityCoverageSoft(int commodityID, string commodityName, string commodityDisplayName, int commodityUnitTypeID, bool isCoverage, bool canHaveLandCapability, string commodityShortName, int sortOrder, bool canHaveCommodityPool) : base(commodityID, commodityName, commodityDisplayName, commodityUnitTypeID, isCoverage, canHaveLandCapability, commodityShortName, sortOrder, canHaveCommodityPool) {}
        public static readonly CommodityCoverageSoft Instance = new CommodityCoverageSoft(3, @"CoverageSoft", @"Coverage (soft)", 2, true, true, @"Soft Cover.", 2, false);
    }

    public partial class CommodityCoveragePotential : Commodity
    {
        private CommodityCoveragePotential(int commodityID, string commodityName, string commodityDisplayName, int commodityUnitTypeID, bool isCoverage, bool canHaveLandCapability, string commodityShortName, int sortOrder, bool canHaveCommodityPool) : base(commodityID, commodityName, commodityDisplayName, commodityUnitTypeID, isCoverage, canHaveLandCapability, commodityShortName, sortOrder, canHaveCommodityPool) {}
        public static readonly CommodityCoveragePotential Instance = new CommodityCoveragePotential(4, @"CoveragePotential", @"Coverage (potential)", 2, true, true, @"Pot. Cover.", 3, false);
    }

    public partial class CommodityExistingResidentialUnit : Commodity
    {
        private CommodityExistingResidentialUnit(int commodityID, string commodityName, string commodityDisplayName, int commodityUnitTypeID, bool isCoverage, bool canHaveLandCapability, string commodityShortName, int sortOrder, bool canHaveCommodityPool) : base(commodityID, commodityName, commodityDisplayName, commodityUnitTypeID, isCoverage, canHaveLandCapability, commodityShortName, sortOrder, canHaveCommodityPool) {}
        public static readonly CommodityExistingResidentialUnit Instance = new CommodityExistingResidentialUnit(5, @"ExistingResidentialUnit", @"Existing Residential Unit (ERU)", 1, false, true, @"ERU", 4, false);
    }

    public partial class CommodityPersonsAtOneTime : Commodity
    {
        private CommodityPersonsAtOneTime(int commodityID, string commodityName, string commodityDisplayName, int commodityUnitTypeID, bool isCoverage, bool canHaveLandCapability, string commodityShortName, int sortOrder, bool canHaveCommodityPool) : base(commodityID, commodityName, commodityDisplayName, commodityUnitTypeID, isCoverage, canHaveLandCapability, commodityShortName, sortOrder, canHaveCommodityPool) {}
        public static readonly CommodityPersonsAtOneTime Instance = new CommodityPersonsAtOneTime(6, @"PersonsAtOneTime", @"Persons-at-one-time (PAOT)", 1, false, false, @"PAOT", 10, true);
    }

    public partial class CommodityResidentialDevelopmentRight : Commodity
    {
        private CommodityResidentialDevelopmentRight(int commodityID, string commodityName, string commodityDisplayName, int commodityUnitTypeID, bool isCoverage, bool canHaveLandCapability, string commodityShortName, int sortOrder, bool canHaveCommodityPool) : base(commodityID, commodityName, commodityDisplayName, commodityUnitTypeID, isCoverage, canHaveLandCapability, commodityShortName, sortOrder, canHaveCommodityPool) {}
        public static readonly CommodityResidentialDevelopmentRight Instance = new CommodityResidentialDevelopmentRight(7, @"ResidentialDevelopmentRight", @"Residential Development Right (RDR)", 1, false, false, @"RDR", 11, false);
    }

    public partial class CommodityResidentialAllocation : Commodity
    {
        private CommodityResidentialAllocation(int commodityID, string commodityName, string commodityDisplayName, int commodityUnitTypeID, bool isCoverage, bool canHaveLandCapability, string commodityShortName, int sortOrder, bool canHaveCommodityPool) : base(commodityID, commodityName, commodityDisplayName, commodityUnitTypeID, isCoverage, canHaveLandCapability, commodityShortName, sortOrder, canHaveCommodityPool) {}
        public static readonly CommodityResidentialAllocation Instance = new CommodityResidentialAllocation(8, @"ResidentialAllocation", @"Residential Allocation", 1, false, false, @"Res. Alloc.", 12, true);
    }

    public partial class CommodityResidentialBonusUnit : Commodity
    {
        private CommodityResidentialBonusUnit(int commodityID, string commodityName, string commodityDisplayName, int commodityUnitTypeID, bool isCoverage, bool canHaveLandCapability, string commodityShortName, int sortOrder, bool canHaveCommodityPool) : base(commodityID, commodityName, commodityDisplayName, commodityUnitTypeID, isCoverage, canHaveLandCapability, commodityShortName, sortOrder, canHaveCommodityPool) {}
        public static readonly CommodityResidentialBonusUnit Instance = new CommodityResidentialBonusUnit(9, @"ResidentialBonusUnit", @"Residential Bonus Unit (RBU)", 1, false, true, @"RBU", 5, true);
    }

    public partial class CommodityRestorationCredit : Commodity
    {
        private CommodityRestorationCredit(int commodityID, string commodityName, string commodityDisplayName, int commodityUnitTypeID, bool isCoverage, bool canHaveLandCapability, string commodityShortName, int sortOrder, bool canHaveCommodityPool) : base(commodityID, commodityName, commodityDisplayName, commodityUnitTypeID, isCoverage, canHaveLandCapability, commodityShortName, sortOrder, canHaveCommodityPool) {}
        public static readonly CommodityRestorationCredit Instance = new CommodityRestorationCredit(10, @"RestorationCredit", @"Restoration Credit", 1, false, false, @"Rest. Cred.", 13, false);
    }

    public partial class CommodityTouristAccommodationUnit : Commodity
    {
        private CommodityTouristAccommodationUnit(int commodityID, string commodityName, string commodityDisplayName, int commodityUnitTypeID, bool isCoverage, bool canHaveLandCapability, string commodityShortName, int sortOrder, bool canHaveCommodityPool) : base(commodityID, commodityName, commodityDisplayName, commodityUnitTypeID, isCoverage, canHaveLandCapability, commodityShortName, sortOrder, canHaveCommodityPool) {}
        public static readonly CommodityTouristAccommodationUnit Instance = new CommodityTouristAccommodationUnit(11, @"TouristAccommodationUnit", @"Tourist Accommodation Unit (TAU)", 1, false, true, @"TAU", 6, true);
    }

    public partial class CommodityResidentialFloorArea : Commodity
    {
        private CommodityResidentialFloorArea(int commodityID, string commodityName, string commodityDisplayName, int commodityUnitTypeID, bool isCoverage, bool canHaveLandCapability, string commodityShortName, int sortOrder, bool canHaveCommodityPool) : base(commodityID, commodityName, commodityDisplayName, commodityUnitTypeID, isCoverage, canHaveLandCapability, commodityShortName, sortOrder, canHaveCommodityPool) {}
        public static readonly CommodityResidentialFloorArea Instance = new CommodityResidentialFloorArea(12, @"ResidentialFloorArea", @"Residential Floor Area (RFA)", 2, false, true, @"RFA", 8, false);
    }

    public partial class CommodityTouristFloorArea : Commodity
    {
        private CommodityTouristFloorArea(int commodityID, string commodityName, string commodityDisplayName, int commodityUnitTypeID, bool isCoverage, bool canHaveLandCapability, string commodityShortName, int sortOrder, bool canHaveCommodityPool) : base(commodityID, commodityName, commodityDisplayName, commodityUnitTypeID, isCoverage, canHaveLandCapability, commodityShortName, sortOrder, canHaveCommodityPool) {}
        public static readonly CommodityTouristFloorArea Instance = new CommodityTouristFloorArea(13, @"TouristFloorArea", @"Tourist Floor Area (TFA)", 2, false, true, @"TFA", 9, false);
    }
}