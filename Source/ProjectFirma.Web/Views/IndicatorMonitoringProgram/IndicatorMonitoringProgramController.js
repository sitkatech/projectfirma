angular.module("ProjectFirmaApp").controller("MonitoringProgramController", function ($scope, angularModelAndViewData)
{
    $scope.resetMonitoringProgramToAdd = function () { $scope.MonitoringProgramToAdd = null; };

    $scope.filteredMonitoringPrograms = function () {
        var usedMonitoringProgramIDs = _.map($scope.AngularModel.IndicatorMonitoringPrograms, function (p) { return p.MonitoringProgramID; });
        return _($scope.AngularViewData.AllMonitoringPrograms).filter(function (f) { return !_.contains(usedMonitoringProgramIDs, f.MonitoringProgramID); }).sortBy(["MonitoringProgramName"]).value();
    };

    $scope.getMonitoringProgramName = function (monitoringProgram) {
        var monitoringProgramToFind = $scope.getMonitoringProgram(monitoringProgram.MonitoringProgramID);
        return monitoringProgramToFind.MonitoringProgramName;
    };

    $scope.getMonitoringProgram = function (monitoringProgramId) {
        return _.find($scope.AngularViewData.AllMonitoringPrograms, function (f) { return monitoringProgramId == f.MonitoringProgramID; });
    };

    $scope.addRow = function()
    {
        if ($scope.MonitoringProgramToAdd != null)
        {
            var newMonitoringProgram = $scope.createNewRow($scope.IndicatorIDToAdd, $scope.MonitoringProgramToAdd);
            $scope.AngularModel.IndicatorMonitoringPrograms.push(newMonitoringProgram);
            $scope.resetMonitoringProgramToAdd();
        }
    };

    $scope.createNewRow = function (indicatorId, monitoringProgram) {
        var newMonitoringProgram = {
            IndicatorID: indicatorId,
            MonitoringProgramID: monitoringProgram.MonitoringProgramID
        };
        return newMonitoringProgram;
    };

    $scope.deleteRow = function (rowToDelete) {
        Sitka.Methods.removeFromJsonArray($scope.AngularModel.IndicatorMonitoringPrograms, rowToDelete);
    };

    $scope.AngularModel = angularModelAndViewData.AngularModel;
    $scope.AngularViewData = angularModelAndViewData.AngularViewData;
    $scope.resetMonitoringProgramToAdd();
    $scope.IndicatorIDToAdd = $scope.AngularViewData.IndicatorID;
});

