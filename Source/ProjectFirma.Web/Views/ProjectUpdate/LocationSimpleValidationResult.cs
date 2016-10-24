using System.Collections.Generic;
using System.Linq;
using ProjectFirma.Web.Models;

namespace ProjectFirma.Web.Views.ProjectUpdate
{
    public class LocationSimpleValidationResult
    {
        public readonly Models.ProjectUpdate ProjectUpdate;
        private readonly List<string> _warningMessages;

        public LocationSimpleValidationResult(Models.ProjectUpdate projectUpdate)
        {
            ProjectUpdate = projectUpdate;

            _warningMessages = new List<string>();

            if (ProjectUpdate.ProjectLocationSimpleType == ProjectLocationSimpleType.PointOnMap &&
                (!ProjectUpdate.ProjectLocationPointLatitude.HasValue || !ProjectUpdate.ProjectLocationPointLongitude.HasValue))
            {
                _warningMessages.Add("The simplified project location is set to 'Point on Map' but no point is specified.");
            }

            if (ProjectUpdate.ProjectLocationSimpleType == ProjectLocationSimpleType.None && string.IsNullOrWhiteSpace(ProjectUpdate.ProjectLocationNotes))
            {
                _warningMessages.Add("If a location point or general project area is not available, explanatory information in the Notes section is required.");
            }
        }

        public List<string> GetWarningMessages()
        {     
            return _warningMessages;
        }

        public bool IsValid
        {
            get { return !_warningMessages.Any(); }
        }
    }
}