angular.module("ProjectFirmaApp").controller("ProjectWatershedController", function ($scope, angularModelAndViewData)
{
    $scope.resetWatershedToAdd = function () { $scope.WatershedToAdd = null; };

    $scope.filteredWatersheds = function () {
        var usedWatershedIDs = _.map($scope.AngularModel.ProjectWatersheds, function (p) { return p.WatershedID; });
        return _($scope.AngularViewData.AllWatersheds).filter(function (f) { return !_.contains(usedWatershedIDs, f.WatershedID); }).sortBy(["DisplayName"]).value();
    };

    $scope.getWatershedName = function (projectWatershed) {
        var watershedToFind = $scope.getWatershed(projectWatershed.WatershedID);
        return watershedToFind.DisplayName;
    };

    $scope.getWatershed = function (watershedId) {
        return _.find($scope.AngularViewData.AllWatersheds, function (f) { return watershedId == f.WatershedID; });
    };

    $scope.addRow = function()
    {
        if ($scope.WatershedToAdd != null)
        {
            var newProjectWatershed = $scope.createNewRow($scope.ProjectIDToAdd, $scope.WatershedToAdd);
            $scope.AngularModel.ProjectWatersheds.push(newProjectWatershed);
            $scope.resetWatershedToAdd();
        }
    };

    $scope.createNewRow = function (projectId, watershed) {
        var newProjectWatershed = {
            ProjectID: projectId,
            WatershedID: watershed.WatershedID
        };
        return newProjectWatershed;
    };

    $scope.deleteRow = function (rowToDelete) {
        Sitka.Methods.removeFromJsonArray($scope.AngularModel.ProjectWatersheds, rowToDelete);
    };

    $scope.AngularModel = angularModelAndViewData.AngularModel;
    $scope.AngularViewData = angularModelAndViewData.AngularViewData;
    $scope.resetWatershedToAdd();
    $scope.ProjectIDToAdd = $scope.AngularViewData.ProjectID;
});

