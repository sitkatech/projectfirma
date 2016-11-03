namespace ProjectFirma.Web.Models
{
    public interface IProjectBudgetAmount : IFundingSourceExpenditure
    {
        int ProjectID { get; }
        ProjectCostType ProjectCostType { get; }
        int ProjectCostTypeID { get; }
    }
}