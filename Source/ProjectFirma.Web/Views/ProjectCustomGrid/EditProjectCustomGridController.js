//#sourceUrl=/Views/ProjectCustomGrid/EditProjectCustomGridController.js
angular.module("ProjectFirmaApp")
    .controller("EditProjectCustomGridController",
        function ($scope, angularModelAndViewData) {
            $scope.AngularModel = angularModelAndViewData.AngularModel;
            $scope.AngularViewData = angularModelAndViewData.AngularViewData;

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
                return _.filter($scope.AngularModel.ProjectCustomGridConfigurationSimples,
                    function(simple) {
                        return simple.IsEnabled == true;
                    });
            }

        });
