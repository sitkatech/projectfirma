/*-----------------------------------------------------------------------
<copyright file="OgrInfoCommandLineRunner.cs" company="Sitka Technology Group">
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
using System.IO;
using System.Linq;
using LtInfo.Common.DesignByContract;

namespace LtInfo.Common.GdalOgr
{
    public static class OgrInfoCommandLineRunner
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ogrInfoExecutableFileInfo">Path to the ogrinfo.exe executable</param>
        /// <param name="gdbFileInfo"></param>
        /// <param name="originalFilename">This is the original name of the file as it appeared on the users file system. It is provided just for error messaging purposes.</param>
        /// <param name="totalMilliseconds"></param>
        /// <returns></returns>
        public static List<string> GetFeatureClassNamesFromFileGdb(FileInfo ogrInfoExecutableFileInfo, FileInfo gdbFileInfo, string originalFilename, double totalMilliseconds)
        {
            // ReSharper disable once AssignNullToNotNullAttribute
            var gdalDataDirectory = new DirectoryInfo(Path.Combine(ogrInfoExecutableFileInfo.DirectoryName, "gdal-data"));
            var commandLineArguments = BuildOgrInfoCommandLineArgumentsToListFeatureClasses(gdbFileInfo, gdalDataDirectory);
            var processUtilityResult = ProcessUtility.ShellAndWaitImpl(ogrInfoExecutableFileInfo.DirectoryName, ogrInfoExecutableFileInfo.FullName, commandLineArguments, true, Convert.ToInt32(totalMilliseconds));
            if (processUtilityResult.ReturnCode != 0)
            {
                throw new SitkaDisplayErrorException($"{ogrInfoExecutableFileInfo.FullName} unable to open GDB file {gdbFileInfo.FullName} - original filename {originalFilename}.");
            }

            var featureClassesFromFileGdb = processUtilityResult.StdOut.Split(new[] {"\r\n"}, StringSplitOptions.RemoveEmptyEntries).ToList();
            return featureClassesFromFileGdb.Select(x => x.Split(' ').Skip(1).First()).ToList();
        }

        public static Tuple<double, double, double, double> GetExtentFromGeoJson(FileInfo ogrInfoFileInfo, string geoJson, double totalMilliseconds)
        {
            using (var geoJsonFile = DisposableTempFile.MakeDisposableTempFileEndingIn(".json"))
            {
                File.WriteAllText(geoJsonFile.FileInfo.FullName, geoJson);

                var gdalDataDirectory = new DirectoryInfo(Path.Combine(ogrInfoFileInfo.DirectoryName, "gdal-data"));
                var commandLineArguments = BuildOgrInfoCommandLineArgumentsGetExtent(geoJsonFile.FileInfo, gdalDataDirectory);
                var processUtilityResult = ProcessUtility.ShellAndWaitImpl(ogrInfoFileInfo.DirectoryName, ogrInfoFileInfo.FullName, commandLineArguments, true, Convert.ToInt32(totalMilliseconds));

                var lines = processUtilityResult.StdOut.Split(new[] {"\r\n"}, StringSplitOptions.RemoveEmptyEntries).ToList();

                // I believe this is happening irregularly - I see crashes below I can't readily reproduce. This is an attempt to narrow down the problem.
                // (Is the problem that a simple GET request is pounding on the Ogr2Ogr command line .EXE, and that the .EXE then gets too busy/overwhelmed to process multiple requests? 
                //  Just my first guess. -- SLG 9/30/2019)
                Check.Ensure(lines.Any(), $"No lines found returning from exec of \"{ogrInfoFileInfo.Name}\" in processed GeoJson string \"{geoJson}\". Raw StdOut: \"{processUtilityResult.StdOut}\"");

                if (lines.Any(x => x.Contains("Feature Count: 0")))
                {
                    return null;
                }

                // We see crash here: "Sequence contains no matching element" on lines.First(..)
                var extentTokens = lines.First(x => x.StartsWith("Extent:")).Split(new[] {' ', '(', ')', ','}, StringSplitOptions.RemoveEmptyEntries).ToList();
                return new Tuple<double, double, double, double>(double.Parse(extentTokens[1]), double.Parse(extentTokens[2]), double.Parse(extentTokens[4]), double.Parse(extentTokens[5]));
            }
        }

        public static List<string> BuildOgrInfoCommandLineArgumentsToListFeatureClasses(FileInfo inputGdbFile, DirectoryInfo gdalDataDirectoryInfo)
        {
            var commandLineArguments =  new List<string>
            {
                "--config",
                "GDAL_DATA",
                gdalDataDirectoryInfo.FullName,
                "-ro",
                "-so",
                "-q",
                inputGdbFile.FullName
            };

            return commandLineArguments;
        }
        public static List<string> BuildOgrInfoCommandLineArgumentsGetExtent(FileInfo inputGdbFile, DirectoryInfo gdalDataDirectoryInfo)
        {
            var commandLineArguments =  new List<string>
            {
                "--config",
                "GDAL_DATA",
                gdalDataDirectoryInfo.FullName,
                "-ro",
                "-al",
                "-so",
                "-geom=NO",
                inputGdbFile.FullName
            };

            return commandLineArguments;
        }
    }
}
