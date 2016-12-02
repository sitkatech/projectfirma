angular.module("ProjectFirmaApp").controller("MonitoringProgramController", function ($scope, angularModelAndViewData)
{
    $scope.resetMonitoringProgramToAdd = function () { $scope.MonitoringProgramToAdd = null; };

    $scope.filteredMonitoringPrograms = function () {
        var usedMonitoringProgramIDs = _.map($scope.AngularModel.PerformanceMeasureMonitoringPrograms, function (p) { return p.MonitoringProgramID; });
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
            var newMonitoringProgram = $scope.createNewRow($scope.PerformanceMeasureIDToAdd, $scope.MonitoringProgramToAdd);
            $scope.AngularModel.PerformanceMeasureMonitoringPrograms.push(newMonitoringProgram);
            $scope.resetMonitoringProgramToAdd();
        }
    };

    $scope.createNewRow = function (performanceMeasureId, monitoringProgram) {
        var newMonitoringProgram = {
            PerformanceMeasureID: performanceMeasureId,
            MonitoringProgramID: monitoringProgram.MonitoringProgramID
        };
        return newMonitoringProgram;
    };

    $scope.deleteRow = function (rowToDelete) {
        Sitka.Methods.removeFromJsonArray($scope.AngularModel.PerformanceMeasureMonitoringPrograms, rowToDelete);
    };

    $scope.AngularModel = angularModelAndViewData.AngularModel;
    $scope.AngularViewData = angularModelAndViewData.AngularViewData;
    $scope.resetMonitoringProgramToAdd();
    $scope.PerformanceMeasureIDToAdd = $scope.AngularViewData.PerformanceMeasureID;
});

