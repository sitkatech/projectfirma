using System;

namespace LtInfo.Common.Views
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public sealed class TextAreaWithMaxLengthAttribute : Attribute
    {
        // At or below this number of characters, the text turns red
        private const int LowCharacterCount = 20;

        //public TextAreaEnableType EnableType { get; set; }
        public int? MaxLength { get; set; }
        public int? Rows { get; set; }
        public int? Columns { get; set; }
        public int LowCharacterCountWarning { get { return LowCharacterCount; } }
        public string CharactersRemainingPrefixString { get { return "Characters Remaining: "; } }
        
        public TextAreaWithMaxLengthAttribute()
        {
            GhostText = "";
            InactiveCssClass = "inactve-text-area";
            ActiveCssClass = "active-text-area";
        }

        public TextAreaWithMaxLengthAttribute(int maxLength, string defaultText)
            :this(maxLength)
        {
            GhostText = defaultText;
        }

        /// <summary>
        /// For use in MetaData annotations
        /// </summary>
        public TextAreaWithMaxLengthAttribute(int maxLength, int rows, int columns)
            : this()
        {
            MaxLength = maxLength;
            Rows = rows;
            Columns = columns;
        }

        public string GhostText { get; set; }

        public string ActiveCssClass { get; private set; }

        public string InactiveCssClass { get; private set; }

        public TextAreaWithMaxLengthAttribute(int maxLength)
            :this()
        {
            MaxLength = maxLength;            
        }
        
        public string CharactersRemainingElementName(string propertyName)
        {
            return string.Format("CharactersRemaining_{0}", propertyName);
        }

        public int? CharactersRemaining(string textAreaContents)
        {
            if (textAreaContents == null) return MaxLength;
            return MaxLength - textAreaContents.Length;
        }

        // This gets used when the page *first* loads. Thereafter, once there are key events in the text pane, the JavaScript handles
        // color updating.
        public string LimitStringStyle(string textAreaContents)
        {
            var charLimitStyle = (CharactersRemaining(textAreaContents) <= LowCharacterCountWarning) ? "color:red;" : "color:#666666;";
            return string.Format("text-align:right;{0}", charLimitStyle);
        }
    }
}