using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.Spatial;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Views.Map;
using ProjectFirma.Web.Views.Shared.ProjectLocationControls;
using LtInfo.Common.DbSpatial;

namespace ProjectFirma.Web.Views.ProjectUpdate
{
    public class LocationSimpleViewModel : EditProjectLocationSimpleViewModel
    {
        [DisplayName("Show Validation Warnings?")]
        public bool ShowValidationWarnings { get; set; }

        [DisplayName("Comments")]
        [StringLength(ProjectUpdateBatch.FieldLengths.LocationSimpleComment)]
        public string Comments { get; set; }

        /// <summary>
        /// Needed by the ModelBinder
        /// </summary>
        public LocationSimpleViewModel()
        {
        }

        public LocationSimpleViewModel(DbGeometry projectLocationPoint, int? projectLocationAreaID, ProjectLocationSimpleTypeEnum projectLocationSimpleType, string projectLocationNotes, string comments, bool showValidationWarnings)
            : base(projectLocationPoint, projectLocationAreaID, projectLocationSimpleType, projectLocationNotes)
        {
            Comments = comments;
            ShowValidationWarnings = showValidationWarnings;
        }

        public void UpdateModelBatch(ProjectUpdateBatch projectUpdateBatch)
        {
            var project = projectUpdateBatch.ProjectUpdate;
            projectUpdateBatch.ShowLocationSimpleValidationWarnings = ShowValidationWarnings;
            project.ProjectLocationSimpleTypeID = Models.ProjectLocationSimpleType.ToType(ProjectLocationSimpleType).ProjectLocationSimpleTypeID;
            switch (ProjectLocationSimpleType)
            {
                case ProjectLocationSimpleTypeEnum.PointOnMap:
                    project.ProjectLocationAreaID = null;

                    project.ProjectLocationPoint = ProjectLocationPointX.HasValue && ProjectLocationPointY.HasValue
                        ? DbSpatialHelper.MakeDbGeometryFromCoordinates(ProjectLocationPointX.Value, ProjectLocationPointY.Value, MapInitJson.CoordinateSystemId)
                        : null;
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

        public override IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            return new List<ValidationResult>();
        }
    }
}