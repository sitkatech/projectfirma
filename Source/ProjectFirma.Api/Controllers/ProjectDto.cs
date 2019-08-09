using System;
using System.Collections.Generic;
using System.Linq;
using GeoJSON.Net.Feature;
using LtInfo.Common.GeoJson;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Api.Controllers
{
    public class ProjectDto
    {
        public ProjectDto(Project project)
        {
            ProjectID = project.ProjectID;
            ProjectName = project.ProjectName;
            PrimaryContact = project.PrimaryContactPerson?.GetFullNameFirstLast();
            OwnerOrganization = project.GetPrimaryContactOrganization()?.OrganizationName;
            ProjectStage = project.ProjectStage.ProjectStageDisplayName;
            ImplementationStartYear = project.ImplementationStartYear;
            CompletionYear = project.CompletionYear;
            var taxonomyTrunks = new List<string> { project.TaxonomyLeaf.TaxonomyBranch.TaxonomyTrunk.GetDisplayName() };
            if (project.SecondaryProjectTaxonomyLeafs.Any())
            {
                taxonomyTrunks.AddRange(project.SecondaryProjectTaxonomyLeafs.Select(x => x.TaxonomyLeaf.TaxonomyBranch.TaxonomyTrunk.GetDisplayName()));
            }
            TaxonomyTrunks = taxonomyTrunks.Distinct(StringComparer.InvariantCultureIgnoreCase).OrderBy(x => x).ToList();
            var taxonomyLeafs = new List<string> {project.TaxonomyLeaf.GetDisplayName()};
            if (project.SecondaryProjectTaxonomyLeafs.Any())
            {
                taxonomyLeafs.AddRange(project.SecondaryProjectTaxonomyLeafs.Select(x => x.TaxonomyLeaf.GetDisplayName()));
            }
            TaxonomyLeafs = taxonomyLeafs.OrderBy(x => x).ToList();
            var taxonomyLeafsShortened = new List<string> {project.TaxonomyLeaf.TaxonomyLeafCode};
            if (project.SecondaryProjectTaxonomyLeafs.Any())
            {
                taxonomyLeafsShortened.AddRange(project.SecondaryProjectTaxonomyLeafs.Select(x => x.TaxonomyLeaf.TaxonomyLeafCode));
            }
            TaxonomyLeafsShortened = taxonomyLeafsShortened.OrderBy(x => x).ToList();
            Classifications = project.ProjectClassifications.Any() ? project.ProjectClassifications.Select(x => x.Classification.DisplayName).OrderBy(x => x).ToList() : new List<string>();
            var leadEntities = project.ProjectGeospatialAreas.Where(x => x.GeospatialArea.GeospatialAreaType.GeospatialAreaTypeName == "Lead Entity").ToList();
            LeadEntities = project.ProjectGeospatialAreas.Any() ? leadEntities.Select(x => x.GeospatialArea.GeospatialAreaName).OrderBy(x => x).ToList() : new List<string>();
            DetailUrl = $"/Project/Detail/{project.ProjectID}";
            EstimatedTotalCost = project.GetEstimatedTotalRegardlessOfFundingType();
            SecuredFunding = project.GetSecuredFunding();
            NoFundingSourceIdentifiedFunding = project.GetNoFundingSourceIdentifiedAmount();
            if (project.ProjectLocationPoint != null)
            {
                LocationPointAsGeoJsonFeature = DbGeometryToGeoJsonHelper.FromDbGeometry(project.ProjectLocationPoint);
            }

            //ProjectCustomAttributes = project.ProjectCustomAttributes.OrderBy(x => x.ProjectCustomAttributeType.ProjectCustomAttributeTypeName).Select(x => new ProjectCustomAttributeDto(x)).ToList();
        }

        public ProjectDto()
        {
        }

        public int ProjectID { get; set; }
        public string OwnerOrganization { get; set; }
        public string ProjectStage { get; set; }

        public string ProjectName { get; set; }
        public List<string> TaxonomyTrunks { get; set; }
        public int? ImplementationStartYear { get; set; }
        public string PrimaryContact { get; set; }
        public List<string> LeadEntities { get; set; }

        public List<string> Classifications { get; set; }

        public int? CompletionYear { get; set; }

        public List<string> TaxonomyLeafs { get; set; }
        public List<string> TaxonomyLeafsShortened { get; set; }
        public string DetailUrl { get; set; }
        public decimal? NoFundingSourceIdentifiedFunding { get; set; }

        public decimal? SecuredFunding { get; set; }

        public decimal? EstimatedTotalCost { get; set; }
        public Feature LocationPointAsGeoJsonFeature { get; set; }

//        public List<ProjectCustomAttributeDto> ProjectCustomAttributes { get; set; }
    }
}