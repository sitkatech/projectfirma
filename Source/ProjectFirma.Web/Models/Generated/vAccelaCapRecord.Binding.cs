//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[vAccelaCapRecord]
using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Data.Entity.Spatial;
using System.Linq;
using ProjectFirma.Web.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirma.Web.Models
{
    public partial class vAccelaCapRecord
    {
        /// <summary>
        /// Needed by ModelBinder
        /// </summary>
        public vAccelaCapRecord()
        {
        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public vAccelaCapRecord(string aPN, string accelaID, string keyOne, string keyTwo, string keyThree, string shortNotes, string detailedDescription, int? accelaCAPRecordStatusID, string accelaCAPRecordStatusDisplayName, string accelaCAPTypeName, DateTime? fileDate) : this()
        {
            this.APN = aPN;
            this.AccelaID = accelaID;
            this.KeyOne = keyOne;
            this.KeyTwo = keyTwo;
            this.KeyThree = keyThree;
            this.ShortNotes = shortNotes;
            this.DetailedDescription = detailedDescription;
            this.AccelaCAPRecordStatusID = accelaCAPRecordStatusID;
            this.AccelaCAPRecordStatusDisplayName = accelaCAPRecordStatusDisplayName;
            this.AccelaCAPTypeName = accelaCAPTypeName;
            this.FileDate = fileDate;
        }

        /// <summary>
        /// Constructor for building a new simple object with the POCO class
        /// </summary>
        public vAccelaCapRecord(vAccelaCapRecord vAccelaCapRecord) : this()
        {
            this.APN = vAccelaCapRecord.APN;
            this.AccelaID = vAccelaCapRecord.AccelaID;
            this.KeyOne = vAccelaCapRecord.KeyOne;
            this.KeyTwo = vAccelaCapRecord.KeyTwo;
            this.KeyThree = vAccelaCapRecord.KeyThree;
            this.ShortNotes = vAccelaCapRecord.ShortNotes;
            this.DetailedDescription = vAccelaCapRecord.DetailedDescription;
            this.AccelaCAPRecordStatusID = vAccelaCapRecord.AccelaCAPRecordStatusID;
            this.AccelaCAPRecordStatusDisplayName = vAccelaCapRecord.AccelaCAPRecordStatusDisplayName;
            this.AccelaCAPTypeName = vAccelaCapRecord.AccelaCAPTypeName;
            this.FileDate = vAccelaCapRecord.FileDate;
            CallAfterConstructor(vAccelaCapRecord);
        }

        partial void CallAfterConstructor(vAccelaCapRecord vAccelaCapRecord);

        public string APN { get; set; }
        public string AccelaID { get; set; }
        public string KeyOne { get; set; }
        public string KeyTwo { get; set; }
        public string KeyThree { get; set; }
        public string ShortNotes { get; set; }
        public string DetailedDescription { get; set; }
        public int? AccelaCAPRecordStatusID { get; set; }
        public string AccelaCAPRecordStatusDisplayName { get; set; }
        public string AccelaCAPTypeName { get; set; }
        public DateTime? FileDate { get; set; }
    }
}