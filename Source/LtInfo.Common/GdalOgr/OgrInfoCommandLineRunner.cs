/*-----------------------------------------------------------------------
<copyright file="OgrInfoCommandLineRunner.cs" company="Sitka Technology Group">
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
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace LtInfo.Common.GdalOgr
{
    public static class OgrInfoCommandLineRunner
    {
        public static List<string> GetFeatureClassNamesFromFileGdb(FileInfo ogrInfoFileInfo, FileInfo gdbFileInfo, double totalMilliseconds)
        {
            var commandLineArguments = BuildOgrInfoCommandLineArgumentsToListFeatureClasses(gdbFileInfo, new DirectoryInfo(ogrInfoFileInfo.FullName));
            var processUtilityResult = ProcessUtility.ShellAndWaitImpl(ogrInfoFileInfo.DirectoryName, ogrInfoFileInfo.FullName, commandLineArguments, true, Convert.ToInt32(totalMilliseconds));

            var featureClassesFromFileGdb = processUtilityResult.StdOut.Split(new[] {"\r\n"}, StringSplitOptions.RemoveEmptyEntries).ToList();
            return featureClassesFromFileGdb.Select(x => x.Split(' ').Skip(1).First()).ToList();
        }

        public static Tuple<double, double, double, double> GetExtentFromGeoJson(FileInfo ogrInfoFileInfo, string geoJson, double totalMilliseconds)
        {
            using (var geoJsonFile = DisposableTempFile.MakeDisposableTempFileEndingIn(".json"))
            {
                File.WriteAllText(geoJsonFile.FileInfo.FullName, geoJson);
                
                var commandLineArguments = BuildOgrInfoCommandLineArgumentsGetExtent(geoJsonFile.FileInfo, new DirectoryInfo(ogrInfoFileInfo.FullName));
                var processUtilityResult = ProcessUtility.ShellAndWaitImpl(ogrInfoFileInfo.DirectoryName, ogrInfoFileInfo.FullName, commandLineArguments, true, Convert.ToInt32(totalMilliseconds));

                var lines = processUtilityResult.StdOut.Split(new[] {"\r\n"}, StringSplitOptions.RemoveEmptyEntries).ToList();
                if (lines.Any(x => x.Contains("Feature Count: 0")))
                {
                    return null;
                }

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
