angular.module("ProjectFirmaApp").controller("EIPPerformanceMeasureExpectedController", function ($scope, angularModelAndViewData)
{
    $scope.resetEIPPerformanceMeasureToAdd = function () { $scope.EIPPerformanceMeasureToAdd = null; };

    $scope.resetProjectToAdd = function () { $scope.ProjectToAdd = $scope.getProject(angularModelAndViewData.AngularViewData.ProjectID); };

    $scope.filteredEIPPerformanceMeasures = function () {
        return _($scope.AngularViewData.AllEIPPerformanceMeasures).sortBy(["EIPPerformanceMeasureID"]).value();
    };

    $scope.filteredProjects = function () {
        return _($scope.AngularViewData.AllProjects).sortBy(["DisplayName"]).value();
    };

    $scope.getProjectName = function (eipPerformanceMeasureExpected)
    {
        var projectToFind = $scope.getProject(eipPerformanceMeasureExpected.ProjectID);
        return projectToFind.DisplayName;
    };

    $scope.getProject = function (projectId) {
        return _.find($scope.AngularViewData.AllProjects, function (f) { return projectId == f.ProjectID; });
    };

    $scope.getEIPPerformanceMeasureName = function (eipPerformanceMeasureExpected) {
        var eipPerformanceMeasureToFind = $scope.getEIPPerformanceMeasure(eipPerformanceMeasureExpected.EIPPerformanceMeasureID);
        return eipPerformanceMeasureToFind.DisplayName;
    };

    $scope.getEIPPerformanceMeasure = function (eipPerformanceMeasureId) {
        return _.find($scope.AngularViewData.AllEIPPerformanceMeasures, function (f) { return eipPerformanceMeasureId == f.EIPPerformanceMeasureID; });
    };

    $scope.getSubcategoriesForEIPPerformanceMeasure = function (eipPerformanceMeasureId)
    {
        var eipPerformanceMeasureSubcategories = _($scope.AngularViewData.AllIndicatorSubcategories).filter(function (pms) { return pms.EIPPerformanceMeasureID == eipPerformanceMeasureId; }).map(function (pms) { return { IndicatorSubcategoryID: pms.IndicatorSubcategoryID, IndicatorSubcategoryName: $scope.getSubcategoryName(pms), SortOrder: pms.SortOrder }; }).sortByAll(["SortOrder", "IndicatorSubcategoryName"]).value();
        return eipPerformanceMeasureSubcategories;
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

    $scope.getSubcategoryName = function (eipPerformanceMeasureExpectedSubcategoryOption)
    {
        var indicatorSubcategory = $scope.getSubcategory(eipPerformanceMeasureExpectedSubcategoryOption.IndicatorSubcategoryID);
        return indicatorSubcategory.IndicatorSubcategoryDisplayName;
    };

    $scope.hasAnySubcategories = function () {
        var eipPerformanceMeasureIDsInModel = _.pluck($scope.AngularModel.EIPPerformanceMeasureExpecteds, function (pmav) { return pmav.EIPPerformanceMeasureID; });
        var anySubcategories = _.any($scope.AngularViewData.AllIndicatorSubcategories, function (sc) { return _.contains(eipPerformanceMeasureIDsInModel, sc.EIPPerformanceMeasureID); });
        return anySubcategories;
    };

    $scope.getEIPPerformanceMeasureExpectedSubcategoryOptionsWithValues = function (eipPerformanceMeasureExpected) {
        return _(eipPerformanceMeasureExpected.EIPPerformanceMeasureExpectedSubcategoryOptions).filter(function (pms) { return pms.IndicatorSubcategoryOptionID > 0; }).sortBy(["IndicatorSubcategoryOptionID"]).value();
    };

    $scope.addRow = function()
    {
        if ($scope.EIPPerformanceMeasureToAdd != null)
        {
            var newEIPPerformanceMeasureExpected = $scope.createNewRow($scope.ProjectToAdd, $scope.EIPPerformanceMeasureToAdd);
            $scope.AngularModel.EIPPerformanceMeasureExpecteds.push(newEIPPerformanceMeasureExpected);
            $scope.resetEIPPerformanceMeasureToAdd();
            $scope.resetProjectToAdd();
        }
    };

    $scope.createNewRow = function (project, eipPerformanceMeasure) {
        var newEIPPerformanceMeasureExpected = {
            ProjectID: project.ProjectID,
            EIPPerformanceMeasureID: eipPerformanceMeasure.EIPPerformanceMeasureID,
            CalendarYear: new Date().getFullYear(),
            ExpectedValue: null,
            MeasurementUnitTypeDisplayName: eipPerformanceMeasure.MeasurementUnitTypeDisplayName,
            EIPPerformanceMeasureExpectedSubcategoryOptions: $scope.createEIPPerformanceMeasureValueSubcategoryOptionRows(eipPerformanceMeasure)
        };
        return newEIPPerformanceMeasureExpected;
    };

    $scope.createEIPPerformanceMeasureValueSubcategoryOptionRows = function (eipPerformanceMeasure)
    {
        var eipPerformanceMeasureId = eipPerformanceMeasure.EIPPerformanceMeasureID;
        var subcategories = $scope.getSubcategoriesForEIPPerformanceMeasure(eipPerformanceMeasureId);
        var eipPerformanceMeasureValueSubcategoryOptionRows = _.map(subcategories, function (indicatorSubcategory) { return $scope.createEIPPerformanceMeasureValueSubcategoryOption(indicatorSubcategory, eipPerformanceMeasureId); });
        if (!eipPerformanceMeasure.HasRealSubcategories) {
            eipPerformanceMeasureValueSubcategoryOptionRows[0].IndicatorSubcategoryOptionID = $scope.getSubcategoryOptionsForSubcategory(subcategories[0].IndicatorSubcategoryID)[0].IndicatorSubcategoryOptionID;
        }
        return eipPerformanceMeasureValueSubcategoryOptionRows;
    };

    $scope.createEIPPerformanceMeasureValueSubcategoryOption = function (indicatorSubcategory, eipPerformanceMeasureId)
    {
        var newEIPPerformanceMeasureExpected = {
            EIPPerformanceMeasureID: eipPerformanceMeasureId,
            IndicatorSubcategoryID: indicatorSubcategory.IndicatorSubcategoryID,
            IndicatorSubcategoryOptionID: null
        };
        return newEIPPerformanceMeasureExpected;
    };

    $scope.deleteRow = function (rowToDelete) {
        Sitka.Methods.removeFromJsonArray($scope.AngularModel.EIPPerformanceMeasureExpecteds, rowToDelete);
    };

    $scope.getMeasurementUnitTypeDisplayName = function (eipPerformanceMeasureExpected) {
        var MeasurementUnitTypeDisplayName = "";
        var eipPerformanceMeasure = $scope.getEIPPerformanceMeasure(eipPerformanceMeasureExpected.EIPPerformanceMeasureID);
        if (eipPerformanceMeasure != null)
        {
            MeasurementUnitTypeDisplayName = eipPerformanceMeasure.MeasurementUnitTypeDisplayName;
        }
        return MeasurementUnitTypeDisplayName;
    };

    $scope.AngularModel = angularModelAndViewData.AngularModel;
    $scope.AngularViewData = angularModelAndViewData.AngularViewData;
    $scope.resetEIPPerformanceMeasureToAdd();
    $scope.resetProjectToAdd();
});

