namespace ProjectFirma.Web.Models
{
    public interface IProjectCustomAttributeValue
    {
        int IProjectCustomAttributeValueID { get; set; }
        int IProjectCustomAttributeID { get; set; }
        string AttributeValue { get; set; }
    }
}
