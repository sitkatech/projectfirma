namespace ProjectFirma.Web.Models
{
    public interface IQuestionAnswer
    {
        int AssessmentQuestionID { get; set; }
        bool? Answer { get; set; }
    }
}