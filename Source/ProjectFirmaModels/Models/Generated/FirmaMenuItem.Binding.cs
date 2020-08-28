//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[FirmaMenuItem]
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
    public abstract partial class FirmaMenuItem : IHavePrimaryKey
    {
        public static readonly FirmaMenuItemAbout About = FirmaMenuItemAbout.Instance;
        public static readonly FirmaMenuItemProjects Projects = FirmaMenuItemProjects.Instance;
        public static readonly FirmaMenuItemProgramInfo ProgramInfo = FirmaMenuItemProgramInfo.Instance;
        public static readonly FirmaMenuItemResults Results = FirmaMenuItemResults.Instance;

        public static readonly List<FirmaMenuItem> All;
        public static readonly ReadOnlyDictionary<int, FirmaMenuItem> AllLookupDictionary;

        /// <summary>
        /// Static type constructor to coordinate static initialization order
        /// </summary>
        static FirmaMenuItem()
        {
            All = new List<FirmaMenuItem> { About, Projects, ProgramInfo, Results };
            AllLookupDictionary = new ReadOnlyDictionary<int, FirmaMenuItem>(All.ToDictionary(x => x.FirmaMenuItemID));
        }

        /// <summary>
        /// Protected constructor only for use in instantiating the set of static lookup values that match database
        /// </summary>
        protected FirmaMenuItem(int firmaMenuItemID, string firmaMenuItemName, string firmaMenuItemDisplayName)
        {
            FirmaMenuItemID = firmaMenuItemID;
            FirmaMenuItemName = firmaMenuItemName;
            FirmaMenuItemDisplayName = firmaMenuItemDisplayName;
        }

        [Key]
        public int FirmaMenuItemID { get; private set; }
        public string FirmaMenuItemName { get; private set; }
        public string FirmaMenuItemDisplayName { get; private set; }
        [NotMapped]
        public int PrimaryKey { get { return FirmaMenuItemID; } }

        /// <summary>
        /// Enum types are equal by primary key
        /// </summary>
        public bool Equals(FirmaMenuItem other)
        {
            if (other == null)
            {
                return false;
            }
            return other.FirmaMenuItemID == FirmaMenuItemID;
        }

        /// <summary>
        /// Enum types are equal by primary key
        /// </summary>
        public override bool Equals(object obj)
        {
            return Equals(obj as FirmaMenuItem);
        }

        /// <summary>
        /// Enum types are equal by primary key
        /// </summary>
        public override int GetHashCode()
        {
            return FirmaMenuItemID;
        }

        public static bool operator ==(FirmaMenuItem left, FirmaMenuItem right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(FirmaMenuItem left, FirmaMenuItem right)
        {
            return !Equals(left, right);
        }

        public FirmaMenuItemEnum ToEnum { get { return (FirmaMenuItemEnum)GetHashCode(); } }

        public static FirmaMenuItem ToType(int enumValue)
        {
            return ToType((FirmaMenuItemEnum)enumValue);
        }

        public static FirmaMenuItem ToType(FirmaMenuItemEnum enumValue)
        {
            switch (enumValue)
            {
                case FirmaMenuItemEnum.About:
                    return About;
                case FirmaMenuItemEnum.ProgramInfo:
                    return ProgramInfo;
                case FirmaMenuItemEnum.Projects:
                    return Projects;
                case FirmaMenuItemEnum.Results:
                    return Results;
                default:
                    throw new ArgumentException(string.Format("Unable to map Enum: {0}", enumValue));
            }
        }
    }

    public enum FirmaMenuItemEnum
    {
        About = 1,
        Projects = 2,
        ProgramInfo = 3,
        Results = 4
    }

    public partial class FirmaMenuItemAbout : FirmaMenuItem
    {
        private FirmaMenuItemAbout(int firmaMenuItemID, string firmaMenuItemName, string firmaMenuItemDisplayName) : base(firmaMenuItemID, firmaMenuItemName, firmaMenuItemDisplayName) {}
        public static readonly FirmaMenuItemAbout Instance = new FirmaMenuItemAbout(1, @"About", @"About");
    }

    public partial class FirmaMenuItemProjects : FirmaMenuItem
    {
        private FirmaMenuItemProjects(int firmaMenuItemID, string firmaMenuItemName, string firmaMenuItemDisplayName) : base(firmaMenuItemID, firmaMenuItemName, firmaMenuItemDisplayName) {}
        public static readonly FirmaMenuItemProjects Instance = new FirmaMenuItemProjects(2, @"Projects", @"Projects");
    }

    public partial class FirmaMenuItemProgramInfo : FirmaMenuItem
    {
        private FirmaMenuItemProgramInfo(int firmaMenuItemID, string firmaMenuItemName, string firmaMenuItemDisplayName) : base(firmaMenuItemID, firmaMenuItemName, firmaMenuItemDisplayName) {}
        public static readonly FirmaMenuItemProgramInfo Instance = new FirmaMenuItemProgramInfo(3, @"ProgramInfo", @"Program Info");
    }

    public partial class FirmaMenuItemResults : FirmaMenuItem
    {
        private FirmaMenuItemResults(int firmaMenuItemID, string firmaMenuItemName, string firmaMenuItemDisplayName) : base(firmaMenuItemID, firmaMenuItemName, firmaMenuItemDisplayName) {}
        public static readonly FirmaMenuItemResults Instance = new FirmaMenuItemResults(4, @"Results", @"Results");
    }
}