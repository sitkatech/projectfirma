using LtInfo.Common.Views;

namespace LtInfo.Common.HtmlHelperExtensions
{
    public static class FieldDefinitionHelpers
    {
        public static string ToGridHeaderString(this IFieldDefinition fieldDefinition)
        {
            return fieldDefinition.ToGridHeaderString(LabelForExtensions.DefaultPopupWidth, fieldDefinition.FieldDefinitionDisplayName);
        }

        public static string ToGridHeaderString(this IFieldDefinition fieldDefinition, string linkText)
        {
            return fieldDefinition.ToGridHeaderString(LabelForExtensions.DefaultPopupWidth, linkText);
        }

        public static string ToGridHeaderString(this IFieldDefinition fieldDefinition, int popupWidth)
        {
            return fieldDefinition.ToGridHeaderString(popupWidth, fieldDefinition.FieldDefinitionDisplayName);
        }

        private static string ToGridHeaderString(this IFieldDefinition fieldDefinition, int popupWidth, string fieldDefinitionDisplayName)
        {
            return
                LabelForExtensions.LabelWithFieldDefinitionFor(fieldDefinition, popupWidth,
                    LabelForExtensions.DisplayStyle.AsGridHeader, fieldDefinitionDisplayName).ToString();
        }

        public static string ToGridHeaderStringWider(this IFieldDefinition fieldDefinition)
        {
            return fieldDefinition.ToGridHeaderString(LabelForExtensions.DefaultPopupWidthWider, fieldDefinition.FieldDefinitionDisplayName);
        }
    }
}