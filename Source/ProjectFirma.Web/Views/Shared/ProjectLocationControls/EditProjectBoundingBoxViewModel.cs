using System.ComponentModel.DataAnnotations;
using System.Data.Entity.Spatial;

namespace ProjectFirma.Web.Views.Shared.ProjectLocationControls
{
    public class EditProjectBoundingBoxViewModel
    {
        [Required(ErrorMessage = "The North coordinate is required.")]
        public decimal? North { get; set; }

        [Required(ErrorMessage = "The South coordinate is required.")]
        public decimal? South { get; set; }

        [Required(ErrorMessage = "The East coordinate is required.")]
        public decimal? East { get; set; }

        [Required(ErrorMessage = "The West coordinate is required.")]
        public decimal? West { get; set; }

        /// <summary>
        /// Needed by ModelBinder
        /// </summary>
        public EditProjectBoundingBoxViewModel()
        {
        }

        public EditProjectBoundingBoxViewModel(Models.Project project)
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

        public void UpdateModel(Models.Project project)
        {
            project.DefaultBoundingBox =
                DbGeometry.FromText(
                    string.Format("POLYGON(({0} {1}, {0} {2}, {3} {2}, {3} {1}, {0} {1}))", West, North, South, East),
                    4326);
        }
    }
}