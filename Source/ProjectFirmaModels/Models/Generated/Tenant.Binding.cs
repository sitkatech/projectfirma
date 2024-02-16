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
using CodeFirstStoreFunctions;
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public abstract partial class Tenant : IHavePrimaryKey
    {
        public static readonly TenantSitkaTechnologyGroup SitkaTechnologyGroup = TenantSitkaTechnologyGroup.Instance;
        public static readonly TenantClackamasPartnership ClackamasPartnership = TenantClackamasPartnership.Instance;
        public static readonly TenantRCDProjectTracker RCDProjectTracker = TenantRCDProjectTracker.Instance;
        public static readonly TenantNCRPProjectTracker NCRPProjectTracker = TenantNCRPProjectTracker.Instance;
        public static readonly TenantDemoProjectFirma DemoProjectFirma = TenantDemoProjectFirma.Instance;
        public static readonly TenantPeaksToPeople PeaksToPeople = TenantPeaksToPeople.Instance;
        public static readonly TenantJohnDayBasinPartnership JohnDayBasinPartnership = TenantJohnDayBasinPartnership.Instance;
        public static readonly TenantAshlandForestAllLandsRestorationInitiative AshlandForestAllLandsRestorationInitiative = TenantAshlandForestAllLandsRestorationInitiative.Instance;
        public static readonly TenantIdahoAssociatonOfSoilConservationDistricts IdahoAssociatonOfSoilConservationDistricts = TenantIdahoAssociatonOfSoilConservationDistricts.Instance;
        public static readonly TenantActionAgendaForPugetSound ActionAgendaForPugetSound = TenantActionAgendaForPugetSound.Instance;
        public static readonly TenantBureauOfReclamation BureauOfReclamation = TenantBureauOfReclamation.Instance;
        public static readonly TenantSSMPProjectTracker SSMPProjectTracker = TenantSSMPProjectTracker.Instance;
        public static readonly TenantTCSProjectTracker TCSProjectTracker = TenantTCSProjectTracker.Instance;

        public static readonly List<Tenant> All;
        public static readonly ReadOnlyDictionary<int, Tenant> AllLookupDictionary;

        /// <summary>
        /// Static type constructor to coordinate static initialization order
        /// </summary>
        static Tenant()
        {
            All = new List<Tenant> { SitkaTechnologyGroup, ClackamasPartnership, RCDProjectTracker, NCRPProjectTracker, DemoProjectFirma, PeaksToPeople, JohnDayBasinPartnership, AshlandForestAllLandsRestorationInitiative, IdahoAssociatonOfSoilConservationDistricts, ActionAgendaForPugetSound, BureauOfReclamation, SSMPProjectTracker, TCSProjectTracker };
            AllLookupDictionary = new ReadOnlyDictionary<int, Tenant>(All.ToDictionary(x => x.TenantID));
        }

        /// <summary>
        /// Protected constructor only for use in instantiating the set of static lookup values that match database
        /// </summary>
        protected Tenant(int tenantID, string tenantName, string canonicalHostNameLocal, string canonicalHostNameQa, string canonicalHostNameProd, DateTime fiscalYearStartDate, bool useFiscalYears, bool arePerformanceMeasuresExternallySourced, bool areOrganizationsExternallySourced, bool areFundingSourcesExternallySourced, bool tenantEnabled)
        {
            TenantID = tenantID;
            TenantName = tenantName;
            CanonicalHostNameLocal = canonicalHostNameLocal;
            CanonicalHostNameQa = canonicalHostNameQa;
            CanonicalHostNameProd = canonicalHostNameProd;
            FiscalYearStartDate = fiscalYearStartDate;
            UseFiscalYears = useFiscalYears;
            ArePerformanceMeasuresExternallySourced = arePerformanceMeasuresExternallySourced;
            AreOrganizationsExternallySourced = areOrganizationsExternallySourced;
            AreFundingSourcesExternallySourced = areFundingSourcesExternallySourced;
            TenantEnabled = tenantEnabled;
        }

        [Key]
        public int TenantID { get; private set; }
        public string TenantName { get; private set; }
        public string CanonicalHostNameLocal { get; private set; }
        public string CanonicalHostNameQa { get; private set; }
        public string CanonicalHostNameProd { get; private set; }
        public DateTime FiscalYearStartDate { get; private set; }
        public bool UseFiscalYears { get; private set; }
        public bool ArePerformanceMeasuresExternallySourced { get; private set; }
        public bool AreOrganizationsExternallySourced { get; private set; }
        public bool AreFundingSourcesExternallySourced { get; private set; }
        public bool TenantEnabled { get; private set; }
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
                case TenantEnum.ActionAgendaForPugetSound:
                    return ActionAgendaForPugetSound;
                case TenantEnum.AshlandForestAllLandsRestorationInitiative:
                    return AshlandForestAllLandsRestorationInitiative;
                case TenantEnum.BureauOfReclamation:
                    return BureauOfReclamation;
                case TenantEnum.ClackamasPartnership:
                    return ClackamasPartnership;
                case TenantEnum.DemoProjectFirma:
                    return DemoProjectFirma;
                case TenantEnum.IdahoAssociatonOfSoilConservationDistricts:
                    return IdahoAssociatonOfSoilConservationDistricts;
                case TenantEnum.JohnDayBasinPartnership:
                    return JohnDayBasinPartnership;
                case TenantEnum.NCRPProjectTracker:
                    return NCRPProjectTracker;
                case TenantEnum.PeaksToPeople:
                    return PeaksToPeople;
                case TenantEnum.RCDProjectTracker:
                    return RCDProjectTracker;
                case TenantEnum.SitkaTechnologyGroup:
                    return SitkaTechnologyGroup;
                case TenantEnum.SSMPProjectTracker:
                    return SSMPProjectTracker;
                case TenantEnum.TCSProjectTracker:
                    return TCSProjectTracker;
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
        NCRPProjectTracker = 4,
        DemoProjectFirma = 5,
        PeaksToPeople = 6,
        JohnDayBasinPartnership = 7,
        AshlandForestAllLandsRestorationInitiative = 8,
        IdahoAssociatonOfSoilConservationDistricts = 9,
        ActionAgendaForPugetSound = 11,
        BureauOfReclamation = 12,
        SSMPProjectTracker = 13,
        TCSProjectTracker = 14
    }

    public partial class TenantSitkaTechnologyGroup : Tenant
    {
        private TenantSitkaTechnologyGroup(int tenantID, string tenantName, string canonicalHostNameLocal, string canonicalHostNameQa, string canonicalHostNameProd, DateTime fiscalYearStartDate, bool useFiscalYears, bool arePerformanceMeasuresExternallySourced, bool areOrganizationsExternallySourced, bool areFundingSourcesExternallySourced, bool tenantEnabled) : base(tenantID, tenantName, canonicalHostNameLocal, canonicalHostNameQa, canonicalHostNameProd, fiscalYearStartDate, useFiscalYears, arePerformanceMeasuresExternallySourced, areOrganizationsExternallySourced, areFundingSourcesExternallySourced, tenantEnabled) {}
        public static readonly TenantSitkaTechnologyGroup Instance = new TenantSitkaTechnologyGroup(1, @"SitkaTechnologyGroup", @"sitka.localhost.projectfirma.com", @"sitka.qa.projectfirma.com", @"sitka.projectfirma.com", DateTime.Parse("01/01/1990"), false, false, false, false, true);
    }

    public partial class TenantClackamasPartnership : Tenant
    {
        private TenantClackamasPartnership(int tenantID, string tenantName, string canonicalHostNameLocal, string canonicalHostNameQa, string canonicalHostNameProd, DateTime fiscalYearStartDate, bool useFiscalYears, bool arePerformanceMeasuresExternallySourced, bool areOrganizationsExternallySourced, bool areFundingSourcesExternallySourced, bool tenantEnabled) : base(tenantID, tenantName, canonicalHostNameLocal, canonicalHostNameQa, canonicalHostNameProd, fiscalYearStartDate, useFiscalYears, arePerformanceMeasuresExternallySourced, areOrganizationsExternallySourced, areFundingSourcesExternallySourced, tenantEnabled) {}
        public static readonly TenantClackamasPartnership Instance = new TenantClackamasPartnership(2, @"ClackamasPartnership", @"clackamaspartnership.localhost.projectfirma.com", @"qa.clackamaspartnership.org", @"www.clackamaspartnership.org", DateTime.Parse("01/01/1990"), false, false, false, false, true);
    }

    public partial class TenantRCDProjectTracker : Tenant
    {
        private TenantRCDProjectTracker(int tenantID, string tenantName, string canonicalHostNameLocal, string canonicalHostNameQa, string canonicalHostNameProd, DateTime fiscalYearStartDate, bool useFiscalYears, bool arePerformanceMeasuresExternallySourced, bool areOrganizationsExternallySourced, bool areFundingSourcesExternallySourced, bool tenantEnabled) : base(tenantID, tenantName, canonicalHostNameLocal, canonicalHostNameQa, canonicalHostNameProd, fiscalYearStartDate, useFiscalYears, arePerformanceMeasuresExternallySourced, areOrganizationsExternallySourced, areFundingSourcesExternallySourced, tenantEnabled) {}
        public static readonly TenantRCDProjectTracker Instance = new TenantRCDProjectTracker(3, @"RCDProjectTracker", @"rcdprojects.localhost.projectfirma.com", @"qa.rcdprojects.org", @"www.rcdprojects.org", DateTime.Parse("01/01/1990"), false, false, false, false, true);
    }

    public partial class TenantNCRPProjectTracker : Tenant
    {
        private TenantNCRPProjectTracker(int tenantID, string tenantName, string canonicalHostNameLocal, string canonicalHostNameQa, string canonicalHostNameProd, DateTime fiscalYearStartDate, bool useFiscalYears, bool arePerformanceMeasuresExternallySourced, bool areOrganizationsExternallySourced, bool areFundingSourcesExternallySourced, bool tenantEnabled) : base(tenantID, tenantName, canonicalHostNameLocal, canonicalHostNameQa, canonicalHostNameProd, fiscalYearStartDate, useFiscalYears, arePerformanceMeasuresExternallySourced, areOrganizationsExternallySourced, areFundingSourcesExternallySourced, tenantEnabled) {}
        public static readonly TenantNCRPProjectTracker Instance = new TenantNCRPProjectTracker(4, @"NCRPProjectTracker", @"ncrp.localhost.projectfirma.com", @"qa.northcoastresourcepartnershipprojects.org", @"www.northcoastresourcepartnershipprojects.org", DateTime.Parse("01/01/1990"), false, false, false, false, true);
    }

    public partial class TenantDemoProjectFirma : Tenant
    {
        private TenantDemoProjectFirma(int tenantID, string tenantName, string canonicalHostNameLocal, string canonicalHostNameQa, string canonicalHostNameProd, DateTime fiscalYearStartDate, bool useFiscalYears, bool arePerformanceMeasuresExternallySourced, bool areOrganizationsExternallySourced, bool areFundingSourcesExternallySourced, bool tenantEnabled) : base(tenantID, tenantName, canonicalHostNameLocal, canonicalHostNameQa, canonicalHostNameProd, fiscalYearStartDate, useFiscalYears, arePerformanceMeasuresExternallySourced, areOrganizationsExternallySourced, areFundingSourcesExternallySourced, tenantEnabled) {}
        public static readonly TenantDemoProjectFirma Instance = new TenantDemoProjectFirma(5, @"DemoProjectFirma", @"demo.localhost.projectfirma.com", @"demo.qa.projectfirma.com", @"demo.projectfirma.com", DateTime.Parse("01/01/1990"), false, false, false, false, true);
    }

    public partial class TenantPeaksToPeople : Tenant
    {
        private TenantPeaksToPeople(int tenantID, string tenantName, string canonicalHostNameLocal, string canonicalHostNameQa, string canonicalHostNameProd, DateTime fiscalYearStartDate, bool useFiscalYears, bool arePerformanceMeasuresExternallySourced, bool areOrganizationsExternallySourced, bool areFundingSourcesExternallySourced, bool tenantEnabled) : base(tenantID, tenantName, canonicalHostNameLocal, canonicalHostNameQa, canonicalHostNameProd, fiscalYearStartDate, useFiscalYears, arePerformanceMeasuresExternallySourced, areOrganizationsExternallySourced, areFundingSourcesExternallySourced, tenantEnabled) {}
        public static readonly TenantPeaksToPeople Instance = new TenantPeaksToPeople(6, @"PeaksToPeople", @"peakstopeople.localhost.projectfirma.com", @"qa-outcomes.peakstopeople.org", @"outcomes.peakstopeople.org", DateTime.Parse("01/01/1990"), false, false, false, false, false);
    }

    public partial class TenantJohnDayBasinPartnership : Tenant
    {
        private TenantJohnDayBasinPartnership(int tenantID, string tenantName, string canonicalHostNameLocal, string canonicalHostNameQa, string canonicalHostNameProd, DateTime fiscalYearStartDate, bool useFiscalYears, bool arePerformanceMeasuresExternallySourced, bool areOrganizationsExternallySourced, bool areFundingSourcesExternallySourced, bool tenantEnabled) : base(tenantID, tenantName, canonicalHostNameLocal, canonicalHostNameQa, canonicalHostNameProd, fiscalYearStartDate, useFiscalYears, arePerformanceMeasuresExternallySourced, areOrganizationsExternallySourced, areFundingSourcesExternallySourced, tenantEnabled) {}
        public static readonly TenantJohnDayBasinPartnership Instance = new TenantJohnDayBasinPartnership(7, @"JohnDayBasinPartnership", @"johndaybasinpartnership.localhost.projectfirma.com", @"qa.johndaybasinpartnership.org", @"www.johndaybasinpartnership.org", DateTime.Parse("01/01/1990"), false, false, false, false, true);
    }

    public partial class TenantAshlandForestAllLandsRestorationInitiative : Tenant
    {
        private TenantAshlandForestAllLandsRestorationInitiative(int tenantID, string tenantName, string canonicalHostNameLocal, string canonicalHostNameQa, string canonicalHostNameProd, DateTime fiscalYearStartDate, bool useFiscalYears, bool arePerformanceMeasuresExternallySourced, bool areOrganizationsExternallySourced, bool areFundingSourcesExternallySourced, bool tenantEnabled) : base(tenantID, tenantName, canonicalHostNameLocal, canonicalHostNameQa, canonicalHostNameProd, fiscalYearStartDate, useFiscalYears, arePerformanceMeasuresExternallySourced, areOrganizationsExternallySourced, areFundingSourcesExternallySourced, tenantEnabled) {}
        public static readonly TenantAshlandForestAllLandsRestorationInitiative Instance = new TenantAshlandForestAllLandsRestorationInitiative(8, @"AshlandForestAllLandsRestorationInitiative", @"ashlanddemo.localhost.projectfirma.com", @"ashlanddemo.qa.projectfirma.com", @"ashlanddemo.projectfirma.com", DateTime.Parse("01/01/1990"), false, false, false, false, false);
    }

    public partial class TenantIdahoAssociatonOfSoilConservationDistricts : Tenant
    {
        private TenantIdahoAssociatonOfSoilConservationDistricts(int tenantID, string tenantName, string canonicalHostNameLocal, string canonicalHostNameQa, string canonicalHostNameProd, DateTime fiscalYearStartDate, bool useFiscalYears, bool arePerformanceMeasuresExternallySourced, bool areOrganizationsExternallySourced, bool areFundingSourcesExternallySourced, bool tenantEnabled) : base(tenantID, tenantName, canonicalHostNameLocal, canonicalHostNameQa, canonicalHostNameProd, fiscalYearStartDate, useFiscalYears, arePerformanceMeasuresExternallySourced, areOrganizationsExternallySourced, areFundingSourcesExternallySourced, tenantEnabled) {}
        public static readonly TenantIdahoAssociatonOfSoilConservationDistricts Instance = new TenantIdahoAssociatonOfSoilConservationDistricts(9, @"IdahoAssociatonOfSoilConservationDistricts", @"swcdemo.localhost.projectfirma.com", @"swcdemo.qa.projectfirma.com", @"conservation.idaho.gov", DateTime.Parse("07/01/1990"), true, false, false, false, false);
    }

    public partial class TenantActionAgendaForPugetSound : Tenant
    {
        private TenantActionAgendaForPugetSound(int tenantID, string tenantName, string canonicalHostNameLocal, string canonicalHostNameQa, string canonicalHostNameProd, DateTime fiscalYearStartDate, bool useFiscalYears, bool arePerformanceMeasuresExternallySourced, bool areOrganizationsExternallySourced, bool areFundingSourcesExternallySourced, bool tenantEnabled) : base(tenantID, tenantName, canonicalHostNameLocal, canonicalHostNameQa, canonicalHostNameProd, fiscalYearStartDate, useFiscalYears, arePerformanceMeasuresExternallySourced, areOrganizationsExternallySourced, areFundingSourcesExternallySourced, tenantEnabled) {}
        public static readonly TenantActionAgendaForPugetSound Instance = new TenantActionAgendaForPugetSound(11, @"ActionAgendaForPugetSound", @"actionagendatracker.localhost.projectfirma.com", @"qa-actionagendatracker.pugetsoundinfo.wa.gov", @"actionagendatracker.pugetsoundinfo.wa.gov", DateTime.Parse("01/01/1990"), false, true, true, true, false);
    }

    public partial class TenantBureauOfReclamation : Tenant
    {
        private TenantBureauOfReclamation(int tenantID, string tenantName, string canonicalHostNameLocal, string canonicalHostNameQa, string canonicalHostNameProd, DateTime fiscalYearStartDate, bool useFiscalYears, bool arePerformanceMeasuresExternallySourced, bool areOrganizationsExternallySourced, bool areFundingSourcesExternallySourced, bool tenantEnabled) : base(tenantID, tenantName, canonicalHostNameLocal, canonicalHostNameQa, canonicalHostNameProd, fiscalYearStartDate, useFiscalYears, arePerformanceMeasuresExternallySourced, areOrganizationsExternallySourced, areFundingSourcesExternallySourced, tenantEnabled) {}
        public static readonly TenantBureauOfReclamation Instance = new TenantBureauOfReclamation(12, @"BureauOfReclamation", @"OBSOLETE_HOSTED_INDEPENDENTLY_bor.localhost.projectfirma.com", @"OBSOLETE_HOSTED_INDEPENDENTLY_bor.qa.projectfirma.com", @"OBSOLETE_HOSTED_INDEPENDENTLY_bor.projectfirma.com", DateTime.Parse("01/01/1990"), false, false, false, false, false);
    }

    public partial class TenantSSMPProjectTracker : Tenant
    {
        private TenantSSMPProjectTracker(int tenantID, string tenantName, string canonicalHostNameLocal, string canonicalHostNameQa, string canonicalHostNameProd, DateTime fiscalYearStartDate, bool useFiscalYears, bool arePerformanceMeasuresExternallySourced, bool areOrganizationsExternallySourced, bool areFundingSourcesExternallySourced, bool tenantEnabled) : base(tenantID, tenantName, canonicalHostNameLocal, canonicalHostNameQa, canonicalHostNameProd, fiscalYearStartDate, useFiscalYears, arePerformanceMeasuresExternallySourced, areOrganizationsExternallySourced, areFundingSourcesExternallySourced, tenantEnabled) {}
        public static readonly TenantSSMPProjectTracker Instance = new TenantSSMPProjectTracker(13, @"SSMPProjectTracker", @"SaltonSeaProjects.localhost.projectfirma.com", @"SaltonSeaProjects.qa.projectfirma.com", @"projects.saltonsea.ca.gov", DateTime.Parse("01/01/1990"), false, false, false, false, true);
    }

    public partial class TenantTCSProjectTracker : Tenant
    {
        private TenantTCSProjectTracker(int tenantID, string tenantName, string canonicalHostNameLocal, string canonicalHostNameQa, string canonicalHostNameProd, DateTime fiscalYearStartDate, bool useFiscalYears, bool arePerformanceMeasuresExternallySourced, bool areOrganizationsExternallySourced, bool areFundingSourcesExternallySourced, bool tenantEnabled) : base(tenantID, tenantName, canonicalHostNameLocal, canonicalHostNameQa, canonicalHostNameProd, fiscalYearStartDate, useFiscalYears, arePerformanceMeasuresExternallySourced, areOrganizationsExternallySourced, areFundingSourcesExternallySourced, tenantEnabled) {}
        public static readonly TenantTCSProjectTracker Instance = new TenantTCSProjectTracker(14, @"TCSProjectTracker", @"tcsprojecttracker.localhost.projectfirma.com", @"tcsprojecttracker.qa.projectfirma.com", @"projecttracker.tahoecentralsierra.org", DateTime.Parse("01/01/1990"), false, false, false, false, true);
    }
}