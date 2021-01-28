using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.GdalOgr;
using ProjectFirma.Web.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace ProjectFirmaModels.Models
{
    public static class ProjectLocationStagingModelExtensions
    {
        public const string FailedGeospatialImportFolderName = "FailedGeospatialImports";

        /// <summary>
        /// 
        /// </summary>
        /// <param name="gdbFile"></param>
        /// <param name="originalFilename">This is the original name of the file as it appeared on the users file system. It is provided just for error messaging purposes.</param>
        /// <param name="project"></param>
        /// <param name="currentFirmaSession"></param>
        /// <returns></returns>
        public static List<ProjectLocationStaging> CreateProjectLocationStagingListFromGdb(FileInfo gdbFile,
                                                                                           string originalFilename, 
                                                                                           Project project, 
                                                                                           FirmaSession currentFirmaSession)
        {
            var ogr2OgrCommandLineRunner = new Ogr2OgrCommandLineRunner(FirmaWebConfiguration.Ogr2OgrExecutable,
                LtInfoGeometryConfiguration.DefaultCoordinateSystemId,
                FirmaWebConfiguration.HttpRuntimeExecutionTimeout.TotalMilliseconds);

            var featureClassNames = OgrInfoCommandLineRunner.GetFeatureClassNamesFromFileGdb(new FileInfo(FirmaWebConfiguration.OgrInfoExecutable), gdbFile, originalFilename, Ogr2OgrCommandLineRunner.DefaultTimeOut);

            var projectLocationStagings =
                featureClassNames.Select(x => new ProjectLocationStaging(project, currentFirmaSession.Person, x, ogr2OgrCommandLineRunner.ImportFileGdbToGeoJson(gdbFile, x, true), true)).ToList();
            Check.Require(!projectLocationStagings.All(x => x.ToGeoJsonFeatureCollection().Features.All(y => y.Geometry == null)), new SitkaGeometryDisplayErrorException($"Cannot create stagings for a location when all features don't have a geometry."));
            return projectLocationStagings;
        }

        public static List<ProjectLocationStaging> CreateProjectLocationStagingListFromKml(FileInfo kmlFile,
            string originalFilename,
            Project project,
            FirmaSession currentFirmaSession)
        {
            var ogr2OgrCommandLineRunner = new Ogr2OgrCommandLineRunner(FirmaWebConfiguration.Ogr2OgrExecutable,
                LtInfoGeometryConfiguration.DefaultCoordinateSystemId,
                FirmaWebConfiguration.HttpRuntimeExecutionTimeout.TotalMilliseconds);

            var featureClassNames = OgrInfoCommandLineRunner.GetFeatureClassNamesFromFileKml(new FileInfo(FirmaWebConfiguration.OgrInfoExecutable), kmlFile, originalFilename, Ogr2OgrCommandLineRunner.DefaultTimeOut);

            var projectLocationStagings =
                featureClassNames.Select(x => new ProjectLocationStaging(project, currentFirmaSession.Person, "", ogr2OgrCommandLineRunner.ImportFileKmlToGeoJson(kmlFile, true), true)).ToList();
            Check.Require(!projectLocationStagings.All(x => x.ToGeoJsonFeatureCollection().Features.All(y => y.Geometry == null)), new SitkaGeometryDisplayErrorException($"Cannot create stagings for a location when all features don't have a geometry."));
            return projectLocationStagings;
        }

        public static List<ProjectLocationStaging> CreateProjectLocationStagingListFromKmz(FileInfo disposableTempFileFileInfo, string fileName, Project project, FirmaSession currentFirmaSession)
        {
            var ogr2OgrCommandLineRunner = new Ogr2OgrCommandLineRunner(FirmaWebConfiguration.Ogr2OgrExecutable,
                LtInfoGeometryConfiguration.DefaultCoordinateSystemId,
                FirmaWebConfiguration.HttpRuntimeExecutionTimeout.TotalMilliseconds);

            var featureClassNames = OgrInfoCommandLineRunner.GetFeatureClassNamesFromFileKmz(new FileInfo(FirmaWebConfiguration.OgrInfoExecutable), disposableTempFileFileInfo, fileName, Ogr2OgrCommandLineRunner.DefaultTimeOut);

            var projectLocationStagings =
                featureClassNames.Select(x => new ProjectLocationStaging(project, currentFirmaSession.Person, "", ogr2OgrCommandLineRunner.ImportFileKmzToGeoJson(disposableTempFileFileInfo, true), true)).ToList();
            Check.Require(!projectLocationStagings.All(x => x.ToGeoJsonFeatureCollection().Features.All(y => y.Geometry == null)), new SitkaGeometryDisplayErrorException($"Cannot create stagings for a location when all features don't have a geometry."));
            return projectLocationStagings;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="httpPostedFileBase"></param>
        /// <returns>Full path to preserved file</returns>
        public static string PreserveFailedLocationImportFile(HttpPostedFileBase httpPostedFileBase)
        {
            var baseTempPath = new DirectoryInfo(SitkaConfiguration.GetRequiredAppSetting("TempFolder"));
            var ogr2OgrTempPath = new DirectoryInfo(Path.Combine(baseTempPath.ToString(), FailedGeospatialImportFolderName));

            if (!ogr2OgrTempPath.Exists)
            {
                baseTempPath.CreateSubdirectory(FailedGeospatialImportFolderName);
            }

            var preservedFilename = Path.Combine(ogr2OgrTempPath.ToString(), $"{DateTime.Now.ToString("yyyyMMddhhmmss")}-{httpPostedFileBase.FileName}");
            httpPostedFileBase.SaveAs(preservedFilename);

            return preservedFilename;
        }
    }
}