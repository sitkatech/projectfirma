namespace ProjectFirma.Web.Models
{
    public interface IEntityDocument
    {
        string DeleteUrl { get; }
        string EditUrl { get; }
        FileResource FileResource { get; set; }
        string DisplayCssClass { get; set; }
        string DisplayName { get; set; }
        string Description { get; set; }
    }
}