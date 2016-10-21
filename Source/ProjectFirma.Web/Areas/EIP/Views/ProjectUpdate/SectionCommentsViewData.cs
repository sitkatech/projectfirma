namespace ProjectFirma.Web.Areas.EIP.Views.ProjectUpdate
{
    public class SectionCommentsViewData
    {
        public readonly string Comments;
        public readonly bool IsReturned;

        public SectionCommentsViewData(string comments, bool isReturned)
        {
            IsReturned = isReturned;
            Comments = comments;
        }
    }
}