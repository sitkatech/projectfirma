/*-----------------------------------------------------------------------
<copyright file="ProjectFundingSourceRequestController.js" company="Tahoe Regional Planning Agency">
Copyright (c) Tahoe Regional Planning Agency. All rights reserved.
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
angular.module("ProjectFirmaApp").controller("ProjectFundingSourceRequestController", function ($scope, angularModelAndViewData)
{
    $scope.$watch(function () {
        jQuery(".selectpicker").selectpicker("refresh");
    });

    $scope.resetFundingSourceIDToAdd = function () { $scope.FundingSourceIDToAdd = ($scope.FromFundingSource) ? $scope.getFundingSource(angularModelAndViewData.AngularViewData.FundingSourceID).FundingSourceID : null; };

    $scope.resetProjectIDToAdd = function () { $scope.ProjectIDToAdd = ($scope.FromProject) ? $scope.getProject(angularModelAndViewData.AngularViewData.ProjectID).ProjectID : null; };

    $scope.getAllUsedFundingSourceIds = function () {
        return _.map($scope.AngularModel.ProjectFundingSourceRequests, function (p) { return p.FundingSourceID; });
    };

    $scope.filteredFundingSources = function () {
        var usedFundingSourceIDs = $scope.getAllUsedFundingSourceIds();
        return _($scope.AngularViewData.AllFundingSources).filter(function (f) {
            return f.IsActive && !_.contains(usedFundingSourceIDs, f.FundingSourceID);
        }).sortBy(function (fs) {
            return [fs.FundingSourceName.toLowerCase()];
        }).value();
    };

    $scope.getAllUsedProjectIDs = function () {
        return _.map($scope.AngularModel.ProjectFundingSourceRequests, function (p) { return p.ProjectID; });
    };

    $scope.filteredProjects = function () {
        var usedProjectIDs = $scope.getAllUsedProjectIDs();
        return _($scope.AngularViewData.AllProjects).filter(function (f) { return !_.includes(usedProjectIDs, f.ProjectID); })
            .sortBy(["DisplayName"]).value();
    };

    $scope.getProjectName = function (projectFundingSourceRequest)
    {
        var projectToFind = $scope.getProject(projectFundingSourceRequest.ProjectID);
        return projectToFind.DisplayName;
    };

    $scope.getProject = function (projectID) {
        return _.find($scope.AngularViewData.AllProjects, function (f) { return projectID == f.ProjectID; });
    };

    $scope.getFundingSourceName = function (projectFundingSourceRequest) {
        var fundingSourceToFind = $scope.getFundingSource(projectFundingSourceRequest.FundingSourceID);
        return fundingSourceToFind.DisplayName;
    };

    $scope.getFundingSource = function (fundingSourceID) {
        return _.find($scope.AngularViewData.AllFundingSources, function (f) { return fundingSourceID == f.FundingSourceID; });
    };

    $scope.getUnsecuredTotal = function () {
        return Number(_.reduce($scope.AngularModel.ProjectFundingSourceRequests, function (m, x) { return Number(m) + Number(x.UnsecuredAmount); }, 0));
    };

    $scope.getSecuredTotal = function () {
        return Number(_.reduce($scope.AngularModel.ProjectFundingSourceRequests,
            function (m, x) { return Number(m) + Number(x.SecuredAmount); },
            0));
    };

    $scope.getTotal = function () {
        return Number($scope.getUnsecuredTotal()) + Number($scope.getSecuredTotal());
    }

    $scope.getRowTotal = function (projectFundingSourceRequest) {
        return Number(projectFundingSourceRequest.SecuredAmount) + Number(projectFundingSourceRequest.UnsecuredAmount);
    }
    
    $scope.findProjectFundingSourceRequestRow = function(projectID, fundingSourceID) { return _.find($scope.AngularModel.ProjectFundingSourceRequests, function(pfse) { return pfse.ProjectID == projectID && pfse.FundingSourceID == fundingSourceID; }); }

    $scope.addRow = function()
    {
        if (($scope.FundingSourceIDToAdd == null) || ($scope.ProjectIDToAdd == null)) {
            return;
        }
        var newProjectFundingSourceRequest = $scope.createNewRow($scope.ProjectIDToAdd, $scope.FundingSourceIDToAdd);
        $scope.AngularModel.ProjectFundingSourceRequests.push(newProjectFundingSourceRequest);
        $scope.resetFundingSourceIDToAdd();
        $scope.resetProjectIDToAdd();
    };

    $scope.createNewRow = function (projectID, fundingSourceID)
    {
        var project = $scope.getProject(projectID);
        var fundingSource = $scope.getFundingSource(fundingSourceID);
        var newProjectFundingSourceRequest = {
            ProjectID: project.ProjectID,
            FundingSourceID: fundingSource.FundingSourceID,
            SecuredAmount: null,
            UnsecuredAmount: null
    };
        return newProjectFundingSourceRequest;
    };

    $scope.deleteRow = function (rowToDelete) {
        Sitka.Methods.removeFromJsonArray($scope.AngularModel.ProjectFundingSourceRequests, rowToDelete);
    };

    $scope.AngularModel = angularModelAndViewData.AngularModel;
    $scope.AngularViewData = angularModelAndViewData.AngularViewData;
    $scope.FromFundingSource = angularModelAndViewData.AngularViewData.FromFundingSource;
    $scope.FromProject = !$scope.FromFundingSource;
    $scope.resetFundingSourceIDToAdd();
    $scope.resetProjectIDToAdd();
});

