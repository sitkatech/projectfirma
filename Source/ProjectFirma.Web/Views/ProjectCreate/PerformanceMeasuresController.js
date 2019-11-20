/*-----------------------------------------------------------------------
<copyright file="PerformanceMeasuresController.js" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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
angular.module("ProjectFirmaApp").controller("PerformanceMeasuresController", function($scope, $timeout, angularModelAndViewData) {

    $scope.performanceMeasureTooltip = function(performanceMeasureExpected) {
        var displayName = $scope.getPerformanceMeasureName(performanceMeasureExpected);
        var definitionAndGuidanceUrl = $scope.getPerformanceMeasureDefinitionAndGuidanceUrl(performanceMeasureExpected);
        ProjectFirma.Views.Methods.addHelpTooltipPopup(jQuery(event.target),
            displayName,
            definitionAndGuidanceUrl,
            430);
    };

    $scope.getPerformanceMeasureDefinitionAndGuidanceUrl = function (performanceMeasureExpected) {
        var performanceMeasureToFind = $scope.getPerformanceMeasure(performanceMeasureExpected.PerformanceMeasureID);
        return performanceMeasureToFind.DefinitionAndGuidanceUrl;
    };

    $scope.groupedPerformanceMeasures = function () {
        return _.uniq($scope.AngularModel.PerformanceMeasureActuals, "PerformanceMeasureID");
    }

    $scope.getGroupPerformanceMeasureActuals = function (performanceMeasureGroup) {
        return _($scope.AngularModel.PerformanceMeasureActuals).filter(function (pm) { return pm.PerformanceMeasureID == performanceMeasureGroup.PerformanceMeasureID; }).value();
    }

    $scope.addPerformanceMeasureToGroup = function (performanceMeasureGroup) {
        var performanceMeasureToAdd = Sitka.Methods.findElementInJsonArray(
            $scope.AngularViewData.AllPerformanceMeasures,
            "PerformanceMeasureID",
            performanceMeasureGroup.PerformanceMeasureID);
        var newPerformanceMeasureActual = $scope.createNewRow($scope.ProjectToAdd, performanceMeasureToAdd);
        $scope.AngularModel.PerformanceMeasureActuals.push(newPerformanceMeasureActual);
    }

    $scope.numberOfSubcategoryOptions = function (performanceMeasureActual) {
        if (Sitka.Methods.isUndefinedNullOrEmpty($scope.AngularModel.PerformanceMeasureActuals)) {
            return 0;
        }

        return Sitka.Methods.findElementInJsonArray($scope.AngularModel.PerformanceMeasureActuals,
            "PerformanceMeasureID",
            performanceMeasureActual.PerformanceMeasureID).PerformanceMeasureActualSubcategoryOptions.length;
    }

    $scope.nextID = -1;
    $scope.resetPerformanceMeasureToAdd = function() { $scope.PerformanceMeasureToAdd = null; };

    $scope.resetProjectToAdd = function() { $scope.ProjectToAdd = { ProjectID: angularModelAndViewData.AngularViewData.ProjectID }; };

    $scope.filteredPerformanceMeasures = function () { return _($scope.AngularViewData.AllPerformanceMeasures).sortBy(["DisplayName"]).value(); };

    $scope.getPerformanceMeasureName = function(performanceMeasureActual)
    {
        var performanceMeasureToFind = $scope.getPerformanceMeasure(performanceMeasureActual.PerformanceMeasureID);
        return performanceMeasureToFind.DisplayName;
    };

    $scope.getPerformanceMeasure = function(performanceMeasureId) { return _.find($scope.AngularViewData.AllPerformanceMeasures, function(f) { return performanceMeasureId == f.PerformanceMeasureID; }); };

    $scope.getSubcategoriesForPerformanceMeasure = function(performanceMeasureId)
    {
        var performanceMeasureSubcategories = _($scope.AngularViewData.AllPerformanceMeasureSubcategories).filter(function(pms) { return pms.PerformanceMeasureID == performanceMeasureId; }).map(function(pms) { return { PerformanceMeasureSubcategoryID: pms.PerformanceMeasureSubcategoryID, PerformanceMeasureSubcategoryName: $scope.getSubcategoryName(pms), SortOrder: pms.SortOrder }; }).sortByAll(["SortOrder", "PerformanceMeasureSubcategoryName"]).value();
        return performanceMeasureSubcategories;
    };

    $scope.addAdditionalColumns = function(performanceMeasureActual)
    {
        var performanceMeasureSubcategoriesCount = performanceMeasureActual.PerformanceMeasureActualSubcategoryOptions.length;
        var arrayLength = $scope.AngularViewData.MaxSubcategoryOptions - performanceMeasureSubcategoriesCount;
        var array = [];
        for (var i = 0; i < arrayLength; ++i)
        {
            array.push(i);
        }
        return array;
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

    $scope.getSubcategoryName = function(performanceMeasureActualSubcategoryOption)
    {
        var performanceMeasureSubcategory = $scope.getSubcategory(performanceMeasureActualSubcategoryOption.PerformanceMeasureSubcategoryID);
        return performanceMeasureSubcategory.PerformanceMeasureSubcategoryDisplayName;
    };

    $scope.hasAnySubcategories = function()
    {
        var performanceMeasureIDsInModel = _.map($scope.AngularModel.PerformanceMeasureActuals, function(pmav) { return pmav.PerformanceMeasureID; });
        var anySubcategories = _.any($scope.AngularViewData.AllPerformanceMeasureSubcategories, function (sc) { return _.contains(performanceMeasureIDsInModel, sc.PerformanceMeasureID); });
        return anySubcategories;
    };

    $scope.addRow = function () {
        if ($scope.PerformanceMeasureToAdd != null) {
            var performanceMeasureToAdd = Sitka.Methods.findElementInJsonArray(
                $scope.AngularViewData.AllPerformanceMeasures,
                "PerformanceMeasureID",
                $scope.PerformanceMeasureToAdd);
            var newPerformanceMeasureActual = $scope.createNewRow($scope.ProjectToAdd, performanceMeasureToAdd);
            $scope.AngularModel.PerformanceMeasureActuals.push(newPerformanceMeasureActual);
            $scope.repositionQtipPopups();
        }
    };

    $scope.createNewRow = function(project, performanceMeasure)
    {
        var newPerformanceMeasureActual = {
            PerformanceMeasureActualID: $scope.nextID--,
            ProjectID: project.ProjectID,
            PerformanceMeasureID: performanceMeasure.PerformanceMeasureID,
            CalendarYear: "",
            ActualValue: null,
            MeasurementUnitTypeDisplayName: performanceMeasure.MeasurementUnitTypeDisplayName,
            PerformanceMeasureReportingPeriodID: -1,
            PerformanceMeasureActualSubcategoryOptions: $scope.createPerformanceMeasureValueSubcategoryOptionRows(performanceMeasure)
        };
        return newPerformanceMeasureActual;
    };

    $scope.createPerformanceMeasureValueSubcategoryOptionRows = function(performanceMeasure)
    {
        var performanceMeasureId = performanceMeasure.PerformanceMeasureID;
        var subcategories = $scope.getSubcategoriesForPerformanceMeasure(performanceMeasureId);
        var performanceMeasureValueSubcategoryOptionRows = _.map(subcategories, function (performanceMeasureSubcategory) { return $scope.createPerformanceMeasureValueSubcategoryOption(performanceMeasureSubcategory, performanceMeasureId); });
        if (!performanceMeasure.HasRealSubcategories)
        {
            performanceMeasureValueSubcategoryOptionRows[0].PerformanceMeasureSubcategoryOptionID = $scope.getSubcategoryOptionsForSubcategory(subcategories[0].PerformanceMeasureSubcategoryID)[0].PerformanceMeasureSubcategoryOptionID;
        }
        return performanceMeasureValueSubcategoryOptionRows;
    };

    $scope.createPerformanceMeasureValueSubcategoryOption = function (performanceMeasureSubcategory, performanceMeasureId)
    {
        var newPerformanceMeasureActual = {
            PerformanceMeasureID: performanceMeasureId,
            PerformanceMeasureSubcategoryID: performanceMeasureSubcategory.PerformanceMeasureSubcategoryID,
            PerformanceMeasureSubcategoryOptionID: -1
        };
        return newPerformanceMeasureActual;
    };

    $scope.deleteRow = function(rowToDelete)
    {
        jQuery("#qtip-RequiredPopup" + rowToDelete.PerformanceMeasureActualID).remove();
        Sitka.Methods.removeFromJsonArray($scope.AngularModel.PerformanceMeasureActuals, rowToDelete);
        $scope.repositionQtipPopups();
    };

    $scope.getMeasurementUnitTypeDisplayName = function(performanceMeasureActual)
    {
        var measurementUnitTypeDisplayName = "";
        var performanceMeasure = $scope.getPerformanceMeasure(performanceMeasureActual.PerformanceMeasureID);
        if (performanceMeasure != null)
        {
            measurementUnitTypeDisplayName = performanceMeasure.MeasurementUnitTypeDisplayName;
        }
        return measurementUnitTypeDisplayName;
    };

    $scope.getSubcategoryOptionsSelected = function(performanceMeasureActual)
    {
        var performanceMeasureActualSubcategoryOptionsSelected = _(performanceMeasureActual.PerformanceMeasureActualSubcategoryOptions).sortByAll(["PerformanceMeasureSubcategoryID", "PerformanceMeasureSubcategoryOptionID"]).value();
        return performanceMeasureActualSubcategoryOptionsSelected;
    }

    $scope.filteredCalendarYears = function()
    {
        var usedCalendarYears = _($scope.AngularModel.ProjectExemptReportingYears).filter(function(f) { return f.IsExempt; }).map(function(p) { return p.CalendarYear; }).value();
        return _($scope.AngularViewData.CalendarYearStrings).filter(function(f) { return !_.contains(usedCalendarYears, f.CalendarYear); }).value();
    };

    $scope.showRowValidationWarnings = function(performanceMeasureActual)
    {
        var showingValidationWarnings = $scope.AngularModel.ShowValidationWarnings;
        var hasValidationWarnings = _.contains($scope.AngularViewData.PerformanceMeasureActualsWithValidationWarnings, performanceMeasureActual.PerformanceMeasureActualID);
        return showingValidationWarnings && hasValidationWarnings;
    };

    $scope.ModelState = angularModelAndViewData.ModelState;
    $scope.AngularModel = angularModelAndViewData.AngularModel;
    $scope.AngularViewData = angularModelAndViewData.AngularViewData;
    $scope.resetProjectToAdd();

    if ($scope.AngularModel.PerformanceMeasureActuals == null) {
        $scope.AngularModel.PerformanceMeasureActuals = [];
    }

    var repositionQtipPopupsTimeout = null;
    $scope.repositionQtipPopups = function()
    {
        if (repositionQtipPopupsTimeout)
        {
            $timeout.cancel(repositionQtipPopupsTimeout);
            repositionQtipPopupsTimeout = null;
        }
        repositionQtipPopupsTimeout = $timeout(function()
        {
            var allQtips = jQuery(".qtip:visible");
            allQtips.qtip('reposition');
        });
    };
});
