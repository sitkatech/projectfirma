namespace ProjectFirmaModels.Models
{
    public interface IProjectCustomAttributeValue : ICanDeleteFull
    {
        void SetIProjectCustomAttributeValueID(int value);
        int GetIProjectCustomAttributeValueID();
        void SetIProjectCustomAttributeID(int value);
        int GetIProjectCustomAttributeID();
        string AttributeValue { get; set; }
        void SetIProjectCustomAttribute(IProjectCustomAttribute value);
        IProjectCustomAttribute GetIProjectCustomAttribute();
    }
}
