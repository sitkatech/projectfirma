using System.Collections.Generic;
using System.IO;
using System.Linq;
using LtInfo.Common.GdalOgr;
using ProjectFirma.Web.Common;

namespace ProjectFirmaModels.Models
{
    public static class ProjectLocationStagingModelExtensions
    {
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
                Ogr2OgrCommandLineRunner.DefaultCoordinateSystemId,
                FirmaWebConfiguration.HttpRuntimeExecutionTimeout.TotalMilliseconds);

            var featureClassNames = OgrInfoCommandLineRunner.GetFeatureClassNamesFromFileGdb(new FileInfo(FirmaWebConfiguration.OgrInfoExecutable), gdbFile, originalFilename, Ogr2OgrCommandLineRunner.DefaultTimeOut);

            var projectLocationStagings =
                featureClassNames.Select(x => new ProjectLocationStaging(project, currentFirmaSession.Person, x, ogr2OgrCommandLineRunner.ImportFileGdbToGeoJson(gdbFile, x, true), true)).ToList();
            return projectLocationStagings;
        }

        public static List<ProjectLocationStaging> CreateProjectLocationStagingListFromKml(FileInfo kmlFile,
            string originalFilename,
            Project project,
            FirmaSession currentFirmaSession)
        {
            var ogr2OgrCommandLineRunner = new Ogr2OgrCommandLineRunner(FirmaWebConfiguration.Ogr2OgrExecutable,
                Ogr2OgrCommandLineRunner.DefaultCoordinateSystemId,
                FirmaWebConfiguration.HttpRuntimeExecutionTimeout.TotalMilliseconds);

            var featureClassNames = OgrInfoCommandLineRunner.GetFeatureClassNamesFromFileKml(new FileInfo(FirmaWebConfiguration.OgrInfoExecutable), kmlFile, originalFilename, Ogr2OgrCommandLineRunner.DefaultTimeOut);

            var projectLocationStagings =
                featureClassNames.Select(x => new ProjectLocationStaging(project, currentFirmaSession.Person, "", ogr2OgrCommandLineRunner.ImportFileKmlToGeoJson(kmlFile, true), true)).ToList();
            return projectLocationStagings;
        }
    }
}