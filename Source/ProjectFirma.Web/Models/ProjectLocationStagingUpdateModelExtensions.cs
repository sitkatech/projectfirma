using System.Collections.Generic;
using System.IO;
using System.Linq;
using LtInfo.Common.GdalOgr;
using ProjectFirma.Web.Common;

namespace ProjectFirmaModels.Models
{
    public static class ProjectLocationStagingUpdateModelExtensions
    {
        public static List<ProjectLocationStagingUpdate> CreateProjectLocationStagingUpdateListFromGdb(FileInfo gdbFile, ProjectUpdateBatch projectUpdateBatch, Person currentPerson)
        {
            var ogr2OgrCommandLineRunner = new Ogr2OgrCommandLineRunner(FirmaWebConfiguration.Ogr2OgrExecutable,
                Ogr2OgrCommandLineRunner.DefaultCoordinateSystemId,
                FirmaWebConfiguration.HttpRuntimeExecutionTimeout.TotalMilliseconds);

            var featureClassNames = OgrInfoCommandLineRunner.GetFeatureClassNamesFromFileGdb(new FileInfo(FirmaWebConfiguration.OgrInfoExecutable), gdbFile, Ogr2OgrCommandLineRunner.DefaultTimeOut);

            var projectLocationStagings =
                featureClassNames.Select(x => new ProjectLocationStagingUpdate(projectUpdateBatch, currentPerson, x, ogr2OgrCommandLineRunner.ImportFileGdbToGeoJson(gdbFile, x, true), true)).ToList();
            return projectLocationStagings;
        }
    }
}