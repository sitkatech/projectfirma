/*-----------------------------------------------------------------------
<copyright file="TextAreaWithMaxLengthAttribute.cs" company="Sitka Technology Group">
Copyright (c) Sitka Technology Group. All rights reserved.
<author>Sitka Technology Group</author>
</copyright>

<license>
This program is free software: you can redistribute it and/or modify
it under the terms of the GNU Affero General Public License as published by
the Free Software Foundation, either version 3 of the License, or
(at your option) any later version.

This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU Affero General Public License <http://www.gnu.org/licenses/> for more details.

Source code is available upon request via <support@sitkatech.com>.
</license>
-----------------------------------------------------------------------*/
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
