namespace LtInfo.Common.Models
{
    public interface IStringIndexer
    {
        object this[string index] { get; }
    }
}