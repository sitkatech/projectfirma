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