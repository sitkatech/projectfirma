angular.module("ProjectFirmaApp").controller("EIPPerformanceMeasuresController", function($scope, $timeout, angularModelAndViewData)
{
    $scope.nextID = -1;
    $scope.resetEIPPerformanceMeasureToAdd = function() { $scope.EIPPerformanceMeasureToAdd = null; };

    $scope.resetProjectToAdd = function() { $scope.ProjectToAdd = { ProjectUpdateBatchID: angularModelAndViewData.AngularViewData.ProjectUpdateBatchID }; };

    $scope.filteredEIPPerformanceMeasures = function() { return _($scope.AngularViewData.AllEIPPerformanceMeasures).sortBy(["EIPPerformanceMeasureID"]).value(); };

    $scope.getEIPPerformanceMeasureName = function(eipPerformanceMeasureActualUpdate)
    {
        var eipPerformanceMeasureToFind = $scope.getEIPPerformanceMeasure(eipPerformanceMeasureActualUpdate.EIPPerformanceMeasureID);
        return eipPerformanceMeasureToFind.DisplayName;
    };

    $scope.getEIPPerformanceMeasure = function(eipPerformanceMeasureId) { return _.find($scope.AngularViewData.AllEIPPerformanceMeasures, function(f) { return eipPerformanceMeasureId == f.EIPPerformanceMeasureID; }); };

    $scope.getSubcategoriesForEIPPerformanceMeasure = function(eipPerformanceMeasureId)
    {
        var eipPerformanceMeasureSubcategories = _($scope.AngularViewData.AllIndicatorSubcategories).filter(function(pms) { return pms.EIPPerformanceMeasureID == eipPerformanceMeasureId; }).map(function(pms) { return { IndicatorSubcategoryID: pms.IndicatorSubcategoryID, IndicatorSubcategoryName: $scope.getSubcategoryName(pms), SortOrder: pms.SortOrder }; }).sortByAll(["SortOrder", "IndicatorSubcategoryName"]).value();
        return eipPerformanceMeasureSubcategories;
    };

    $scope.addAdditionalColumns = function(eipPerformanceMeasureActualUpdate)
    {
        var eipPerformanceMeasureSubcategoriesCount = eipPerformanceMeasureActualUpdate.EIPPerformanceMeasureActualSubcategoryOptionUpdates.length;
        var arrayLength = $scope.AngularViewData.MaxSubcategoryOptions - eipPerformanceMeasureSubcategoriesCount;
        var array = [];
        for (var i = 0; i < arrayLength; ++i)
        {
            array.push(i);
        }
        return array;
    };

    $scope.getSubcategoryOptionsForSubcategory = function (indicatorSubcategoryId)
    {
        var subcategoryOptions = _($scope.AngularViewData.AllIndicatorSubcategoryOptions).filter(function (sco) { return sco.IndicatorSubcategoryID == indicatorSubcategoryId; }).sortByAll(["SortOrder", "IndicatorSubcategoryOptionName"]).value();
        return subcategoryOptions;
    };

    $scope.getSubcategory = function (indicatorSubcategoryId)
    {
        var indicatorSubcategory = _.find($scope.AngularViewData.AllIndicatorSubcategories, function (sc) { return sc.IndicatorSubcategoryID == indicatorSubcategoryId; });
        return indicatorSubcategory;
    };

    $scope.getSubcategoryName = function(eipPerformanceMeasureActualUpdateSubcategoryOptionUpdate)
    {
        var indicatorSubcategory = $scope.getSubcategory(eipPerformanceMeasureActualUpdateSubcategoryOptionUpdate.IndicatorSubcategoryID);
        return indicatorSubcategory.IndicatorSubcategoryDisplayName;
    };

    $scope.hasAnySubcategories = function()
    {
        var eipPerformanceMeasureIDsInModel = _.pluck($scope.AngularModel.EIPPerformanceMeasureActualUpdates, function(pmav) { return pmav.EIPPerformanceMeasureID; });
        var anySubcategories = _.any($scope.AngularViewData.AllIndicatorSubcategories, function (sc) { return _.contains(eipPerformanceMeasureIDsInModel, sc.EIPPerformanceMeasureID); });
        return anySubcategories;
    };

    $scope.BlankOutEmptyYearsFromModel = function()
    {
        var filteredCalendarYears = $scope.filteredCalendarYears();
        _($scope.AngularModel.EIPPerformanceMeasureActualUpdates).filter(function(pmav) { return !_.contains(filteredCalendarYears, pmav.CalendarYear); }).each(function(pmav) { pmav.CalendarYear = ""; });
    };

    $scope.addRow = function()
    {
        if ($scope.EIPPerformanceMeasureToAdd != null)
        {
            var newEIPPerformanceMeasureActual = $scope.createNewRow($scope.ProjectToAdd, $scope.EIPPerformanceMeasureToAdd);
            $scope.AngularModel.EIPPerformanceMeasureActualUpdates.unshift(newEIPPerformanceMeasureActual);
            $scope.resetEIPPerformanceMeasureToAdd();
            $scope.repositionQtipPopups();
        }
    };

    $scope.createNewRow = function(project, eipPerformanceMeasure)
    {
        var newEIPPerformanceMeasureActual = {
            EIPPerformanceMeasureActualUpdateID: $scope.nextID--,
            ProjectUpdateBatchID: project.ProjectUpdateBatchID,
            EIPPerformanceMeasureID: eipPerformanceMeasure.EIPPerformanceMeasureID,
            CalendarYear: "",
            ActualValue: null,
            MeasurementUnitTypeDisplayName: eipPerformanceMeasure.MeasurementUnitTypeDisplayName,
            EIPPerformanceMeasureActualSubcategoryOptionUpdates: $scope.createEIPPerformanceMeasureValueSubcategoryOptionRows(eipPerformanceMeasure)
        };
        return newEIPPerformanceMeasureActual;
    };

    $scope.createEIPPerformanceMeasureValueSubcategoryOptionRows = function(eipPerformanceMeasure)
    {
        var eipPerformanceMeasureId = eipPerformanceMeasure.EIPPerformanceMeasureID;
        var subcategories = $scope.getSubcategoriesForEIPPerformanceMeasure(eipPerformanceMeasureId);
        var eipPerformanceMeasureValueSubcategoryOptionRows = _.map(subcategories, function (indicatorSubcategory) { return $scope.createEIPPerformanceMeasureValueSubcategoryOption(indicatorSubcategory, eipPerformanceMeasureId); });
        if (!eipPerformanceMeasure.HasRealSubcategories)
        {
            eipPerformanceMeasureValueSubcategoryOptionRows[0].IndicatorSubcategoryOptionID = $scope.getSubcategoryOptionsForSubcategory(subcategories[0].IndicatorSubcategoryID)[0].IndicatorSubcategoryOptionID;
        }
        return eipPerformanceMeasureValueSubcategoryOptionRows;
    };

    $scope.createEIPPerformanceMeasureValueSubcategoryOption = function (indicatorSubcategory, eipPerformanceMeasureId)
    {
        var newEIPPerformanceMeasureActual = {
            EIPPerformanceMeasureID: eipPerformanceMeasureId,
            IndicatorSubcategoryID: indicatorSubcategory.IndicatorSubcategoryID,
            IndicatorSubcategoryOptionID: -1
        };
        return newEIPPerformanceMeasureActual;
    };

    $scope.deleteRow = function(rowToDelete)
    {
        jQuery("#qtip-RequiredPopup" + rowToDelete.EIPPerformanceMeasureActualUpdateID).remove();
        Sitka.Methods.removeFromJsonArray($scope.AngularModel.EIPPerformanceMeasureActualUpdates, rowToDelete);
        $scope.repositionQtipPopups();
    };

    $scope.getMeasurementUnitTypeDisplayName = function(eipPerformanceMeasureActualUpdate)
    {
        var MeasurementUnitTypeDisplayName = "";
        var eipPerformanceMeasure = $scope.getEIPPerformanceMeasure(eipPerformanceMeasureActualUpdate.EIPPerformanceMeasureID);
        if (eipPerformanceMeasure != null)
        {
            MeasurementUnitTypeDisplayName = eipPerformanceMeasure.MeasurementUnitTypeDisplayName;
        }
        return MeasurementUnitTypeDisplayName;
    };

    $scope.getSubcategoryOptionsSelected = function(eipPerformanceMeasureActualUpdate)
    {
        var eipPerformanceMeasureActualSubcategoryOptionUpdatesSelected = _(eipPerformanceMeasureActualUpdate.EIPPerformanceMeasureActualSubcategoryOptionUpdates).sortByAll(["IndicatorSubcategoryID", "IndicatorSubcategoryOptionID"]).value();
        return eipPerformanceMeasureActualSubcategoryOptionUpdatesSelected;
    }

    $scope.filteredCalendarYears = function()
    {
        var usedCalendarYears = _($scope.AngularModel.ProjectExemptReportingYearUpdates).filter(function(f) { return f.IsExempt; }).map(function(p) { return p.CalendarYear; }).value();
        return _($scope.AngularViewData.CalendarYears).filter(function(f) { return !_.contains(usedCalendarYears, f); }).value();
    };

    $scope.showRowValidationWarnings = function(eipPerformanceMeasureActualUpdate)
    {
        var showingValidationWarnings = $scope.AngularModel.ShowValidationWarnings;
        var hasValidationWarnings = _.contains($scope.AngularViewData.EIPPerformanceMeasureActualUpdatesWithValidationWarnings, eipPerformanceMeasureActualUpdate.EIPPerformanceMeasureActualUpdateID);
        return showingValidationWarnings && hasValidationWarnings;
    };

    $scope.ModelState = angularModelAndViewData.ModelState;
    $scope.AngularModel = angularModelAndViewData.AngularModel;
    $scope.AngularViewData = angularModelAndViewData.AngularViewData;
    $scope.resetEIPPerformanceMeasureToAdd();
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