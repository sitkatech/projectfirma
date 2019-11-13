using System;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Models
{
    public static class ProjectColorByTypeModelExtensions
    {
        public static string GetDisplayName(this ProjectColorByType projectColorByType)
        {
            switch (projectColorByType.ToEnum)
            {
                case ProjectColorByTypeEnum.TaxonomyTrunk:
                    return FieldDefinitionEnum.TaxonomyTrunk.ToType().GetFieldDefinitionLabel();
                case ProjectColorByTypeEnum.ProjectStage:
                    return FieldDefinitionEnum.ProjectStage.ToType().GetFieldDefinitionLabel();
                case ProjectColorByTypeEnum.TaxonomyBranch:
                    return FieldDefinitionEnum.TaxonomyBranch.ToType().GetFieldDefinitionLabel();
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public static FieldDefinition GetDisplayNameFieldDefinition(this ProjectColorByType projectColorByType)
        {
            switch (projectColorByType.ToEnum)
            {
                case ProjectColorByTypeEnum.TaxonomyTrunk:
                    return FieldDefinitionEnum.TaxonomyTrunk.ToType();
                case ProjectColorByTypeEnum.ProjectStage:
                    return FieldDefinitionEnum.ProjectStage.ToType();
                //                    return projectColorByType.ProjectColorByTypeDisplayName;
                case ProjectColorByTypeEnum.TaxonomyBranch:
                    return FieldDefinitionEnum.TaxonomyBranch.ToType();
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}