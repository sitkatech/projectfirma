using LtInfo.Common.Views;

namespace LtInfo.Common.HtmlHelperExtensions
{
    public static class FieldDefinitionHelpers
    {
        public static string ToGridHeaderString(this IFieldDefinition fieldDefinition)
        {
            return fieldDefinition.ToGridHeaderString(LabelWithSugarForExtensions.DefaultPopupWidth, fieldDefinition.FieldDefinitionDisplayName);
        }

        public static string ToGridHeaderString(this IFieldDefinition fieldDefinition, string linkText)
        {
            return fieldDefinition.ToGridHeaderString(LabelWithSugarForExtensions.DefaultPopupWidth, linkText);
        }

        public static string ToGridHeaderString(this IFieldDefinition fieldDefinition, int popupWidth)
        {
            return fieldDefinition.ToGridHeaderString(popupWidth, fieldDefinition.FieldDefinitionDisplayName);
        }

        private static string ToGridHeaderString(this IFieldDefinition fieldDefinition, int popupWidth, string fieldDefinitionDisplayName)
        {
            return
                LabelWithSugarForExtensions.LabelWithSugarFor(fieldDefinition, popupWidth,
                    LabelWithSugarForExtensions.DisplayStyle.AsGridHeader, fieldDefinitionDisplayName).ToString();
        }

        public static string ToGridHeaderStringWider(this IFieldDefinition fieldDefinition)
        {
            return fieldDefinition.ToGridHeaderString(LabelWithSugarForExtensions.DefaultPopupWidthWider, fieldDefinition.FieldDefinitionDisplayName);
        }
    }
}