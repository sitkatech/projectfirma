namespace LtInfo.Common.Models
{
    public interface IStateType
    {
        string Display { get; }
        int ID { get; }
        string Name { get; }
        object ToEnumObject { get; }
    }
}