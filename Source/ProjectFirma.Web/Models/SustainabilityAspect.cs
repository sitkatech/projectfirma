using System.Linq;
using ProjectFirma.Web.Common;
using MoreLinq;

namespace ProjectFirma.Web.Models
{
    public partial class SustainabilityAspect
    {
        private SustainabilityAspect _nextAspect;
        private static string _imageRoot = "/Areas/Sustainability/Content/";
        public string GetKeyImageFullPath()
        {
            return string.Format("{0}{1}", _imageRoot, KeyImageFileName);
        }

        public SustainabilityAspect GetNextAspect()
        {
            if (_nextAspect == null)
            {
                var aspects = HttpRequestStorage.DatabaseEntities.SustainabilityAspects.OrderBy(x => x.DisplayOrder);
                _nextAspect = DisplayOrder < aspects.Max(x => x.DisplayOrder) ? aspects.First(x => x.DisplayOrder > DisplayOrder) : aspects.MinBy(x => x.DisplayOrder);
            }

            return _nextAspect;
        }
    }
}