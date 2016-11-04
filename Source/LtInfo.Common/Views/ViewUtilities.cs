using System;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Security;
using System.Text;
using System.Web;
using System.Xml;
using LtInfo.Common.DhtmlWrappers;
using LtInfo.Common.Models;
using LtInfo.Common.MvcResults;

namespace LtInfo.Common.Views
{
    public static class ViewUtilities
    {
        public const string NoneString = "None";
        public const string NoAnswerProvided = "<No answer provided>";
        public const string NoCommentString = "<no comment>";
        public const string NaString = "n/a";
        public const string NotFoundString = "(not found)";
        public const string NotAvailableString = "Not available";
        public const string NotProvidedString = "not provided";
        public const string NoChangesRecommended = "No changes recommended";
        public const string NotApplicableIndicatorIsInAttainment = "Not applicable.  Indicator is in attainment.";

        public static string CheckedIfEqual(int? value, int testValue)
        {
            return (value.HasValue && testValue == value.Value).ToCheckedOrEmpty();
        }

        public static string CheckedIfEqual(bool? value, bool testValue)
        {
            return (value.HasValue && testValue == value.Value).ToCheckedOrEmpty();
        }

        public static string Prune(this string value, int totalLength)
        {
            if (String.IsNullOrEmpty(value))
                return value;

            if (value.Length < totalLength)
                return value;

            return String.Format("{0}...", value.Substring(0, totalLength - 3));
        }

        public static string Flatten(this string value, string replacement)
        {
            return String.IsNullOrEmpty(value) ? value : value.Replace("\r\n", replacement).Replace("\n", replacement).Replace("\r", replacement);
        }

        public static string Flatten(this string value)
        {
            return Flatten(value, " ");
        }

        public static string HtmlEncode(this string value)
        {
            return String.IsNullOrEmpty(value) ? value : HttpUtility.HtmlEncode(value);
        }

        public static string HtmlEncodeWithBreaks(this string value)
        {
            var ret = value.HtmlEncode();
            return String.IsNullOrEmpty(ret) ? ret : ret.Replace("\r\n","\n").Replace("\r","\n").Replace("\n", "<br/>\r\n");
        }

        /// <summary>
        /// Adds the proper HTTP headers for a file download.  <see>
        ///                                                        <cref>SitkaGlobalBase.AddCachingHeaders</cref>
        ///                                                    </see>
        /// </summary>
        public static void SetupHttpHeadersForDownload(HttpResponseBase response, DownloadFileDescriptor descriptor)
        {
            SetupHttpHeadersForDownloadImpl(response, descriptor, Encoding.Default);
        }

        /// <summary>
        /// Adds the proper HTTP headers for a file download.  <see>
        ///                                                        <cref>SitkaGlobalBase.AddCachingHeaders</cref>
        ///                                                    </see>
        /// </summary>
        public static void SetupHttpHeadersForDownload(HttpResponseBase response, DownloadFileDescriptor descriptor, Encoding downloadContentEncoding)
        {
            SetupHttpHeadersForDownloadImpl(response, descriptor, downloadContentEncoding);
        }

        private static void SetupHttpHeadersForDownloadImpl(HttpResponseBase response, DownloadFileDescriptor descriptor, Encoding downloadContentEncoding)
        {
            // Leaving this ClearHeaders since it is IMMEDIDATELY followed by a line replacing the SetExpires below. -- SLG 10/2/2012
            response.ClearHeaders();
            SetupHttpContentDispositionForDownload(response, descriptor, downloadContentEncoding);
            SetupHttpCachingHeaders(response);
        }

        /// <summary>
        /// Adds the proper HTTP headers for a file download.  <see>
        ///                                                        <cref>SitkaGlobalBase.AddCachingHeaders</cref>
        ///                                                    </see>
        /// </summary>
        public static void SetupHttpHeadersForDownload(HttpResponseBase response)
        {
            // Leaving this ClearHeaders since it is IMMEDIDATELY followed by a line replacing the SetExpires below. -- SLG 10/2/2012
            response.ClearHeaders();
            SetupHttpCachingHeaders(response);
        }

        private static void SetupHttpCachingHeaders(HttpResponseBase response)
        {
            // this is to fix the problem with IE opening csv files under ssl.  you must set these headers, and these headers only.
            // you CANNOT set Cache-Control: no-store and Pragma: no-cache.
            // You HAVE to set Cache-Control: max-age=0
            // the other cache headers should match the global.asax.cs

            // Cache-Control: private
            response.Cache.SetCacheability(HttpCacheability.Private);

            // Cache-Control: must-revalidate
            response.Cache.SetRevalidation(HttpCacheRevalidation.AllCaches);

            // Expires: Mon, 01 Jan 1990 00:00:00 GMT
            response.Cache.SetExpires(DateTime.Parse("01 Jan 1990 00:00:00 GMT"));

            // Cache-Control: max-age=0
            response.Cache.SetMaxAge(TimeSpan.Zero);
        }

        private static void SetupHttpContentDispositionForDownload(HttpResponseBase response, DownloadFileDescriptor descriptor, Encoding downloadContentEncoding)
        {
            response.ContentType = descriptor.MimeType;

            response.ContentEncoding = downloadContentEncoding;

            var filename = descriptor.ToStandardizedCsvDownloadFilename();
            var contentDisposition = String.Format("attachment; filename=\"{0}\"", filename);
            response.AddHeader("Content-Disposition", contentDisposition);
        }

        public static string DataTableToCsv(this DataTable table, GridSpec<IStringIndexer> spec)
        {
            var output = new StringBuilder();

            output.AppendLine(ToCsvExtensionMethods.EnumerableStringToCsvRow(spec.ColumnNames));

            var reader = table.CreateDataReader();

            while (reader.Read())
            {
                var line = String.Join(ToCsvExtensionMethods.CsvDelimiter, spec.Select(cs => ToCsvExtensionMethods.CsvEscape(cs.CalculateStringValue(AdaptReaderToIStringIndexer(reader)))));
                output.AppendLine(line);
            }

            reader.Close();

            return output.ToString();
        }

        public static string DataTableToXmlRowCol(this DataTable table, GridSpec<IStringIndexer> spec)
        {
            var rowID = 0;

            using (var stream = new MemoryStream())
            using (var writer = new XmlTextWriter(stream, null))
            {
                writer.WriteStartElement("rows");
                var reader = table.CreateDataReader();

                while (reader.Read())
                {
                    var indexer = AdaptReaderToIStringIndexer(reader);
                    indexer.ToXmlRowCell(writer, rowID, spec);
                    rowID++;
                }

                reader.Close();
                writer.WriteFullEndElement();
                writer.Flush();

                var array = stream.ToArray();
                var s = Encoding.UTF8.GetString(array);

                return s;
            }
        }

        public static void ToXmlRowCell<T>(this T thingToRead, XmlTextWriter writer, int rowID, GridSpec<T> gridSpec)
        {
            writer.WriteStartElement("row");
            writer.WriteAttributeString("id", rowID.ToString(CultureInfo.InvariantCulture));

            foreach (var columnSpec in gridSpec)
            {
                writer.WriteStartElement("cell");

                var cellCssClass = columnSpec.CalculateCellCssClass(thingToRead);
                var title = columnSpec.CalculateTitle(thingToRead);

                if (!String.IsNullOrEmpty(cellCssClass))
                {
                    writer.WriteAttributeString("class", cellCssClass);
                }

                if (!String.IsNullOrEmpty(title))
                {
                    writer.WriteAttributeString("title", title);
                }

                //if (columnSpec.IsHidden)
                //{
                //    writer.WriteAttributeString("hidden", "true");
                //}

                var value = columnSpec.CalculateStringValue(thingToRead) ?? String.Empty;
                var stripped = XmlResult.StripInvalidCharacters(value);
                var xmlEncoded = SecurityElement.Escape(stripped);
                var translated = XmlResult.XmlEncodeCodePage1252Characters(xmlEncoded);

                writer.WriteRaw(translated);
                writer.WriteFullEndElement();
            }

            writer.WriteFullEndElement();
        }

        private static IStringIndexer AdaptReaderToIStringIndexer(DataTableReader reader)
        {
            return new StringIndexerDataReader(reader);
        }


        public static string DisplayDataLine(Func<object> value)
        {
            return DisplayDataLine(true, value);
        }

        public static string DisplayDataLineDefaultString(string defaultString)
        {
            var result = "<p style=\"color:grey\">" + defaultString + "</p>";
            return result;
        }

        public static string DisplayDataLine(bool predicate, Func<object> stringFuncIfTrue, string stringIfFalse)
        {
            var result = stringIfFalse;

            if (predicate)
            {
                var o = stringFuncIfTrue();
                if (o != null)
                    result = o.ToString();
            }
            return result.HtmlEncode().Flatten("<br/>");
        }

        public static string DisplayDataLine(bool predicate, Func<object> stringFuncIfTrue)
        {
            return DisplayDataLine(predicate, stringFuncIfTrue, NoneString);
        }

        public static string DisplayValue(this int value, string stringIfNullOrDefault)
        {
            return new int?(value).DisplayValue(stringIfNullOrDefault);
        }

        public static string DisplayValue(this int? value, string stringIfNullOrDefault)
        {
            return value == null || value == default(int) ? stringIfNullOrDefault : value.ToString();
        }

        public static string DisplayValue(this int? value)
        {
            return DisplayValue(value, String.Empty);
        }

        public static string DisplayValue(this int value)
        {
            return DisplayValue(value, String.Empty);
        }

        public static string DisplayValue(this DateTime? value, string format)
        {
            return value == null ? String.Empty : value.Value.ToString(format);
        }

        public static string DisplayValue(this Boolean? value)
        {
            return value == null ? String.Empty : value.Value.ToString();
        }
    }
}