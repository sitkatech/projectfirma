using System.Collections.Generic;
using System.Linq;

namespace ProjectFirma.Web.Models
{
    public class LeadAgencyJson : ToadJson
    {
        public readonly int LeadAgencyID;
        public readonly string LeadAgencyName;
        public readonly List<TransactionTypeJson> TransactionTypes;

        public LeadAgencyJson(int leadAgencyID, string leadAgencyName, List<TransactionTypeJson> transactionTypes)
        {
            LeadAgencyID = leadAgencyID;
            LeadAgencyName = leadAgencyName;
            TransactionTypes = transactionTypes.OrderBy(x => x.TransactionTypeDisplayName).ToList();
        }
    }
}