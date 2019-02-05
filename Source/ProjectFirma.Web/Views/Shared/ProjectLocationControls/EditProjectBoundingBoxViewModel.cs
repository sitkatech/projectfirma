using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.Spatial;
using System.Linq;
using ProjectFirma.Web.Models;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Views.Shared.ProjectLocationControls
{
    public class EditProjectBoundingBoxViewModel : IValidatableObject
    {
        public decimal? North { get; set; }
        public decimal? South { get; set; }
        public decimal? East { get; set; }
        public decimal? West { get; set; }

        /// <summary>
        /// Needed by ModelBinder
        /// </summary>
        public EditProjectBoundingBoxViewModel()
        {
        }

        public EditProjectBoundingBoxViewModel(ProjectFirmaModels.Models.Project project)
        {
            if (project.DefaultBoundingBox != null)
            {
                var defaultBoundingBoxBoundary = project.DefaultBoundingBox.Boundary;
                var southWest = defaultBoundingBoxBoundary.PointAt(1);
                var northEast = defaultBoundingBoxBoundary.PointAt(3);

                if (northEast.YCoordinate != null)
                {
                    North = (decimal) northEast.YCoordinate;
                }
                if (southWest.YCoordinate != null)
                {
                    South = (decimal) southWest.YCoordinate;
                }
                if (northEast.XCoordinate != null)
                {
                    East = (decimal) northEast.XCoordinate;
                }
                if (southWest.XCoordinate != null)
                {
                    West = (decimal) southWest.XCoordinate;
                }
            }
        }

        public void UpdateModel(ProjectFirmaModels.Models.Project project)
        {
            project.DefaultBoundingBox = North.HasValue && South.HasValue && East.HasValue && West.HasValue
                ? DbGeometry.FromText(
                    string.Format("POLYGON(({0} {1}, {0} {2}, {3} {2}, {3} {1}, {0} {1}))", West, North, South, East),
                    4326)
                : null;
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var errors = new List<ValidationResult>();

            var coords = new List<decimal?> {North, South, East, West}.Where(x => x != null).ToList();
            if (coords.Count != 0 && coords.Count != 4) // Either expect all or none of the coordinates
            {
                errors.Add(new ValidationResult($"Invalid coordinates provided for {FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabel()} Bounding Box."));
            }

            return errors;
        }
    }
}
