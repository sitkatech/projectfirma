using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;
using LtInfo.Common.DhtmlWrappers;
using LtInfo.Common.Models;

namespace ProjectFirma.Web.Service.ServiceModels
{
    [DataContract]
    public class WebServiceOrganization : SimpleModelObject
    {
        public WebServiceOrganization(Organization organization)
        {
            OrganizationID = organization.OrganizationID;
            OrganizationName = organization.OrganizationName;
            OrganizationAbbreviation = organization.OrganizationAbbreviation;
            Sector = organization.Sector.SectorDisplayName;
            PrimaryContact = organization.PrimaryContactPersonAsString;
            ProjectCount = organization.GetAllProjectOrganizations().Count;
            FundingSourceCount = organization.FundingSources.Count;
            UserCount = organization.People.Count;
            OrganizationSummaryUrl = organization.GetSummaryUrl();
        }    

        [DataMember] public int OrganizationID { get; set; }
        [DataMember] public string OrganizationName { get; set; }
        [DataMember] public string OrganizationAbbreviation { get; set; }
        [DataMember] public string Sector { get; set; }
        
        [DataMember] public string PrimaryContact { get; set; }
        [DataMember] public int ProjectCount { get; set; }
        [DataMember] public int FundingSourceCount { get; set; }
        [DataMember] public int UserCount { get; set; }

        [DataMember] public string OrganizationSummaryUrl { get; set; }

        public static List<WebServiceOrganization> GetOrganizations()
        {
            var organizations = HttpRequestStorage.DatabaseEntities.Organizations.GetActiveOrganizations();
            return organizations.Select(x => new WebServiceOrganization(x)).OrderBy(x => x.OrganizationName).ToList();
        }
    }

    public class WebServiceOrganizationGridSpec : GridSpec<WebServiceOrganization>
    {
        public WebServiceOrganizationGridSpec()
        {
            Add("OrganizationID", a => a.OrganizationID, 0);
            Add("Organization", a => a.OrganizationName, 0);
            Add("OrganizationAbbreviation", a => a.OrganizationAbbreviation, 0);
            Add("Sector", a => a.Sector, 0);
            Add("PrimaryContact", a => a.PrimaryContact, 0);
            Add("NumberOfProjects", a => a.ProjectCount, 0);
            Add("NumberOfFundingSources", a => a.FundingSourceCount, 0);
            Add("NumberOfUsers", a => a.UserCount, 0);
            Add("OrganizationSummaryUrl", x => x.OrganizationSummaryUrl, 0);
        }
    }
}
