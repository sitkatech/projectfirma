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