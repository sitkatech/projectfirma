angular.module("ProjectFirmaApp").controller("PerformanceMeasureExpectedController", function ($scope, angularModelAndViewData)
{
    $scope.resetPerformanceMeasureToAdd = function () { $scope.PerformanceMeasureToAdd = null; };

    $scope.resetProjectToAdd = function () { $scope.ProjectToAdd = $scope.getProject(angularModelAndViewData.AngularViewData.ProjectID); };

    $scope.filteredPerformanceMeasures = function () {
        return _($scope.AngularViewData.AllPerformanceMeasures).sortBy(["PerformanceMeasureID"]).value();
    };

    $scope.filteredProjects = function () {
        return _($scope.AngularViewData.AllProjects).sortBy(["DisplayName"]).value();
    };

    $scope.getProjectName = function (performanceMeasureExpected)
    {
        var projectToFind = $scope.getProject(performanceMeasureExpected.ProjectID);
        return projectToFind.DisplayName;
    };

    $scope.getProject = function (projectId) {
        return _.find($scope.AngularViewData.AllProjects, function (f) { return projectId == f.ProjectID; });
    };

    $scope.getPerformanceMeasureName = function (performanceMeasureExpected) {
        var performanceMeasureToFind = $scope.getPerformanceMeasure(performanceMeasureExpected.PerformanceMeasureID);
        return performanceMeasureToFind.DisplayName;
    };

    $scope.getPerformanceMeasure = function (performanceMeasureId) {
        return _.find($scope.AngularViewData.AllPerformanceMeasures, function (f) { return performanceMeasureId == f.PerformanceMeasureID; });
    };

    $scope.getSubcategoriesForPerformanceMeasure = function (performanceMeasureId)
    {
        var performanceMeasureSubcategories = _($scope.AngularViewData.AllIndicatorSubcategories).filter(function (pms) { return pms.PerformanceMeasureID == performanceMeasureId; }).map(function (pms) { return { IndicatorSubcategoryID: pms.IndicatorSubcategoryID, IndicatorSubcategoryName: $scope.getSubcategoryName(pms), SortOrder: pms.SortOrder }; }).sortByAll(["SortOrder", "IndicatorSubcategoryName"]).value();
        return performanceMeasureSubcategories;
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

    $scope.getSubcategoryName = function (performanceMeasureExpectedSubcategoryOption)
    {
        var indicatorSubcategory = $scope.getSubcategory(performanceMeasureExpectedSubcategoryOption.IndicatorSubcategoryID);
        return indicatorSubcategory.IndicatorSubcategoryDisplayName;
    };

    $scope.hasAnySubcategories = function () {
        var performanceMeasureIDsInModel = _.pluck($scope.AngularModel.PerformanceMeasureExpecteds, function (pmav) { return pmav.PerformanceMeasureID; });
        var anySubcategories = _.any($scope.AngularViewData.AllIndicatorSubcategories, function (sc) { return _.contains(performanceMeasureIDsInModel, sc.PerformanceMeasureID); });
        return anySubcategories;
    };

    $scope.getPerformanceMeasureExpectedSubcategoryOptionsWithValues = function (performanceMeasureExpected) {
        return _(performanceMeasureExpected.PerformanceMeasureExpectedSubcategoryOptions).filter(function (pms) { return pms.IndicatorSubcategoryOptionID > 0; }).sortBy(["IndicatorSubcategoryOptionID"]).value();
    };

    $scope.addRow = function()
    {
        if ($scope.PerformanceMeasureToAdd != null)
        {
            var newPerformanceMeasureExpected = $scope.createNewRow($scope.ProjectToAdd, $scope.PerformanceMeasureToAdd);
            $scope.AngularModel.PerformanceMeasureExpecteds.push(newPerformanceMeasureExpected);
            $scope.resetPerformanceMeasureToAdd();
            $scope.resetProjectToAdd();
        }
    };

    $scope.createNewRow = function (project, performanceMeasure) {
        var newPerformanceMeasureExpected = {
            ProjectID: project.ProjectID,
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
        var performanceMeasureValueSubcategoryOptionRows = _.map(subcategories, function (indicatorSubcategory) { return $scope.createPerformanceMeasureValueSubcategoryOption(indicatorSubcategory, performanceMeasureId); });
        if (!performanceMeasure.HasRealSubcategories) {
            performanceMeasureValueSubcategoryOptionRows[0].IndicatorSubcategoryOptionID = $scope.getSubcategoryOptionsForSubcategory(subcategories[0].IndicatorSubcategoryID)[0].IndicatorSubcategoryOptionID;
        }
        return performanceMeasureValueSubcategoryOptionRows;
    };

    $scope.createPerformanceMeasureValueSubcategoryOption = function (indicatorSubcategory, performanceMeasureId)
    {
        var newPerformanceMeasureExpected = {
            PerformanceMeasureID: performanceMeasureId,
            IndicatorSubcategoryID: indicatorSubcategory.IndicatorSubcategoryID,
            IndicatorSubcategoryOptionID: null
        };
        return newPerformanceMeasureExpected;
    };

    $scope.deleteRow = function (rowToDelete) {
        Sitka.Methods.removeFromJsonArray($scope.AngularModel.PerformanceMeasureExpecteds, rowToDelete);
    };

    $scope.getMeasurementUnitTypeDisplayName = function (performanceMeasureExpected) {
        var MeasurementUnitTypeDisplayName = "";
        var performanceMeasure = $scope.getPerformanceMeasure(performanceMeasureExpected.PerformanceMeasureID);
        if (performanceMeasure != null)
        {
            MeasurementUnitTypeDisplayName = performanceMeasure.MeasurementUnitTypeDisplayName;
        }
        return MeasurementUnitTypeDisplayName;
    };

    $scope.AngularModel = angularModelAndViewData.AngularModel;
    $scope.AngularViewData = angularModelAndViewData.AngularViewData;
    $scope.resetPerformanceMeasureToAdd();
    $scope.resetProjectToAdd();
});

