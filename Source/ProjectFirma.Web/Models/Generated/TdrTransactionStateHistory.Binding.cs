//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[TdrTransactionStateHistory]
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
    [Table("[dbo].[TdrTransactionStateHistory]")]
    public partial class TdrTransactionStateHistory : IHavePrimaryKey
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected TdrTransactionStateHistory()
        {

        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public TdrTransactionStateHistory(int tdrTransactionStateHistoryID, int tdrTransactionID, int transactionStateID, int updatePersonID, DateTime transitionDate) : this()
        {
            this.TdrTransactionStateHistoryID = tdrTransactionStateHistoryID;
            this.TdrTransactionID = tdrTransactionID;
            this.TransactionStateID = transactionStateID;
            this.UpdatePersonID = updatePersonID;
            this.TransitionDate = transitionDate;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields in preparation for insert into database
        /// </summary>
        public TdrTransactionStateHistory(int tdrTransactionID, int transactionStateID, int updatePersonID, DateTime transitionDate) : this()
        {
            // Mark this as a new object by setting primary key with special value
            TdrTransactionStateHistoryID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            
            this.TdrTransactionID = tdrTransactionID;
            this.TransactionStateID = transactionStateID;
            this.UpdatePersonID = updatePersonID;
            this.TransitionDate = transitionDate;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields, using objects whenever possible
        /// </summary>
        public TdrTransactionStateHistory(TdrTransaction tdrTransaction, TransactionState transactionState, Person updatePerson, DateTime transitionDate) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.TdrTransactionStateHistoryID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            this.TdrTransactionID = tdrTransaction.TdrTransactionID;
            this.TdrTransaction = tdrTransaction;
            tdrTransaction.TdrTransactionStateHistories.Add(this);
            this.TransactionStateID = transactionState.TransactionStateID;
            this.UpdatePersonID = updatePerson.PersonID;
            this.UpdatePerson = updatePerson;
            updatePerson.TdrTransactionStateHistoriesWhereYouAreTheUpdatePerson.Add(this);
            this.TransitionDate = transitionDate;
        }

        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static TdrTransactionStateHistory CreateNewBlank(TdrTransaction tdrTransaction, TransactionState transactionState, Person updatePerson)
        {
            return new TdrTransactionStateHistory(tdrTransaction, transactionState, updatePerson, default(DateTime));
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
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(TdrTransactionStateHistory).Name};

        [Key]
        public int TdrTransactionStateHistoryID { get; set; }
        public int TdrTransactionID { get; set; }
        public int TransactionStateID { get; set; }
        public int UpdatePersonID { get; set; }
        public DateTime TransitionDate { get; set; }
        public int PrimaryKey { get { return TdrTransactionStateHistoryID; } set { TdrTransactionStateHistoryID = value; } }

        public virtual TdrTransaction TdrTransaction { get; set; }
        public TransactionState TransactionState { get { return TransactionState.AllLookupDictionary[TransactionStateID]; } }
        public virtual Person UpdatePerson { get; set; }

        public static class FieldLengths
        {

        }
    }
}