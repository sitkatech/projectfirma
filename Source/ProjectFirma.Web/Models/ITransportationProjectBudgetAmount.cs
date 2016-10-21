namespace ProjectFirma.Web.Models
{
    public interface ITransportationProjectBudgetAmount : IFundingSourceExpenditure
    {
        int ProjectID { get; }
        TransportationProjectCostType TransportationProjectCostType { get; }
        int TransportationProjectCostTypeID { get; }
    }
}