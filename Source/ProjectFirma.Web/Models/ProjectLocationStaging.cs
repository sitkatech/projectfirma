using System.Collections.Generic;
using System.IO;
using System.Linq;
using ProjectFirma.Web.Common;
using GeoJSON.Net.Feature;
using LtInfo.Common;
using LtInfo.Common.GdalOgr;

namespace ProjectFirma.Web.Models
{
    public partial class ProjectLocationStaging : IProjectLocationStaging
    {
        public FeatureCollection ToGeoJsonFeatureCollection()
        {
            var featureCollection = JsonTools.DeserializeObject<FeatureCollection>(GeoJson);
            return featureCollection;
        }

        public static List<ProjectLocationStaging> CreateProjectLocationStagingListFromGdb(FileInfo gdbFile, Project project, Person currentPerson)
        {
            var ogr2OgrCommandLineRunner = new Ogr2OgrCommandLineRunner(ProjectFirmaWebConfiguration.Ogr2OgrExecutable,
                Ogr2OgrCommandLineRunner.DefaultCoordinateSystemId,
                ProjectFirmaWebConfiguration.HttpRuntimeExecutionTimeout.TotalMilliseconds);

            var featureClassNames = OgrInfoCommandLineRunner.GetFeatureClassNamesFromFileGdb(new FileInfo(ProjectFirmaWebConfiguration.OgrInfoExecutable), gdbFile, Ogr2OgrCommandLineRunner.DefaultTimeOut);

            var projectLocationStagings =
                featureClassNames.Select(x => new ProjectLocationStaging(project, currentPerson.PersonID, x, ogr2OgrCommandLineRunner.ImportFileGdbToGeoJson(gdbFile, x), true)).ToList();
            return projectLocationStagings;
        }
    }
}