using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Web.Mvc;
using System.Xml;

namespace LtInfo.Common.MvcResults
{
    /// <summary>
    /// This class takes an XmlDocument and further massages it to remove invalid XML characters (see http://support.microsoft.com/kb/315580/en-us)
    /// </summary>
    public class XmlResult : ActionResult
    {
        public XmlResult(XmlDocument document)
        {
            _document = document;
            CleanDocumentOfLowOrderCharacters(_document.DocumentElement);
        }

        private static void CleanDocumentOfLowOrderCharacters(XmlNode element)
        {
            StripInvalidCharacters(element);
            foreach (XmlNode childElement in element.ChildNodes)
            {
                CleanDocumentOfLowOrderCharacters(childElement);
            }
        }


        // #x9 | #xA | #xD | [#x20-#xD7FF] | [#xE000-#xFFFD] | [#x10000-#x10FFFF]
        private static readonly Regex _invalidCharactersRegex = new Regex(@"[\x01-\x08\x0B-\x0C\x0E-\x1F]", RegexOptions.Compiled);
        public static string StripInvalidCharacters(string value)
        {
            if (value != null)
            {
                value = _invalidCharactersRegex.Replace(value, String.Empty);
            }
            return value;
        }

        private static void StripInvalidCharacters(XmlNode element)
        {
            if (element.Value != null)
            {
                element.Value = StripInvalidCharacters(element.Value);
            }
        }

        /// <summary>
        /// The windows 1252 code page utilizes non-ascii characters in the range 0x80-0xFF which are present in data pasted from windows
        /// applications.  These characters in the data are not valid UTF8 encodings and will cause xml parsers to fail. in
        /// order to display them, we need to xml-encode the best-fit unicode mappings for these characters. 
        /// </summary>
        static readonly Dictionary<int, string> _bestFitTranlation = new Dictionary<int, string>
        {
            {0x80,	"&#x20ac;"}
            ,   {0x81,	"&#x0081;"}
            ,   {0x82,	"&#x201a;"}
            ,   {0x83,	"&#x0192;"}
            ,   {0x84,	"&#x201e;"}
            ,   {0x85,	"&#x2026;"}
            ,   {0x86,	"&#x2020;"}
            ,   {0x87,	"&#x2021;"}
            ,   {0x88,	"&#x02c6;"}
            ,   {0x89,	"&#x2030;"}
            ,   {0x8a,	"&#x0160;"}
            ,   {0x8b,	"&#x2039;"}
            ,   {0x8c,	"&#x0152;"}
            ,   {0x8d,	"&#x008d;"}
            ,   {0x8e,	"&#x017d;"}
            ,   {0x8f,	"&#x008f;"}
            ,   {0x90,	"&#x0090;"}
            ,   {0x91,	"&#x2018;"}
            ,   {0x92,	"&#x2019;"}
            ,   {0x93,	"&#x201c;"}
            ,   {0x94,	"&#x201d;"}
            ,   {0x95,	"&#x2022;"}
            ,   {0x96,	"&#x2013;"}
            ,   {0x97,	"&#x2014;"}
            ,   {0x98,	"&#x02dc;"}
            ,   {0x99,	"&#x2122;"}
            ,   {0x9a,	"&#x0161;"}
            ,   {0x9b,	"&#x203a;"}
            ,   {0x9c,	"&#x0153;"}
            ,   {0x9d,	"&#x009d;"}
            ,   {0x9e,	"&#x017e;"}
            ,   {0x9f,	"&#x0178;"}
        };

        private static readonly Regex _highByteChars = new Regex(@"[\x80-\xFF]", RegexOptions.Compiled);
        public static string XmlEncodeCodePage1252Characters(string unClean)
        {
            if (String.IsNullOrEmpty(unClean))
                return unClean;

            if (!_highByteChars.IsMatch(unClean))
                return unClean;

            var cleanedString = new StringBuilder();
            var encoding = Encoding.GetEncoding(1252);
            var bytes = encoding.GetBytes(unClean);

            for (var i = 0; i < bytes.Length; i++)
            {
                if (bytes[i] > 0x7f && bytes[i] < 0xa0)
                {
                    // translate to best fit, then encode
                    if (_bestFitTranlation.ContainsKey(bytes[i]))
                        cleanedString.Append(_bestFitTranlation[bytes[i]]);
                }
                else if (bytes[i] >= 0xa0 && bytes[i] <= 0xff)
                {
                    // no translation, just output as four digit unicode entity
                    cleanedString.Append(string.Format("&#x{0:x4};", bytes[i]));
                }
                else
                {
                    cleanedString.Append(encoding.GetString(bytes, i, 1));
                }
            }

            return cleanedString.ToString();
        }

        private readonly XmlDocument _document;

        public override void ExecuteResult(ControllerContext context)
        {
            context.HttpContext.Response.ContentEncoding = Encoding.ASCII;
            context.HttpContext.Response.AddHeader("Content-type", "text/xml");
            context.HttpContext.Response.Write(_document.InnerXml);
        }
    }
}