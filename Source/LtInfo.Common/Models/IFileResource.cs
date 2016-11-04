namespace LtInfo.Common.Models
{
    public interface IFileResource
    {
        string ContentType { get; }
        byte[] Data { get; }
    }
}