using System.Data.Entity.Spatial;

namespace ProjectFirma.Web.Models
{
    public interface IProjectLocation
    {
        DbGeometry ProjectLocationGeometry { get; set; }
        string Annotation { get; set; }
    }
}