//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[AccelaCAPRecord]
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
    [Table("[dbo].[AccelaCAPRecord]")]
    public partial class AccelaCAPRecord : IHavePrimaryKey
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected AccelaCAPRecord()
        {
            this.ParcelAccelaCAPRecords = new HashSet<ParcelAccelaCAPRecord>();
            this.ParcelLandCapabilities = new HashSet<ParcelLandCapability>();
            this.TdrTransactions = new HashSet<TdrTransaction>();
        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public AccelaCAPRecord(int accelaCAPRecordID, string accelaID, string keyOne, string keyTwo, string keyThree, string shortNotes, string detailedDescription, int? accelaCAPRecordStatusID, string accelaCAPTypeName, DateTime? fileDate) : this()
        {
            this.AccelaCAPRecordID = accelaCAPRecordID;
            this.AccelaID = accelaID;
            this.KeyOne = keyOne;
            this.KeyTwo = keyTwo;
            this.KeyThree = keyThree;
            this.ShortNotes = shortNotes;
            this.DetailedDescription = detailedDescription;
            this.AccelaCAPRecordStatusID = accelaCAPRecordStatusID;
            this.AccelaCAPTypeName = accelaCAPTypeName;
            this.FileDate = fileDate;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields in preparation for insert into database
        /// </summary>
        public AccelaCAPRecord(string accelaID, string keyOne, string keyTwo, string keyThree) : this()
        {
            // Mark this as a new object by setting primary key with special value
            AccelaCAPRecordID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            
            this.AccelaID = accelaID;
            this.KeyOne = keyOne;
            this.KeyTwo = keyTwo;
            this.KeyThree = keyThree;
        }


        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static AccelaCAPRecord CreateNewBlank()
        {
            return new AccelaCAPRecord(default(string), default(string), default(string), default(string));
        }

        /// <summary>
        /// Does this object have any dependent objects? (If it does have dependent objects, these would need to be deleted before this object could be deleted.)
        /// </summary>
        /// <returns></returns>
        public bool HasDependentObjects()
        {
            return ParcelAccelaCAPRecords.Any() || ParcelLandCapabilities.Any() || TdrTransactions.Any();
        }

        /// <summary>
        /// Dependent type names of this entity
        /// </summary>
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(AccelaCAPRecord).Name, typeof(ParcelAccelaCAPRecord).Name, typeof(ParcelLandCapability).Name, typeof(TdrTransaction).Name};

        [Key]
        public int AccelaCAPRecordID { get; set; }
        public string AccelaID { get; set; }
        public string KeyOne { get; set; }
        public string KeyTwo { get; set; }
        public string KeyThree { get; set; }
        public string ShortNotes { get; set; }
        public string DetailedDescription { get; set; }
        public int? AccelaCAPRecordStatusID { get; set; }
        public string AccelaCAPTypeName { get; set; }
        public DateTime? FileDate { get; set; }
        public int PrimaryKey { get { return AccelaCAPRecordID; } set { AccelaCAPRecordID = value; } }

        public virtual ICollection<ParcelAccelaCAPRecord> ParcelAccelaCAPRecords { get; set; }
        public virtual ICollection<ParcelLandCapability> ParcelLandCapabilities { get; set; }
        public virtual ICollection<TdrTransaction> TdrTransactions { get; set; }
        public AccelaCAPRecordStatus AccelaCAPRecordStatus { get { return AccelaCAPRecordStatusID.HasValue ? AccelaCAPRecordStatus.AllLookupDictionary[AccelaCAPRecordStatusID.Value] : null; } }

        public static class FieldLengths
        {
            public const int AccelaID = 50;
            public const int KeyOne = 50;
            public const int KeyTwo = 50;
            public const int KeyThree = 50;
            public const int ShortNotes = 255;
            public const int DetailedDescription = 4000;
            public const int AccelaCAPTypeName = 100;
        }
    }
}