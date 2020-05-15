using System;
using System.Data.Entity.Infrastructure.Pluralization;
using System.Linq;
using System.Web;
using LtInfo.Common.HtmlHelperExtensions;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Controllers;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Models
{
    public static class FieldDefinitionModelExtensions
    {
        public static readonly EnglishPluralizationService PluralizationService = new EnglishPluralizationService();

        public static FieldDefinition ToType(this FieldDefinitionEnum fieldDefinitionEnum)
        {
            return ToType((int) fieldDefinitionEnum);
        }
        public static FieldDefinition ToType(int fieldDefinitionID)
        {
            return HttpRequestStorage.DatabaseEntities.FieldDefinitions.SingleOrDefault(x =>
                x.FieldDefinitionID == fieldDefinitionID);
        }

        public static HtmlString GetFieldDefinitionDescription(this FieldDefinition fieldDefinition)
        {
            var fieldDefinitionData = fieldDefinition.GetFieldDefinitionData();
            if (fieldDefinitionData != null && !String.IsNullOrWhiteSpace(fieldDefinitionData.FieldDefinitionDataValueHtmlString?.ToString()))
            {
                return fieldDefinitionData.FieldDefinitionDataValueHtmlString;
            }
            return fieldDefinition.FieldDefinitionDefault.DefaultDefinitionHtmlString;
        }

        public static string GetFieldDefinitionLabel(this FieldDefinition fieldDefinition)
        {
            var fieldDefinitionData = fieldDefinition.GetFieldDefinitionData();
            if (fieldDefinitionData != null && !String.IsNullOrWhiteSpace(fieldDefinitionData.FieldDefinitionLabel))
            {
                return fieldDefinitionData.FieldDefinitionLabel;
            }
            return fieldDefinition.FieldDefinitionDisplayName;
        }

        public static bool HasCustomFieldLabel(this FieldDefinition fieldDefinition)
        {
            var fieldDefinitionData = fieldDefinition.GetFieldDefinitionData();
            return fieldDefinitionData != null && !String.IsNullOrWhiteSpace(fieldDefinitionData.FieldDefinitionLabel);
        }

        public static bool HasCustomFieldDefinition(this FieldDefinition fieldDefinition)
        {
            var fieldDefinitionData = fieldDefinition.GetFieldDefinitionData();
            return fieldDefinitionData != null && fieldDefinitionData.FieldDefinitionDataValueHtmlString != null;
        }

        public static string GetFieldDefinitionLabelPluralized(this FieldDefinition fieldDefinition)
        {
            return PluralizationService.Pluralize(fieldDefinition.GetFieldDefinitionLabel());
        }

        public static IFieldDefinitionData GetFieldDefinitionData(this FieldDefinition fieldDefinition)
        {
            return fieldDefinition.FieldDefinitionDatas.SingleOrDefault(x => x.TenantID == HttpRequestStorage.DatabaseEntities.TenantID);
        }

        public static string GetContentUrl(this FieldDefinition fieldDefinition)
        {
            return SitkaRoute<FieldDefinitionController>.BuildUrlFromExpression(x => x.FieldDefinitionDetails(fieldDefinition.FieldDefinitionID));
        }
    }
}