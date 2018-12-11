using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Models
{
    public interface IProjectCustomAttributeValue : ICanDeleteFull
    {
        int IProjectCustomAttributeValueID { get; set; }
        int IProjectCustomAttributeID { get; set; }
        string AttributeValue { get; set; }
        IProjectCustomAttribute IProjectCustomAttribute { get; set; }
    }
}
