using System.Collections.Generic;
using System.Linq;

namespace ProjectFirmaModels.Models
{
    public partial class ProjectGeospatialAreaUpdate : IAuditableEntity
    {
        public string GetAuditDescriptionString()
        {
            return $"GeospatialArea: {GeospatialAreaID}, Project Update Batch: {ProjectUpdateBatchID}";
        }
    }
}