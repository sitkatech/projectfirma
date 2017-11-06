namespace ProjectFirma.Web.Models
{
    public class ProjectFundingSourceRequestSimple
    {

        /// <summary>
        /// Needed by ModelBinder
        /// </summary>
        public ProjectFundingSourceRequestSimple()
        {
        }
        
        public ProjectFundingSourceRequestSimple(ProjectFundingSourceRequest projectFundingSourceRequest)
            : this()
        {
            ProjectID = projectFundingSourceRequest.ProjectID;
            FundingSourceID = projectFundingSourceRequest.FundingSourceID;
            UnsecuredAmount = projectFundingSourceRequest.UnsecuredAmount;
            SecuredAmount = projectFundingSourceRequest.SecuredAmount;
        }

        //public ProjectFundingSourceRequestSimple(ProjectFundingSourceRequestUpdate projectFundingSourceRequestUpdate)
        //{
        //    ProjectID = projectFundingSourceRequestUpdate.ProjectUpdateBatchID;
        //    FundingSourceID = projectFundingSourceRequestUpdate.FundingSourceID;
        //    UnsecuredAmount = projectFundingSourceRequestUpdate.UnsecuredAmount;
        //    SecuredAmount = projectFundingSourceRequestUpdate.SecuredAmount;
        //}

        public ProjectFundingSourceRequest ToProjectFundingSourceRequest()
        {
            return new ProjectFundingSourceRequest(ProjectID, FundingSourceID, SecuredAmount ?? 0, UnsecuredAmount ?? 0);
        }

        public int ProjectID { get; set; }
        public int FundingSourceID { get; set; }
        public decimal? SecuredAmount { get; set; }
        public decimal? UnsecuredAmount { get; set; }

        //public ProjectFundingSourceRequestUpdate ToProjectFundingSourceRequestUpdate()
        //{
        //    return new ProjectFundingSourceRequestUpdate(ProjectID, FundingSourceID, SecuredAmount ?? 0, UnsecuredAmount ?? 0);
        //}

        public bool AreBothValuesZeroOrEmpty()
        {
            return (SecuredAmount == null && UnsecuredAmount == null) ||
                (SecuredAmount == 0 && UnsecuredAmount == 0) ||
                (SecuredAmount == 0 && UnsecuredAmount == null) ||
                (SecuredAmount == null && UnsecuredAmount == 0);
        }
    }
}