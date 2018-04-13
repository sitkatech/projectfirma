/*-----------------------------------------------------------------------
<copyright file="PerformanceMeasureExpectedController.js" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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
angular.module("ProjectFirmaApp").controller("PerformanceMeasureExpectedController", function ($scope, angularModelAndViewData)
{

    $scope.performanceMeasureTooltip = function (performanceMeasureExpected) {
        var displayName = $scope.getPerformanceMeasureName(performanceMeasureExpected);
        var definitionAndGuidanceUrl = $scope.getPerformanceMeasureDefinitionAndGuidanceUrl(performanceMeasureExpected);
        ProjectFirma.Views.Methods.addHelpTooltipPopup(jQuery(event.target), displayName, definitionAndGuidanceUrl, 430);
    }

    $scope.groupedPerformanceMeasures = function () {        
        return _.uniq($scope.AngularModel.PerformanceMeasureExpecteds, "PerformanceMeasureID");
    }

    $scope.getGroupPerformanceMeasureExpecteds = function (performanceMeasureGroup) {
        return _($scope.AngularModel.PerformanceMeasureExpecteds).filter(function (pm) { return pm.PerformanceMeasureID == performanceMeasureGroup.PerformanceMeasureID; }).value();
    }

    $scope.addPerformanceMeasureToGroup = function (performanceMeasureGroup) {
        var performanceMeasureToAdd = Sitka.Methods.findElementInJsonArray(
            $scope.AngularViewData.AllPerformanceMeasures,
            "PerformanceMeasureID",
            performanceMeasureGroup.PerformanceMeasureID);
        var newPerformanceMeasureExpected = $scope.createNewRow(performanceMeasureToAdd);
        $scope.AngularModel.PerformanceMeasureExpecteds.push(newPerformanceMeasureExpected);
    }

    $scope.numberOfSubcategoryOptions = function(performanceMeasureExpected) {
        if (Sitka.Methods.isUndefinedNullOrEmpty($scope.AngularModel.PerformanceMeasureExpecteds)) {
            return 0;
        }

        return Sitka.Methods.findElementInJsonArray($scope.AngularModel.PerformanceMeasureExpecteds,
            "PerformanceMeasureID",
            performanceMeasureExpected.PerformanceMeasureID).PerformanceMeasureExpectedSubcategoryOptions.length;
    }

    $scope.resetPerformanceMeasureToAdd = function () { $scope.PerformanceMeasureToAdd = null; };
   
    $scope.filteredPerformanceMeasures = function () {
        return _($scope.AngularViewData.AllPerformanceMeasures).value();
    };    
    
    $scope.getPerformanceMeasureName = function (performanceMeasureExpected) {
        var performanceMeasureToFind = $scope.getPerformanceMeasure(performanceMeasureExpected.PerformanceMeasureID);
        return performanceMeasureToFind.DisplayName;
    };

    $scope.getPerformanceMeasureDefinitionAndGuidanceUrl = function (performanceMeasureExpected) {
        var performanceMeasureToFind = $scope.getPerformanceMeasure(performanceMeasureExpected.PerformanceMeasureID);
        return performanceMeasureToFind.DefinitionAndGuidanceUrl;
    };

    $scope.getPerformanceMeasure = function (performanceMeasureId) {
        return _.find($scope.AngularViewData.AllPerformanceMeasures, function (f) { return performanceMeasureId == f.PerformanceMeasureID; });
    };

    $scope.getSubcategoriesForPerformanceMeasure = function (performanceMeasureId)
    {
        var performanceMeasureSubcategories = _($scope.AngularViewData.AllPerformanceMeasureSubcategories).filter(function (pms) { return pms.PerformanceMeasureID == performanceMeasureId; }).map(function (pms) { return { PerformanceMeasureSubcategoryID: pms.PerformanceMeasureSubcategoryID, PerformanceMeasureSubcategoryName: $scope.getSubcategoryName(pms), SortOrder: pms.SortOrder }; }).sortByAll(["SortOrder", "PerformanceMeasureSubcategoryName"]).value();
        return performanceMeasureSubcategories;
    };

    $scope.getSubcategoryOptionsForSubcategory = function (performanceMeasureSubcategoryId)
    {
        var subcategoryOptions = _($scope.AngularViewData.AllPerformanceMeasureSubcategoryOptions).filter(function (sco) { return sco.PerformanceMeasureSubcategoryID == performanceMeasureSubcategoryId; }).sortByAll(["SortOrder", "PerformanceMeasureSubcategoryOptionName"]).value();        
        return subcategoryOptions;
    };

    $scope.getSubcategory = function (performanceMeasureSubcategoryId)
    {
        var performanceMeasureSubcategory = _.find($scope.AngularViewData.AllPerformanceMeasureSubcategories, function (sc) { return sc.PerformanceMeasureSubcategoryID == performanceMeasureSubcategoryId; });
        return performanceMeasureSubcategory;
    };

    $scope.getSubcategoryName = function (performanceMeasureExpectedSubcategoryOption)
    {
        var performanceMeasureSubcategory = $scope.getSubcategory(performanceMeasureExpectedSubcategoryOption.PerformanceMeasureSubcategoryID);
        return performanceMeasureSubcategory.PerformanceMeasureSubcategoryDisplayName;
    };

    $scope.hasAnySubcategories = function () {
        var performanceMeasureIDsInModel = _.map($scope.AngularModel.PerformanceMeasureExpecteds, function (pmav) { return pmav.PerformanceMeasureID; });
        var anySubcategories = _.any($scope.AngularViewData.AllPerformanceMeasureSubcategories, function (sc) { return _.contains(performanceMeasureIDsInModel, sc.PerformanceMeasureID); });
        return anySubcategories;
    };

    $scope.getPerformanceMeasureExpectedSubcategoryOptionsWithValues = function (performanceMeasureExpected) {
        return _(performanceMeasureExpected.PerformanceMeasureExpectedSubcategoryOptions).filter(function (pms) { return pms.PerformanceMeasureSubcategoryOptionID > 0; }).sortBy(["PerformanceMeasureSubcategoryOptionID"]).value();
    };

    $scope.addRow = function() {
        if ($scope.PerformanceMeasureToAdd != null) {
            var performanceMeasureToAdd = Sitka.Methods.findElementInJsonArray(
                $scope.AngularViewData.AllPerformanceMeasures,
                "PerformanceMeasureID",
                $scope.PerformanceMeasureToAdd);
            var newPerformanceMeasureExpected = $scope.createNewRow(performanceMeasureToAdd);
            $scope.AngularModel.PerformanceMeasureExpecteds.push(newPerformanceMeasureExpected);
        }
    };

    $scope.createNewRow = function (performanceMeasure) {
        var newPerformanceMeasureExpected = {
            ProjectID: performanceMeasure.ProjectID,
            PerformanceMeasureID: performanceMeasure.PerformanceMeasureID,
            CalendarYear: new Date().getFullYear(),
            ExpectedValue: null,
            MeasurementUnitTypeDisplayName: performanceMeasure.MeasurementUnitTypeDisplayName,
            PerformanceMeasureExpectedSubcategoryOptions: $scope.createPerformanceMeasureValueSubcategoryOptionRows(performanceMeasure)
        };
        return newPerformanceMeasureExpected;
    };

    $scope.createPerformanceMeasureValueSubcategoryOptionRows = function (performanceMeasure)
    {
        var performanceMeasureId = performanceMeasure.PerformanceMeasureID;
        var subcategories = $scope.getSubcategoriesForPerformanceMeasure(performanceMeasureId);
        var performanceMeasureValueSubcategoryOptionRows = _.map(subcategories, function (performanceMeasureSubcategory) { return $scope.createPerformanceMeasureValueSubcategoryOption(performanceMeasureSubcategory, performanceMeasureId); });
        if (!performanceMeasure.HasRealSubcategories) {
            performanceMeasureValueSubcategoryOptionRows[0].PerformanceMeasureSubcategoryOptionID = $scope.getSubcategoryOptionsForSubcategory(subcategories[0].PerformanceMeasureSubcategoryID)[0].PerformanceMeasureSubcategoryOptionID;
        }
        return performanceMeasureValueSubcategoryOptionRows;
    };

    $scope.createPerformanceMeasureValueSubcategoryOption = function (performanceMeasureSubcategory, performanceMeasureId)
    {
        var newPerformanceMeasureExpected = {
            PerformanceMeasureID: performanceMeasureId,
            PerformanceMeasureSubcategoryID: performanceMeasureSubcategory.PerformanceMeasureSubcategoryID,
            PerformanceMeasureSubcategoryOptionID: null
        };
        return newPerformanceMeasureExpected;
    };

    $scope.deleteRow = function (rowToDelete) {
        Sitka.Methods.removeFromJsonArray($scope.AngularModel.PerformanceMeasureExpecteds, rowToDelete);
    };

    $scope.getMeasurementUnitTypeDisplayName = function (performanceMeasureExpected) {
        var measurementUnitTypeDisplayName = "";
        var performanceMeasure = $scope.getPerformanceMeasure(performanceMeasureExpected.PerformanceMeasureID);
        if (performanceMeasure != null)
        {
            measurementUnitTypeDisplayName = performanceMeasure.MeasurementUnitTypeDisplayName;
        }
        return measurementUnitTypeDisplayName;
    };

    $scope.maxNumberOfSubcategoryOptions = function() {
        if (Sitka.Methods.isUndefinedNullOrEmpty($scope.AngularModel.PerformanceMeasureExpecteds)) {
            return 0;
        }

        return _($scope.AngularModel.PerformanceMeasureExpecteds).map(function(performanceMeasureExpected) {
            return performanceMeasureExpected.PerformanceMeasureExpectedSubcategoryOptions.length;
        }).max();
    };

    $scope.AngularModel = angularModelAndViewData.AngularModel;
    $scope.AngularViewData = angularModelAndViewData.AngularViewData;

});

