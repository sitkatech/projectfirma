//#sourceUrl=/Views/ProjectGeospatialArea/QuickSetProjectSpatialInformationController.js
angular.module("ProjectFirmaApp")
    .controller("QuickSetProjectSpatialInformationController",
        function ($scope, angularModelAndViewData) {
            $scope.AngularModel = angularModelAndViewData.AngularModel;
            $scope.AngularViewData = angularModelAndViewData.AngularViewData;

            $scope.getGeospatialAreaName = function (geospatialAreaId) {
                return $scope.AngularViewData.GeospatialAreaNameByID[geospatialAreaId];
            };


            ProjectFirmaMaps.Map.prototype.handleWmsPopupClickEventWithCurrentLayer = function() {
                // Override parent to do nothing
                return function() {};
            };

            function initializeMap() {
                $scope.firmaMap = new ProjectFirmaMaps.Map($scope.AngularViewData.MapInitJson);
                //$scope.firmaMap.map.on("click", onMapClick);
                $scope.firmaMap.map.scrollWheelZoom.enable();
            };

            initializeMap();

            $scope.noGeospatialAreasSelected = function () {
                return !$scope.AngularModel.GeospatialAreaIDs || $scope.AngularModel.GeospatialAreaIDs.length < 1;
            };

            $scope.canSetGeospatialAreaFromProjectLocation = function () {
                return $scope.AngularViewData.HasProjectLocationPoint &&
                    $scope.AngularViewData.GeospatialAreaIDsContainingProjectSimpleLocation.length > 0;
            };

            $scope.setGeospatialAreaFromProjectLocation = function () {
                $scope.AngularModel.GeospatialAreaIDs = [];
                _.forEach($scope.AngularViewData.GeospatialAreaIDsContainingProjectSimpleLocation, function (geospatialAreaID) {                    
                    $scope.AngularModel.GeospatialAreaIDs.push(geospatialAreaID);
                });

            };

            $scope.selectedGeospatialAreaDoesNotMatchProjectLocation = function () {                
                if (!$scope.canSetGeospatialAreaFromProjectLocation()) {
                    return false;
                }
                if ($scope.AngularModel.GeospatialAreaIDs === null ||
                    $scope.AngularModel.GeospatialAreaIDs.length === 0) {
                    return true;
                }

                var selectedAreaMatches = false;

                _.forEach($scope.AngularViewData.GeospatialAreaIDsContainingProjectSimpleLocation, function (geospatialAreaID) {
                    if (!$scope.AngularModel.GeospatialAreaIDs.includes(geospatialAreaID)) {
                        selectedAreaMatches =  true;
                        
                    }
                });                
                return selectedAreaMatches;
            };
        });
