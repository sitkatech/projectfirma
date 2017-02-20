angular.module("ProjectFirmaApp").controller("PerformanceMeasuresController", function($scope, $timeout, angularModelAndViewData)
{
    $scope.nextID = -1;
    $scope.resetPerformanceMeasureToAdd = function() { $scope.PerformanceMeasureToAdd = null; };

    $scope.resetProjectToAdd = function() { $scope.ProjectToAdd = { ProjectUpdateBatchID: angularModelAndViewData.AngularViewData.ProjectUpdateBatchID }; };

    $scope.filteredPerformanceMeasures = function () { return _($scope.AngularViewData.AllPerformanceMeasures).sortBy(["DisplayName"]).value(); };

    $scope.getPerformanceMeasureName = function(performanceMeasureActualUpdate)
    {
        var performanceMeasureToFind = $scope.getPerformanceMeasure(performanceMeasureActualUpdate.PerformanceMeasureID);
        return performanceMeasureToFind.DisplayName;
    };

    $scope.getPerformanceMeasure = function(performanceMeasureId) { return _.find($scope.AngularViewData.AllPerformanceMeasures, function(f) { return performanceMeasureId == f.PerformanceMeasureID; }); };

    $scope.getSubcategoriesForPerformanceMeasure = function(performanceMeasureId)
    {
        var performanceMeasureSubcategories = _($scope.AngularViewData.AllPerformanceMeasureSubcategories).filter(function(pms) { return pms.PerformanceMeasureID == performanceMeasureId; }).map(function(pms) { return { PerformanceMeasureSubcategoryID: pms.PerformanceMeasureSubcategoryID, PerformanceMeasureSubcategoryName: $scope.getSubcategoryName(pms), SortOrder: pms.SortOrder }; }).sortByAll(["SortOrder", "PerformanceMeasureSubcategoryName"]).value();
        return performanceMeasureSubcategories;
    };

    $scope.addAdditionalColumns = function(performanceMeasureActualUpdate)
    {
        var performanceMeasureSubcategoriesCount = performanceMeasureActualUpdate.PerformanceMeasureActualSubcategoryOptionUpdates.length;
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

    $scope.getSubcategoryName = function(performanceMeasureActualUpdateSubcategoryOptionUpdate)
    {
        var performanceMeasureSubcategory = $scope.getSubcategory(performanceMeasureActualUpdateSubcategoryOptionUpdate.PerformanceMeasureSubcategoryID);
        return performanceMeasureSubcategory.PerformanceMeasureSubcategoryDisplayName;
    };

    $scope.hasAnySubcategories = function()
    {
        var performanceMeasureIDsInModel = _.pluck($scope.AngularModel.PerformanceMeasureActualUpdates, function(pmav) { return pmav.PerformanceMeasureID; });
        var anySubcategories = _.any($scope.AngularViewData.AllPerformanceMeasureSubcategories, function (sc) { return _.contains(performanceMeasureIDsInModel, sc.PerformanceMeasureID); });
        return anySubcategories;
    };

    $scope.BlankOutEmptyYearsFromModel = function()
    {
        var filteredCalendarYears = $scope.filteredCalendarYears();
        _($scope.AngularModel.PerformanceMeasureActualUpdates).filter(function(pmav) { return !_.contains(filteredCalendarYears, pmav.CalendarYear); }).each(function(pmav) { pmav.CalendarYear = ""; });
    };

    $scope.addRow = function()
    {
        if ($scope.PerformanceMeasureToAdd != null)
        {
            var newPerformanceMeasureActual = $scope.createNewRow($scope.ProjectToAdd, $scope.PerformanceMeasureToAdd);
            $scope.AngularModel.PerformanceMeasureActualUpdates.unshift(newPerformanceMeasureActual);
            $scope.resetPerformanceMeasureToAdd();
            $scope.repositionQtipPopups();
        }
    };

    $scope.createNewRow = function(project, performanceMeasure)
    {
        var newPerformanceMeasureActual = {
            PerformanceMeasureActualUpdateID: $scope.nextID--,
            ProjectUpdateBatchID: project.ProjectUpdateBatchID,
            PerformanceMeasureID: performanceMeasure.PerformanceMeasureID,
            CalendarYear: "",
            ActualValue: null,
            MeasurementUnitTypeDisplayName: performanceMeasure.MeasurementUnitTypeDisplayName,
            PerformanceMeasureActualSubcategoryOptionUpdates: $scope.createPerformanceMeasureValueSubcategoryOptionRows(performanceMeasure)
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
        jQuery("#qtip-RequiredPopup" + rowToDelete.PerformanceMeasureActualUpdateID).remove();
        Sitka.Methods.removeFromJsonArray($scope.AngularModel.PerformanceMeasureActualUpdates, rowToDelete);
        $scope.repositionQtipPopups();
    };

    $scope.getMeasurementUnitTypeDisplayName = function(performanceMeasureActualUpdate)
    {
        var MeasurementUnitTypeDisplayName = "";
        var performanceMeasure = $scope.getPerformanceMeasure(performanceMeasureActualUpdate.PerformanceMeasureID);
        if (performanceMeasure != null)
        {
            MeasurementUnitTypeDisplayName = performanceMeasure.MeasurementUnitTypeDisplayName;
        }
        return MeasurementUnitTypeDisplayName;
    };

    $scope.getSubcategoryOptionsSelected = function(performanceMeasureActualUpdate)
    {
        var performanceMeasureActualSubcategoryOptionUpdatesSelected = _(performanceMeasureActualUpdate.PerformanceMeasureActualSubcategoryOptionUpdates).sortByAll(["PerformanceMeasureSubcategoryID", "PerformanceMeasureSubcategoryOptionID"]).value();
        return performanceMeasureActualSubcategoryOptionUpdatesSelected;
    }

    $scope.filteredCalendarYears = function()
    {
        var usedCalendarYears = _($scope.AngularModel.ProjectExemptReportingYearUpdates).filter(function(f) { return f.IsExempt; }).map(function(p) { return p.CalendarYear; }).value();
        return _($scope.AngularViewData.CalendarYears).filter(function(f) { return !_.contains(usedCalendarYears, f); }).value();
    };

    $scope.showRowValidationWarnings = function(performanceMeasureActualUpdate)
    {
        var showingValidationWarnings = $scope.AngularModel.ShowValidationWarnings;
        var hasValidationWarnings = _.contains($scope.AngularViewData.PerformanceMeasureActualUpdatesWithValidationWarnings, performanceMeasureActualUpdate.PerformanceMeasureActualUpdateID);
        return showingValidationWarnings && hasValidationWarnings;
    };

    $scope.ModelState = angularModelAndViewData.ModelState;
    $scope.AngularModel = angularModelAndViewData.AngularModel;
    $scope.AngularViewData = angularModelAndViewData.AngularViewData;
    $scope.resetPerformanceMeasureToAdd();
    $scope.resetProjectToAdd();

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