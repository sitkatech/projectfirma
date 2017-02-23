/*-----------------------------------------------------------------------
<copyright file="PerformanceMeasureMonitoringProgramController.js" company="Sitka Technology Group">
Copyright (c) Sitka Technology Group. All rights reserved.
<author>Sitka Technology Group</author>
<date>Wednesday, February 22, 2017</date>
</copyright>

<license>
This program is free software: you can redistribute it and/or modify
it under the terms of the GNU Affero General Public License as published by
the Free Software Foundation, either version 3 of the License, or
(at your option) any later version.

This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU Affero General Public License <http://www.gnu.org/licenses/> for more details.

Source code is available upon request via <support@sitkatech.com>.
</license>
-----------------------------------------------------------------------*/
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

