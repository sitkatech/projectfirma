namespace ProjectFirma.Web.Models
{
    public interface IEntityThresholdCategory
    {        
        int ThresholdCategoryID { get; }
        ThresholdCategory ThresholdCategory { get; }
    }
    
}