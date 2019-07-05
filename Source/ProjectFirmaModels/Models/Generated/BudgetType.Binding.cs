//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[BudgetType]
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Linq;
using System.Web;
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public abstract partial class BudgetType : IHavePrimaryKey
    {
        public static readonly BudgetTypeNoBudget NoBudget = BudgetTypeNoBudget.Instance;
        public static readonly BudgetTypeSimpleBudget SimpleBudget = BudgetTypeSimpleBudget.Instance;
        public static readonly BudgetTypeAnnualBudget AnnualBudget = BudgetTypeAnnualBudget.Instance;
        public static readonly BudgetTypeAnnualBudgetByCostType AnnualBudgetByCostType = BudgetTypeAnnualBudgetByCostType.Instance;

        public static readonly List<BudgetType> All;
        public static readonly ReadOnlyDictionary<int, BudgetType> AllLookupDictionary;

        /// <summary>
        /// Static type constructor to coordinate static initialization order
        /// </summary>
        static BudgetType()
        {
            All = new List<BudgetType> { NoBudget, SimpleBudget, AnnualBudget, AnnualBudgetByCostType };
            AllLookupDictionary = new ReadOnlyDictionary<int, BudgetType>(All.ToDictionary(x => x.BudgetTypeID));
        }

        /// <summary>
        /// Protected constructor only for use in instantiating the set of static lookup values that match database
        /// </summary>
        protected BudgetType(int budgetTypeID, string budgetTypeName, string budgetTypeDisplayName, string budgetTypeDescription)
        {
            BudgetTypeID = budgetTypeID;
            BudgetTypeName = budgetTypeName;
            BudgetTypeDisplayName = budgetTypeDisplayName;
            BudgetTypeDescription = budgetTypeDescription;
        }

        [Key]
        public int BudgetTypeID { get; private set; }
        public string BudgetTypeName { get; private set; }
        public string BudgetTypeDisplayName { get; private set; }
        public string BudgetTypeDescription { get; private set; }
        [NotMapped]
        public int PrimaryKey { get { return BudgetTypeID; } }

        /// <summary>
        /// Enum types are equal by primary key
        /// </summary>
        public bool Equals(BudgetType other)
        {
            if (other == null)
            {
                return false;
            }
            return other.BudgetTypeID == BudgetTypeID;
        }

        /// <summary>
        /// Enum types are equal by primary key
        /// </summary>
        public override bool Equals(object obj)
        {
            return Equals(obj as BudgetType);
        }

        /// <summary>
        /// Enum types are equal by primary key
        /// </summary>
        public override int GetHashCode()
        {
            return BudgetTypeID;
        }

        public static bool operator ==(BudgetType left, BudgetType right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(BudgetType left, BudgetType right)
        {
            return !Equals(left, right);
        }

        public BudgetTypeEnum ToEnum { get { return (BudgetTypeEnum)GetHashCode(); } }

        public static BudgetType ToType(int enumValue)
        {
            return ToType((BudgetTypeEnum)enumValue);
        }

        public static BudgetType ToType(BudgetTypeEnum enumValue)
        {
            switch (enumValue)
            {
                case BudgetTypeEnum.AnnualBudget:
                    return AnnualBudget;
                case BudgetTypeEnum.AnnualBudgetByCostType:
                    return AnnualBudgetByCostType;
                case BudgetTypeEnum.NoBudget:
                    return NoBudget;
                case BudgetTypeEnum.SimpleBudget:
                    return SimpleBudget;
                default:
                    throw new ArgumentException(string.Format("Unable to map Enum: {0}", enumValue));
            }
        }
    }

    public enum BudgetTypeEnum
    {
        NoBudget = 1,
        SimpleBudget = 2,
        AnnualBudget = 3,
        AnnualBudgetByCostType = 4
    }

    public partial class BudgetTypeNoBudget : BudgetType
    {
        private BudgetTypeNoBudget(int budgetTypeID, string budgetTypeName, string budgetTypeDisplayName, string budgetTypeDescription) : base(budgetTypeID, budgetTypeName, budgetTypeDisplayName, budgetTypeDescription) {}
        public static readonly BudgetTypeNoBudget Instance = new BudgetTypeNoBudget(1, @"NoBudget", @"No Budget", @"No project budget information will be provided.");
    }

    public partial class BudgetTypeSimpleBudget : BudgetType
    {
        private BudgetTypeSimpleBudget(int budgetTypeID, string budgetTypeName, string budgetTypeDisplayName, string budgetTypeDescription) : base(budgetTypeID, budgetTypeName, budgetTypeDisplayName, budgetTypeDescription) {}
        public static readonly BudgetTypeSimpleBudget Instance = new BudgetTypeSimpleBudget(2, @"SimpleBudget", @"Simple Budget", @"Enter project budgets by funding source.");
    }

    public partial class BudgetTypeAnnualBudget : BudgetType
    {
        private BudgetTypeAnnualBudget(int budgetTypeID, string budgetTypeName, string budgetTypeDisplayName, string budgetTypeDescription) : base(budgetTypeID, budgetTypeName, budgetTypeDisplayName, budgetTypeDescription) {}
        public static readonly BudgetTypeAnnualBudget Instance = new BudgetTypeAnnualBudget(3, @"AnnualBudget", @"Annual Budget", @"Enter project budgets by year and funding source");
    }

    public partial class BudgetTypeAnnualBudgetByCostType : BudgetType
    {
        private BudgetTypeAnnualBudgetByCostType(int budgetTypeID, string budgetTypeName, string budgetTypeDisplayName, string budgetTypeDescription) : base(budgetTypeID, budgetTypeName, budgetTypeDisplayName, budgetTypeDescription) {}
        public static readonly BudgetTypeAnnualBudgetByCostType Instance = new BudgetTypeAnnualBudgetByCostType(4, @"AnnualBudgetByCostType", @"Annual Budget by Cost Type", @"Enter project budgets by year, funding source, and cost type.");
    }
}