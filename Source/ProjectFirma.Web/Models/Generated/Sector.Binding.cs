//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[Sector]
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Models
{
    public abstract partial class Sector : IHavePrimaryKey
    {
        public static readonly SectorFederal Federal = SectorFederal.Instance;
        public static readonly SectorLocal Local = SectorLocal.Instance;
        public static readonly SectorPrivate Private = SectorPrivate.Instance;
        public static readonly SectorState State = SectorState.Instance;

        public static readonly List<Sector> All;
        public static readonly ReadOnlyDictionary<int, Sector> AllLookupDictionary;

        /// <summary>
        /// Static type constructor to coordinate static initialization order
        /// </summary>
        static Sector()
        {
            All = new List<Sector> { Federal, Local, Private, State };
            AllLookupDictionary = new ReadOnlyDictionary<int, Sector>(All.ToDictionary(x => x.SectorID));
        }

        /// <summary>
        /// Protected constructor only for use in instantiating the set of static lookup values that match database
        /// </summary>
        protected Sector(int sectorID, string sectorName, string sectorDisplayName, string sectorAbbreviation, string legendColor)
        {
            SectorID = sectorID;
            SectorName = sectorName;
            SectorDisplayName = sectorDisplayName;
            SectorAbbreviation = sectorAbbreviation;
            LegendColor = legendColor;
        }

        [Key]
        public int SectorID { get; private set; }
        public string SectorName { get; private set; }
        public string SectorDisplayName { get; private set; }
        public string SectorAbbreviation { get; private set; }
        public string LegendColor { get; private set; }
        public int PrimaryKey { get { return SectorID; } }

        /// <summary>
        /// Enum types are equal by primary key
        /// </summary>
        public bool Equals(Sector other)
        {
            if (other == null)
            {
                return false;
            }
            return other.SectorID == SectorID;
        }

        /// <summary>
        /// Enum types are equal by primary key
        /// </summary>
        public override bool Equals(object obj)
        {
            return Equals(obj as Sector);
        }

        /// <summary>
        /// Enum types are equal by primary key
        /// </summary>
        public override int GetHashCode()
        {
            return SectorID;
        }

        public static bool operator ==(Sector left, Sector right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Sector left, Sector right)
        {
            return !Equals(left, right);
        }

        public SectorEnum ToEnum { get { return (SectorEnum)GetHashCode(); } }

        public static Sector ToType(int enumValue)
        {
            return ToType((SectorEnum)enumValue);
        }

        public static Sector ToType(SectorEnum enumValue)
        {
            switch (enumValue)
            {
                case SectorEnum.Federal:
                    return Federal;
                case SectorEnum.Local:
                    return Local;
                case SectorEnum.Private:
                    return Private;
                case SectorEnum.State:
                    return State;
                default:
                    throw new ArgumentException(string.Format("Unable to map Enum: {0}", enumValue));
            }
        }
    }

    public enum SectorEnum
    {
        Federal = 1,
        Local = 2,
        Private = 3,
        State = 4
    }

    public partial class SectorFederal : Sector
    {
        private SectorFederal(int sectorID, string sectorName, string sectorDisplayName, string sectorAbbreviation, string legendColor) : base(sectorID, sectorName, sectorDisplayName, sectorAbbreviation, legendColor) {}
        public static readonly SectorFederal Instance = new SectorFederal(1, @"Federal", @"Federal", @"FED", @"#1f77b4");
    }

    public partial class SectorLocal : Sector
    {
        private SectorLocal(int sectorID, string sectorName, string sectorDisplayName, string sectorAbbreviation, string legendColor) : base(sectorID, sectorName, sectorDisplayName, sectorAbbreviation, legendColor) {}
        public static readonly SectorLocal Instance = new SectorLocal(2, @"Local", @"Local", @"LOC", @"#aec7e8");
    }

    public partial class SectorPrivate : Sector
    {
        private SectorPrivate(int sectorID, string sectorName, string sectorDisplayName, string sectorAbbreviation, string legendColor) : base(sectorID, sectorName, sectorDisplayName, sectorAbbreviation, legendColor) {}
        public static readonly SectorPrivate Instance = new SectorPrivate(3, @"Private", @"Private", @"PRI", @"#ff7f0e");
    }

    public partial class SectorState : Sector
    {
        private SectorState(int sectorID, string sectorName, string sectorDisplayName, string sectorAbbreviation, string legendColor) : base(sectorID, sectorName, sectorDisplayName, sectorAbbreviation, legendColor) {}
        public static readonly SectorState Instance = new SectorState(4, @"State", @"State", @"ST", @"#ffbb78");
    }
}