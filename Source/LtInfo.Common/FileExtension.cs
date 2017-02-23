/*-----------------------------------------------------------------------
<copyright file="FileExtension.cs" company="Sitka Technology Group">
Copyright (c) Sitka Technology Group. All rights reserved.
<author>Sitka Technology Group</author>
<date>Wednesday, February 22, 2017</date>
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
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace LtInfo.Common
{
    public class FileExtension
    {
        private readonly string _extension;

        private FileExtension(string extension)
        {
            _extension = extension;
        }

        private static readonly Regex _legalExtensionRegex = new Regex(@"[^\w]", RegexOptions.Compiled);
        public static FileExtension Parse(string name)
        {
            name = _legalExtensionRegex.Replace(name, "");
            return All.SingleOrDefault(x => x._extension == name.ToLower());
        }

        public static implicit operator string(FileExtension mt)
        {
            return mt._extension;
        }

        public string Extension { get { return _extension; } }

        public static readonly FileExtension Accdb = new FileExtension("accdb");
        public static readonly FileExtension Csv = new FileExtension("csv");
        public static readonly FileExtension Doc = new FileExtension("doc");
        public static readonly FileExtension Docx = new FileExtension("docx");
        public static readonly FileExtension Gif = new FileExtension("gif");
        public static readonly FileExtension Htm = new FileExtension("htm");
        public static readonly FileExtension Html = new FileExtension("html");
        public static readonly FileExtension Jpeg = new FileExtension("jpeg");
        public static readonly FileExtension Jpg = new FileExtension("jpg");
        public static readonly FileExtension Mdb = new FileExtension("mdb");
        public static readonly FileExtension Mov = new FileExtension("mov");
        public static readonly FileExtension Mpeg = new FileExtension("mpeg");
        public static readonly FileExtension Mpg = new FileExtension("mpg");
        public static readonly FileExtension Mp4 = new FileExtension("mp4");
        public static readonly FileExtension Pdf = new FileExtension("pdf");
        public static readonly FileExtension Png = new FileExtension("png");
        public static readonly FileExtension Ppt = new FileExtension("ppt");
        public static readonly FileExtension Pptx = new FileExtension("pptx");
        public static readonly FileExtension Qt = new FileExtension("qt");
        public static readonly FileExtension Txt = new FileExtension("txt");
        public static readonly FileExtension Tgz = new FileExtension("tgz");
        public static readonly FileExtension Xls = new FileExtension("xls");
        public static readonly FileExtension Xlsx = new FileExtension("xlsx");
        public static readonly FileExtension Xlsm = new FileExtension("xlsm");
        public static readonly FileExtension Zip = new FileExtension("zip");
        public static readonly FileExtension Vsd = new FileExtension("vsd");
        public static readonly FileExtension Xml = new FileExtension("xml");
        public static readonly FileExtension Msi = new FileExtension("msi");

        public static readonly List<FileExtension> All = new List<FileExtension> { 
            Accdb,
            Csv, 
            Doc, Docx, 
            Gif, 
            Htm, Html, 
            Jpeg, Jpg, 
            Mdb, Mp4, Mpeg, Mpg, Mov, 
            Pdf, Png, Ppt, Pptx, 
            Qt, 
            Txt, 
            Xls, Xlsx, Xlsm,
            Vsd,
            Zip ,
            Xml,
            Msi
        };
    }
}
