using System.Collections.Generic;
using System.IO;
using System.Linq;
using ProjectFirma.Web.Common;
using GeoJSON.Net.Feature;
using LtInfo.Common;
using LtInfo.Common.GdalOgr;

namespace ProjectFirma.Web.Models
{
    public partial class ProposedProjectLocationStaging : IProjectLocationStaging
    {
        public FeatureCollection ToGeoJsonFeatureCollection()
        {
            var featureCollection = JsonTools.DeserializeObject<FeatureCollection>(GeoJson);
            return featureCollection;
        }

        public static List<ProposedProjectLocationStaging> CreateProposedProjectLocationStagingListFromGdb(FileInfo gdbFile, ProposedProject proposedProject, Person currentPerson)
        {
            var ogr2OgrCommandLineRunner = new Ogr2OgrCommandLineRunner(FirmaWebConfiguration.Ogr2OgrExecutable,
                Ogr2OgrCommandLineRunner.DefaultCoordinateSystemId,
                FirmaWebConfiguration.HttpRuntimeExecutionTimeout.TotalMilliseconds);

            var featureClassNames = OgrInfoCommandLineRunner.GetFeatureClassNamesFromFileGdb(new FileInfo(FirmaWebConfiguration.OgrInfoExecutable), gdbFile, Ogr2OgrCommandLineRunner.DefaultTimeOut);

            var projectLocationStagings =
                featureClassNames.Select(x => new ProposedProjectLocationStaging(proposedProject, currentPerson, x, ogr2OgrCommandLineRunner.ImportFileGdbToGeoJson(gdbFile, x), true)).ToList();
            return projectLocationStagings;
        }
    }
}