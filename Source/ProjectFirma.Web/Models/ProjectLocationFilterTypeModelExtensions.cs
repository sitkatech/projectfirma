using System;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Models
{
    public static class ProjectLocationFilterTypeModelExtensions
    {
        public static string GetDisplayName(this ProjectLocationFilterType projectLocationFilterType)
        {
            switch (projectLocationFilterType.ToEnum)
            {
                case ProjectLocationFilterTypeEnum.TaxonomyTrunk:
                    return FieldDefinitionEnum.TaxonomyTrunk.ToType().GetFieldDefinitionLabel();
                case ProjectLocationFilterTypeEnum.TaxonomyBranch:
                    return FieldDefinitionEnum.TaxonomyBranch.ToType().GetFieldDefinitionLabel();
                case ProjectLocationFilterTypeEnum.TaxonomyLeaf:
                    return FieldDefinitionEnum.TaxonomyLeaf.ToType().GetFieldDefinitionLabel();
                case ProjectLocationFilterTypeEnum.Classification:
                    return FieldDefinitionEnum.Classification.ToType().GetFieldDefinitionLabel();
                case ProjectLocationFilterTypeEnum.ProjectStage:
                    return FieldDefinitionEnum.ProjectStage.ToType().GetFieldDefinitionLabel();
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

    }
}