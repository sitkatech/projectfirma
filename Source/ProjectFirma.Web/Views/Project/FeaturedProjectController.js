/*-----------------------------------------------------------------------
<copyright file="FeaturedProjectController.js" company="Tahoe Regional Planning Agency">
Copyright (c) Tahoe Regional Planning Agency. All rights reserved.
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
angular.module("ProjectFirmaApp").controller("FeaturedProjectController", function ($scope, angularModelAndViewData)
{
    $scope.resetProjectToAdd = function () { $scope.ProjectToAdd = null; };

    $scope.filteredProjects = function ()
    {
        var usedProjectIDs = $scope.AngularModel.ProjectIDList;
        return _($scope.AngularViewData.AllProjects).filter(function (f) { return !_.contains(usedProjectIDs, f.ProjectID); }).sortBy(["DisplayName"]).value();
    };

    $scope.getProjectName = function (projectId)
    {
        var projectToFind = $scope.getProject(projectId);
        return projectToFind.DisplayName;
    };

    $scope.getProject = function (projectId) {
        return _.find($scope.AngularViewData.AllProjects, function (f) { return projectId == f.ProjectID; });
    };

    $scope.addRow = function()
    {
        if ($scope.ProjectToAdd != null)
        {
            $scope.AngularModel.ProjectIDList.push($scope.ProjectToAdd.ProjectID);
            $scope.resetProjectToAdd();
        }
    };

    $scope.deleteRow = function (rowToDelete)
    {
        $scope.AngularModel.ProjectIDList = _.without($scope.AngularModel.ProjectIDList, rowToDelete);
    };

    $scope.AngularModel = angularModelAndViewData.AngularModel;
    $scope.AngularViewData = angularModelAndViewData.AngularViewData;
    $scope.resetProjectToAdd();
});
