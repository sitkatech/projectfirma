using System;
using System.Linq;
using System.Web;
using LtInfo.Common;
using ProjectFirma.Web.Areas.ParcelTracker.Controllers;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Models
{
    public enum AllocationStatus
    {
        AllocatedWithTransactionRecord,
        AllocatedWithoutTransactionRecord,
        Unallocated
    };

    public partial class ResidentialAllocation : IAuditableEntity
    {
        public static readonly UrlTemplate<string> SummaryUrlTemplate = new UrlTemplate<string>(SitkaRoute<ResidentialAllocationController>.BuildUrlFromExpression(t => t.Summary(UrlTemplate.Parameter1String)));

        public string ResidentialAllocationNumber
        {
            get
            {
                string residentialAllocationAbbreviation;
                if (ResidentialAllocationType != ResidentialAllocationType.AllocationPool)
                {
                    residentialAllocationAbbreviation = Jurisdiction.ResidentialAllocationAbbreviation;
                }
                else
                {
                    residentialAllocationAbbreviation = AssignedToJurisdiction == null ? Jurisdiction.ResidentialAllocationAbbreviation : AssignedToJurisdiction.ResidentialAllocationAbbreviation;
                }
                return string.Format("{0}-{1}-{2}-{3}",
                    residentialAllocationAbbreviation,
                    new DateTime(IssuanceYear, 1, 1).ToString("yy"),
                    ResidentialAllocationType.ResidentialAllocationTypeCode,
                    AllocationSequence.ToString("00"));
            }
        }

        public bool IsAllocated
        {
            get { return TdrTransactionID.HasValue || IsAllocatedButNoTransactionRecord; }
        }

        public HtmlString GetResidentialAllocationNumberAsUrlIfAuthorized()
        {
            return UrlTemplate.MakeHrefString(GetSummaryUrl(), ResidentialAllocationNumber);
        }

        public string GetSummaryUrl()
        {
            return SummaryUrlTemplate.ParameterReplace(ResidentialAllocationNumber);
        }

        public string AuditDescriptionString { get { return ResidentialAllocationNumber; } }
        public AllocationStatus AllocationStatus
        {
            get
            {
                if (IsAllocatedButNoTransactionRecord)
                {
                    return AllocationStatus.AllocatedWithoutTransactionRecord;
                }
                return IsAllocated ? AllocationStatus.AllocatedWithTransactionRecord : AllocationStatus.Unallocated;
            }
        }
        public string AllocationStatusString
        {
            get
            {
                switch (AllocationStatus)
                {
                    case AllocationStatus.AllocatedWithTransactionRecord:
                        return "Allocated";
                    case AllocationStatus.AllocatedWithoutTransactionRecord:
                        return "Allocated w/out Transaction";
                    case AllocationStatus.Unallocated:
                        return "Unallocated";
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
        }

        public bool IsVisibleToJurisdiction(LeadAgency leadAgency)
        {
            return leadAgency.LeadAgencyID == LeadAgency.TRPALeadAgencyID || (Jurisdiction.Organization.OrganizationID == leadAgency.OrganizationID);
        }
    }
}