//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[vProjectFunctionallyComplete]
using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Data.Entity.Spatial;
using System.Linq;
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public partial class vProjectFunctionallyComplete
    {
        /// <summary>
        /// Needed by ModelBinder
        /// </summary>
        public vProjectFunctionallyComplete()
        {
        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public vProjectFunctionallyComplete(int projectID, int primaryKey, bool? functionallyComplete) : this()
        {
            this.ProjectID = projectID;
            this.PrimaryKey = primaryKey;
            this.FunctionallyComplete = functionallyComplete;
        }

        /// <summary>
        /// Constructor for building a new simple object with the POCO class
        /// </summary>
        public vProjectFunctionallyComplete(vProjectFunctionallyComplete vProjectFunctionallyComplete) : this()
        {
            this.ProjectID = vProjectFunctionallyComplete.ProjectID;
            this.PrimaryKey = vProjectFunctionallyComplete.PrimaryKey;
            this.FunctionallyComplete = vProjectFunctionallyComplete.FunctionallyComplete;
            CallAfterConstructor(vProjectFunctionallyComplete);
        }

        partial void CallAfterConstructor(vProjectFunctionallyComplete vProjectFunctionallyComplete);

        public int ProjectID { get; set; }
        public int PrimaryKey { get; set; }
        public bool? FunctionallyComplete { get; set; }
    }
}