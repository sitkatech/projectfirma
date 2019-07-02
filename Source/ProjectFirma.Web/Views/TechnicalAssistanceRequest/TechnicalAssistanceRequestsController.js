/*-----------------------------------------------------------------------
<copyright file="PerformanceMeasureActualController.js" company="Tahoe Regional Planning Agency and Sitka Technology Group">
Copyright (c) Tahoe Regional Planning Agency and Sitka Technology Group. All rights reserved.
<author>Sitka Technology Group</author>
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
angular.module("ProjectFirmaApp").controller("TechnicalAssistanceRequestsController", function ($scope, angularModelAndViewData) {

    $scope.AngularModel = angularModelAndViewData.AngularModel;
    $scope.AngularViewData = angularModelAndViewData.AngularViewData;

    $scope.projectID = $scope.AngularViewData.ProjectID;

    $scope.technicalAssistanceTypes = $scope.AngularViewData.TechnicalAssistanceTypes;

    $scope.fiscalYearStrings = $scope.AngularViewData.FiscalYearStrings;

    $scope.technicalAssistanceRequests = $scope.AngularModel.TechnicalAssistanceRequestSimples;

    $scope.personSimples = $scope.AngularViewData.PersonSimples;

    $scope.placeholderID = -1;

    $scope.getReportedYears = function () {
        var years = _($scope.AngularModel.TechnicalAssistanceRequestSimples).map(function (item) {
            return item.FiscalYear;
        }).uniq().sort().value();
        return _(years.reverse()).value();
    }

    function filterYears(year) {
        var yearsInUse = $scope.getReportedYears();
        return yearsInUse.indexOf(year.CalendarYear) < 0;  // IE doesn't support Array.includes()
    }

    $scope.getAddableFiscalYearStrings = function () {
        return $scope.fiscalYearStrings.filter(filterYears); // Calls filterYears for each fiscalYearString
    }

    $scope.getGroupedTechnicalAssistanceRequests = function (fiscalYear) {
        return _.filter($scope.technicalAssistanceRequests, function (tar) { return tar.FiscalYear === fiscalYear; });
    }

    $scope.addTechnicalAssistanceRequestToYear = function(reportedYear) {
        var newTechnicalAssistanceRequest = $scope.createNewRow(reportedYear);
        $scope.AngularModel.TechnicalAssistanceRequestSimples.push(newTechnicalAssistanceRequest);
    }

    $scope.createNewRow = function (year) {
        var newTechnicalAssistanceRequest = {
            TechnicalAssistanceRequestID: $scope.placeholderID--,
            ProjectID: $scope.projectID,
            FiscalYear: year,
            PersonID: null,
            TechnicalAssistanceTypeID: null,
            HoursRequested: null,
            HoursAllocated: null,
            HoursProvided: null,
            Notes: null
        };
        return newTechnicalAssistanceRequest;
    };

    $scope.addRow = function () {
        if ($scope.YearToAdd != null) {
            var yearToAdd = Sitka.Methods.findElementInJsonArray(
                $scope.AngularViewData.FiscalYearStrings,
                "CalendarYear",
                $scope.YearToAdd);
            var newTechnicalAssistanceRequest = $scope.createNewRow(yearToAdd.CalendarYear);
            $scope.AngularModel.TechnicalAssistanceRequestSimples.push(newTechnicalAssistanceRequest);
            $scope.YearToAdd = null;
        }
    };

    $scope.deleteRow = function (rowToDelete) {
        Sitka.Methods.removeFromJsonArray($scope.AngularModel.TechnicalAssistanceRequestSimples, rowToDelete);
    };
});

