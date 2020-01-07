//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[EvaluationVisibility]
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
    public abstract partial class EvaluationVisibility : IHavePrimaryKey
    {
        public static readonly EvaluationVisibilityOnlyMe OnlyMe = EvaluationVisibilityOnlyMe.Instance;
        public static readonly EvaluationVisibilityAdminsFromMyOrganizationOnly AdminsFromMyOrganizationOnly = EvaluationVisibilityAdminsFromMyOrganizationOnly.Instance;
        public static readonly EvaluationVisibilityAllAdmins AllAdmins = EvaluationVisibilityAllAdmins.Instance;

        public static readonly List<EvaluationVisibility> All;
        public static readonly ReadOnlyDictionary<int, EvaluationVisibility> AllLookupDictionary;

        /// <summary>
        /// Static type constructor to coordinate static initialization order
        /// </summary>
        static EvaluationVisibility()
        {
            All = new List<EvaluationVisibility> { OnlyMe, AdminsFromMyOrganizationOnly, AllAdmins };
            AllLookupDictionary = new ReadOnlyDictionary<int, EvaluationVisibility>(All.ToDictionary(x => x.EvaluationVisibilityID));
        }

        /// <summary>
        /// Protected constructor only for use in instantiating the set of static lookup values that match database
        /// </summary>
        protected EvaluationVisibility(int evaluationVisibilityID, string evaluationVisibilityName, string evaluationVisibilityDisplayName)
        {
            EvaluationVisibilityID = evaluationVisibilityID;
            EvaluationVisibilityName = evaluationVisibilityName;
            EvaluationVisibilityDisplayName = evaluationVisibilityDisplayName;
        }

        [Key]
        public int EvaluationVisibilityID { get; private set; }
        public string EvaluationVisibilityName { get; private set; }
        public string EvaluationVisibilityDisplayName { get; private set; }
        [NotMapped]
        public int PrimaryKey { get { return EvaluationVisibilityID; } }

        /// <summary>
        /// Enum types are equal by primary key
        /// </summary>
        public bool Equals(EvaluationVisibility other)
        {
            if (other == null)
            {
                return false;
            }
            return other.EvaluationVisibilityID == EvaluationVisibilityID;
        }

        /// <summary>
        /// Enum types are equal by primary key
        /// </summary>
        public override bool Equals(object obj)
        {
            return Equals(obj as EvaluationVisibility);
        }

        /// <summary>
        /// Enum types are equal by primary key
        /// </summary>
        public override int GetHashCode()
        {
            return EvaluationVisibilityID;
        }

        public static bool operator ==(EvaluationVisibility left, EvaluationVisibility right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(EvaluationVisibility left, EvaluationVisibility right)
        {
            return !Equals(left, right);
        }

        public EvaluationVisibilityEnum ToEnum { get { return (EvaluationVisibilityEnum)GetHashCode(); } }

        public static EvaluationVisibility ToType(int enumValue)
        {
            return ToType((EvaluationVisibilityEnum)enumValue);
        }

        public static EvaluationVisibility ToType(EvaluationVisibilityEnum enumValue)
        {
            switch (enumValue)
            {
                case EvaluationVisibilityEnum.AdminsFromMyOrganizationOnly:
                    return AdminsFromMyOrganizationOnly;
                case EvaluationVisibilityEnum.AllAdmins:
                    return AllAdmins;
                case EvaluationVisibilityEnum.OnlyMe:
                    return OnlyMe;
                default:
                    throw new ArgumentException(string.Format("Unable to map Enum: {0}", enumValue));
            }
        }
    }

    public enum EvaluationVisibilityEnum
    {
        OnlyMe = 1,
        AdminsFromMyOrganizationOnly = 2,
        AllAdmins = 3
    }

    public partial class EvaluationVisibilityOnlyMe : EvaluationVisibility
    {
        private EvaluationVisibilityOnlyMe(int evaluationVisibilityID, string evaluationVisibilityName, string evaluationVisibilityDisplayName) : base(evaluationVisibilityID, evaluationVisibilityName, evaluationVisibilityDisplayName) {}
        public static readonly EvaluationVisibilityOnlyMe Instance = new EvaluationVisibilityOnlyMe(1, @"OnlyMe", @"Only Me");
    }

    public partial class EvaluationVisibilityAdminsFromMyOrganizationOnly : EvaluationVisibility
    {
        private EvaluationVisibilityAdminsFromMyOrganizationOnly(int evaluationVisibilityID, string evaluationVisibilityName, string evaluationVisibilityDisplayName) : base(evaluationVisibilityID, evaluationVisibilityName, evaluationVisibilityDisplayName) {}
        public static readonly EvaluationVisibilityAdminsFromMyOrganizationOnly Instance = new EvaluationVisibilityAdminsFromMyOrganizationOnly(2, @"AdminsFromMyOrganizationOnly", @"Admins from my Org only");
    }

    public partial class EvaluationVisibilityAllAdmins : EvaluationVisibility
    {
        private EvaluationVisibilityAllAdmins(int evaluationVisibilityID, string evaluationVisibilityName, string evaluationVisibilityDisplayName) : base(evaluationVisibilityID, evaluationVisibilityName, evaluationVisibilityDisplayName) {}
        public static readonly EvaluationVisibilityAllAdmins Instance = new EvaluationVisibilityAllAdmins(3, @"AllAdmins", @"All Admins");
    }
}