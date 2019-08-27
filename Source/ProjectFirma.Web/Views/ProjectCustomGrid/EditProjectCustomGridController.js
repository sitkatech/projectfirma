//#sourceUrl=/Views/ProjectCustomGrid/EditProjectCustomGridController.js
angular.module("ProjectFirmaApp")
    .controller("EditProjectCustomGridController",
        function ($scope, angularModelAndViewData) {
            $scope.AngularModel = angularModelAndViewData.AngularModel;
            $scope.AngularViewData = angularModelAndViewData.AngularViewData;

            $scope.sortIndexes = {};

            $scope.getColumnName = function(projectCustomGridConfigurationSimple)
            {
                if (projectCustomGridConfigurationSimple.ProjectCustomAttributeTypeName) {
                    return projectCustomGridConfigurationSimple.ProjectCustomAttributeTypeName;
                }
                if (projectCustomGridConfigurationSimple.GeospatialAreaTypeName) {
                    return projectCustomGridConfigurationSimple.GeospatialAreaTypeName;
                }
                return projectCustomGridConfigurationSimple.ProjectCustomGridColumnName;
            }

            $scope.getEnabledProjectCustomGridConfigurationSimples = function() {
                var enabled = _.filter($scope.AngularModel.ProjectCustomGridConfigurationSimples,
                    function(simple) {
                        return simple.IsEnabled == true;
                    });
                return _.sortBy(enabled,
                    function(el) {
                        return el.SortOrder;
                    });
            }

            $scope.getUniqueIdentifier = function (projectCustomGridConfigurationSimple) {
                var id = "col_" + projectCustomGridConfigurationSimple.ProjectCustomGridColumnID;
                if (projectCustomGridConfigurationSimple.ProjectCustomAttributeTypeID) {
                    id += "_attr_" + projectCustomGridConfigurationSimple.ProjectCustomAttributeTypeID;
                }
                if (projectCustomGridConfigurationSimple.GeospatialAreaTypeID) {
                    id += "_geo_" + projectCustomGridConfigurationSimple.GeospatialAreaTypeID;
                }
                return id;
            }

            $scope.getSortOrder = function (projectCustomGridConfigurationSimple) {
                var id = $scope.getUniqueIdentifier(projectCustomGridConfigurationSimple);
                var keys = Object.keys($scope.sortIndexes);
                if (keys.indexOf(id) > -1) {
                    return $scope.sortIndexes[id];
                }
                return null;
            }

            // Used when order is changed via Sortable
            $scope.refreshSortOrder = function() {
                $scope.sortIndexes = {};
                var list = document.getElementById("sortables-list");

                var gridColumns = list.getElementsByTagName("div");
                for (var i = 0; i < gridColumns.length; i++) {
                    $scope.sortIndexes[gridColumns[i].id] = i * 10;
                }
            }

            // Used to rebuild sort order when items are added/removed as this doesn't trigger Sortable.onUpdate and new list isn't rendered yet
            $scope.rebuildSortOrder = function (projectCustomGridConfigurationSimple) {
                var id = $scope.getUniqueIdentifier(projectCustomGridConfigurationSimple);
                var sortedKeys = _.sortBy(Object.keys($scope.sortIndexes),
                    function(key) {
                        return $scope.sortIndexes[key];
                    });
                // if enabled, add to end of array
                if (projectCustomGridConfigurationSimple.IsEnabled) {
                    sortedKeys.push(id);
                } else {
                    sortedKeys.splice(sortedKeys.indexOf(id), 1);
                }
                // Rebuild sortIndexes
                $scope.sortIndexes = {};
                for (i = 0; i < sortedKeys.length; i++) {
                    $scope.sortIndexes[sortedKeys[i]] = i * 10;
                    if (sortedKeys[i] == id) {
                        projectCustomGridConfigurationSimple.SortOrder = i * 10;  // Set SortOrder of object also so it will go to bottom of list
                    }
                }
            }

            $scope.initializeSortables = function () {
                // capture original sort order
                $scope.refreshSortOrder();
                $scope.$apply();
                var list = document.getElementById("sortables-list");
                new Sortable(list, {
                    onUpdate: function (evt) {
                        // get new sort order
                        $scope.refreshSortOrder();
                        $scope.$apply();
                    }
                }); 
            };

        });
