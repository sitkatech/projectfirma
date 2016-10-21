//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[BaileyRating]
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
    public abstract partial class BaileyRating : IHavePrimaryKey
    {
        public static readonly BaileyRatinga_1 a_1 = BaileyRatinga_1.Instance;
        public static readonly BaileyRatingb_1 b_1 = BaileyRatingb_1.Instance;
        public static readonly BaileyRatingc_1 c_1 = BaileyRatingc_1.Instance;
        public static readonly BaileyRating_2 _2 = BaileyRating_2.Instance;
        public static readonly BaileyRating_3 _3 = BaileyRating_3.Instance;
        public static readonly BaileyRating_4 _4 = BaileyRating_4.Instance;
        public static readonly BaileyRating_5 _5 = BaileyRating_5.Instance;
        public static readonly BaileyRating_6 _6 = BaileyRating_6.Instance;
        public static readonly BaileyRating_7 _7 = BaileyRating_7.Instance;

        public static readonly List<BaileyRating> All;
        public static readonly ReadOnlyDictionary<int, BaileyRating> AllLookupDictionary;

        /// <summary>
        /// Static type constructor to coordinate static initialization order
        /// </summary>
        static BaileyRating()
        {
            All = new List<BaileyRating> { a_1, b_1, c_1, _2, _3, _4, _5, _6, _7 };
            AllLookupDictionary = new ReadOnlyDictionary<int, BaileyRating>(All.ToDictionary(x => x.BaileyRatingID));
        }

        /// <summary>
        /// Protected constructor only for use in instantiating the set of static lookup values that match database
        /// </summary>
        protected BaileyRating(int baileyRatingID, string baileyRatingName, string baileyRatingDisplayName)
        {
            BaileyRatingID = baileyRatingID;
            BaileyRatingName = baileyRatingName;
            BaileyRatingDisplayName = baileyRatingDisplayName;
        }

        [Key]
        public int BaileyRatingID { get; private set; }
        public string BaileyRatingName { get; private set; }
        public string BaileyRatingDisplayName { get; private set; }
        public int PrimaryKey { get { return BaileyRatingID; } }

        /// <summary>
        /// Enum types are equal by primary key
        /// </summary>
        public bool Equals(BaileyRating other)
        {
            if (other == null)
            {
                return false;
            }
            return other.BaileyRatingID == BaileyRatingID;
        }

        /// <summary>
        /// Enum types are equal by primary key
        /// </summary>
        public override bool Equals(object obj)
        {
            return Equals(obj as BaileyRating);
        }

        /// <summary>
        /// Enum types are equal by primary key
        /// </summary>
        public override int GetHashCode()
        {
            return BaileyRatingID;
        }

        public static bool operator ==(BaileyRating left, BaileyRating right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(BaileyRating left, BaileyRating right)
        {
            return !Equals(left, right);
        }

        public BaileyRatingEnum ToEnum { get { return (BaileyRatingEnum)GetHashCode(); } }

        public static BaileyRating ToType(int enumValue)
        {
            return ToType((BaileyRatingEnum)enumValue);
        }

        public static BaileyRating ToType(BaileyRatingEnum enumValue)
        {
            switch (enumValue)
            {
                case BaileyRatingEnum.a_1:
                    return a_1;
                case BaileyRatingEnum.b_1:
                    return b_1;
                case BaileyRatingEnum.c_1:
                    return c_1;
                case BaileyRatingEnum._2:
                    return _2;
                case BaileyRatingEnum._3:
                    return _3;
                case BaileyRatingEnum._4:
                    return _4;
                case BaileyRatingEnum._5:
                    return _5;
                case BaileyRatingEnum._6:
                    return _6;
                case BaileyRatingEnum._7:
                    return _7;
                default:
                    throw new ArgumentException(string.Format("Unable to map Enum: {0}", enumValue));
            }
        }
    }

    public enum BaileyRatingEnum
    {
        a_1 = 1,
        b_1 = 2,
        c_1 = 3,
        _2 = 4,
        _3 = 5,
        _4 = 6,
        _5 = 7,
        _6 = 8,
        _7 = 9
    }

    public partial class BaileyRatinga_1 : BaileyRating
    {
        private BaileyRatinga_1(int baileyRatingID, string baileyRatingName, string baileyRatingDisplayName) : base(baileyRatingID, baileyRatingName, baileyRatingDisplayName) {}
        public static readonly BaileyRatinga_1 Instance = new BaileyRatinga_1(1, @"1a", @"1a");
    }

    public partial class BaileyRatingb_1 : BaileyRating
    {
        private BaileyRatingb_1(int baileyRatingID, string baileyRatingName, string baileyRatingDisplayName) : base(baileyRatingID, baileyRatingName, baileyRatingDisplayName) {}
        public static readonly BaileyRatingb_1 Instance = new BaileyRatingb_1(2, @"1b", @"1b");
    }

    public partial class BaileyRatingc_1 : BaileyRating
    {
        private BaileyRatingc_1(int baileyRatingID, string baileyRatingName, string baileyRatingDisplayName) : base(baileyRatingID, baileyRatingName, baileyRatingDisplayName) {}
        public static readonly BaileyRatingc_1 Instance = new BaileyRatingc_1(3, @"1c", @"1c");
    }

    public partial class BaileyRating_2 : BaileyRating
    {
        private BaileyRating_2(int baileyRatingID, string baileyRatingName, string baileyRatingDisplayName) : base(baileyRatingID, baileyRatingName, baileyRatingDisplayName) {}
        public static readonly BaileyRating_2 Instance = new BaileyRating_2(4, @"2", @"2");
    }

    public partial class BaileyRating_3 : BaileyRating
    {
        private BaileyRating_3(int baileyRatingID, string baileyRatingName, string baileyRatingDisplayName) : base(baileyRatingID, baileyRatingName, baileyRatingDisplayName) {}
        public static readonly BaileyRating_3 Instance = new BaileyRating_3(5, @"3", @"3");
    }

    public partial class BaileyRating_4 : BaileyRating
    {
        private BaileyRating_4(int baileyRatingID, string baileyRatingName, string baileyRatingDisplayName) : base(baileyRatingID, baileyRatingName, baileyRatingDisplayName) {}
        public static readonly BaileyRating_4 Instance = new BaileyRating_4(6, @"4", @"4");
    }

    public partial class BaileyRating_5 : BaileyRating
    {
        private BaileyRating_5(int baileyRatingID, string baileyRatingName, string baileyRatingDisplayName) : base(baileyRatingID, baileyRatingName, baileyRatingDisplayName) {}
        public static readonly BaileyRating_5 Instance = new BaileyRating_5(7, @"5", @"5");
    }

    public partial class BaileyRating_6 : BaileyRating
    {
        private BaileyRating_6(int baileyRatingID, string baileyRatingName, string baileyRatingDisplayName) : base(baileyRatingID, baileyRatingName, baileyRatingDisplayName) {}
        public static readonly BaileyRating_6 Instance = new BaileyRating_6(8, @"6", @"6");
    }

    public partial class BaileyRating_7 : BaileyRating
    {
        private BaileyRating_7(int baileyRatingID, string baileyRatingName, string baileyRatingDisplayName) : base(baileyRatingID, baileyRatingName, baileyRatingDisplayName) {}
        public static readonly BaileyRating_7 Instance = new BaileyRating_7(9, @"7", @"7");
    }
}