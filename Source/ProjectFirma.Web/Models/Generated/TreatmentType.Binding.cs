//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[TreatmentType]
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
    public abstract partial class TreatmentType : IHavePrimaryKey
    {
        public static readonly TreatmentTypeToDo ToDo = TreatmentTypeToDo.Instance;

        public static readonly List<TreatmentType> All;
        public static readonly ReadOnlyDictionary<int, TreatmentType> AllLookupDictionary;

        /// <summary>
        /// Static type constructor to coordinate static initialization order
        /// </summary>
        static TreatmentType()
        {
            All = new List<TreatmentType> { ToDo };
            AllLookupDictionary = new ReadOnlyDictionary<int, TreatmentType>(All.ToDictionary(x => x.TreatmentTypeID));
        }

        /// <summary>
        /// Protected constructor only for use in instantiating the set of static lookup values that match database
        /// </summary>
        protected TreatmentType(int treatmentTypeID, string treatmentTypeName, string treatmentTypeDisplayName)
        {
            TreatmentTypeID = treatmentTypeID;
            TreatmentTypeName = treatmentTypeName;
            TreatmentTypeDisplayName = treatmentTypeDisplayName;
        }

        [Key]
        public int TreatmentTypeID { get; private set; }
        public string TreatmentTypeName { get; private set; }
        public string TreatmentTypeDisplayName { get; private set; }
        [NotMapped]
        public int PrimaryKey { get { return TreatmentTypeID; } }

        /// <summary>
        /// Enum types are equal by primary key
        /// </summary>
        public bool Equals(TreatmentType other)
        {
            if (other == null)
            {
                return false;
            }
            return other.TreatmentTypeID == TreatmentTypeID;
        }

        /// <summary>
        /// Enum types are equal by primary key
        /// </summary>
        public override bool Equals(object obj)
        {
            return Equals(obj as TreatmentType);
        }

        /// <summary>
        /// Enum types are equal by primary key
        /// </summary>
        public override int GetHashCode()
        {
            return TreatmentTypeID;
        }

        public static bool operator ==(TreatmentType left, TreatmentType right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(TreatmentType left, TreatmentType right)
        {
            return !Equals(left, right);
        }

        public TreatmentTypeEnum ToEnum { get { return (TreatmentTypeEnum)GetHashCode(); } }

        public static TreatmentType ToType(int enumValue)
        {
            return ToType((TreatmentTypeEnum)enumValue);
        }

        public static TreatmentType ToType(TreatmentTypeEnum enumValue)
        {
            switch (enumValue)
            {
                case TreatmentTypeEnum.ToDo:
                    return ToDo;
                default:
                    throw new ArgumentException(string.Format("Unable to map Enum: {0}", enumValue));
            }
        }
    }

    public enum TreatmentTypeEnum
    {
        ToDo = 1
    }

    public partial class TreatmentTypeToDo : TreatmentType
    {
        private TreatmentTypeToDo(int treatmentTypeID, string treatmentTypeName, string treatmentTypeDisplayName) : base(treatmentTypeID, treatmentTypeName, treatmentTypeDisplayName) {}
        public static readonly TreatmentTypeToDo Instance = new TreatmentTypeToDo(1, @"ToDo", @"To-do");
    }
}