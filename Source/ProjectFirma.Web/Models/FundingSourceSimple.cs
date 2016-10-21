namespace ProjectFirma.Web.Models
{
    public class FundingSourceSimple
    {
        /// <summary>
        /// Constructor for building a new simple object with the POCO class
        /// </summary>
        public FundingSourceSimple(FundingSource fundingSource)
        {
            FundingSourceID = fundingSource.FundingSourceID;
            OrganizationID = fundingSource.OrganizationID;
            OrganizationName = fundingSource.Organization.AbbreviationIfAvailable;
            FundingSourceName = fundingSource.FundingSourceName;
            IsActive = fundingSource.IsActive;
            DisplayName = fundingSource.DisplayName;
        }

        public int FundingSourceID { get; set; }
        public int OrganizationID { get; set; }
        public string FundingSourceName { get; set; }
        public bool IsActive { get; set; }

        public string OrganizationName { get; set; }
        public string DisplayName { get; set; }
    }
}