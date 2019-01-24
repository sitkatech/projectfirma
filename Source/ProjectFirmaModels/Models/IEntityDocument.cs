namespace ProjectFirmaModels.Models
{
    public interface IEntityDocument
    {
        string GetDeleteUrl();
        string GetEditUrl();
        FileResource FileResource { get; set; }
        void SetDisplayCssClass(string value);
        string GetDisplayCssClass();
        string DisplayName { get; set; }
        string Description { get; set; }
    }
}