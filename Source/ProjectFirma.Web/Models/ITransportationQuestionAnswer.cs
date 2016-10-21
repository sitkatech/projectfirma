namespace ProjectFirma.Web.Models
{
    public interface ITransportationQuestionAnswer
    {
        int TransportationQuestionID { get; set; }
        bool? Answer { get; set; }
    }
}