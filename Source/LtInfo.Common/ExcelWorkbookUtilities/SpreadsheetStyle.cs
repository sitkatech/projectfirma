using System;
using System.Linq;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;

namespace LtInfo.Common.ExcelWorkbookUtilities
{
    /// <summary>
    /// A few parts in the ExcelWorkbookUtilities namespace used portions of code from the SimpleOOXML library: https://www.nuget.org/packages/SimpleOOXML/
    ///
    /// This library had a dependency on an older version of DocumentFormat.OpenXml that we do not want to support. The parts from the SimpleOOXML library that we used have been
    /// added to this project directly. This is all related to work done on PF #2056, #2058, and #2061.
    /// </summary>
    public class SpreadsheetStyle : ICloneable
    {
        //Constructors
        internal SpreadsheetStyle(Font font)
        {
            AddFont(font);
        }

        internal SpreadsheetStyle(Fill fill)
        {
            AddFill(fill);
        }

        internal SpreadsheetStyle(Border border)
        {
            AddBorder(border);
        }

        internal SpreadsheetStyle(Alignment alignment)
        {
            AddAlignment(alignment);
        }

        internal SpreadsheetStyle(NumberingFormat format)
        {
            AddFormat(format);
        }

        internal SpreadsheetStyle(Font font, Fill fill, Border border, Alignment alignment, NumberingFormat format)
        {
            AddFont(font);
            AddFill(fill);
            AddBorder(border);
            AddAlignment(alignment);
            AddFormat(format);
        }

        //Properties
        protected internal Italic Italic { get; set; }
        protected internal Bold Bold { get; set; }
        protected internal Underline Underline { get; set; }
        protected internal Color Color { get; set; }
        protected internal FontSize FontSize { get; set; }
        protected internal FontName FontName { get; set; }
        protected internal FontFamily FontFamily { get; set; }
        protected internal FontScheme FontScheme { get; set; }

        protected internal PatternFill PatternFill { get; set; }

        protected internal TopBorder TopBorder { get; set; }
        protected internal LeftBorder LeftBorder { get; set; }
        protected internal BottomBorder BottomBorder { get; set; }
        protected internal RightBorder RightBorder { get; set; }

        protected internal BooleanValue WrapText { get; set; }
        protected internal EnumValue<VerticalAlignmentValues> VerticalAlignment { get; set; }
        protected internal EnumValue<HorizontalAlignmentValues> HorizontalAlignment { get; set; }

        public StringValue FormatCode;

        ///<summary>
        ///Sets or gets whether the style is italic
        ///</summary>
        public bool IsItalic
        {
            get
            {
                return Italic != null;
            }
            set
            {
                if (value)
                {
                    if (Italic == null) Italic = new Italic();
                }
                else
                {
                    if (Italic != null) Italic = null;
                }
            }
        }

        ///<summary>
        ///Sets or gets whether the style is bold
        ///</summary>
        public bool IsBold
        {
            get
            {
                return Bold != null;
            }
            set
            {
                if ((value))
                {
                    if (Bold == null) Bold = new Bold();
                }
                else
                {
                    if (Bold != null) Bold = null;
                }
            }
        }

        ///<summary>
        ///Sets or gets whether the style is underline
        ///</summary>
        public bool IsUnderline
        {
            get
            {
                return Underline != null;
            }
            set
            {
                if ((value))
                {
                    if (Underline == null) Underline = new Underline();
                }
                else
                {
                    if (Underline != null) Underline = null;
                }
            }
        }

        ///<summary>
        ///Sets or gets whether the style is underline
        ///</summary>
        public bool IsWrapped
        {
            get
            {
                if (WrapText == null || !WrapText.HasValue) return false;
                return WrapText.Value;
            }
            set
            {
                if (WrapText == null) WrapText = new BooleanValue();
                WrapText.Value = value;
            }
        }

        /// <summary>
        /// Returns the default SpreadsheetStyle obejct for the spreadsheet provided.
        /// </summary>
        public static SpreadsheetStyle GetDefault(SpreadsheetDocument spreadsheet)
        {
            return SpreadsheetReader.GetDefaultStyle(spreadsheet);
        }

        ///<summary>
        ///Sets the color using R,G and B hex values eg "FF0000"
        ///</summary>
        public void SetColor(string rgb)
        {
            Color.Theme = null;
            Color.Rgb = "FF" + rgb;
        }

        ///<summary>
        ///Sets the color using R,G and B hex values eg "FF0000"
        ///</summary>
        public void SetBackgroundColor(string rgb)
        {
            if (PatternFill.BackgroundColor == null) PatternFill.BackgroundColor = new BackgroundColor();
            PatternFill.BackgroundColor.Theme = null;
            PatternFill.PatternType = new EnumValue<PatternValues>(PatternValues.Solid);
            PatternFill.BackgroundColor.Rgb = "FF" + rgb;

            if (PatternFill.ForegroundColor == null) PatternFill.ForegroundColor = new ForegroundColor();
            PatternFill.ForegroundColor.Theme = null;
            PatternFill.ForegroundColor.Rgb = "FF" + rgb;
        }

        ///<summary>
        ///Sets all four border color and styles.
        ///</summary>
        public void SetBorder(string rgb, BorderStyleValues style)
        {
            SetBorder(TopBorder, rgb, style);
            SetBorder(LeftBorder, rgb, style);
            SetBorder(RightBorder, rgb, style);
            SetBorder(BottomBorder, rgb, style);
        }

        ///<summary>
        ///Sets the top border's color and style.
        ///</summary>
        public void SetBorderTop(string rgb, BorderStyleValues style)
        {
            SetBorder(TopBorder, rgb, style);
        }

        ///<summary>
        ///Sets the left border's color and style.
        ///</summary>
        public void SetBorderLeft(string rgb, BorderStyleValues style)
        {
            SetBorder(LeftBorder, rgb, style);
        }

        ///<summary>
        ///Sets the bottom border's color and style.
        ///</summary>
        public void SetBorderBottom(string rgb, BorderStyleValues style)
        {
            SetBorder(BottomBorder, rgb, style);
        }

        ///<summary>
        ///Sets the right border's color and style.
        ///</summary>
        public void SetBorderRight(string rgb, BorderStyleValues style)
        {
            SetBorder(RightBorder, rgb, style);
        }

        ///<summary>
        ///Sets an individual border's color and style.
        ///</summary>
        protected void SetBorder(BorderPropertiesType item, string rgb, BorderStyleValues style)
        {
            if (item.Color == null) item.Color = new Color();
            item.Color.Theme = null;
            item.Color.Rgb = "FF" + rgb;
            item.Style = new EnumValue<BorderStyleValues>(style);
        }

        ///<summary>
        ///Sets the horizontal alignment value
        ///</summary>
        public void SetHorizontalAlignment(HorizontalAlignmentValues value)
        {
            if (HorizontalAlignment == null) HorizontalAlignment = new EnumValue<HorizontalAlignmentValues>();
            HorizontalAlignment.Value = value;
        }

        ///<summary>
        ///Sets the vertical alignment value
        ///</summary>
        public void SetVerticalAlignment(VerticalAlignmentValues value)
        {
            if (VerticalAlignment == null) VerticalAlignment = new EnumValue<VerticalAlignmentValues>();
            VerticalAlignment.Value = value;
        }

        ///<summary>
        ///Sets the format code value
        ///</summary>
        public void SetFormat(string format)
        {
            if (FormatCode == null) FormatCode = new StringValue();
            FormatCode.Value = format;
        }

        ///<summary>
        ///Sets all four border color and styles.
        ///</summary>
        public void ClearBorder()
        {
            ClearBorder(TopBorder);
            ClearBorder(LeftBorder);
            ClearBorder(RightBorder);
            ClearBorder(BottomBorder);
        }

        ///<summary>
        ///Sets the top border's color and style.
        ///</summary>
        public void ClearBorderTop()
        {
            ClearBorder(TopBorder);
        }

        ///<summary>
        ///Sets the left border's color and style.
        ///</summary>
        public void ClearBorderLeft()
        {
            ClearBorder(LeftBorder);
        }

        ///<summary>
        ///Sets the bottom border's color and style.
        ///</summary>
        public void ClearBorderBottom()
        {
            ClearBorder(BottomBorder);
        }

        ///<summary>
        ///Sets the right border's color and style.
        ///</summary>
        public void ClearBorderRight()
        {
            ClearBorder(RightBorder);
        }

        ///<summary>
        ///Sets an individual border's color and style.
        ///</summary>
        protected internal void ClearBorder(BorderPropertiesType item)
        {
            if (item.Color == null) item.Color = new Color();
            item.Color.Theme = null;
            item.Color.Rgb = null;
            item.Style = new EnumValue<BorderStyleValues>(BorderStyleValues.None);
        }

        ///<summary>
        ///Overrides any style information by copying from the Font object provided.
        ///</summary>
        public void AddFont(Font font)
        {
            Italic = null;
            Bold = null;
            Underline = null;

            if (font.ChildElements.OfType<Italic>().Count() > 0) Italic = new Italic();
            if (font.ChildElements.OfType<Bold>().Count() > 0) Bold = new Bold();
            if (font.ChildElements.OfType<Underline>().Count() > 0) Underline = new Underline();

            if (font.ChildElements.OfType<Color>().Count() > 0) Color = font.ChildElements.OfType<Color>().First().CloneElement<Color>();
            if (font.ChildElements.OfType<FontSize>().Count() > 0) FontSize = font.ChildElements.OfType<FontSize>().First().CloneElement<FontSize>();
            if (font.ChildElements.OfType<FontName>().Count() > 0) FontName = font.ChildElements.OfType<FontName>().First().CloneElement<FontName>();
            if (font.ChildElements.OfType<FontFamily>().Count() > 0) FontFamily = font.ChildElements.OfType<FontFamily>().First().CloneElement<FontFamily>();
            if (font.ChildElements.OfType<FontScheme>().Count() > 0) FontScheme = font.ChildElements.OfType<FontScheme>().First().CloneElement<FontScheme>();
        }

        ///<summary>
        ///Overrides any fill style information by copying from from the Fill object provided
        ///</summary>
        public void AddFill(Fill fill)
        {
            PatternFill = fill.ChildElements.OfType<PatternFill>().First().CloneElement<PatternFill>();
        }

        ///<summary>
        ///Overrides any border style information by copying from the Border object provided
        ///</summary>
        public void AddBorder(Border border)
        {
            this.TopBorder = border.TopBorder.CloneElement<TopBorder>();
            this.LeftBorder = border.LeftBorder.CloneElement<LeftBorder>();
            this.BottomBorder = border.BottomBorder.CloneElement<BottomBorder>();
            this.RightBorder = border.RightBorder.CloneElement<RightBorder>();
        }

        ///<summary>
        ///Overrides any style information by copying from the Alignment object provided.
        ///</summary>
        public void AddAlignment(Alignment alignment)
        {
            WrapText = new BooleanValue();
            HorizontalAlignment = new EnumValue<HorizontalAlignmentValues>();
            VerticalAlignment = new EnumValue<VerticalAlignmentValues>();

            if (alignment != null)
            {
                if (alignment.WrapText != null && alignment.WrapText.HasValue) WrapText.Value = alignment.WrapText.Value;
                if (alignment.Horizontal != null && alignment.Horizontal.HasValue) HorizontalAlignment.Value = alignment.Horizontal.Value;
                if (alignment.Vertical != null && alignment.Vertical.HasValue) VerticalAlignment.Value = alignment.Vertical.Value;
            }
        }

        ///<summary>
        ///Overrides any number format information by copying from from the object provided
        ///</summary>
        public void AddFormat(NumberingFormat format)
        {
            FormatCode = new StringValue();
            if (format != null && format.FormatCode != null) FormatCode.Value = format.FormatCode.Value;
        }

        ///<summary>
        ///Returns a new Font object from the style information provided
        ///</summary>
        public Font ToFont()
        {
            Font font = new Font();

            if (Italic != null) font.AppendChild<Italic>(new Italic());
            if (Bold != null) font.AppendChild<Bold>(new Bold());
            if (Underline != null) font.AppendChild<Underline>(new Underline());

            if (Color != null) font.AppendChild<Color>(Color.CloneElement<Color>());
            if (FontSize != null) font.AppendChild<FontSize>(FontSize.CloneElement<FontSize>());
            if (FontName != null) font.AppendChild<FontName>(FontName.CloneElement<FontName>());
            if (FontFamily != null) font.AppendChild<FontFamily>(FontFamily.CloneElement<FontFamily>());
            if (FontScheme != null) font.AppendChild<FontScheme>(FontScheme.CloneElement<FontScheme>());

            return font;
        }

        ///<summary>
        ///Returns a new Font object from the style information provided
        ///</summary>
        public Fill ToFill()
        {
            Fill fill = new Fill();

            fill.AppendChild<PatternFill>(PatternFill.CloneElement<PatternFill>());

            return fill;
        }

        ///<summary>
        ///Returns a new Border object from the style information provided
        ///</summary>
        public Border ToBorder()
        {
            Border border = new Border();

            border.TopBorder = TopBorder.CloneElement<TopBorder>();
            border.LeftBorder = LeftBorder.CloneElement<LeftBorder>();
            border.BottomBorder = BottomBorder.CloneElement<BottomBorder>();
            border.RightBorder = RightBorder.CloneElement<RightBorder>();
            border.DiagonalBorder = new DiagonalBorder();
            return border;
        }

        ///<summary>
        ///Returns a new Alignment object from this object
        ///</summary>
        public Alignment ToAlignment()
        {
            if ((WrapText == null || !WrapText.HasValue) && (HorizontalAlignment == null || !HorizontalAlignment.HasValue) && (VerticalAlignment == null || !VerticalAlignment.HasValue)) return null;

            var alignment = new Alignment();

            if (WrapText != null && WrapText.HasValue) alignment.WrapText = new BooleanValue(WrapText.Value);
            if (HorizontalAlignment != null && HorizontalAlignment.HasValue) alignment.Horizontal = new EnumValue<HorizontalAlignmentValues>(HorizontalAlignment.Value);
            if (VerticalAlignment != null && VerticalAlignment.HasValue) alignment.Vertical = new EnumValue<VerticalAlignmentValues>(VerticalAlignment.Value);

            return alignment;
        }

        ///<summary>
        ///Returns a new NumberFormat object from this object
        ///</summary>
        public NumberingFormat ToNumberFormat()
        {
            if (FormatCode == null || !FormatCode.HasValue) return null;

            NumberingFormat format = new NumberingFormat();
            format.FormatCode = FormatCode;
            return format;
        }

        ///<summary>
        ///Returns a deep copy of this object.
        ///</summary>
        public object Clone()
        {
            return new SpreadsheetStyle(this.ToFont(), this.ToFill(), this.ToBorder(), this.ToAlignment(), this.ToNumberFormat());
        }

        ///<summary>
        ///Determines if the two font settings supplied are the same.
        ///</summary>
        protected internal static bool CompareFont(Font font1, Font font2)
        {
            return CompareFont(new SpreadsheetStyle(font1), new SpreadsheetStyle(font2));
        }

        ///<summary>
        ///Determines if the two font settings supplied are the same.
        ///</summary>
        protected internal static bool CompareFont(Font font1, SpreadsheetStyle font2)
        {
            return CompareFont(new SpreadsheetStyle(font1), font2);
        }

        ///<summary>
        ///Determines if the two font settings supplied are the same.
        ///</summary>
        protected internal static bool CompareFont(SpreadsheetStyle font1, SpreadsheetStyle font2)
        {
            if (!font1.Italic.Compare(font2.Italic)) return false;
            if (!font1.Bold.Compare(font2.Bold)) return false;
            if (!font1.Underline.Compare(font2.Underline)) return false;

            if (!font1.Color.Compare(font2.Color)) return false;
            if (!font1.FontSize.Compare(font2.FontSize)) return false;
            if (!font1.FontName.Compare(font2.FontName)) return false;
            if (!font1.FontFamily.Compare(font2.FontFamily)) return false;
            if (!font1.FontScheme.Compare(font2.FontScheme)) return false;

            return true;
        }

        ///<summary>
        ///Determines if the two fill settings supplied are the same.
        ///</summary>
        protected internal static bool CompareFill(Fill fill1, Fill fill2)
        {
            return CompareFill(new SpreadsheetStyle(fill1), new SpreadsheetStyle(fill2));
        }

        ///<summary>
        ///Determines if the two fill settings supplied are the same.
        ///</summary>
        protected internal static bool CompareFill(Fill fill1, SpreadsheetStyle fill2)
        {
            return CompareFill(new SpreadsheetStyle(fill1), fill2);
        }

        ///<summary>
        ///Determines if the two fill settings supplied are the same.
        ///</summary>
        protected internal static bool CompareFill(SpreadsheetStyle fill1, SpreadsheetStyle fill2)
        {
            if (!fill1.PatternFill.ForegroundColor.Compare(fill2.PatternFill.ForegroundColor)) return false;
            if (!fill1.PatternFill.BackgroundColor.Compare(fill2.PatternFill.BackgroundColor)) return false;
            if (!fill1.PatternFill.PatternType.Compare(fill2.PatternFill.PatternType)) return false;

            return true;
        }

        ///<summary>
        ///Determines if the two border settings supplied are the same.
        ///</summary>
        protected internal static bool CompareBorder(Border border1, Border border2)
        {
            return CompareBorder(new SpreadsheetStyle(border1), new SpreadsheetStyle(border2));
        }

        ///<summary>
        ///Determines if the two border settings supplied are the same.
        ///</summary>
        protected internal static bool CompareBorder(Border border1, SpreadsheetStyle border2)
        {
            return CompareBorder(new SpreadsheetStyle(border1), border2);
        }

        ///<summary>
        ///Determines if the two border settings supplied are the same.
        ///</summary>
        protected internal static bool CompareBorder(SpreadsheetStyle border1, SpreadsheetStyle border2)
        {
            if (!border1.TopBorder.Compare(border2.TopBorder)) return false;
            if (!border1.LeftBorder.Compare(border2.LeftBorder)) return false;
            if (!border1.BottomBorder.Compare(border2.BottomBorder)) return false;
            if (!border1.RightBorder.Compare(border2.RightBorder)) return false;

            return true;
        }

        ///<summary>
        ///Determines if the two alignment settings supplied are the same.
        ///</summary>
        protected internal static bool CompareAlignment(Alignment alignment1, Alignment alignment2)
        {
            return CompareAlignment(new SpreadsheetStyle(alignment1), new SpreadsheetStyle(alignment2));
        }

        ///<summary>
        ///Determines if the two alignment settings supplied are the same.
        ///</summary>
        protected internal static bool CompareAlignment(Alignment alignment1, SpreadsheetStyle alignment2)
        {
            return CompareAlignment(new SpreadsheetStyle(alignment1), alignment2);
        }

        ///<summary>
        ///Determines if the two alignment settings supplied are the same.
        ///</summary>
        protected internal static bool CompareAlignment(SpreadsheetStyle alignment1, SpreadsheetStyle alignment2)
        {
            if (!alignment1.WrapText.Compare(alignment2.WrapText)) return false;
            if (!alignment1.HorizontalAlignment.Compare(alignment2.HorizontalAlignment)) return false;
            if (!alignment1.VerticalAlignment.Compare(alignment2.VerticalAlignment)) return false;

            return true;
        }

        ///<summary>
        ///Determines if the two format settings supplied are the same.
        ///</summary>
        protected internal static bool CompareNumberFormat(NumberingFormat format1, NumberingFormat format2)
        {
            return CompareNumberFormat(new SpreadsheetStyle(format1), new SpreadsheetStyle(format2));
        }

        ///<summary>
        ///Determines if the two format settings supplied are the same.
        ///</summary>
        protected internal static bool CompareNumberFormat(NumberingFormat format1, SpreadsheetStyle format2)
        {
            return CompareNumberFormat(new SpreadsheetStyle(format1), format2);
        }

        ///<summary>
        ///Determines if the two format settings supplied are the same.
        ///</summary>
        protected internal static bool CompareNumberFormat(SpreadsheetStyle format1, SpreadsheetStyle format2)
        {
            if (!format1.FormatCode.Compare(format2.FormatCode)) return false;
            return true;
        }
    }
}