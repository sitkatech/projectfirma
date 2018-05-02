//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[Tenant]
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Linq;
using System.Web;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Models
{
    public abstract partial class Tenant : IHavePrimaryKey
    {
        public static readonly TenantSitkaTechnologyGroup SitkaTechnologyGroup = TenantSitkaTechnologyGroup.Instance;
        public static readonly TenantClackamasPartnership ClackamasPartnership = TenantClackamasPartnership.Instance;
        public static readonly TenantRCDProjectTracker RCDProjectTracker = TenantRCDProjectTracker.Instance;
        public static readonly TenantInternationYearOfTheSalmon InternationYearOfTheSalmon = TenantInternationYearOfTheSalmon.Instance;
        public static readonly TenantDemoProjectFirma DemoProjectFirma = TenantDemoProjectFirma.Instance;
        public static readonly TenantPeaksToPeople PeaksToPeople = TenantPeaksToPeople.Instance;
        public static readonly TenantJohnDayPartnership JohnDayPartnership = TenantJohnDayPartnership.Instance;
        public static readonly TenantAshlandForestAllLandsRestorationInitiative AshlandForestAllLandsRestorationInitiative = TenantAshlandForestAllLandsRestorationInitiative.Instance;
        public static readonly TenantIdahoAssociatonOfSoilConservationDistricts IdahoAssociatonOfSoilConservationDistricts = TenantIdahoAssociatonOfSoilConservationDistricts.Instance;

        public static readonly List<Tenant> All;
        public static readonly ReadOnlyDictionary<int, Tenant> AllLookupDictionary;

        /// <summary>
        /// Static type constructor to coordinate static initialization order
        /// </summary>
        static Tenant()
        {
            All = new List<Tenant> { SitkaTechnologyGroup, ClackamasPartnership, RCDProjectTracker, InternationYearOfTheSalmon, DemoProjectFirma, PeaksToPeople, JohnDayPartnership, AshlandForestAllLandsRestorationInitiative, IdahoAssociatonOfSoilConservationDistricts };
            AllLookupDictionary = new ReadOnlyDictionary<int, Tenant>(All.ToDictionary(x => x.TenantID));
        }

        /// <summary>
        /// Protected constructor only for use in instantiating the set of static lookup values that match database
        /// </summary>
        protected Tenant(int tenantID, string tenantName, string tenantDomain, string tenantSubdomain)
        {
            TenantID = tenantID;
            TenantName = tenantName;
            TenantDomain = tenantDomain;
            TenantSubdomain = tenantSubdomain;
        }

        [Key]
        public int TenantID { get; private set; }
        public string TenantName { get; private set; }
        public string TenantDomain { get; private set; }
        public string TenantSubdomain { get; private set; }
        [NotMapped]
        public int PrimaryKey { get { return TenantID; } }

        /// <summary>
        /// Enum types are equal by primary key
        /// </summary>
        public bool Equals(Tenant other)
        {
            if (other == null)
            {
                return false;
            }
            return other.TenantID == TenantID;
        }

        /// <summary>
        /// Enum types are equal by primary key
        /// </summary>
        public override bool Equals(object obj)
        {
            return Equals(obj as Tenant);
        }

        /// <summary>
        /// Enum types are equal by primary key
        /// </summary>
        public override int GetHashCode()
        {
            return TenantID;
        }

        public static bool operator ==(Tenant left, Tenant right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Tenant left, Tenant right)
        {
            return !Equals(left, right);
        }

        public TenantEnum ToEnum { get { return (TenantEnum)GetHashCode(); } }

        public static Tenant ToType(int enumValue)
        {
            return ToType((TenantEnum)enumValue);
        }

        public static Tenant ToType(TenantEnum enumValue)
        {
            switch (enumValue)
            {
                case TenantEnum.AshlandForestAllLandsRestorationInitiative:
                    return AshlandForestAllLandsRestorationInitiative;
                case TenantEnum.ClackamasPartnership:
                    return ClackamasPartnership;
                case TenantEnum.DemoProjectFirma:
                    return DemoProjectFirma;
                case TenantEnum.IdahoAssociatonOfSoilConservationDistricts:
                    return IdahoAssociatonOfSoilConservationDistricts;
                case TenantEnum.InternationYearOfTheSalmon:
                    return InternationYearOfTheSalmon;
                case TenantEnum.JohnDayPartnership:
                    return JohnDayPartnership;
                case TenantEnum.PeaksToPeople:
                    return PeaksToPeople;
                case TenantEnum.RCDProjectTracker:
                    return RCDProjectTracker;
                case TenantEnum.SitkaTechnologyGroup:
                    return SitkaTechnologyGroup;
                default:
                    throw new ArgumentException(string.Format("Unable to map Enum: {0}", enumValue));
            }
        }
    }

    public enum TenantEnum
    {
        SitkaTechnologyGroup = 1,
        ClackamasPartnership = 2,
        RCDProjectTracker = 3,
        InternationYearOfTheSalmon = 4,
        DemoProjectFirma = 5,
        PeaksToPeople = 6,
        JohnDayPartnership = 7,
        AshlandForestAllLandsRestorationInitiative = 8,
        IdahoAssociatonOfSoilConservationDistricts = 9
    }

    public partial class TenantSitkaTechnologyGroup : Tenant
    {
        private TenantSitkaTechnologyGroup(int tenantID, string tenantName, string tenantDomain, string tenantSubdomain) : base(tenantID, tenantName, tenantDomain, tenantSubdomain) {}
        public static readonly TenantSitkaTechnologyGroup Instance = new TenantSitkaTechnologyGroup(1, @"SitkaTechnologyGroup", @"projectfirma.com", @"sitka");
    }

    public partial class TenantClackamasPartnership : Tenant
    {
        private TenantClackamasPartnership(int tenantID, string tenantName, string tenantDomain, string tenantSubdomain) : base(tenantID, tenantName, tenantDomain, tenantSubdomain) {}
        public static readonly TenantClackamasPartnership Instance = new TenantClackamasPartnership(2, @"ClackamasPartnership", @"clackamaspartnership.org", null);
    }

    public partial class TenantRCDProjectTracker : Tenant
    {
        private TenantRCDProjectTracker(int tenantID, string tenantName, string tenantDomain, string tenantSubdomain) : base(tenantID, tenantName, tenantDomain, tenantSubdomain) {}
        public static readonly TenantRCDProjectTracker Instance = new TenantRCDProjectTracker(3, @"RCDProjectTracker", @"rcdprojects.org", null);
    }

    public partial class TenantInternationYearOfTheSalmon : Tenant
    {
        private TenantInternationYearOfTheSalmon(int tenantID, string tenantName, string tenantDomain, string tenantSubdomain) : base(tenantID, tenantName, tenantDomain, tenantSubdomain) {}
        public static readonly TenantInternationYearOfTheSalmon Instance = new TenantInternationYearOfTheSalmon(4, @"InternationYearOfTheSalmon", @"projectfirma.com", @"iysdemo");
    }

    public partial class TenantDemoProjectFirma : Tenant
    {
        private TenantDemoProjectFirma(int tenantID, string tenantName, string tenantDomain, string tenantSubdomain) : base(tenantID, tenantName, tenantDomain, tenantSubdomain) {}
        public static readonly TenantDemoProjectFirma Instance = new TenantDemoProjectFirma(5, @"DemoProjectFirma", @"projectfirma.com", @"demo");
    }

    public partial class TenantPeaksToPeople : Tenant
    {
        private TenantPeaksToPeople(int tenantID, string tenantName, string tenantDomain, string tenantSubdomain) : base(tenantID, tenantName, tenantDomain, tenantSubdomain) {}
        public static readonly TenantPeaksToPeople Instance = new TenantPeaksToPeople(6, @"PeaksToPeople", @"projectfirma.com", @"peakstopeople");
    }

    public partial class TenantJohnDayPartnership : Tenant
    {
        private TenantJohnDayPartnership(int tenantID, string tenantName, string tenantDomain, string tenantSubdomain) : base(tenantID, tenantName, tenantDomain, tenantSubdomain) {}
        public static readonly TenantJohnDayPartnership Instance = new TenantJohnDayPartnership(7, @"JohnDayPartnership", @"projectfirma.com", @"johndaydemo");
    }

    public partial class TenantAshlandForestAllLandsRestorationInitiative : Tenant
    {
        private TenantAshlandForestAllLandsRestorationInitiative(int tenantID, string tenantName, string tenantDomain, string tenantSubdomain) : base(tenantID, tenantName, tenantDomain, tenantSubdomain) {}
        public static readonly TenantAshlandForestAllLandsRestorationInitiative Instance = new TenantAshlandForestAllLandsRestorationInitiative(8, @"AshlandForestAllLandsRestorationInitiative", @"projectfirma.com", @"ashlanddemo");
    }

    public partial class TenantIdahoAssociatonOfSoilConservationDistricts : Tenant
    {
        private TenantIdahoAssociatonOfSoilConservationDistricts(int tenantID, string tenantName, string tenantDomain, string tenantSubdomain) : base(tenantID, tenantName, tenantDomain, tenantSubdomain) {}
        public static readonly TenantIdahoAssociatonOfSoilConservationDistricts Instance = new TenantIdahoAssociatonOfSoilConservationDistricts(9, @"IdahoAssociatonOfSoilConservationDistricts", @"projectfirma.com", @"swcdemo");
    }
}