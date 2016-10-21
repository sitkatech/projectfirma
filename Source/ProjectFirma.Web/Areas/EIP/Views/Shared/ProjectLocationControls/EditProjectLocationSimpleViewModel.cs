using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.Spatial;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Areas.EIP.Views.Map;
using LtInfo.Common;
using LtInfo.Common.DbSpatial;
using LtInfo.Common.Models;

namespace ProjectFirma.Web.Areas.EIP.Views.Shared.ProjectLocationControls
{
    public class EditProjectLocationSimpleViewModel : FormViewModel, IValidatableObject
    {
        public int? ProjectLocationAreaID { get; set; }
        public double? ProjectLocationPointX { get; set; }
        public double? ProjectLocationPointY { get; set; }
        public ProjectLocationSimpleTypeEnum ProjectLocationSimpleType { get; set; }

        [DisplayName("Notes")]
        [StringLength(Models.Project.FieldLengths.ProjectLocationNotes)]
        public string ProjectLocationNotes { get; set; }

        /// <summary>
        /// Needed by model binder
        /// </summary>
        public EditProjectLocationSimpleViewModel()
        {
        }

        public EditProjectLocationSimpleViewModel(DbGeometry projectLocationPoint, int? projectLocationAreaID, ProjectLocationSimpleTypeEnum projectLocationSimpleType, string projectLocationNotes)
        {
            ProjectLocationAreaID = projectLocationAreaID;
            ProjectLocationSimpleType = projectLocationSimpleType;
            if (projectLocationPoint != null)
            {
                ProjectLocationPointX = projectLocationPoint.XCoordinate;
                ProjectLocationPointY = projectLocationPoint.YCoordinate;
            }
            else
            {
                ProjectLocationPointX = null;
                ProjectLocationPointY = null;
            }
            ProjectLocationNotes = projectLocationNotes;
        }

        public virtual void UpdateModel(IProject project)
        {
            project.ProjectLocationSimpleTypeID = Models.ProjectLocationSimpleType.ToType(ProjectLocationSimpleType).ProjectLocationSimpleTypeID;
            switch (ProjectLocationSimpleType)
            {                
                case ProjectLocationSimpleTypeEnum.PointOnMap:
                    project.ProjectLocationAreaID = null;
                    project.ProjectLocationPoint = DbSpatialHelper.MakeDbGeometryFromCoordinates(ProjectLocationPointX.Value, ProjectLocationPointY.Value, MapInitJson.CoordinateSystemId);
                    break;
                case ProjectLocationSimpleTypeEnum.NamedAreas:
                    project.ProjectLocationAreaID = ProjectLocationAreaID;
                    project.ProjectLocationPoint = null;
                    break;
                case ProjectLocationSimpleTypeEnum.None:
                    project.ProjectLocationAreaID = null;
                    project.ProjectLocationPoint = null;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
            project.ProjectLocationNotes = ProjectLocationNotes;
        }

        public virtual IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            return GetValidationResults();
        }

        public IEnumerable<ValidationResult> GetValidationResults()
        {
            var errors = new List<ValidationResult>();

            if (ProjectLocationSimpleType == ProjectLocationSimpleTypeEnum.PointOnMap && (!ProjectLocationPointX.HasValue || !ProjectLocationPointY.HasValue))
            {
                errors.Add(new SitkaValidationResult<EditProjectLocationSimpleViewModel, double?>("Please specify a point on the map", x => x.ProjectLocationPointX));
            }

            if (ProjectLocationSimpleType == ProjectLocationSimpleTypeEnum.None && string.IsNullOrWhiteSpace(ProjectLocationNotes))
            {
                errors.Add(
                    new SitkaValidationResult<EditProjectLocationSimpleViewModel, string>(
                        "If a location point or general project area is not available, explanatory information in the Notes section is required.",
                        x => x.ProjectLocationNotes));
            }

            return errors;
        }
    }
}