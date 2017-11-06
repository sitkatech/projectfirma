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
    $scope.resetFundingSourceToAdd = function () { $scope.FundingSourceToAdd = ($scope.FromFundingSource) ? $scope.getFundingSource(angularModelAndViewData.AngularViewData.FundingSourceID) : null; };

    $scope.resetProjectToAdd = function () { $scope.ProjectToAdd = ($scope.FromProject) ? $scope.getProject(angularModelAndViewData.AngularViewData.ProjectID) : null; };

    $scope.getAllUsedFundingSourceIDs = function () {
        return _.map($scope.AngularModel.ProjectFundingSourceRequests, function (p) { return p.FundingSourceID; });
    };

    $scope.filteredFundingSources = function () {
        var usedFundingSourceIDs = $scope.getAllUsedFundingSourceIDs();        
        return _($scope.AngularViewData.AllFundingSources).filter(function (f) { return f.IsActive && !_.includes(usedFundingSourceIDs, f.FundingSourceID); })
            .sortBy(function (fs) {
                return [fs.FundingSourceName.toLowerCase(), fs.OrganizationName.toLowerCase()];
            }).value();
    };

    $scope.getAllUsedProjectIDs = function () {
        return _.map($scope.AngularModel.ProjectFundingSourceRequests, function (p) { return p.ProjectID; });
    };

    $scope.filteredProjects = function () {
        var usedProjectIDs = $scope.getAllUsedProjectIDs();
        return _($scope.AngularViewData.AllProjects).filter(function (f) { return !_.includes(usedProjectIDs, f.ProjectID); })
            .sortBy(function (p) {
                return p.DisplayName.toLowerCase();
            }).value();
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

    $scope.getUnsecuredTotal = function ()
    {
        return _.reduce($scope.AngularModel.ProjectFundingSourceRequests, function (m, x) { return m + x.UnsecuredAmount; }, 0);
    };

    $scope.getSecuredTotal = function ()
    {
        return _.reduce($scope.AngularModel.ProjectFundingSourceRequests, function (m, x) { return m + x.SecuredAmount; }, 0);
    };
    
    $scope.findProjectFundingSourceRequestRow = function(projectID, fundingSourceID) { return _.find($scope.AngularModel.ProjectFundingSourceRequests, function(pfse) { return pfse.ProjectID == projectID && pfse.FundingSourceID == fundingSourceID; }); }

    $scope.addRow = function()
    {
        if (($scope.FundingSourceToAdd == null) || ($scope.ProjectToAdd == null))
        {
            return;
        }
        var newProjectFundingSourceRequest = $scope.createNewRow($scope.ProjectToAdd.ProjectID, $scope.FundingSourceToAdd.FundingSourceID);
        $scope.AngularModel.ProjectFundingSourceRequests.push(newProjectFundingSourceRequest);
        $scope.resetFundingSourceToAdd();
        $scope.resetProjectToAdd();
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
    $scope.resetFundingSourceToAdd();
    $scope.resetProjectToAdd();
});

