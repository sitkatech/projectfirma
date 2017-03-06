/*-----------------------------------------------------------------------
<copyright file="MimeType.cs" company="Sitka Technology Group">
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
using System.Collections.Generic;
using System.Linq;

namespace LtInfo.Common
{
    public class MimeType
    {
        private readonly string _mimeType;
        private readonly List<FileExtension> _fileExtensions;
        private readonly string _icon;

        MimeType(string mimeType, List<FileExtension> fileExtensions, string icon)
        {
            _mimeType = mimeType;
            _fileExtensions = fileExtensions;
            _icon = icon;
        }

        public static MimeType Parse(string name)
        {
            return All.SingleOrDefault(x => x._mimeType.ToLower() == name.ToLower());
        }

        public static implicit operator string(MimeType mt)
        {
            return mt._mimeType.ToLower();
        }

        public List<FileExtension> FileExtensions
        {
            get
            {
                return _fileExtensions;
            }
        }

        public string Icon
        {
            get
            {
                return _icon;
            }
        }

        // reference: http://www.w3schools.com/media/media_mimeref.asp
        // and: http://en.wikipedia.org/wiki/Internet_media_type
        
        public static readonly MimeType ApplicationDoc = new MimeType("application/msword", new List<FileExtension> {FileExtension.Doc}, "doc.png");
        public static readonly MimeType ApplicationDocx = new MimeType("application/vnd.openxmlformats-officedocument.wordprocessingml.document", new List<FileExtension> {FileExtension.Docx}, "doc.png");
        public static readonly MimeType ApplicationMdb = new MimeType("application/msaccess", new List<FileExtension>(), "unknown.png");
        
        public static readonly MimeType ApplicationPdf = new MimeType("application/pdf", new List<FileExtension> { FileExtension.Pdf }, "pdf.png");
        public static readonly MimeType ApplicationXpdf = new MimeType("application/x-pdf", new List<FileExtension> { FileExtension.Pdf }, "pdf.png");
        public static readonly MimeType ApplicationAcrobat = new MimeType("application/acrobat", new List<FileExtension> { FileExtension.Pdf }, "pdf.png");
        public static readonly MimeType ApplicationVndPdf = new MimeType("application/vnd.pdf", new List<FileExtension> { FileExtension.Pdf }, "pdf.png");

        public static readonly MimeType ApplicationOctetStream = new MimeType("application/octet-stream", new List<FileExtension> { FileExtension.Pdf }, "pdf.png");

        public static readonly MimeType TextPdf = new MimeType("text/pdf", new List<FileExtension> { FileExtension.Pdf }, "pdf.png");
        public static readonly MimeType TextXpdf = new MimeType("text/x-pdf", new List<FileExtension> { FileExtension.Pdf }, "pdf.png");

        public static readonly MimeType ApplicationPpt = new MimeType("application/vnd.ms-powerpoint", new List<FileExtension> { FileExtension.Ppt }, "ppt.png");
        public static readonly MimeType ApplicationPptx = new MimeType("application/vnd.openxmlformats-officedocument.presentationml.presentation", new List<FileExtension> { FileExtension.Pptx }, "pptx.png");
        public static readonly MimeType ApplicationVsd = new MimeType("application/visio", new List<FileExtension> { FileExtension.Vsd }, "vsd.png");
        public static readonly MimeType ApplicationXls = new MimeType("application/vnd.ms-excel", new List<FileExtension> {FileExtension.Xls}, "xls.png");
        public static readonly MimeType ApplicationXlsx = new MimeType("application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", new List<FileExtension> {FileExtension.Xlsx}, "xls.png");

        public static readonly MimeType ApplicationXlsm = new MimeType("application/vnd.ms-excel.sheet.macroEnabled.12", new List<FileExtension> { FileExtension.Xlsm }, "xls.png");

        public static readonly MimeType ApplicationZip = new MimeType("application/zip", new List<FileExtension> { FileExtension.Zip }, "zip.png");

        public static readonly MimeType ImageJpg = new MimeType("image/jpeg", new List<FileExtension> {FileExtension.Jpeg, FileExtension.Jpg}, "jpg.png");
        public static readonly MimeType ImagePjpg = new MimeType("image/pjpeg", new List<FileExtension> { FileExtension.Jpeg, FileExtension.Jpg }, "jpg.png"); //IE uploads some jpegs as pjpegs...
        public static readonly MimeType ImageGif = new MimeType("image/gif", new List<FileExtension> { FileExtension.Gif }, "gif.png");
        public static readonly MimeType ImagePng = new MimeType("image/png", new List<FileExtension> {FileExtension.Png}, "unknown.png");
        public static readonly MimeType ImageXpng = new MimeType("image/x-png", new List<FileExtension> { FileExtension.Png }, "unknown.png"); //IE uploads some pngs as x-pngs...

        public static readonly MimeType TextCsv = new MimeType("text/csv", new List<FileExtension> { FileExtension.Csv }, "csv.png");
        public static readonly MimeType TextHtml = new MimeType("text/html", new List<FileExtension> { FileExtension.Htm, FileExtension.Html }, "unknown.png");
        public static readonly MimeType TextPlain = new MimeType("text/plain", new List<FileExtension> { FileExtension.Txt }, "txt.png");

        public static readonly MimeType VideoMp4 = new MimeType("video/mp4", new List<FileExtension> { FileExtension.Mp4 }, "unknown.png");
        public static readonly MimeType VideoMpeg = new MimeType("video/mpeg", new List<FileExtension> { FileExtension.Mpeg, FileExtension.Mpg }, "mpeg.png");
        public static readonly MimeType VideoQuicktime = new MimeType("video/quicktime", new List<FileExtension> { FileExtension.Mov, FileExtension.Qt }, "quicktime.png");

        public static readonly MimeType Xml = new MimeType("application/xml", new List<FileExtension> { FileExtension.Xml }, "unknown.png");

        public static readonly MimeType Msi = new MimeType("application/x-msi",
                                                           new List<FileExtension> {FileExtension.Msi}, "unknown.png");

        public static readonly MimeType BinaryOctetStream = new MimeType("binary/octet-stream", new List<FileExtension>(), "unknown.png");

        public static readonly List<MimeType> All = new List<MimeType>
        {
            ApplicationAcrobat,
            ApplicationDoc,
            ApplicationDocx,
            ApplicationMdb,
            ApplicationOctetStream,
            ApplicationPdf,
            ApplicationPpt,
            ApplicationPptx,
            ApplicationVndPdf,
            ApplicationVsd,
            ApplicationXls,
            ApplicationXlsx,
            ApplicationXpdf,
            ApplicationZip,
            ImageGif,
            ImageJpg,
            ImagePjpg,
            ImagePng,
            ImageXpng,
            TextCsv,
            TextPdf,
            TextPlain,
            TextXpdf,
            BinaryOctetStream,
            VideoMp4,
            VideoMpeg
        };

        public static readonly List<MimeType> Photos = new List<MimeType> { ImageGif, ImageJpg, ImagePjpg, ImagePng, ImageXpng };
        public static readonly List<MimeType> Video = new List<MimeType> { VideoMp4, VideoMpeg, VideoQuicktime };
        public static readonly List<MimeType> Pdfs = new List<MimeType> { ApplicationPdf, ApplicationXpdf, ApplicationAcrobat, ApplicationVndPdf, TextPdf, TextXpdf };


        /// <summary>
        /// Return a MimeType for a given FileExtension
        /// </summary>
        /// <param name="fileExtension"></param>
        /// <returns></returns>
        public static MimeType DefaultMimeTypeForFileExtension(FileExtension fileExtension)
        {
            if (fileExtension != null && _defaultExtensionMappings.ContainsKey(fileExtension))
                return _defaultExtensionMappings[fileExtension];

            return MimeType.BinaryOctetStream;
        }

        private static readonly Dictionary<FileExtension, MimeType> _defaultExtensionMappings = new Dictionary<FileExtension, MimeType>()
            { 
                {FileExtension.Accdb,   MimeType.ApplicationMdb},
                {FileExtension.Csv,     MimeType.TextCsv},
                {FileExtension.Doc,     MimeType.ApplicationDoc},
                {FileExtension.Docx,    MimeType.ApplicationDocx},
                {FileExtension.Gif,     MimeType.ImageGif},
                {FileExtension.Html,    MimeType.TextHtml},
                {FileExtension.Htm,     MimeType.TextHtml},
                {FileExtension.Jpg,     MimeType.ImageJpg},
                {FileExtension.Jpeg,    MimeType.ImageJpg},
                {FileExtension.Mdb,     MimeType.ApplicationMdb},
                {FileExtension.Mov,     MimeType.VideoQuicktime},
                {FileExtension.Mp4,     MimeType.VideoMp4},
                {FileExtension.Mpeg,    MimeType.VideoMpeg},
                {FileExtension.Mpg,     MimeType.VideoMpeg},
                {FileExtension.Pdf,     MimeType.ApplicationPdf},
                {FileExtension.Png,     MimeType.ImagePng},
                {FileExtension.Ppt,     MimeType.ApplicationPpt},
                {FileExtension.Pptx,    MimeType.ApplicationPptx},
                {FileExtension.Qt,      MimeType.VideoQuicktime},
                {FileExtension.Txt,     MimeType.TextPlain},
                {FileExtension.Vsd,     MimeType.ApplicationVsd},
                {FileExtension.Xls,     MimeType.ApplicationXls},
                {FileExtension.Xlsx,    MimeType.ApplicationXlsx},
                {FileExtension.Zip,     MimeType.ApplicationZip}
            };

        public string MimeTypeString { get { return _mimeType; }}

        /// <summary>
        /// Indicates if it's a match on mime type
        /// </summary>
        /// <returns></returns>
        public bool IsMimeTypeMatch(string contentType)
        {
            return String.Equals(_mimeType, contentType);
        }
    }
}
