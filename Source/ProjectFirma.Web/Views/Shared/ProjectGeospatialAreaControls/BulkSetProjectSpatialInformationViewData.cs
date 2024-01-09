﻿using System.Collections.Generic;
using System.Data.Entity.Spatial;
using System.Linq;
using Microsoft.Ajax.Utilities;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Views.Shared.ProjectGeospatialAreaControls
{
    public class BulkSetProjectSpatialInformationViewData : FirmaViewData
    {
        public DbGeometry ProjectSimpleLocation { get; }
        public List<GeospatialAreaType> GeospatialAreaTypes { get; }
        public string EditProjectGeospatialAreasUrl { get; }
        public BulkSetProjectSpatialInformationViewDataForAngular ViewDataForAngular { get; }
        public string EditProjectGeospatialAreasFormID { get; }
        public bool HasProjectLocationPoint { get; }
        public bool HasProjectLocationDetail { get; }
        public string SimplePointMarkerImg { get; }
        public string EditSimpleLocationUrl { get; }

        public BulkSetProjectSpatialInformationViewData(FirmaSession currentFirmaSession, 
                                                         IProject iProject, 
                                                         List<ProjectFirmaModels.Models.GeospatialArea> geospatialAreasOnProject, 
                                                         List<GeospatialAreaType> geospatialAreaTypes, 
                                                         MapInitJson mapInitJson, 
                                                         string editProjectGeospatialAreasUrl, 
                                                         string editProjectGeospatialAreasFormID, 
                                                         List<fGeoServerGeospatialAreaAreasContainingProjectLocation_Result> geospatialAreasContainingProjectSimpleLocation, 
                                                         bool hasProjectLocationPoint, 
                                                         bool hasProjectLocationDetail,
                                                         string editSimpleLocationUrl, bool canEdit) : base(currentFirmaSession)
        {
            var userCanViewPrivateLocations = currentFirmaSession.UserCanViewPrivateLocations(iProject.GetProject());
            ProjectSimpleLocation = iProject.GetProjectLocationPoint(userCanViewPrivateLocations);
            GeospatialAreaTypes = geospatialAreaTypes;
            EditProjectGeospatialAreasUrl = editProjectGeospatialAreasUrl;
            EditProjectGeospatialAreasFormID = editProjectGeospatialAreasFormID;
            HasProjectLocationPoint = hasProjectLocationPoint;
            HasProjectLocationDetail = hasProjectLocationDetail;
            SimplePointMarkerImg = $"https://api.tiles.mapbox.com/v4/marker/pin-s-marker+838383.png?access_token={FirmaWebConfiguration.MapBoxApiKey}";
            ViewDataForAngular = new BulkSetProjectSpatialInformationViewDataForAngular(mapInitJson, geospatialAreaTypes, geospatialAreasContainingProjectSimpleLocation, hasProjectLocationPoint, geospatialAreasOnProject, canEdit);

            EditSimpleLocationUrl = editSimpleLocationUrl;
        }
    }


    public class BulkSetProjectSpatialInformationViewDataForAngular
    {
        public MapInitJson MapInitJson { get; }
        public string MapServiceUrl { get; }
        public List<GeospatialAreaTypeSimple> GeospatialAreaTypes { get; }
        public List<int> GeospatialAreaIDsContainingProjectSimpleLocation { get; }
        public bool HasProjectLocationPoint { get; }
        public Dictionary<int, string> GeospatialAreaNameByID { get; }
        public bool CanEdit { get; }

        public BulkSetProjectSpatialInformationViewDataForAngular(MapInitJson mapInitJson, 
                                                                  List<GeospatialAreaType> geospatialAreaTypes, 
                                                                  List<fGeoServerGeospatialAreaAreasContainingProjectLocation_Result> geospatialAreasContainingProjectSimpleLocation, 
                                                                  bool hasProjectLocationPoint,
                                                                  List<ProjectFirmaModels.Models.GeospatialArea> selectedGeospatialAreas, bool canEdit)
        {

            var possibleGeospatialAreas = new List<fGeoServerGeospatialAreaAreasContainingProjectLocation_Result>();
            geospatialAreasContainingProjectSimpleLocation.CopyItemsTo(possibleGeospatialAreas);
            var possibleGeospatialAreaIDs = possibleGeospatialAreas.Select(y => y.GeospatialAreaID).ToList();
            var selectedGeospatialAreasNotInPossibleGeospatialAreas = selectedGeospatialAreas.Select(x => x.MakefGeoServerGeospatialAreaAreasContainingProjectLocation()).Where(x => !possibleGeospatialAreaIDs.Contains(x.GeospatialAreaID));
            possibleGeospatialAreas.AddRange(selectedGeospatialAreasNotInPossibleGeospatialAreas);
            GeospatialAreaTypes = geospatialAreaTypes.OrderBy(gat => gat.GeospatialAreaTypeName).Select(x =>
            {
                var geospatialAreaIDsContainingProjectSimpleLocation = geospatialAreasContainingProjectSimpleLocation.Where(gacpsl => gacpsl.GeospatialAreaTypeID == x.GeospatialAreaTypeID).Select(y => y.GeospatialAreaID).ToList();
                var geospatialAreaIDsInitiallySelected = selectedGeospatialAreas.Where(gacpsl => gacpsl.GeospatialAreaTypeID == x.GeospatialAreaTypeID).Select(y => y.GeospatialAreaID).ToList();
                return new GeospatialAreaTypeSimple(x, geospatialAreaIDsContainingProjectSimpleLocation, geospatialAreaIDsInitiallySelected);
            }).ToList();
            GeospatialAreaNameByID = possibleGeospatialAreas.ToDictionary(x => x.GeospatialAreaID, y => y.GeospatialAreaShortName);
            GeospatialAreaIDsContainingProjectSimpleLocation = geospatialAreasContainingProjectSimpleLocation.Select(x => x.GeospatialAreaID).ToList();
            CanEdit = canEdit;
            MapInitJson = mapInitJson;
            MapServiceUrl = geospatialAreaTypes.FirstOrDefault().MapServiceUrl();
            HasProjectLocationPoint = hasProjectLocationPoint;
        }
    }
}
