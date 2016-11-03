using System.Collections.Generic;
using System.Data.Entity.Spatial;

namespace ProjectFirma.Web.Models
{
    public enum ProjectType
    {
        Project,
        ProjectUpdate,
        ProposedProject
    }

    public interface IProject
    {
        int EntityID { get; }
        DbGeometry ProjectLocationPoint { get; set; }
        string DisplayName { get; }
        int? ProjectLocationAreaID { get; set; }
        ProjectLocationSimpleType ProjectLocationSimpleType { get; }
        int ProjectLocationSimpleTypeID { get; set; }
        ProjectLocationArea ProjectLocationArea { get; }
        string ProjectLocationNotes { get; set; }

        int? PlanningDesignStartYear { get; }
        int? ImplementationStartYear { get; }
        int? CompletionYear { get; }

        ProjectStage ProjectStage { get; }
        FundingType FundingType { get; }

        decimal? EstimatedTotalCost { get; }
        decimal? EstimatedAnnualOperatingCost { get; }

        ProjectType ProjectType { get; }


        IEnumerable<IQuestionAnswer> GetQuestionAnswers();

        IEnumerable<IProjectLocation> GetProjectLocationDetails();

        GeoJSON.Net.Feature.FeatureCollection DetailedLocationToGeoJsonFeatureCollection();

        GeoJSON.Net.Feature.FeatureCollection SimpleLocationToGeoJsonFeatureCollection(bool addProjectProperties);

    }
}