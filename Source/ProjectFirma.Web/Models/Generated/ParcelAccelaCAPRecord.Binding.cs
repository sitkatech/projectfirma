//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ParcelAccelaCAPRecord]
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.Data.Entity.Spatial;
using System.Linq;
using System.Web;
using ProjectFirma.Web.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirma.Web.Models
{
    [Table("[dbo].[ParcelAccelaCAPRecord]")]
    public partial class ParcelAccelaCAPRecord : IHavePrimaryKey
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected ParcelAccelaCAPRecord()
        {

        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public ParcelAccelaCAPRecord(int parcelAccelaCAPRecordID, int parcelID, int accelaCAPRecordID) : this()
        {
            this.ParcelAccelaCAPRecordID = parcelAccelaCAPRecordID;
            this.ParcelID = parcelID;
            this.AccelaCAPRecordID = accelaCAPRecordID;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields in preparation for insert into database
        /// </summary>
        public ParcelAccelaCAPRecord(int parcelID, int accelaCAPRecordID) : this()
        {
            // Mark this as a new object by setting primary key with special value
            ParcelAccelaCAPRecordID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            
            this.ParcelID = parcelID;
            this.AccelaCAPRecordID = accelaCAPRecordID;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields, using objects whenever possible
        /// </summary>
        public ParcelAccelaCAPRecord(Parcel parcel, AccelaCAPRecord accelaCAPRecord) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.ParcelAccelaCAPRecordID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            this.ParcelID = parcel.ParcelID;
            this.Parcel = parcel;
            parcel.ParcelAccelaCAPRecords.Add(this);
            this.AccelaCAPRecordID = accelaCAPRecord.AccelaCAPRecordID;
            this.AccelaCAPRecord = accelaCAPRecord;
            accelaCAPRecord.ParcelAccelaCAPRecords.Add(this);
        }

        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static ParcelAccelaCAPRecord CreateNewBlank(Parcel parcel, AccelaCAPRecord accelaCAPRecord)
        {
            return new ParcelAccelaCAPRecord(parcel, accelaCAPRecord);
        }

        /// <summary>
        /// Does this object have any dependent objects? (If it does have dependent objects, these would need to be deleted before this object could be deleted.)
        /// </summary>
        /// <returns></returns>
        public bool HasDependentObjects()
        {
            return false;
        }

        /// <summary>
        /// Dependent type names of this entity
        /// </summary>
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(ParcelAccelaCAPRecord).Name};

        [Key]
        public int ParcelAccelaCAPRecordID { get; set; }
        public int ParcelID { get; set; }
        public int AccelaCAPRecordID { get; set; }
        public int PrimaryKey { get { return ParcelAccelaCAPRecordID; } set { ParcelAccelaCAPRecordID = value; } }

        public virtual Parcel Parcel { get; set; }
        public virtual AccelaCAPRecord AccelaCAPRecord { get; set; }

        public static class FieldLengths
        {

        }
    }
}